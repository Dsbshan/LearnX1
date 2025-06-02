namespace CustomAuh.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int CourseId { get; set; }
        public string UserId { get; set; } // This will store the user's email
        public DateTime EnrolledDate { get; set; } = DateTime.Now;
        public Course Course { get; set; }

        public string UserEmail { get; set; }
    }
}
