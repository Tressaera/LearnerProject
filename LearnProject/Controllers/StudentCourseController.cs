using LearnProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace LearnProject.Controllers
{
    public class StudentCourseController : Controller
    {
        LearnerContext context = new LearnerContext();
        public ActionResult Index(int pageNumber = 1)
        {
            string studentName = Session["student"].ToString();
            var student = context.Students.Where(x => x.UserName == studentName).Select(x => x.StudentId).FirstOrDefault();
            var values = context.CourseRegisters.Where(x => x.StudentId == student).ToList();
            return View(values);
        }

        public ActionResult MyCourseList(int id, int pageNumber = 1)
        {
            var values = context.CourseVideos.Where(x => x.CourseId == id).ToList().ToPagedList(pageNumber, 2);
            return View(values);
        }
    }
}