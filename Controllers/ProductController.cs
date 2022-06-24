using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Menswear_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Menswear_App.Controllers;

public class ProductController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly menswear_dbContext _context;


    public ProductController(ILogger<HomeController> logger, menswear_dbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        ViewData["Product"] = _context.Products.OrderBy(i => i.ProductId).ToList();
        return View();
    }

    public IActionResult Details(int id)
    {
        ViewData["Product"] = _context.Products.Single(i => i.ProductId == id);
        if (ViewData["Product"] == null)
        {
            TempData["msg"] = "Can't find Item with id = " + id; 
        }
        return View();
    }

    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
