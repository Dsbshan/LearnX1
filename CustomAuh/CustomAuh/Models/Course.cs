namespace CustomAuh.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } // This will store the user's email

        // You can add more properties as needed:
        public string Category { get; set; }
        public int DurationInHours { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
