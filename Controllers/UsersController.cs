using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VulnerabilidadProyecto.Models;
using System.Threading.Tasks;

namespace VulnerabilidadProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly VulnerabilidadesContext _context;

        public AuthController(VulnerabilidadesContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User loginRequest)
        {
            if (string.IsNullOrWhiteSpace(loginRequest?.Usuario) || string.IsNullOrWhiteSpace(loginRequest?.Contrasena))
            {
                return BadRequest(new { message = "Usuario y contraseña son requeridos." });
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Usuario == loginRequest.Usuario && u.Contrasena == loginRequest.Contrasena);

            if (user == null)
            {
                return Unauthorized(new { message = "Credenciales inválidas." });
            }

            return Ok(new { message = "Login exitoso", user = "Bienvenido " + user.Usuario });
        }
    }
}
