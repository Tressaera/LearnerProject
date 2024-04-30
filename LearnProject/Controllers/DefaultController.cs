using LearnProject.Models.Context;
using LearnProject.Models.Entities;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace LearnProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult DefaultBannerPartial()
        {
            ViewBag.LatestCourse = context.Courses.OrderByDescending(x => x.CourseId).Select(x => x.CourseId).FirstOrDefault();
            var values = context.Banners.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultCategoryPartial()
        {

         

           
                ViewBag.courseCount = context.CourseVideos.Where(x => x.Course.CourseId == 1).Count();

  

            var values = context.Categories.Where(x => x.Status == true).ToList();
              
            return PartialView(values);
        }
        public PartialViewResult DefaultClassroomPartial()
        {
            var values = context.Classrooms.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultCoursePartial()
        {
            var values = context.Courses.Include(x => x.Reviews).OrderByDescending(x => x.CourseId).Take(3).ToList();
            return PartialView(values);
        }


        public ActionResult CourseDetail(int id )
        {
            var value = context.Courses.Find(id);
            var reviewList = context.Reviews.Where(x=>x.CourseId==id).ToList();
            ViewBag.review = reviewList;
            return View(value);
        }
        public PartialViewResult DefaultAboutPartial()
        {
            var values = context.Abouts.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultTestimonialPartial()
        {
            var values = context.Testimonials.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultFAQPartial()
        {
            var values = context.FAQs.ToList();
            return PartialView(values);
        }


    }
}