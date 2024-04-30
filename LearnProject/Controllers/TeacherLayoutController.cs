using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnProject.Controllers
{
    public class TeacherLayoutController : Controller
    {
        // GET: TeacherLayout
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult TeacherLayoutHead()
        {
            return PartialView();
        }

        public PartialViewResult TeacherLayoutSidebar()
        {
            return PartialView();
        }
    }
}