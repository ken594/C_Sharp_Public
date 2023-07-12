using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoginAndRegistration.Models;
// Add this using statement to be able to use PasswordHasher
using Microsoft.AspNetCore.Identity;

namespace LoginAndRegistration.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;

    private MyContext db;

    public UserController(ILogger<UserController> logger, MyContext context)
    {
        _logger = logger;
        // When our HomeController is instantiated, it will fill in _context with context
        // Remember that when context is initialized, it brings in everything we need from DbContext
        // which comes from Entity Framework Core
        db = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("users/create")]
    public IActionResult Register(User newUser)
    {
        Console.WriteLine("Registering");
        if (ModelState.IsValid)
        {
            // Initializing a PasswordHasher object, providing our User class as its type
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            // Updating our newUser's password to a hashed version
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            // Save your user object to the database
            db.Add(newUser);
            db.SaveChanges();

            // Session security
            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            // Redirect to the internal page
            return Redirect("/success");
        }
        return View("Index");
    }

    [HttpPost("users/login")]
    public IActionResult Login(LoginUser userSubmission)
    {
        if (ModelState.IsValid)
        {
            // If initial ModelState is valid, query for a user with the provided email 
            User? userInDb = db.Users.FirstOrDefault(u => u.Email == userSubmission.LoginEmail);
            // If no user exists with the provided email 
            if (userInDb == null)
            {
                // Add an error to ModelState and return to View! 
                ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
                ModelState.AddModelError("LoginPassword", "Invalid Email/Password");
                return View("Index");
            }
            // Otherwise, we have a user, now we need to check their password                 
            // Initialize hasher object
            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            // Verify provided password against hash stored in db
            var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.LoginPassword);
            // Result can be compared to 0 for failure      
            if (result == 0)
            {
                // Handle failure
                ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
                ModelState.AddModelError("LoginPassword", "Invalid Email/Password");
                return View("Index");
            }
            // Handle Success && Session security
            HttpContext.Session.SetInt32("UserId", userInDb.UserId);
            return Redirect("/success");
        }
        return View("Index");
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

