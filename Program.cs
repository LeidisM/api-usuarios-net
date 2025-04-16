using Microsoft.EntityFrameworkCore;
using ApiUsuariosNet.Data;

namespace ApiUsuariosNet
{
    public class Program
    {
        public static void Main(string[] args)

        {
            var builder = WebApplication.CreateBuilder(args);
            // Acá le decimos a la app que vamos a usar nuestra clase ApiDbContext para trabajar con la base de datos
            builder.Services.AddDbContext<ApiDbContext>(options =>
            // Y que esa base de datos es de tipo SQL Server, usando la cadena de conexión que está en appsettings.json con  el nombre "ConexionSQL"
            options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSQL")));


            builder.Services.AddControllers();           
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
         
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
