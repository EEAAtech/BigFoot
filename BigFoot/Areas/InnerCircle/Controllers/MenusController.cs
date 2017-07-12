using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BigFoot;

namespace BigFoot.Areas.InnerCircle.Controllers
{
    public class MenusController : Controller
    {
        private BigFootEntities db = new BigFootEntities();

        // GET: InnerCircle/Menus
        public ActionResult Index()
        {
            return View(db.Menus.ToList());
        }

        // GET: InnerCircle/Menus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menus menus = db.Menus.Find(id);
            if (menus == null)
            {
                return HttpNotFound();
            }
            ViewBag.Menu = menus;
            ViewBag.SubMenus = db.SubMenus.Where(sm => sm.MenuID == id).Include(p => p.Pages).ToList();
            return View();
        }

        /// <summary>
        /// Autocomplete for the Page list dropdown
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        public ActionResult AutoCompletePages(string term)
        {
            var filteredItems = db.Pages.Where(c => c.Page.Contains(term)).Select(c => new { id = c.PageID, value = c.Page});

            return Json(filteredItems, JsonRequestBehavior.AllowGet);
        }


        // POST: InnerCircle/SubMenus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSubMenu([Bind(Include = "SubMenuID,SubMenu,MenuID,PageID")] SubMenus subMenus)
        {
            if (ModelState.IsValid)
            {
                if (subMenus.PageID != null)
                    subMenus.smUrl = SetUrl((int)subMenus.PageID, (int)subMenus.MenuID);
                db.SubMenus.Add(subMenus);
                db.SaveChanges();
                return RedirectToAction("Details", new { id=subMenus.MenuID });
            }
            
            return View("Index");
        }

        // GET: InnerCircle/SubMenus/Edit/5
        public ActionResult EditSubMenu(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubMenus subMenus = db.SubMenus.Find(id);
            if (subMenus == null)
            {
                return HttpNotFound();
            }
            ViewBag.MenuID = new SelectList(db.Menus, "MenuID", "Menu", subMenus.MenuID);
            return View(subMenus);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSubMenu([Bind(Include = "SubMenuID,SubMenu,PageID,MenuID")] SubMenus subMenus)
        {
            if (ModelState.IsValid)
            {
                if (subMenus.PageID != null)
                    subMenus.smUrl = SetUrl((int)subMenus.PageID, (int)subMenus.MenuID);

                db.Entry(subMenus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MenuID = new SelectList(db.Menus, "MenuID", "Menu", subMenus.MenuID);
            return View("Index");
        }

        // GET: InnerCircle/SubMenus/Delete/5
        public ActionResult DeleteSubMenu(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubMenus subMenus = db.SubMenus.Find(id);
            if (subMenus == null)
            {
                return HttpNotFound();
            }
            return PartialView("ConfDeleteSubMenu",subMenus);
        }

        // POST: InnerCircle/SubMenus/Delete/5                
        public ActionResult DeleteSM(int id)
        {
            SubMenus subMenus = db.SubMenus.Find(id);
            db.SubMenus.Remove(subMenus);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        private string SetUrl(int PageID, int MenuID = 0)
        {
            string ResultStr = (MenuID > 0) ? db.Menus.Find(MenuID).Menu : "";            
            ResultStr += $"/{db.Pages.Find(PageID).Page}";

            return ResultStr.Replace(' ', '-');
        }

        // GET: InnerCircle/Menus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InnerCircle/Menus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MenuID,Menu,PageID")] Menus menus)
        {
            if (ModelState.IsValid)
            {
                if (menus.PageID !=null)
                    menus.mUrl = SetUrl((int)menus.PageID,0);
                db.Menus.Add(menus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menus);
        }

        // GET: InnerCircle/Menus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menus menus = db.Menus.Find(id);
            if (menus == null)
            {
                return HttpNotFound();
            }

            

            return View(menus);
        }

        // POST: InnerCircle/Menus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MenuID,Menu,PageID")] Menus menus)
        {
            if (ModelState.IsValid)
            {
                if (menus.PageID != null)
                    menus.mUrl = SetUrl((int)menus.PageID,0);
                db.Entry(menus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menus);
        }

        // GET: InnerCircle/Menus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menus menus = db.Menus.Find(id);
            if (menus == null)
            {
                return HttpNotFound();
            }
            return View(menus);
        }

        // POST: InnerCircle/Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!db.SubMenus.Any(ms => ms.MenuID == id))
            {
                Menus menus = db.Menus.Find(id);
                db.Menus.Remove(menus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Delete", new { id = id }); 
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
