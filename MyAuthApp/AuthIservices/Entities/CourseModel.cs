using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthIservices.Entities
{
    public class CourseModel
    {
        public int CourseId { get; set; }

        public string CourseTitle { get; set; }


        public string CourseDescription { get; set; }

        public int CourseDuration { get; set; }


        public List<Video>VideoList { get; set;}




    }
}
