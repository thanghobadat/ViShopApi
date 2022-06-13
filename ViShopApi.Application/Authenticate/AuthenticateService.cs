using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ViShopApi.Data.Enities;
using ViShopApi.ViewModel.Authenticate;
using ViShopApi.ViewModel.Common;

namespace ViShopApi.Application.Authenticate
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;
        public AuthenticateService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
        }
        public async Task<ApiResult<string>> Login(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) return new ApiErrorResult<string>("User doesn't exits");
            var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, true);
            if (!result.Succeeded)
            {
                return new ApiErrorResult<string>("Login unsuccessful");
            }
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.Name),
                new Claim(ClaimTypes.Role,string.Join(";",roles)),
                new Claim(ClaimTypes.Name,request.UserName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            return new ApiSuccessResult<string>(new JwtSecurityTokenHandler().WriteToken(token));
        }

        public async Task<ApiResult<bool>> Register(RegisterRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null)
            {
                return new ApiErrorResult<bool>("UserName is exist");
            }
            user = new AppUser()
            {
                Email = request.Email,
                Name = request.Name,
                Age = request.Age,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber,
                DateCreated = DateTime.Now
            };
            var result = await _userManager.CreateAsync(user, request.Password);

            await _userManager.AddToRoleAsync(user, "customer");

            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>(true);
            }
            return new ApiErrorResult<bool>("Register Fail") ;
        }
    }
}
