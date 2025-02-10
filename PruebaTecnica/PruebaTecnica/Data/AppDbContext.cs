using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Models;

namespace PruebaTecnica.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Configuración de las tablas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapear la entidad Persona a la tabla Libo_Personas
            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("Personas"); // Nombre de la tabla en la base de datos
                entity.Property(p => p.Identificador).HasColumnName("Id"); // Mapear columna
                entity.Property(p => p.NumeroIdentificacionConcatenado).HasColumnName("NumeroIdentificacionCompleto");
                entity.Property(p => p.NombresApellidosConcatenados).HasColumnName("NombreCompleto");
            });

            // Mapear la entidad Usuario a la tabla Libo_Usuarios
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuarios"); // Nombre de la tabla en la base de datos
                entity.Property(u => u.Identificador).HasColumnName("Id"); // Mapear columna
                entity.Property(u => u.NombreUsuario).HasColumnName("Usuario");
                entity.Property(u => u.Pass).HasColumnName("Pass");
                entity.Property(u => u.FechaCreacion).HasColumnName("FechaCreacion");
            });
        }

        // DbSet para las entidades
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}