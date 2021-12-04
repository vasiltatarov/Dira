namespace Dira.Data.Models;

public class Category
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    public string? ImageUrl { get; set; }

    public int? ParentCategoryId { get; set; }

    public Category ParentCategory { get; set; }

    public bool IsDeleted { get; set; }
}
