#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ProductsNCategories.Models;

public class Product
{
    [Key]
    public int ProductId { get; set; }

    [Required]
    public string ProductName { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public double? Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // reference to Associations
    public List<Association> Categories { get; set; } = new List<Association>();
}