using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Sistema_de_PersonagensDBFirst.Models;

namespace Sistema_de_PersonagensDBFirst.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TabelaPersonagem> TabelaPersonagems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
