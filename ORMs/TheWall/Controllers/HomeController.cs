using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TheWall.Models;
// to be able to use Filters library
using Microsoft.AspNetCore.Mvc.Filters;
// to be able to use Include()
using Microsoft.EntityFrameworkCore;

namespace TheWall.Controllers;

[SessionCheck]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private MyContext db;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        db = context;
    }

    [HttpGet("/messages")]
    public IActionResult Index()
    {
        MyModel aModel = new MyModel();
        aModel.UserName = HttpContext.Session.GetString("UserName");
        aModel.MessageList = db.Messages
                                    .Include(m => m.Creator)
                                    .Include(m => m.AllComments)
                                    .ThenInclude(c => c.Creator)
                                    .ToList();
        // string userName = HttpContext.Session.GetString("UserName");
        return View("Index", aModel);
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return Redirect("/");
    }

    [HttpPost("/messages/create")]
    public IActionResult CreateMessages(Message newMessage)
    {
        if (ModelState.IsValid)
        {
            newMessage.UserId = (int)HttpContext.Session.GetInt32("UserId");
            db.Add(newMessage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        MyModel aModel = new MyModel();
        aModel.UserName = HttpContext.Session.GetString("UserName");
        aModel.MessageList = db.Messages
                                    .Include(m => m.Creator)
                                    .ToList();
        return View("Index", aModel);
    }

    [HttpPost("/comments/create")]
    public IActionResult CreateComments(Comment newComment)
    {
        if (ModelState.IsValid)
        {
            newComment.UserId = (int)HttpContext.Session.GetInt32("UserId");
            Console.WriteLine("********************");
            Console.WriteLine(newComment.MessageId);
            Console.WriteLine(newComment.CommentText);
            db.Add(newComment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        MyModel aModel = new MyModel();
        aModel.UserName = HttpContext.Session.GetString("UserName");
        aModel.MessageList = db.Messages
                                    .Include(m => m.Creator)
                                    .ToList();
        return View("Index", aModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

// ActionFilterAttribute
// Name this anything you want with the word "Attribute" at the end
public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // base.OnActionExecuting(context);
        // Find the session, but remember it may be null so we need int?
        // Question: Why here using context.HttpContext...
        int? userId = context.HttpContext.Session.GetInt32("UserId");
        // Check to see if we got back null
        if (userId == null)
        {
            // Redirect to the Index page if there was nothing in session
            // "Home" here is referring to "HomeController", you can use any controller that is appropriate here
            context.Result = new RedirectToActionResult("Index", "User", null);
        }
    }
}