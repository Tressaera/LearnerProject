using LearnProject.Models.Context;
using LearnProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LearnProject.Controllers
{
    public class StudentController : Controller
    {
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            var values = context.Students.ToList();
            return View(values);
        }

        public ActionResult DeleteStudent(int id)
        {
            var value = context.Students.Find(id);
            context.Students.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateStudent(int id)
        {
            var value = context.Students.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateStudent(Student student)
        {
            var value = context.Students.Find(student.StudentId);
            value.NameSurname = student.NameSurname;
            value.UserName = student.UserName;
            value.Password = student.Password;
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult StudentLogin()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult StudentLogin(Student student)
        {
            var value = context.Students.FirstOrDefault(x => x.UserName == student.UserName && x.Password == student.Password);
            if (value != null)
            {

 
                FormsAuthentication.SetAuthCookie(value.UserName, false);
                Session["student"] = value.UserName;


                return RedirectToAction("Index", "StudentDashboard");
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı!");
                return View();
            }
        }
        [AllowAnonymous]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Default");
        }



        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
            return RedirectToAction("StudentLogin", "Student");
        }
    }
}