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
    public class SubMenusController : Controller
    {
        private BigFootEntities db = new BigFootEntities();

        // GET: InnerCircle/SubMenus
        public ActionResult Index()
        {
            var subMenus = db.SubMenus.Include(s => s.Menus);
            return View(subMenus.ToList());
        }

        // GET: InnerCircle/SubMenus/Details/5
        public ActionResult Details(int? id)
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
            return View(subMenus);
        }

        // GET: InnerCircle/SubMenus/Create
        public ActionResult Create()
        {
            ViewBag.MenuID = new SelectList(db.Menus, "MenuID", "Menu");
            return View();
        }

        // POST: InnerCircle/SubMenus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubMenuID,SubMenu,smUrl,MenuID")] SubMenus subMenus)
        {
            if (ModelState.IsValid)
            {
                db.SubMenus.Add(subMenus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MenuID = new SelectList(db.Menus, "MenuID", "Menu", subMenus.MenuID);
            return View(subMenus);
        }

        // GET: InnerCircle/SubMenus/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: InnerCircle/SubMenus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubMenuID,SubMenu,smUrl,MenuID")] SubMenus subMenus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subMenus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MenuID = new SelectList(db.Menus, "MenuID", "Menu", subMenus.MenuID);
            return View(subMenus);
        }

        // GET: InnerCircle/SubMenus/Delete/5
        public ActionResult Delete(int? id)
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
            return View(subMenus);
        }

        // POST: InnerCircle/SubMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubMenus subMenus = db.SubMenus.Find(id);
            db.SubMenus.Remove(subMenus);
            db.SaveChanges();
            return RedirectToAction("Index");
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
