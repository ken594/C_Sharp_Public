#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models;

public class LoginUser
{
    [Required]
    [EmailAddress]
    [RegularExpression(@"[^@ \t\r\n]+@[^@ \t\r\n]+\.[^@ \t\r\n]+", ErrorMessage = "Email must be in a valid format")]
    public string LoginEmail { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string LoginPassword { get; set; }
}