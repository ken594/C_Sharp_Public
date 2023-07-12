﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoginAndRegistration.Models;
// to be able to use Filters library
using Microsoft.AspNetCore.Mvc.Filters;

namespace LoginAndRegistration.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [SessionCheck]
    [HttpGet("/success")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return Redirect("/");
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