using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;


namespace Learn.Controllers
{
    public class AuthendicationController : Controller
    {
        public IActionResult Sign()
        {
            return View();
        }

        public IActionResult Login() 
        {
            return View();
        
        }

        





    }
}
