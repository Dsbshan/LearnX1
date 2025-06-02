using System.ComponentModel.DataAnnotations;

namespace CustomAuh.Models
{
    public class CourseViewModel
    {

        [Required]
        public int CourseId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string Category { get; set; }

        [Range(1, 100)]
        public int DurationInHours { get; set; }

       
    }
}
