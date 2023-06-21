using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SistemaDeCadenasAlimenticias.Data.Entidades
{
    public partial class PW3PracticaSegundoParcialContext : DbContext
    {
        public PW3PracticaSegundoParcialContext()
        {
        }

        public PW3PracticaSegundoParcialContext(DbContextOptions<PW3PracticaSegundoParcialContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cadena> Cadenas { get; set; } = null!;
        public virtual DbSet<Sucursal> Sucursals { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=PW3PracticaSegundoParcial;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cadena>(entity =>
            {
                entity.ToTable("Cadena");

                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(50)
                    .HasColumnName("Razon_social");
            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.ToTable("Sucursal");

                entity.Property(e => e.Ciudad).HasMaxLength(50);

                entity.Property(e => e.Direccion).HasMaxLength(50);

                entity.HasOne(d => d.IdCadenaNavigation)
                    .WithMany(p => p.Sucursals)
                    .HasForeignKey(d => d.IdCadena)
                    .HasConstraintName("FK__Sucursal__IdCade__3E52440B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
