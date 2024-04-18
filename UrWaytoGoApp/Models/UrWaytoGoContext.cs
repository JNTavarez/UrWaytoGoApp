using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UrWaytoGoApp.Models;

public partial class UrWaytoGoContext : DbContext
{
    public UrWaytoGoContext()
    {
    }

    public UrWaytoGoContext(DbContextOptions<UrWaytoGoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__645723A6A6D0F862");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.CorreoUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correoUsuario");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreUsuario");
            entity.Property(e => e.PasswordUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("passwordUsuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
