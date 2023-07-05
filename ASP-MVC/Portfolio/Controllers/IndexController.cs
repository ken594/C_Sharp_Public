using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers;

public class IndexController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View();
    }

    [HttpGet("/projects")]
    public ViewResult Projects()
    {
        return View("projects");
    }

    [HttpGet("/contact")]
    public ViewResult Contact()
    {
        return View("contact");
    }
}