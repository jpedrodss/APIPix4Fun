using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using APIEdux.Utils;
using APIPix4Fun.Context;
using APIPix4Fun.Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIPix4Fun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        Pix4FunContext _context = new Pix4FunContext();

        private IConfiguration _config;
        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// Autentifica o usuario
        /// </summary>
        /// <param name="login">Objeto para conseguir informações de login</param>
        /// <returns>Status code da ação</returns>
        private Usuario AuthenticateUser(Usuario login)
        {
            login.Senha = Crypto.Criptografar(login.Senha, login.Email.Substring(0, 4));

            return _context.Usuarios
                .Include(a => a.IdPerfilAcessoNavigation)
                .FirstOrDefault(u => u.Email == login.Email && u.Senha == login.Senha);
        }

        /// <summary>
        /// Gera o token de acesso
        /// </summary>
        /// <param name="userInfo">Informações de usuário</param>
        /// <returns>Token de acesso</returns>
        private string GenerateJSONWebToken(Usuario userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.NameId, userInfo.Nome),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim("Role", userInfo.IdPerfilAcesso.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, userInfo.IdPerfilAcessoNavigation.TipoPerfil)
        };

            var token = new JwtSecurityToken
                (
                    _config["Jwt:Issuer"],
                    _config["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Realiza o login do usuario
        /// </summary>
        /// <param name="login">Objeto para conseguir informações do usuário</param>
        /// <returns>Status code do login</returns>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] Usuario login)
        {
            IActionResult response = Unauthorized();

            var user = AuthenticateUser(login);
            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }
    }
}
