﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigFoot.Controllers
{
    public class HomeController : Controller
    {
        private BigFootEntities db = new BigFootEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About(string id)
        {
            var pg = db.Pages.FirstOrDefault(p => p.Page == id);

            IEnumerable<BigFoot.Content> cont;
            if (pg != null)
            {
                cont = db.Contents.Where(c => c.PageID == pg.PageID).OrderBy(c => c.Position);
                ViewBag.Title = id.Replace('-', ' ');
                return View(cont);
            }
            return RedirectToAction("Index");

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}