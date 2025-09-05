using AtivSistemaDeVendas.Data;
using AtivSistemaDeVendas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SistemaTarefa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly SistemaTarefasDbContext _dbContext;
        public ContaController(SistemaTarefasDbContext sistemaTarefasDbContext)
        {
            _dbContext = sistemaTarefasDbContext;
        }

        /* Primeira coisa que */
        [HttpPost]
        public IActionResult Login([FromBody] UsuarioModel usuario)
        {
            //var usuarioExistente = _dbContext.Usuarios.FirstOrDefault(u => u.Email == usuario.Email);

            ////verificando com usuário existente utilizando banco de dados
            //if (usuarioExistente != null && usuarioExistente.Senha == usuario.Senha && usuarioExistente.Nome == usuario.Nome)
            //{
            //    var token = GerarToken(usuario);
            //    return Ok(new { token });
            //}

            // verificando com usuário padrão/estático. Ou seja, sem banco de dados
            if (usuario.Nome == "admin" && usuario.Email == "admin" && usuario.Senha == "admin")
            {
                var token = GerarToken(usuario);
                return Ok(new { token });
            }

            return BadRequest(new { mensagem = "Credenciais inválidas. Por favor, verifique e tente novamente." });
        }

        private string GerarToken(UsuarioModel usuario)
        {
            string chaveSecreta = "0cbc84a9-98c5-4837-99bf-ddb35bf588a0";

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta));
            var credencial = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Email, usuario.Email),
            };


            var token = new JwtSecurityToken(
                issuer: "empresa",
                audience: "aplicacao",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credencial
             );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}