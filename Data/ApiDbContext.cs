// Importamos el modelo 'Usuario' que seguramente tiene las propiedades del usuario (como nombre, correo, etc.)
using ApiUsuariosNet.Models;

// Esta es una herramienta de Entity Framework que nos permite trabajar con bases de datos
using Microsoft.EntityFrameworkCore;

// Esto es por si necesitamos usar listas, aunque acá no se usa directamente
using System.Collections.Generic;

// Definimos el espacio donde está nuestra clase, como una carpeta virtual para organizar el código
namespace ApiUsuariosNet.Data
{
    // Esta clase es la conexión con la base de datos, como el "puente" entre la app y los datos
    public class ApiDbContext : DbContext
    {
        // Este constructor se usa para configurar cómo se va a conectar la app con la base de datos
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
            // Aquí podríamos poner cosas que se ejecutan cuando se crea el contexto, pero está vacío por ahora
        }

        // Esta propiedad representa la tabla de usuarios en la base de datos
        // Es como decir: “voy a trabajar con una tabla llamada Usuarios”
        public DbSet<Usuario> Usuarios { get; set; }
    }

}
