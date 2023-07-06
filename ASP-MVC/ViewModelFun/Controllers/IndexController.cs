using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers;

public class IndexController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        Message aMessage = new Message()
        {
            message = "Message: I dont know what is going on"
        };
        return View(aMessage);
    }

    [HttpGet("/numbers")]
    public ViewResult Number()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
        return View(numbers);
    }

    [HttpGet("/user")]
    public ViewResult OneUser()
    {
        string userName = "Neil Gaiman";
        return View("OneUser", userName);
    }

    [HttpGet("/users")]
    public ViewResult Users()
    {
        List<string> userNameList = new List<string> {
            "Neil Gaiman",
            "Terry Pratchet",
            "Jone Austen"
        };
        return View("Users", userNameList);
    }
}