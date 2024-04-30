using LearnProject.Models.Context;
using LearnProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnProject.Controllers
{
    public class ReviewController : Controller
    {
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            var values = context.Reviews.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddReview()
        {

            var reviews = context.Courses.ToList();


            List<SelectListItem> courseList = (from y in reviews
                                                 select new SelectListItem
                                                 {
                                                     Text = y.CourseName,
                                                     Value = y.CourseId.ToString()
                                                 }).ToList();

            ViewBag.course = courseList;


            var students = context.Students.ToList();


            List<SelectListItem> studentList = (from x in students
                                               select new SelectListItem
                                               {
                                                   Text = x.UserName,
                                                   Value = x.StudentId.ToString()
                                               }).ToList();

            ViewBag.student = studentList;
            return View();

        }

        [HttpPost]
        public ActionResult AddReview(Review review)
        {
            context.Reviews.Add(review);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult DeleteReview(int id)
        {
            var value = context.Reviews.Find(id);
            context.Reviews.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateReview(int id)
        {
            var reviews = context.Courses.ToList();


            List<SelectListItem> courseList = (from y in reviews
                                               select new SelectListItem
                                               {
                                                   Text = y.CourseName,
                                                   Value = y.CourseId.ToString()
                                               }).ToList();

            ViewBag.course = courseList;


            var students = context.Students.ToList();


            List<SelectListItem> studentList = (from x in students
                                                select new SelectListItem
                                                {
                                                    Text = x.UserName,
                                                    Value = x.StudentId.ToString()
                                                }).ToList();

            ViewBag.student = studentList;



            var value = context.Reviews.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateReview(Review review)
        {
            var value = context.Reviews.Find(review.ReviewId);
            
            
            value.CourseId = review.CourseId;
            value.ReviewValue = review.ReviewValue;
            value.Comment = review.Comment;
            value.StudentId = review.StudentId;
            


            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}