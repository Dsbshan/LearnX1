using Microsoft.AspNetCore.Mvc;

namespace Learn.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Addcourse()
        {
            return View();
        }

        public IActionResult ViewCourse()
        {

            return View();
         
        }
    }
}
