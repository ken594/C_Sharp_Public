using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        // Get all dishes
        // List<Dish> AllDishes = _context.Dishes.ToList();
        ViewBag.AllDishes = _context.Dishes.ToList();

        // Hard code to insert some initial data
        // Dish newDish = new Dish();
        // newDish.DishID = 2;
        // newDish.Name = "test2";
        // newDish.Chef = "Admin";
        // newDish.Tastiness = 5;
        // newDish.Calories = 330;
        // newDish.Description = "Description2";
        // newDish.CreatedAt = DateTime.Now;
        // newDish.UpdatedAt = DateTime.Now;
        // _context.Add(newDish);
        // _context.SaveChanges();
        return View();
    }

    [HttpGet("dishes/{id}")]
    public IActionResult Show(int id)
    {
        // ViewBag.DishId = id;
        Dish? OneDish = _context.Dishes.FirstOrDefault(i => i.DishID == id);
        if (OneDish == null)
        {
            return RedirectToAction("Index");
        }

        ViewBag.OneDish = OneDish;
        return View();
    }

    [HttpGet("dishes/new")]
    public IActionResult New()
    {
        return View();
    }

    [HttpPost("/dishes/create")]
    public IActionResult Create(Dish newDish)
    {
        // return View();
        if (ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("New");
        }
    }

    [HttpGet("/dishes/{id}/edit")]
    public IActionResult Edit(int id)
    {
        // ViewBag.OneDish = _context.Dishes.FirstOrDefault(i => i.DishID == id);
        Dish? oneDish = _context.Dishes.FirstOrDefault(i => i.DishID == id);
        if (oneDish == null) return RedirectToAction("Index");
        return View("Edit", oneDish);
    }

    [HttpPost("dishes/{DishId}/update")]
    public IActionResult UpdateDish(Dish NewDish, int DishId)
    {
        Dish? OldDish = _context.Dishes.FirstOrDefault(i => i.DishID == DishId);
        if (OldDish == null)
        {
            return RedirectToAction("New");
        }

        if (ModelState.IsValid)
        {
            OldDish.Name = NewDish.Name;
            OldDish.Chef = NewDish.Chef;
            OldDish.Tastiness = NewDish.Tastiness;
            OldDish.Calories = NewDish.Calories;
            OldDish.Description = NewDish.Description;
            OldDish.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("Edit", OldDish);
    }

    [HttpPost("dishes/{DishId}/destroy")]
    public IActionResult Destroy(int DishId)
    {
        Dish? DishToDelete = _context.Dishes.SingleOrDefault(i => i.DishID == DishId);
        if (DishToDelete == null)
        {
            RedirectToAction("Index");
        }
        _context.Dishes.Remove(DishToDelete);
        _context.SaveChanges();
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
}
