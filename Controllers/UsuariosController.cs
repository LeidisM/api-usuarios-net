// Importamos lo necesario: controladores, contexto de base de datos y modelo de usuario
using Microsoft.AspNetCore.Mvc;
using ApiUsuariosNet.Data;
using ApiUsuariosNet.Models;
using System.Threading.Tasks;
using System.Linq;

namespace ApiUsuariosNet.Controllers
{
    // Indicamos que esta clase será un controlador API
    [ApiController]
    // La ruta base será: api/usuarios
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        // Variable para acceder a la base de datos
        private readonly ApiDbContext _context;

        // Constructor para recibir el contexto al crear el controlador
        public UsuariosController(ApiDbContext context)
        {
            _context = context;
        }

        // Ruta para registrar un nuevo usuario: POST api/usuarios/registrar
        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] Usuario usuario)
        {
            // Validamos que el nombre de usuario y contraseña no estén vacíos
            if (string.IsNullOrEmpty(usuario.NombreUsuario) || string.IsNullOrEmpty(usuario.Contrasena))
            {
                return BadRequest(new { mensaje = "Nombre de usuario y contraseña son obligatorios" });
            }

            // Verificamos si ya existe un usuario con el mismo nombre
            if (_context.Usuarios.Any(u => u.NombreUsuario == usuario.NombreUsuario))
            {
                return Conflict(new { mensaje = "El nombre de usuario ya está registrado" });
            }

            // Agregamos el usuario y guardamos en la base de datos
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Usuario registrado exitosamente", id = usuario.Id });
        }

        // Ruta para login: POST api/usuarios/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] Usuario usuario)
        {
            // Buscamos si existe un usuario con ese nombre y contraseña
            var usuarioEncontrado = _context.Usuarios
                .FirstOrDefault(u => u.NombreUsuario == usuario.NombreUsuario && u.Contrasena == usuario.Contrasena);

            // Si no lo encuentra, devuelve error
            if (usuarioEncontrado == null)
            {
                return Unauthorized(new { mensaje = "Credenciales incorrectas" });
            }

            // Si lo encuentra, devuelve éxito
            return Ok(new { mensaje = "Inicio de sesión exitoso", id = usuarioEncontrado.Id });
        }
    }
}
