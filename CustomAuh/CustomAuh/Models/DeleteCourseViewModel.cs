using System;
using System.ComponentModel.DataAnnotations;

namespace CustomAuh.Models
{
    public class DeleteCourseViewModel
    {
        public int CourseId { get; set; }

        [Display(Name = "Course Title")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Category")]
        public string Category { get; set; }

        [Display(Name = "Duration (hours)")]
        public int DurationInHours { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Creation Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime CreatedDate { get; set; }

      
        
        
        

        // Internal property for file size (bytes)
        

        // Additional metadata that might be useful
        [Display(Name = "Last Modified")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? LastModifiedDate { get; set; }

        
    }
}