using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Sistema_de_AnimaisDBFirst.Models;

namespace Sistema_de_AnimaisDBFirst.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TabelaAnimal> TabelaAnimals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
