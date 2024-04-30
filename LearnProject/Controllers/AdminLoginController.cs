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
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        LearnerContext context = new LearnerContext();
        [HttpGet]
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Index(AdminLogin adminLogin)
        {
            var value = context.AdminLogins.FirstOrDefault(x=>x.UserName == adminLogin.UserName && x.Password == adminLogin.Password);
            if (value != null)
            {
                FormsAuthentication.SetAuthCookie(value.UserName,false);
                Session["userName"] = value.UserName;
                return RedirectToAction("Index", "AdminDashboard");
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı!");
                return View();
            }
          
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Default");
        }

    

    }
}