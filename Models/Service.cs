using ConsoleApp12.Enums;

namespace ConsoleApp12.Models;

internal class Service
{

    public int Id { get; set; }
    public Category Category { get; set; } = Category.Other;
    public decimal Price { get; set; }
    public int DurationInMinutes { get; set; }
    public string Description { get; set; }
    public bool IsShipable { get; set; }

    public Service(int id, Category category, decimal price,
        int durationInMinutes, string description, bool isShipable)
    {
        Id = id;
        Category = category;
        Price = price;
        DurationInMinutes = durationInMinutes;
        Description = description;
        IsShipable = isShipable;
    }
}
