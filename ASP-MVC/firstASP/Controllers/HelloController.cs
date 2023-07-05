using Microsoft.AspNetCore.Mvc;

namespace firstASP.Controllers;
public class HelloController : Controller
{
    [HttpGet]
    [Route("")]
    public string Index()
    {
        return "Hello World from HelloController!";
    }

    [HttpGet("user/more")]
    public string User()
    {
        return "Hello user";
    }

    [HttpPost]
    [Route("submission")]
    // Don't worry about what the form is doing for now. We'll get to those soon!
    // Note: You will not be able to navigate to this route! This is for demonstration only!
    public string FormSubmission(string formInput)
    {
        // Logic for post request here
        return "I handled a request!";
    }
}