using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APIBACKEND.Models;

public partial class PruebafiContext : DbContext
{
    public PruebafiContext()
    {
    }

    public PruebafiContext(DbContextOptions<PruebafiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Todolist> Todolists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todolist>(entity =>
        {
            entity.ToTable("TODOLIST");

            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
