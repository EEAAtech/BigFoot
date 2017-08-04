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

        public ActionResult About(string id)
        {
            if (id?.Length > 0)
            {
                id = id.Replace('-', ' ');
                var pg = db.Pages.FirstOrDefault(p => p.Page.Contains(id));

                IEnumerable<BigFoot.Content> cont;
                if (pg != null)
                {
                    cont = db.Contents.Where(c => c.PageID == pg.PageID).OrderBy(c => c.Position);
                    ViewBag.Title = id.Replace('-', ' ');
                    return View(cont);
                }
            }
            return View("Index");

        }

        public ActionResult MainMenu()
        {
            var m = db.Menus.ToList();
            return PartialView(m);
        }

        public ActionResult Mirabai()
        {
            ViewBag.Message = "Record Created in 30 days.";

            IEnumerable<BigFoot.Content> cont;

            cont = db.Contents.Where(c => c.PageID == 1).OrderBy(c => c.Position);
                     
            return View("Mirabai", cont);


        }

        public ActionResult Legend()
        {
            ViewBag.Message = "Legend of the Big Foot.";

            IEnumerable<BigFoot.Content> cont;
            
            cont = db.Contents.Where(c => c.PageID == 1).OrderBy(c => c.Position);

            ViewBag.Images = System.IO.Directory.EnumerateFiles(Server.MapPath("/Pictures/Prayers"))
                             .Select(fn => "/Pictures/Prayers/" + System.IO.Path.GetFileName(fn));



            return View("Legend",cont);
            
            
        }

    }
}