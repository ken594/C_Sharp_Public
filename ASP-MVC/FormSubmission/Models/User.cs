#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace FormSubmission.Models;



public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value != null && (DateTime)value > DateTime.Now)
        {
            return new ValidationResult("Birthday must be in the past!");
        }
        else
        {
            return ValidationResult.Success;
        }
    }
}

public class IsOddNumberAttribute : ValidationAttribute
{
    // Reference: https://stackoverflow.com/questions/15743192/check-if-number-is-prime-number
    public bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        var boundary = (int)Math.Floor(Math.Sqrt(number));

        for (int i = 3; i < boundary; i += 2)
        {
            if (number % i == 0) return false;
        }
        return true;
    }
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        // Odd number check
        // if (value != null && (int)value % 2 == 0)
        // Bonus: Prime number check
        if (value != null && !IsPrime((int)value))
        {
            // return new ValidationResult("Favorite Odd Number must be a whole odd number");
            return new ValidationResult("Favorite Prime Number must be a whole prime number");
        }
        else
        {
            return ValidationResult.Success;
        }
    }
}

public class User
{
    [Required(ErrorMessage = "Name is Required!")]
    [MinLength(2, ErrorMessage = "Name must be at least 2 characters in length.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email is Required!")]
    // [DataType(DataType.EmailAddress)]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Date of Birth is Required!")]
    [DataType(DataType.Date)]
    [FutureDate]
    public DateTime? DateOfBirth { get; set; }

    [Required(ErrorMessage = "Password is Required!")]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters in length.")]
    public string Password { get; set; }

    // [Required(ErrorMessage = "Odd Number is Required!")]
    // same annotation but it contains isOdd and isPrime
    [Required(ErrorMessage = "Prime Number is Required!")]
    [IsOddNumber]
    public int? OddNumber { get; set; }
}

