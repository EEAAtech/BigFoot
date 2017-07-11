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
    public class PagesController : EAIController
    {
        private BigFootEntities db = new BigFootEntities();

        // GET: InnerCircle/Pages
        public ActionResult Index()
        {
            return View(db.Pages.ToList());
        }

        // GET: InnerCircle/Pages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pages pages = db.Pages.Find(id);
            if (pages == null)
            {
                return HttpNotFound();
            }
            return View(pages);
        }

        // GET: InnerCircle/Pages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InnerCircle/Pages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PageID,Page")] Pages pages)
        {
            if (ModelState.IsValid)
            {
                db.Pages.Add(pages);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pages);
        }

        // GET: InnerCircle/Pages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pages pages = db.Pages.Find(id);
            if (pages == null)
            {
                return HttpNotFound();
            }
            return View(pages);
        }

        // POST: InnerCircle/Pages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PageID,Page")] Pages pages)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pages).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pages);
        }

        // GET: InnerCircle/Pages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pages pages = db.Pages.Find(id);
            if (pages == null)
            {
                return HttpNotFound();
            }
            return View(pages);
        }

        // POST: InnerCircle/Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pages pages = db.Pages.Find(id);
            db.Pages.Remove(pages);
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
