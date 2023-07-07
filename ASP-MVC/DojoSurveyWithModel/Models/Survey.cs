#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DojoSurveyWithModel.Models;

public class Survey
{
    [Required(ErrorMessage = "Name is required")]
    [MinLength(2, ErrorMessage = "Name must be at least 2 characters in length")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Location is required")]
    public string Location { get; set; }
    [Required(ErrorMessage = "Location is required")]
    public string Language { get; set; }
    [MinLength(20, ErrorMessage = "Comment needs to be at least 20 characters long")]
    // ? meaning comment could be null, otherwise the validation could not go through
    public string? Comment { get; set; }
}