using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionWorkShop.Models;

namespace SessionWorkShop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("login")]
    public IActionResult Login(string name)
    {
        // lazy check if the name empty
        // return back to the first page
        // could've better to make a model and validation
        if (name == null)
        {
            return RedirectToAction("Index");
        }
        HttpContext.Session.SetString("UserName", name);
        HttpContext.Session.SetInt32("Num", 22);
        HttpContext.Session.SetString("isLogin", "1");
        return RedirectToAction("Dashboard");
    }

    [HttpGet("/dashboard")]
    public IActionResult Dashboard()
    {
        // prevent users getting this page without typing the name
        if (HttpContext.Session.GetString("isLogin") != "1")
        {
            // back to the first page if the user didn't login
            return RedirectToAction("Index");
        }
        string? name = HttpContext.Session.GetString("UserName");
        int? number = HttpContext.Session.GetInt32("Num");
        // use ViewBag to render the name
        ViewBag.Name = name;
        return View();
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        // clear out the session when logout
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    [HttpPost("calculation")]
    public IActionResult Calculation(string action)
    {
        int? newNumber = HttpContext.Session.GetInt32("Num");
        switch (action)
        {
            // button +1
            case "1":
                newNumber++;
                break;
            // button -1
            case "2":
                newNumber--;
                break;
            // button x2
            case "3":
                newNumber *= 2;
                break;
            // button +Random
            case "4":
                Random rand = new Random();
                newNumber += rand.Next(1, 11);
                break;
        }

        // null check to handle
        // error CS1503: Argument 3: cannot convert from 'int?' to 'int'
        if (newNumber != null) HttpContext.Session.SetInt32("Num", (int)newNumber);
        return RedirectToAction("Dashboard");
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
