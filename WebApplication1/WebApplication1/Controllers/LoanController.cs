using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class LoanController : Controller
    {
        public IActionResult Loan()
        {
            return View();
        }
    }
}
