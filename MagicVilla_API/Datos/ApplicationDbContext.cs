using MagicVilla_API.Modelos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_API.Datos
{
    public class ApplicationDbContext : IdentityDbContext<UsuarioAplicacion>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
                    
        }
        public DbSet<UsuarioAplicacion> UsuariosAplicacion {  get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Villa> Villas { get; set; }
        public DbSet<NumeroVilla> NumeroVillas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);  //es lo agrego cuando agrego Identity

            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Nombre = "Villa Real",
                    Detalle = "Detalle de la villa...",
                    ImagenUrl = "",
                    Ocupantes = 5,
                    MetrosCuadrados = 50,
                    Tarifa = 200,
                    Amenidad = "",
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now
                },
                new Villa()
                {
                    Id = 2,
                    Nombre = "Premium Villa Europea",
                    Detalle = "Detalle de la villa...",
                    ImagenUrl = "",
                    Ocupantes = 4,
                    MetrosCuadrados = 150,
                    Tarifa = 1200,
                    Amenidad = "",
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now
                }
                );
        }
    }
}
