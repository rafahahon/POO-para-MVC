using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Sistema_de_VeiculosDBFirst.Models;

namespace Sistema_de_VeiculosDBFirst.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TabelaVeiculo> TabelaVeiculos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
