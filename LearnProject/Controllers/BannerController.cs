using LearnProject.Models.Context;
using LearnProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnProject.Controllers
{
    public class BannerController : Controller
    {
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            var values = context.Banners.ToList();                                                                          
            return View(values);
        }

        public ActionResult DeleteBanner(int id)
        {
            var value = context.Banners.Find(id);
            context.Banners.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateBanner(int id)
        {
            var value = context.Banners.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateBanner(Banner banner)
        {
            var value = context.Banners.Find(banner.BannerId);
            value.Title = banner.Title;
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult AddBanner()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBanner(Banner banner)
        {
            context.Banners.Add(banner);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }                                                               
}                     