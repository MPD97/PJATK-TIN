using BikeShop_Core.Entities;
using BikeShop_Infrastructure.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BikeShop_Infrastructure.Services
{
    public interface IUserAuthenticationService
    {
        public string GenerateJwtToken(ApplicationUser user, string[] roles);
        public Task<ApplicationUser> GetCurrentUserAsync();
    }
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly BikeShopContext _context;
        private readonly IHttpContextAccessor _httpAccessor;
        private readonly UserAuthorizationSettings _settings;

        public UserAuthenticationService(BikeShopContext context, IHttpContextAccessor httpAccessor, UserAuthorizationSettings settings)
        {
            _context = context;
            _httpAccessor = httpAccessor;
            _settings = settings;
        }

        public string GenerateJwtToken(ApplicationUser user, string[] roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.UserName),
                    new Claim(ClaimTypes.Role, string.Join(", ", roles))
                }),
                Expires = DateTime.UtcNow.AddMinutes(_settings.ExpireAfterMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            //TODO: Log
            return tokenHandler.WriteToken(token);
        }
        public async Task<ApplicationUser> GetCurrentUserAsync()
        {
            var userId = _httpAccessor.HttpContext.User.Identity.Name;
            if (int.TryParse(userId, out var id))
            {
                return await _context.Users.FindAsync(id);
            }   //TODO: Log
            return null;
        }
    }
}
