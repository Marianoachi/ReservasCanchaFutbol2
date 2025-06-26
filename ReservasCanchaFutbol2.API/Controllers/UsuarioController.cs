using Microsoft.AspNetCore.Mvc;
using ReservasCanchaFutbol2.API.Data;
using ReservasCanchaFutbol2.API.Models;

namespace ReservasCanchaFutbol2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ReservasDbContext _context;

        public UsuarioController(ReservasDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Usuario request)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u =>
                u.NombreUsuario == request.NombreUsuario &&
                u.Contraseña == request.Contraseña);

            if (usuario == null)
                return Unauthorized("Nombre de usuario o contraseña incorrectos.");

            return Ok(new { usuario.Id, usuario.NombreUsuario });
        }
        [HttpPost]
        public IActionResult Registrar([FromBody] Usuario nuevoUsuario)
        {
            if (string.IsNullOrWhiteSpace(nuevoUsuario.NombreUsuario) || string.IsNullOrWhiteSpace(nuevoUsuario.Contraseña))
                return BadRequest("Usuario y contraseña son obligatorios.");

            if (_context.Usuarios.Any(u => u.NombreUsuario == nuevoUsuario.NombreUsuario))
                return Conflict("Ya existe un usuario con ese nombre.");

            _context.Usuarios.Add(nuevoUsuario);
            _context.SaveChanges();
            return Ok();
        }

    }

}
