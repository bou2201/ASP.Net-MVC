using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Menswear_App.Models;
using Microsoft.EntityFrameworkCore;
using System.Web;
using System.IO;

namespace Menswear_App.Controllers;

public class AdminPageController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly menswear_dbContext _context;

    
    public AdminPageController(ILogger<HomeController> logger, menswear_dbContext context)
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
    
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("ProductName, ProductDescription, ProductBrand, ProductMaterial, ProductPrice, ProductImage, CategoryId")] Product product)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }
        catch (DbUpdateException)
        {
            ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists " +
                "see your system administrator.");
        }
        return View(product);
    }

    public IActionResult Edit(int id) {
        return View(_context.Products.Where(x => x.ProductId == id).FirstOrDefault());
    }

    [HttpPost]
    public IActionResult Edit(int id, Product product) {
        try {
            if(ModelState.IsValid){
                _context.Entry(product).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        } catch (DbUpdateException) {
            ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists " +
                "see your system administrator.");
        }
        return View(product);
    }

    public IActionResult Delete(int id) {
        return View(_context.Products.Where(x => x.ProductId == id).FirstOrDefault());
    }

    [HttpPost]
    // public IActionResult Delete(int id, FormCollection collection) {
    //     try {
    //         if(ModelState.IsValid){
    //             Product product = _context.Products.Where(x => x.ProductId == id).FirstOrDefault();
    //             _context.Products.Remove(product);
    //             _context.SaveChanges();
    //             return RedirectToAction("Index");
    //         }
    //     } catch (DbUpdateException) {
    //         ModelState.AddModelError("", "Unable to save changes. " +
    //             "Try again, and if the problem persists " +
    //             "see your system administrator.");
    //     }
    //     return View();
    // }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
