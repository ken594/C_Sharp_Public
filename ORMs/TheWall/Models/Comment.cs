#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace TheWall.Models;

public class Comment
{
    [Key]
    public int CommentId { get; set; }

    [Required]
    public string CommentText { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public int MessageId { get; set; }
    public int UserId { get; set; }

    // Navigation
    public Message? Message { get; set; }
    public User? Creator { get; set; }

}