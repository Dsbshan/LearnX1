namespace CustomAuh.Models
{


    public class EnrollmentViewModel
    {
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }

        public string UserEmail { get; set; }
        public string InstructorName { get; set; }
        public bool IsEnrolled { get; set; }
    }

}