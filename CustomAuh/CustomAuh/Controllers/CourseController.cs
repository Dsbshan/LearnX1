using CustomAuh.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CustomAuh.Helpers;
using Dapper;
using System.Data;
using System.Security.Claims;
using Google.Apis.Admin.Directory.directory_v1.Data;
using CImplementation.Services;

namespace CustomAuh.Controllers
{
    [Authorize]
    public class CourseController : BaseController
    {
        private readonly DatabaseHelper _dbHelper;

        public CourseController(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }


        public async Task<IActionResult> Cindex()
        {
            var courses = await _dbHelper.QueryAsync<Course>("dbo.GetAllCourses");
            return View(courses);
        }

        [Authorize(Roles = "Instructor")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Instructor")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseViewModel model)
        {
            if (!ModelState.IsValid)
            {
               
                return BadRequest(ModelState);
            }

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Title", model.Title);
                parameters.Add("@Description", model.Description);
                parameters.Add("@Category", model.Category);
                parameters.Add("@DurationInHours", model.DurationInHours);
                parameters.Add("@CreatedBy", User.Identity.Name);
                parameters.Add("@CourseId", dbType: DbType.Int32, direction: ParameterDirection.Output);

                await _dbHelper.ExecuteAsync("[dbo].[CreateCourse]", parameters);

                var courseId = parameters.Get<int>("@CourseId");

                return RedirectToAction(nameof(Cindex));
            }
            catch (Exception ex)
            {
              
                ModelState.AddModelError("", "An error occurred while creating the course.");
                return BadRequest(ModelState);

            }
        }

        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> Edit(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@CourseId", id);

            var course = await _dbHelper.QuerySingleAsync<EditCourseViewModel>(
                "[dbo].[GetCourseById]", parameters);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost]
        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> Edit(int id, EditCourseViewModel model)
        {
            if (id != model.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CourseId", id);
                parameters.Add("@Title", model.Title);
                parameters.Add("@Description", model.Description);
                parameters.Add("@Category", model.Category);
                parameters.Add("@DurationInHours", model.DurationInHours);

                await _dbHelper.ExecuteAsync("[dbo].[UpdateCourse]", parameters);

                

                return RedirectToAction(nameof(Cindex));
            }
            return View(model);
        }


        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> Delete(int id)
        {
            // Retrieve course details for confirmation
            var parameters = new DynamicParameters();
            parameters.Add("@CourseId", id);

            var course = await _dbHelper.QuerySingleAsync<DeleteCourseViewModel>(
                "[dbo].[GetCourseById]", parameters);

            if (course == null)
            {
                return NotFound();
            }
            
            course.CreatedBy ??= "Unknown Author";
            
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CourseId", id);

                // Execute stored procedure to delete course
                await _dbHelper.ExecuteAsync("[dbo].[DeleteCourse]", parameters);

                return RedirectToAction(nameof(Cindex));
            }
            catch (Exception ex)
            {
                // Log error (you can use ILogger or any logging framework)
                ModelState.AddModelError("", "An error occurred while deleting the course.");
                return View("Delete");
            }
        }
    

        [Authorize(Roles = "User")] // Only users can enroll
        public async Task<IActionResult> Enroll(int id)
        {
            // Get course details
            var courseParameters = new DynamicParameters();
            courseParameters.Add("@CourseId", id);
            var course = await _dbHelper.QuerySingleAsync<Course>("[dbo].[GetCourseById]", courseParameters);

            if (course == null)
            {
                return NotFound();
            }

            // Check if user is already enrolled
            var enrollmentParameters = new DynamicParameters();
            enrollmentParameters.Add("@CourseId", id);
            enrollmentParameters.Add("@UserId", User.Identity.Name);

            var existingEnrollment = await _dbHelper.QuerySingleAsync<Enrollment>(
                "[dbo].[CheckEnrollment]", enrollmentParameters);

            var model = new EnrollmentViewModel
            {
                CourseId = course.CourseId,
                CourseTitle = course.Title,
                InstructorName = course.CreatedBy,
                IsEnrolled = existingEnrollment != null
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Enroll(int id, EnrollmentViewModel model)
        {
            if (id != model.CourseId)
            {
                return NotFound();
            }

            // Check if user is already enrolled
            var checkParameters = new DynamicParameters();
            checkParameters.Add("@CourseId", id);
            checkParameters.Add("@UserId", User.Identity.Name);

            var existingEnrollment = await _dbHelper.QuerySingleAsync<Enrollment>(
                "[dbo].[CheckEnrollment]", checkParameters);

            if (existingEnrollment != null)
            {
                ModelState.AddModelError("", "You are already enrolled in this course.");
                return View(model);
            }

            // Create new enrollment
            var enrollParameters = new DynamicParameters();
            enrollParameters.Add("@CourseId", id);
            enrollParameters.Add("@UserId", User.Identity.Name);
            enrollParameters.Add("@UserEmail", User.Identity.Name);
            enrollParameters.Add("@EnrollmentId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbHelper.ExecuteAsync("[dbo].[CreateEnrollment]", enrollParameters);

            return RedirectToAction(nameof(MyCourses));
        }

        [Authorize(Roles = "User")]
        public async Task<IActionResult> MyCourses()
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", User.Identity.Name);

            var enrolledCourses = await _dbHelper.QueryAsync<Course>(
                "[dbo].[GetUserEnrolledCourses]", parameters);

            return View(enrolledCourses);
        }

        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> CourseEnrollments(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@CourseId", id);

            var enrollments = await _dbHelper.QueryAsync<Enrollment>(
                "[dbo].[GetCourseEnrollments]", parameters);

            return View(enrollments);
        }




    }
}