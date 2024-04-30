using LearnProject.Models.Context;
using LearnProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnProject.Controllers
{
    public class FAQController : Controller
    {
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            var values = context.FAQs.Where(x => x.Status == true).ToList();
            return View(values);
        }

        public ActionResult DeleteFAQ(int id)
        {
            var value = context.FAQs.Find(id);
            value.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateFAQ(int id)
        {
            var value = context.FAQs.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateFAQ(FAQ fAQ)
        {
            var value = context.FAQs.Find(fAQ.FAQId);
            value.Question = fAQ.Question;
            value.Answer = fAQ.Answer;
            value.ImageUrl = fAQ.ImageUrl;
            value.Status = true;

            context.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult AddFAQ()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddFAQ(FAQ fAQ)
        {
            fAQ.Status = true;
            context.FAQs.Add(fAQ);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}