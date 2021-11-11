using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoVestuário.Model;
using Repositorio;
using Entidades;
using AutoMapper;

namespace ProjetoVestuário.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegurancaController : ControllerBase
    {
        private IConfiguration _config;
        public SegurancaController(IConfiguration Configuration)
        {
            _config = Configuration;
        }

        [HttpGet]
        public IActionResult Login(String email, String senha)
        {
            Usuario usu = (new usuarioRepositorio()).validarlogin(email, senha);

            if (usu!=null)
            {
                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                usuarioModel usumodel = mapper.Map<usuarioModel>(usu);  // Conversão do usuário para usuáriomodel para retornar o obj usuariomodel pelo token com as info do usuário.
                var tokenString = GerarTokenJWT();
                return Ok(new { token = tokenString, usuario= usumodel });
            }
            else
            {
                return Unauthorized();
            }
        }


        private string GerarTokenJWT()
        {
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var expiry = DateTime.Now.AddMinutes(120);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: issuer, audience: audience,
            expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
        
    }

}
