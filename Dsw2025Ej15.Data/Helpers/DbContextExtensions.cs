using Dsw2025Ej15.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dsw2025Ej15.Data.Helpers;

public static class DbContextExtensions
{
    public static void Seedwork(this Dsw2025Ej15Context context)
    {
        if (context.Set<Product>().Any()) return;
        var json = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Sources\\products.json"));
        var products = JsonSerializer.Deserialize<List<Product>>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        });
        if (products == null || products.Count == 0) return;
        context.Set<Product>().AddRange(products);
        context.SaveChanges();
    }
}
