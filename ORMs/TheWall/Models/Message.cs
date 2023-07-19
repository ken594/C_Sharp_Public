#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace TheWall.Models;

public class Message
{
    [Key]
    public int MessageId { get; set; }

    [Required]
    public string MessageText { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public int UserId { get; set; }

    // Navigation property to track which user made this Message
    public User? Creator { get; set; }
    public List<Comment> AllComments { get; set; } = new List<Comment>();
}