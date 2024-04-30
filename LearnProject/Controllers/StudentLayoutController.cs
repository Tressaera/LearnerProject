using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnProject.Controllers
{
    public class StudentLayoutController : Controller
    {
        // GET: StudentLayout
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult StudentLayoutHead()
        {
            return PartialView();
        }

        public PartialViewResult StudentLayoutSidebar()
        {
            return PartialView();
        }
    }
}