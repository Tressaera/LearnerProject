using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnProject.Models.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int? TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Category Category { get; set; } //İlişki
        public List<Review> Reviews { get; set; }
        public List<CourseRegister> CourseRegisters { get; set; }
        public List<CourseVideo> CourseVideos { get; set; }
    }
}