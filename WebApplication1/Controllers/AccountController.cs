using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IConfiguration _configuration;

        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("auth")]
        public IActionResult Authenticate([FromBody] AuthModel model)
        {
            if ((model.Username == "abidinyarata" || model.Username == "ayarata") && model.Password == "123123")
            {
                string key = _configuration["JWT:secret"];
                byte[] keyBytes = Encoding.UTF8.GetBytes(key);

                SymmetricSecurityKey securityKey = new SymmetricSecurityKey(keyBytes);
                SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                string issuer = _configuration["JWT:issuer"];
                string audience = _configuration["JWT:audience"];

                List<Claim> claims = new List<Claim>
                {
                    new Claim("username", model.Username),
                    new Claim("role", (model.Username == "abidinyarata"  ? "yonetici" : "uye"))
                };

                JwtSecurityToken securityToken = new JwtSecurityToken(issuer, audience, claims, null, DateTime.Now.AddDays(30), signingCredentials);
                string token = new JwtSecurityTokenHandler().WriteToken(securityToken);

                return Ok(new { Token = token});
            }

            return BadRequest();
        }
    }
}
