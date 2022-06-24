using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Menswear_App.Models;
using System.Web;

namespace Menswear_App.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<HomeController> _logger;
    // menswear_dbContext _DbContext = new menswear_dbContext();
    // private readonly ISession session;
    private readonly menswear_dbContext _DbContext;
    public AccountController(ILogger<HomeController> logger, menswear_dbContext DbContext)
    {
        _logger = logger;
        _DbContext = DbContext;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    // [ValidateAntiForgeryToken]
    public IActionResult Login(string email, string password)
    {
        // if (ModelState.IsValid)
        // {
                Console.WriteLine("awfawf");
            // var md5_password = GetMD5(password);
            var data = _DbContext.Users.Where(x => x.UserEmail.Equals(email) &&
                                                x.UserPassword.Equals(password)).ToList();
            if (data != null && data.Count() > 0)
            {
                // Session["Name"] = data.FirstOrDefault().UserUsername;
                //     Session["Email"] = data.FirstOrDefault().UserEmail;
                //     Session["UserId"] = data.FirstOrDefault().UserId;
                // ViewBag.session["Name"] = data.FirstOrDefault().UserUsername;
                HttpContext.Session.SetString("Email", data.FirstOrDefault().UserEmail);
                HttpContext.Session.SetInt32("UserID", data.FirstOrDefault().UserId);
                HttpContext.Session.SetString("Name", data.FirstOrDefault().UserUsername);
                return RedirectToAction("Index", "AdminPage");
            }
            else
            {
                ViewBag.Error = "Login Failed";
                return RedirectToAction("Register");
            }
        // }
        // return View();
    }


    public IActionResult Register()
    {
        return View();
    }

    // [HttpPost]
    // [ValidateAntiForgeryToken]
    // public ActionResult Register(User user)
    // {
    //     var check = _DbContext.Users.FirstOrDefault(s => s.UserEmail == user.UserEmail);
    //     if (check == null)
    //     {
    //         user.UserPassword = GetMD5(user.UserPassword);
    //         _DbContext.confi
    //     }
    // }

    // public static string GetMD5(string str)
    // {
    //     MD5 md5 = new MD5CryptoServiceProvider();
    //     byte[] fromData = Encoding.UTF8.GetBytes(str);
    //     byte[] targetData = md5.ComputeHash(fromData);
    //     string byte2String = null;

    //     for (int i = 0; i < targetData.Length; i++)
    //     {
    //         byte2String += targetData[i].ToString("x2");

    //     }
    //     return byte2String;
    // }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


}
