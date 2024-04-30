using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnProject.Models.Entities
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public String NameSurname { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public List<Course> Courses { get; set; }
        public List<CourseVideo> CourseVideos { get; set;}


    }
}