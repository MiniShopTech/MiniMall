using AutoMapper;
using MayNghien.Infrastructure.Request.Base;
using MayNghien.Models.Response.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MiniMall.DALs.Entities;
using MiniMall.DALs.Repositories.Interfaces;
using MiniMall.Models.DTOs.Auth.Requests;
using MiniMall.Models.DTOs.Requests;
using MiniMall.Models.DTOs.Responses;
using MiniMall.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MiniMall.Services.Implements
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;
        private readonly IHttpContextAccessor _httpContextAccesor;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _config;

        public StaffService(IStaffRepository staffRepository,
            IHttpContextAccessor httpContextAccesor, IMapper mapper,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, 
            IConfiguration config)
        {
            _staffRepository = staffRepository;
            _httpContextAccesor = httpContextAccesor;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _config = config;
        }

        public AppResponse<StaffResponse> GetById(Guid id)
        {
            var result = new AppResponse<StaffResponse>();
            try
            {
                var staff = _staffRepository.Get(id);
                if (staff == null || staff.IsDeleted == true)
                    return result.BuildError("Staff not found or deleted");

                var data = new StaffResponse
                {
                    Id = staff.Id,
                    Name = staff.Name,
                    Email = staff.Email,
                    PhoneNumber = staff.PhoneNumber,
                    Role = staff.Role
                };
                result.BuildResult(data);
            }
            catch (Exception ex)
            {
                result.BuildError(ex.Message + " " + ex.StackTrace);
            }
            return result;
        }

        public async Task<AppResponse<StaffResponse>> Create(StaffRequest request)
        {
            var result = new AppResponse<StaffResponse>();
            try
            {
                var user = await _userManager.FindByEmailAsync(_httpContextAccesor.HttpContext?.User.Identity?.Name!);
                if (user == null)
                    return result.BuildError("Unauthorize");
                if (await CheckUserExists(request.Email, request.PhoneNumber))
                    return result.BuildError("Staff already exists");

                var newStaff = await CreateStaff(request);
                var createUserResult = await CreateUser(request, newStaff.Id);
                if (!createUserResult.Succeeded)
                    return result.BuildError("Cannot create user: " + string.Join(", ", createUserResult.Errors.Select(e => e.Description)));

                var identityUser = await _userManager.FindByEmailAsync(request.Email);
                if (identityUser == null)
                    return result.BuildError("Failed to retrive created staff");

                await AssignRole(identityUser, request.Role);
                var response = new StaffResponse
                {
                    Id = newStaff.Id,
                    Name = newStaff.Name,
                    Email = newStaff.Email,
                    PhoneNumber = newStaff.PhoneNumber,
                    Role = newStaff.Role,
                    Token = GenerateAccessToken(new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, request.Email),
                        new Claim(ClaimTypes.Role, request.Role)
                    })
                };
                return result.BuildResult(response, "Staff registered successfully!");
            }
            catch (Exception ex)
            {
                result.BuildError(ex.Message + " " + ex.InnerException?.Message);
            }
            return result;
        }

        private async Task<bool> CheckUserExists(string email, string phoneNumber)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(email));

            var userByEmail = await _userManager.FindByEmailAsync(email);
            if (userByEmail != null) return true;

            var userByPhoneNumber = _userManager.Users.FirstOrDefault(x => x.PhoneNumber == phoneNumber);
            return userByPhoneNumber != null;
        }

        private async Task<Staff> CreateStaff(StaffRequest request)
        {
            var user = await _userManager.FindByEmailAsync(_httpContextAccesor.HttpContext?.User.Identity?.Name!);
            if (request == null)
                throw new ArgumentNullException(nameof(request), "SignUp request for Staff is invalid");

            var newStaff = new Staff
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                Address = request.Address,
                Age = request.Age,
                Email = request.Email,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber,
                Role = request.Role,
                CreatedOn = DateTime.UtcNow,
                CreatedBy = _httpContextAccesor.HttpContext?.User.Identity?.Name,
                TenantId = (Guid)user!.TenantId!,
            };
            _staffRepository.Add(newStaff);
            return newStaff;
        }

        private async Task<IdentityResult> CreateUser(StaffRequest request, Guid staffId)
        {
            var user = await _userManager.FindByEmailAsync(_httpContextAccesor.HttpContext?.User.Identity?.Name!);
            if (request == null)
                throw new ArgumentNullException(nameof(request), "SignUp request for User is invalid");

            var identityUser = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                StaffId = staffId,
                TenantId = user!.TenantId
            };
            var result = await _userManager.CreateAsync(identityUser, request.Password);
            return result;
        }

        private async Task AssignRole(ApplicationUser user, string roleName)
        {
            if (user == null || string.IsNullOrEmpty(roleName))
                throw new ArgumentNullException("User or RoleName is invalid.");
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole(roleName));
                if (!roleResult.Succeeded)
                    throw new Exception("Cannot create role: " + string.Join(", ", roleResult.Errors.Select(e => e.Description)));

            }

            var assignResult = await _userManager.AddToRoleAsync(user, roleName);
            if (!assignResult.Succeeded)
                throw new Exception("Cannot assign permission role to User: " + string.Join(", ", assignResult.Errors.Select(e => e.Description)));
        }

        private async Task<List<Claim>> GetClaims(LogInRequest user, ApplicationUser identityUser)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email)
            };

            var roles = await _userManager.GetRolesAsync(identityUser);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
                claims.Add(new Claim(ClaimTypes.Name, user.Email));
            }
            return claims;
        }

        private string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken
            (
                _config["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public AppResponse<StaffResponse> Update(StaffRequest request)
        {
            throw new NotImplementedException();
        }

        public AppResponse<string> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public AppResponse<SearchResponse<StaffResponse>> Search(SearchRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
