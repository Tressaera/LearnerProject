using LearnProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnProject.Models.Class
{
    public class IEClass
    {
        public IEnumerable<Course> CourseIE { get; set; }
        public IEnumerable<Category> CategoryIE { get; set; }
       

    }
}