using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
// to be able to use Filters library
using Microsoft.AspNetCore.Mvc.Filters;
// to be able to use ExpandoObject()
using System.Dynamic;
// To use Include()
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private MyContext db;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        db = context;
    }

    // all wedding page
    [SessionCheck]
    [HttpGet("/weddings")]
    public IActionResult Index()
    {
        dynamic myModel = getMyModel();
        // myModel.Wedding = db.Weddings.ToList();
        // Get all the wedding joining Association table and user table
        myModel.Wedding = db.Weddings
                                .Include(w => w.User)
                                .ThenInclude(a => a.User)
                                .ToList();
        myModel.thisUserId = HttpContext.Session.GetInt32("UserId");
        return View("Index", myModel);
    }

    // Handle logout action
    [SessionCheck]
    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return Redirect("/");
    }

    // New Wedding page
    [SessionCheck]
    [HttpGet("/weddings/new")]
    public IActionResult NewWedding()
    {
        dynamic myModel = getMyModel();
        return View(myModel);
    }

    // Handle create a new wedding
    [SessionCheck]
    [HttpPost("/weddings/create")]
    public IActionResult CreateWedding(Wedding NewWedding)
    {
        if (ModelState.IsValid)
        {
            // get the userId from session
            NewWedding.CreatorId = HttpContext.Session.GetInt32("UserId");
            db.Add(NewWedding);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        dynamic myModel = getMyModel();
        return View("NewWedding", myModel);
    }

    // Show one wedding page
    [SessionCheck]
    [HttpGet("/weddings/{id}")]
    public IActionResult ShowWedding(int id)
    {
        dynamic myModel = getMyModel();
        myModel.Wedding = db.Weddings
                                .Include(w => w.User)
                                .ThenInclude(a => a.User)
                                .FirstOrDefault(w => w.WeddingId == id);
        // Console.WriteLine()
        return View(myModel);
    }

    // Handle delete a wedding
    [SessionCheck]
    [HttpPost("/weddings/destroy/{weddingId}")]
    public IActionResult DeleteWedding(int weddingId)
    {
        Wedding? WeddingToDelete = db.Weddings.SingleOrDefault(w => w.WeddingId == weddingId);
        if (WeddingToDelete == null) return RedirectToAction("Index");

        db.Weddings.Remove(WeddingToDelete);

        // When delete a wedding, also clear out the associations of this wedding
        // List<Association> AList = db.Associations.Where(a => a.WeddingId == weddingId).ToList();
        // // Not sure if we could just remove a list
        // // So we use a foreach loop to remove each
        // foreach (Association a in AList)
        // {
        //     db.Associations.Remove(a);
        // }
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    // Handle create an assocaition
    [SessionCheck]
    [HttpPost("/associations/create/{userId}/{weddingId}")]
    public IActionResult CreateAssociation(int userId, int weddingId)
    {
        Association newAssociation = new Association();
        newAssociation.UserId = userId;
        newAssociation.WeddingId = weddingId;

        db.Add(newAssociation);
        db.SaveChanges();
        // Console.WriteLine("*********************");
        // Console.WriteLine(newAssociation.AssociationId);
        // Console.WriteLine(newAssociation.UserId);
        // Console.WriteLine(newAssociation.WeddingId);
        return RedirectToAction("Index");
    }

    // Handle delete an association
    [SessionCheck]
    [HttpPost("/associations/destroy/{userId}/{weddingId}")]
    public IActionResult DeleteAssociation(int userId, int weddingId)
    {
        Association? AssToDelete = db.Associations
                                        .SingleOrDefault(a => a.UserId == userId && a.WeddingId == weddingId);
        if (AssToDelete == null) return RedirectToAction("Index");

        db.Associations.Remove(AssToDelete);
        db.SaveChanges();
        Console.WriteLine("**************Deleted Successfully***********");
        return RedirectToAction("Index");
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

    // helper function to create a dynamic
    public dynamic getMyModel()
    {
        dynamic myModel = new ExpandoObject();
        myModel.UserName = HttpContext.Session.GetString("UserName");
        myModel.Wedding = new Wedding();
        myModel.Wedding.WeddingDate = DateTime.Now;
        myModel.Wedding.CreatorId = HttpContext.Session.GetInt32("UserId");
        return myModel;
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
