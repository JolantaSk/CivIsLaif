using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CIV
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;

        public AuthController(
            IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // POST api/auth/login
        [HttpPost("login")]
        public object Post([FromBody]LoginViewModel model)
        {
            var token = GenerateJwtToken(model.Username);
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
