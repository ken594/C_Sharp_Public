#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace firstConnection.Models;
public class Pet
{
    [Key]
    public int PetId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public int Age { get; set; }
    bool hasFur { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}