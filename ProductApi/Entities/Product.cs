namespace ProductApi.Entities;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;    
    public string? Description { get; set; }
    public bool Status { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int Amount { get; set; }
    public decimal Price { get; set; }
}