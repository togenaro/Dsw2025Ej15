using Dsw2025Ej15.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej15.Data;

public class Dsw2025Ej15Context: DbContext
{
    public Dsw2025Ej15Context(DbContextOptions<Dsw2025Ej15Context> options)
        : base(options)
    {
            
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>()
            .ToTable("Products")
            .Property(p=> p.Sku).HasMaxLength(20);
        modelBuilder.Entity<Product>()
            .Property(p => p.Name).HasMaxLength(60);
        modelBuilder.Entity<Product>()
            .Property(p => p.CurrentUnitPrice).HasPrecision(15, 2);
    }
}
