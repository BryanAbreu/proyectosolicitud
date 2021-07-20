using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace proyectosolicitud.Models
{
    public partial class solicitudespersonasContext : DbContext
    {
       

        public solicitudespersonasContext(DbContextOptions<solicitudespersonasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Solicitud> Solicituds { get; set; }

     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.ToTable("Estado");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("Persona");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimieto).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Solicitud>(entity =>
            {
                entity.ToTable("Solicitud");

                entity.Property(e => e.FecahrCrea).HasColumnType("date");

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.Solicituds)
                    .HasForeignKey(d => d.EstadoId)
                    .HasConstraintName("FK_Solicitud_Estado");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Solicituds)
                    .HasForeignKey(d => d.PersonaId)
                    .HasConstraintName("FK_Solicitud_Persona");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
