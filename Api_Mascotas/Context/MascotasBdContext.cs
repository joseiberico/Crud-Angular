using System;
using System.Collections.Generic;
using Api_Mascotas.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Mascotas.Context;

public partial class MascotasBdContext : DbContext
{
    public MascotasBdContext()
    {
    }

    public MascotasBdContext(DbContextOptions<MascotasBdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Mascota> Mascota { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mascota>(entity =>
        {
            entity.HasKey(e => e.IdMascota).HasName("PK__Mascota__6F03735288958CEC");

            entity.Property(e => e.IdMascota).HasColumnName("id_mascota");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(180)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
