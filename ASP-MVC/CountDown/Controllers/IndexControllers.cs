using Microsoft.AspNetCore.Mvc;

namespace CountDown.Controllers;

public class IndexController : Controller
{
    Timer? myTimer; // Nullable field
    DateTime endDate;
    TimeSpan remainingTime;
    // Timer myTimer = new Timer(Callback, null, 0, 1000);
    // public string FormatTime(TimeSpan t)
    // {
    //     int days = TimeSpan.Days;
    //     int hours = TimeSpan.Hours;
    //     int minutes = TimeSpan.Minutes;

    //     // D2 format specifier to make sure to display with leading zeros
    //     return $"{days:D2} Day(s), {hours:D2} Hour(s), {minutes:D2} Minute(s) Remaining";
    // }

    void Callback(object? state)
    {
        remainingTime = endDate - DateTime.Now;
        ViewBag.RemainingTime = remainingTime;

        if (remainingTime.TotalMilliseconds <= 0)
        {
            myTimer!.Dispose();
        }
    }

    [HttpGet]
    [Route("")]
    public ViewResult Index()
    {
        DateTime CurrentTime = DateTime.Now;
        ViewBag.currentTime = CurrentTime.ToString("MMMM dd, yyyy h:mm tt");

        endDate = new DateTime(2023, 12, 25, 7, 0, 0);
        ViewBag.EndTime = endDate.ToString("MMMM dd, yyyy h:mm tt");

        remainingTime = endDate - CurrentTime;

        myTimer = new Timer(Callback, null, 0, 1000);

        return View();
    }
}
