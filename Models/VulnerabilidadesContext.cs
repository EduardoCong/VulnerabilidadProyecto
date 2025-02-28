using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VulnerabilidadProyecto.Models;

public partial class VulnerabilidadesContext : DbContext
{
    public VulnerabilidadesContext()
    {
    }

    public VulnerabilidadesContext(DbContextOptions<VulnerabilidadesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Personid).HasName("PK__Users__AA2CFFDD708195AC");

            entity.Property(e => e.Contrasena)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Usuario)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
