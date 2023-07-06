using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyWithModel.Models;

namespace DojoSurveyWithModel.Controllers;

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

    [HttpPost("process")]
    public IActionResult Process(Survey mySurvey)
    {
        // Console.WriteLine(mySurvey.Name);
        // Console.WriteLine(mySurvey.Location);
        return RedirectToAction("Result", mySurvey);
    }

    [HttpGet("/results")]
    public ViewResult Result(Survey survey)
    {
        // Console.WriteLine(survey.Language);
        // Console.WriteLine(survey.Comment);
        return View("Result", survey);
    }

    // public IActionResult Privacy()
    // {
    //     return View();
    // }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
