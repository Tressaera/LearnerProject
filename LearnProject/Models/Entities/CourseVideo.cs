using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnProject.Models.Entities
{
    public class CourseVideo
    {
        public int CourseVideoId { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public int VideNumber { get; set; }
        public String VideoUrl { get; set; }

        public int? TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}