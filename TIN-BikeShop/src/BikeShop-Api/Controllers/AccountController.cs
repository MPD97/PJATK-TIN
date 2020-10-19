using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BikeShop_Core.Entities;
using BikeShop_Infrastructure.Authorization;
using BikeShop_Infrastructure.Authorization.Models;
using BikeShop_Infrastructure.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace BikeShop_Api.Controllers
{
    [Authorize(AuthenticationSchemes = BikeShopJwtConfig.AuthShemes)]
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly BikeShopContext _context;
        private readonly BikeShopJwtConfig _config;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager, BikeShopContext context, BikeShopJwtConfig config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            _config = config;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateToken([FromBody] JwtTokenModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            ApplicationUser user = await _userManager.FindByNameAsync(model.UserName);

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!signInResult.Succeeded)
            {
                return BadRequest();
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, model.UserName),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.UniqueName, model.UserName),
                new Claim(ClaimTypes.Role, string.Join(", ", roles)),
                new Claim(ClaimTypes.NameIdentifier, model.UserName)

            };

            var token = new JwtSecurityToken
            (
                _config.Issuer,
                _config.Audience,
                claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
            );

            var results = new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            };

            return Created("", results);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut([FromBody] JwtTokenModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            ApplicationUser user = await _userManager.FindByNameAsync(model.UserName);

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!signInResult.Succeeded)
            {
                return BadRequest();
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, model.UserName),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.UniqueName, model.UserName),
            };

            var token = new JwtSecurityToken
            (
                _config.Issuer,
                _config.Audience,
                claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
            );

            var results = new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            };

            return Created("", results);
        }
    }
}
