using Meetup.DAL.Models;
using Meetup.WebApi.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Meetup.WebApi.Extensions {
    public class AuthManager {
        IConfiguration _configuration;
        UserManager<User> _userManager;
        User _user;
        public AuthManager(IConfiguration configuration, UserManager<User> userManager) {
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<bool> ValidateUser(AuthUserDTO user) {
            _user = await _userManager.FindByNameAsync(user.UserName);
            return(user != null && await _userManager.CheckPasswordAsync(_user, user.Password));
        }

        public async Task<string> CreateToken() {
            var signCredentials = GetSignCredentials();
            var claims = await GetClaims();
            var tokenOptions = GetTokenOptions(signCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private SigningCredentials GetSignCredentials() {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        async Task<List<Claim>> GetClaims() {
            var claims = new List<Claim>() {
                new Claim(ClaimTypes.Name, _user.UserName)
            };
            return claims;
        }

        private JwtSecurityToken GetTokenOptions(SigningCredentials signingCredentials, List<Claim> claims) {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var tokenOptions = new JwtSecurityToken(
                issuer: jwtSettings.GetSection("validIssuer").Value,
                audience: jwtSettings.GetSection("validAudience").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("expires").Value)),
                signingCredentials: signingCredentials
                );
            return tokenOptions;
        }
    }
}
