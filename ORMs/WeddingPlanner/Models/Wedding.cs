#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models;

public class Wedding
{
    [Key]
    public int WeddingId { get; set; }

    [Required]
    public string WedderOne { get; set; }

    [Required]
    public string WedderTwo { get; set; }

    [FutureDate]
    [DataType(DataType.Date)]
    public DateTime WeddingDate { get; set; }

    [Required]
    public string Address { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // This is the ID we will use to know which User made the wedding
    public int? CreatorId { get; set; }

    public List<Association> User { get; set; } = new List<Association>();
}

// The wedding date must be in the future
public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Date is required!");
        }
        if ((DateTime)value < DateTime.Now)
        {
            return new ValidationResult("Birthday must be in the future!");
        }
        else
        {
            return ValidationResult.Success;
        }
    }
}