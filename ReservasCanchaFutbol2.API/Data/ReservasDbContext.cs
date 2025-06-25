using System.Linq;
using Microsoft.EntityFrameworkCore;
using ReservasCanchaFutbol2.API.Models;

namespace ReservasCanchaFutbol2.API.Data
{
    public class ReservasDbContext : DbContext
    {
        public ReservasDbContext(DbContextOptions<ReservasDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cancha> Canchas { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        /// <summary>
        /// Inserta datos semilla si no hay ninguna Cancha registrada.
        /// </summary>
        public static void SeedData(ReservasDbContext context)
        {
            if (!context.Canchas.Any())
            {
                context.Canchas.AddRange(
                    new Cancha { Nombre = "Cancha Futbol 5", Tipo = "Fútbol 5", PrecioPorHora = 2500 },
                    new Cancha { Nombre = "Cancha Futbol 7", Tipo = "Fútbol 7", PrecioPorHora = 3500 },
                    new Cancha { Nombre = "Cancha Futbol 5 Techada", Tipo = "Fútbol 5", PrecioPorHora = 4000 }
                );
                context.SaveChanges();
                if (!context.Usuarios.Any())
                {
                    context.Usuarios.Add(new Usuario
                    {
                        NombreUsuario = "admin",
                        Contraseña = "1234"
                    });

                    context.SaveChanges();
                }

            }
        }
    }
}
