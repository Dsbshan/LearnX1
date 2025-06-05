using AuthIservices.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MyAuthApp.Controllers
{
    public class CourseController : BaseController
    {
        private ICourseDataService _courseDataService;

        public CourseController(ICourseDataService courseDataService) {

            _courseDataService = courseDataService;
        }
       
        public IActionResult CreateCourse()
        {
            return View();
        }

        public Response CreateCouse(CourseModel course) {
            try
            {
                var Course = _courseDataService.createCourse(course);
                return ReturnSuccess(Course, true, "001");

            }
            catch (Exception ex) {

                return ReturnError(ex, "002", ModelState);               
            }
            
        
        
        
        
        
        
        }



    }

}
