using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FutebolManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Endpoint solicitado: Get api/Auth/auth
        [HttpGet("auth")]
        public IActionResult Auth()
        {
            var token = GenerateJwtToken();
            return Ok(new { token = token });
        }

        private string GenerateJwtToken()
        {
            // Pega a chave do appsettings.json (MESMA do Program.cs)
            var keyConfig = _configuration["Jwt:Key"];

            // Segurança: Garante que a chave existe antes de tentar converter
            if (string.IsNullOrEmpty(keyConfig))
                throw new Exception("A chave Jwt:Key não foi configurada no appsettings.json");

            var key = Encoding.ASCII.GetBytes(keyConfig);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, "UsuarioTeste")
                }),
                // Tempo de expiração do token (ex: 2 horas)
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }        
}
