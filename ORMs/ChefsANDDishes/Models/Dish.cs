#pragma warning disable CS8618
namespace ChefsANDDishes.Models;
using System.ComponentModel.DataAnnotations;

public class Dish
{
    [Key]

    public int DishId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [Range(0, 10000, ErrorMessage = "Calories must be greater than 0")]
    public int? Calories { get; set; }

    public int Tastiness { get; set; }

    public string? ChefName { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public int ChefId { get; set; }
    public Chef? Creator { get; set; }
}