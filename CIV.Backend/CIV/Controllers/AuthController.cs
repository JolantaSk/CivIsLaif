using CIV.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CIV
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AuthController(
            IConfiguration configuration,
            IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        // POST api/auth/login
        [HttpPost("login")]
        public async Task<object> Post([FromBody]LoginViewModel model)
        {
            string username = model.Username;
            if(!await _userService.ExistsAsync(username))
            {
                await _userService.CreateAsync(username);
            }
            var token = GenerateJwtToken(username);
            return new { token };
        }

        private string GenerateJwtToken(string username)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, username),
                new Claim(ClaimTypes.Name, username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenAuthentication:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["TokenAuthentication:TokenExpirationInDays"]));

            var token = new JwtSecurityToken(
                _configuration["TokenAuthentication:Authority"],
                _configuration["TokenAuthentication:Audience"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }

    public class LoginViewModel
    {
        public string Username { get; set; }
    }
}
