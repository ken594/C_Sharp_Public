#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace TheWall.Models;

public class LoginUser
{
    [Required]
    [EmailAddress]
    public string LoginEmail { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string LoginPassword { get; set; }
}