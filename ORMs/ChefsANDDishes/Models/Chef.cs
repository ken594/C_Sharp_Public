#pragma warning disable CS8618
namespace ChefsANDDishes.Models;
using System.ComponentModel.DataAnnotations;

public class Chef
{
    [Key]
    public int ChefId { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [FutureDate]
    public DateTime DateOfBirth { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // Our navigation property to track the many Posts our user has made
    // Be sure to include the part about instantiating a new List!
    // public List<Post> AllPosts { get; set; } = new List<Post>();
    public List<Dish> AllDishes { get; set; } = new List<Dish>();
}

public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if ((DateTime)value > DateTime.Now)
        {
            return new ValidationResult("Birthday must be in the past!");
        }
        else
        {
            return ValidationResult.Success;
        }
    }
}