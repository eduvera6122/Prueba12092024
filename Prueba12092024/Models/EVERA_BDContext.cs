using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Prueba12092024.Models
{
    public partial class EVERA_BDContext : DbContext
    {
        public EVERA_BDContext()
        {
        }

        public EVERA_BDContext(DbContextOptions<EVERA_BDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EVeraSolicitud> EVeraSolicituds { get; set; } = null!;
        public virtual DbSet<EVeraUsuario> EVeraUsuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EVeraSolicitud>(entity =>
            {
                entity.ToTable("E_VERA_Solicitud");

                entity.Property(e => e.DescripcionSolicitud).HasMaxLength(255);

                entity.Property(e => e.DetalleGestion).HasMaxLength(255);

                entity.Property(e => e.Estado).HasMaxLength(50);

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaGestion).HasColumnType("datetime");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Tipo).HasMaxLength(50);

                entity.HasOne(d => d.UsuarioCreador)
                    .WithMany(p => p.EVeraSolicitudUsuarioCreadors)
                    .HasForeignKey(d => d.UsuarioCreadorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Solicitud_UsuarioCreador");

                entity.HasOne(d => d.UsuarioGestor)
                    .WithMany(p => p.EVeraSolicitudUsuarioGestors)
                    .HasForeignKey(d => d.UsuarioGestorId)
                    .HasConstraintName("FK_Solicitud_UsuarioGestor");
            });

            modelBuilder.Entity<EVeraUsuario>(entity =>
            {
                entity.ToTable("E_VERA_Usuario");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Estado).HasMaxLength(20);

                entity.Property(e => e.Nombres).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.Rol).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
