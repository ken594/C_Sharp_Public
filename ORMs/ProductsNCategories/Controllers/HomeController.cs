using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductsNCategories.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductsNCategories.Controllers;

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
        ViewBag.AllProducts = db.Products.ToList();
        return View();
    }

    [HttpPost("/products/create")]
    public IActionResult CreateProduct(Product newProduct)
    {
        if (ModelState.IsValid)
        {
            db.Add(newProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // Need to set the ViewBag to render all the products
        ViewBag.AllProducts = db.Products.ToList();
        return View("Index");
    }

    [HttpGet("/categories")]
    public IActionResult CategoryIndex()
    {
        ViewBag.AllCategories = db.Categories.ToList();
        return View();
    }

    [HttpGet("/products/{id}")]
    public IActionResult ShowOneProduct(int id)
    {
        Product? OneProduct = db.Products.FirstOrDefault(p => p.ProductId == id);
        if (OneProduct == null) return RedirectToAction("Index");
        ViewBag.OneProduct = OneProduct;
        ViewBag.ProductId = id;
        // ViewBag.AllCategories = db.Categories.ToList();
        ViewBag.ProductWithCategories = db.Products
                                            .Include(p => p.Categories)
                                            .ThenInclude(a => a.Category)
                                            .FirstOrDefault(p => p.ProductId == id);

        // To filtered the selected options in the dropdown
        // first grab all the categories and include the Associations table
        // then pick categories which the id does NOT match the categoryID inside of the association table
        ViewBag.AllCategories = db.Categories
                                        .Include(c => c.Products)
                                        .Where(c => !c.Products.Any(a => a.ProductId == id))
                                        .ToList();
        return View("ShowOneProduct");
    }

    [HttpPost("/categories/create")]
    public IActionResult CreateCategory(Category newCategory)
    {
        if (ModelState.IsValid)
        {
            db.Add(newCategory);
            db.SaveChanges();
            return RedirectToAction("CategoryIndex");
        }
        // Need to set the ViewBag to render all the categories
        ViewBag.AllCategories = db.Categories.ToList();
        return View("CategoryIndex");
    }

    [HttpGet("/categories/{id}")]
    public IActionResult ShowOneCategory(int id)
    {
        Category? OneCategory = db.Categories.FirstOrDefault(c => c.CategoryId == id);
        if (OneCategory == null) return RedirectToAction("CategoryIndex");
        ViewBag.OneCategory = OneCategory;
        ViewBag.CategoryId = id;
        ViewBag.AllProducts = db.Products.ToList();
        ViewBag.CategoriesWithProducts = db.Categories
                                            .Include(c => c.Products)
                                            .ThenInclude(a => a.Product)
                                            .FirstOrDefault(c => c.CategoryId == id);
        return View("ShowOneCategory");
    }

    [HttpPost("/associations/create/{name}")]
    public IActionResult CreateAssociation(Association newAssociation, string name)
    {
        if (newAssociation == null) return RedirectToAction("Index");

        db.Add(newAssociation);
        db.SaveChanges();
        if (name == "product")
            return Redirect("/products/" + newAssociation.ProductId);
        return Redirect("/categories/" + newAssociation.CategoryId);
    }

    [HttpPost("/associations/destroy")]
    public IActionResult DeleteAssociation(Association oldAssociation)
    {
        // Console.WriteLine("*********************");
        // Console.WriteLine(oldAssociation.CategoryId);
        Association? AssToDelete = db.Associations
                                    .SingleOrDefault(i => i.CategoryId == oldAssociation.CategoryId && i.ProductId == oldAssociation.ProductId);
        if (AssToDelete == null) return RedirectToAction("Index");

        db.Associations.Remove(AssToDelete);
        db.SaveChanges();
        Console.WriteLine("**************Deleted Successfully***********");
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
