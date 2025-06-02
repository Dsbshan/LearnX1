// HomeController.cs
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    

   

    public IActionResult Index1() {

        return View();
    }



    public IActionResult Index()
    {
        if (string.IsNullOrEmpty(HttpContext.Session.GetString("Email")))
        {
            return RedirectToAction("Login", "Account");
        }

        ViewBag.Email = HttpContext.Session.GetString("Email");
        return View();
    }
}