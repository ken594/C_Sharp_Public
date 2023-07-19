#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace TheWall.Models;

public class MyModel
{
    public string UserName { get; set; }
    public Message message { get; set; }
    public List<Message> MessageList { get; set; }
}