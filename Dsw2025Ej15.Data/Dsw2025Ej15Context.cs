using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej15.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dsw2025Ej15.Data;

public class Dsw2025Ej15Context: DbContext
{
    public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }

    public Dsw2025Ej15Context(DbContextOptions<Dsw2025Ej15Context> options): base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>()
            .Property(p => p.Name)
            .HasMaxLength(50);

        modelBuilder.Entity<Product>(eb =>
        {
            eb.ToTable("Products");
            eb.Property(p => p.Sku)
            .HasMaxLength(20)
            .IsRequired(); // Indica que la propiedad es requerida. Si se quiere hacer un insert y no se 
                           // pasa valor a esta propiedad, habrá un error.
            eb.Property(p => p.Name)
            .HasMaxLength(60);
            eb.Property(p => p.CurrentUnitPrice)
            .HasPrecision(15, 2); // 15 digitos en total, de los cuales 2 son decimales.

        });

    }
}
