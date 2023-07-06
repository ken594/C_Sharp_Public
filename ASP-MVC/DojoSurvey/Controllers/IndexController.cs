using Microsoft.AspNetCore.Mvc;

namespace DojoSurvey.Controllers;

public class IndexController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View();
    }

    [HttpPost("process")]
    public IActionResult Process(string name, string location, string language, string comment)
    {
        return RedirectToAction("Result", new { name = name, location = location, language = language, comment = comment });
    }

    [HttpGet("/results")]
    public ViewResult Result(string name, string location, string language, string comment = "No comments")
    {
        ViewBag.Name = name;
        ViewBag.Location = location;
        ViewBag.Language = language;
        ViewBag.Comment = comment;
        return View("Result");
    }
}