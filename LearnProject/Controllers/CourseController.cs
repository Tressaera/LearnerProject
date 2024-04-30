using LearnProject.Models.Class;
using LearnProject.Models.Context;
using LearnProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnProject.Controllers
{
    public class CourseController : Controller
    {
        LearnerContext context = new LearnerContext();
        IEClass ie = new IEClass();

        public ActionResult Index()
        {
            ie.CourseIE = context.Courses.ToList();
            ie.CategoryIE = context.Categories.ToList();
            return View(ie);
        }
        [HttpGet]
        public ActionResult AddCourse()
        {

            var categories = context.Categories.Where(x=>x.Status==true).ToList();


            List<SelectListItem> categoryList = (from x in categories
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();

            ViewBag.category = categoryList;
            return View();

        }

        [HttpPost]
        public ActionResult AddCourse(Course course)
        {

            context.Courses.Add(course);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCourse(int id)
        {
            var value = context.Courses.Find(id);
            context.Courses.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult UpdateCourse(int id)
        {
            var categories = context.Categories.Where(x => x.Status == true).ToList();


            List<SelectListItem> categoryList = (from x in categories
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();

            ViewBag.category = categoryList;
            var value = context.Courses.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCourse(Course course)
        {
            var value = context.Courses.Find(course.CourseId);
            value.CourseName = course.CourseName;
            value.ImageUrl = course.ImageUrl;
            value.Description = course.Description;
            value.Price = course.Price;
            value.CategoryId = course.CategoryId;


            context.SaveChanges();
            return RedirectToAction("Index");

        }

    }


}