#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DateValidator.Models;

public class BeforeNowDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        DateTime CurrentTime = DateTime.Now;
        TimeSpan remainingTime;
        if (value != null)
        {
            remainingTime = CurrentTime - (DateTime)value;
            Console.WriteLine(remainingTime.TotalMilliseconds);
            if (remainingTime.TotalMilliseconds < 0)
            {
                return new ValidationResult("Please pick a date time that is before the present moment!");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
        return ValidationResult.Success;
    }
}

// Platform Solution
// public class FutureDateAttribute : ValidationAttribute
// {
//     protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
//     {
//         if((DateTime)value > DateTime.Now)
//         {
//             return new ValidationResult("Birthday must be in the past!");
//         } else {
//             return ValidationResult.Success;
//         }
//     }
// }

public class Form
{
    [Required]
    [BeforeNowDate]
    public DateTime Date { get; set; }
}