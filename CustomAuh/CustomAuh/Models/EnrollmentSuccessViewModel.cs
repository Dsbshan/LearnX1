namespace CustomAuh.Models
{
    public class EnrollmentSuccessViewModel
    {
        public int EnrollmentId { get; set; }
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string CourseDescription { get; set; }
        public DateTime EnrolledDate { get; set; }
    }
}