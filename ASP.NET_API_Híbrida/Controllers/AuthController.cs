using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using APIhibridaASP.Data;
using APIhibridaASP.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIhibridaASP.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class AuthController : ControllerBase
        {
            private readonly AppDbContext _context;
            private readonly IConfiguration _configuration;

            public AuthController(AppDbContext context, IConfiguration configuration)
            {
                _context = context;
                _configuration = configuration;
            }

            [HttpPost("login")]
            public async Task<IActionResult> Login(LoginRequest request)
            {
                var usuario = await _context.Usuarios
                    .FirstOrDefaultAsync(u =>
                        u.NombreUsuario == request.NombreUsuario &&
                        u.Contrasenia == request.Contrasenia);

                if (usuario == null)
                    return Unauthorized("Credenciales incorrectas");

                var token = GenerarToken(usuario);

                return Ok(new { token });
            }

            private string GenerarToken(Usuario usuario)
            {
                var jwtSettings = _configuration.GetSection("Jwt");

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, usuario.NombreUsuario),
                    new Claim(ClaimTypes.Role, usuario.Tipo.ToString()), 
                    new Claim("UsuarioId", usuario.Id.ToString())
            };

                var key = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings["Key"]!));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: jwtSettings["Issuer"],
                    audience: jwtSettings["Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(
                        Convert.ToDouble(jwtSettings["ExpiresInMinutes"])),
                    signingCredentials: creds
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        }
}
