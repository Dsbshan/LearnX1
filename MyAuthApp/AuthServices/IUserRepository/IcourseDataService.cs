using AuthIservices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public interface ICourseDataService

{
    int createCourse(CourseModel courseModel);

    int AddAttachment(Video video);


}