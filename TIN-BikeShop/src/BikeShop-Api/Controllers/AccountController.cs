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
using BikeShop_Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace BikeShop_Api.Controllers
{
    [Authorize(Roles = "Admin, Moderator")]
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly BikeShopContext _context;
        private readonly IUserAuthenticationService _authorizationManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager, BikeShopContext context, IUserAuthenticationService authorizationManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            _authorizationManager = authorizationManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LogIn([FromBody] LoginModel model)
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
            var roles = (await _userManager.GetRolesAsync(user))?.ToArray();

            var token = _authorizationManager.GenerateJwtToken(user, roles);

            var response = new //TODO: Create response model
            {
                token = token,
            };

            return Created("", response);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut([FromBody] LoginModel model)
        {
            throw new NotImplementedException();
        }
    }
}
