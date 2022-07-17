using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.DTOs.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{
    public class AuthController:BaseApiController
    {
        private readonly IConfiguration _config;
        private SymmetricSecurityKey _key;
        public AuthController(IConfiguration config)
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }


        [HttpPost]
        public ActionResult login(LoginDTO model)
        {
            if (string.IsNullOrEmpty(model.username)){
                return BadRequest("Usuario inválido");
            }

            if (string.IsNullOrEmpty(model.password)){
                return BadRequest("Contraseña inválida");
            }

            var token = CreateToken(model.username);

            return Ok(new { username = model.username, token });    
        }

        private string CreateToken(string username)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, username),
                new Claim(JwtRegisteredClaimNames.NameId, "1")
            };

            var creds = new SigningCredentials(_key,SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}