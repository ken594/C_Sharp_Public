using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChefsANDDishes.Models;

namespace ChefsANDDishes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext db;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        db = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        // List<Chef> AllChefs = db.Chefs.ToList();
        ViewBag.AllChefs = db.Chefs.Include(c => c.AllDishes).ToList();
        return View();
    }

    [HttpGet("/dishes")]
    public IActionResult AllDishes()
    {
        ViewBag.AllDishes = db.Dishes.Include(d => d.Creator).ToList();
        return View();
    }

    [HttpGet("/chefs/new")]
    public IActionResult NewChef()
    {
        return View();
    }

    [HttpPost("/chefs/create")]
    public IActionResult CreateChef(Chef newChef)
    {
        if (ModelState.IsValid)
        {
            db.Add(newChef);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("NewChef");
    }

    [HttpGet("/dishes/new")]
    public IActionResult NewDish()
    {
        ViewBag.AllChefs = db.Chefs.ToList();
        return View();
    }

    [HttpPost("/dishes/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            Chef? TheChef = db.Chefs.FirstOrDefault(i => i.ChefId == newDish.ChefId);

            // get the name of the chef by the input id
            if (TheChef != null)
            {
                newDish.ChefName = $"{TheChef.FirstName} {TheChef.LastName}";
            }

            db.Add(newDish);
            db.SaveChanges();
            return RedirectToAction("AllDishes");
        }
        Console.WriteLine("***********************TEST*********");
        ViewBag.AllChefs = db.Chefs.ToList();
        return View("NewDish");
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
