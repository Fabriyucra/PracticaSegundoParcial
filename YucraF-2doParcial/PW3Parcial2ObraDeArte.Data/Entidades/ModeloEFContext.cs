using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PW3Parcial2ObraDeArte.Data.Entidades
{
    public partial class ModeloEFContext : DbContext
    {
        public ModeloEFContext()
        {
        }

        public ModeloEFContext(DbContextOptions<ModeloEFContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ObraDeArte> ObraDeArtes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=ModeloEF;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ObraDeArte>(entity =>
            {
                entity.ToTable("ObraDeArte");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
