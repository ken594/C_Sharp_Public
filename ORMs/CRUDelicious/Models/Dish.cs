#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace CRUDelicious.Models;
public class Dish
{
    [Key]
    public int DishID { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Chef { get; set; }

    [Required]
    // [Range(1, 5)]
    [BetweenOneAndFive]
    public int Tastiness { get; set; }

    [Required]
    [GreaterThanZero]
    public int? Calories { get; set; }

    [Required]
    public string Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}

public class GreaterThanZeroAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value != null && (int)value > 0)
        {
            return ValidationResult.Success;
        }
        else
        {
            return new ValidationResult("Calories must be greater than 0");
        }
    }
}

public class BetweenOneAndFiveAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if ((int)value < 1 && (int)value > 5)
        {
            return new ValidationResult("Tastiness must be between 1 and 5");
        }
        else
        {
            return ValidationResult.Success;
        }
    }
}