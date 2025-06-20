namespace Dsw2025Ej15.Domain.Entities;

public class Product: EntityBase
{
    public Product()
    {
        
    }
    public Product(string sku, string name, decimal price, Guid categoryId)
    {
        Sku = sku;
        Name = name;
        CurrentUnitPrice = price;
        IsActive = true;
        CategoryId = categoryId;
    }
    public string? Sku { get; set; }
    public string? Name { get; set; }
    public decimal CurrentUnitPrice { get; set; }
    public bool  IsActive { get; set; }

    public Guid? CategoryId { get; set; }
    public Category? Category { get; set; }
}
