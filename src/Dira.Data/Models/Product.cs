namespace Dira.Data.Models;

public class Product
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    public decimal Price { get; set; }

    public string ImageUrl { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; }

    public bool IsDeleted { get; set; }
}
