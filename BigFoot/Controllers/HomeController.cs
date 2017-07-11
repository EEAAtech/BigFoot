using System;
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

        public ActionResult About()
        {
            var cont = db.Contents.Where(c => c.PageID == 1).OrderBy(c => c.Position);            

            return View(cont);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}