using Microsoft.EntityFrameworkCore;

namespace EmpleadosAPI.Models
{
    public class BDEmpleadosContext : DbContext
    {
        public BDEmpleadosContext()
        {

        }

        public BDEmpleadosContext(DbContextOptions<BDEmpleadosContext> options) : base(options)
        {

        }

        public virtual DbSet<Empleados> Empleados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleados>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Empleados");

                entity.ToTable("Empleado");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.nombre).HasMaxLength(50)
                    .HasColumnName("nombre");
                entity.Property(e => e.correo).HasMaxLength(50);
                entity.Property(e => e.telefono).HasMaxLength(10)
                    .HasColumnName("telefono");
                entity.Property(e => e.fechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fechaNacimiento");
                entity.Property(e => e.genero).HasMaxLength(9);
            });
        }
    }
}
