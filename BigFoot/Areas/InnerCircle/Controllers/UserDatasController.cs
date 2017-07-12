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
    public class UserDatasController : EAIController
    {
        private BigFootEntities db = new BigFootEntities();

        // GET: InnerCircle/UserDatas
        public ActionResult Index()
        {
            var userDatas = db.UserDatas.Include(u => u.Content).Include(u => u.ContentTypes);
            return View(userDatas.OrderBy(u=>u.Content.PageID).ThenBy(u=>u.ContentID).ToList());
        }

        // GET: InnerCircle/UserDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserData userData = db.UserDatas.Find(id);
            if (userData == null)
            {
                return HttpNotFound();
            }
            return View(userData);
        }

        // GET: InnerCircle/UserDatas/Create
        public ActionResult Create()
        {
            ViewBag.ContentID = new SelectList(db.Contents, "ContentID", "ImagPath");
            ViewBag.ContentTypeID = new SelectList(db.ContentTypes, "ContentTypeID", "ContentType");
            return View();
        }

        // POST: InnerCircle/UserDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UDID,ContentID,ContentTypeID,Udata")] UserData userData)
        {
            if (ModelState.IsValid)
            {
                db.UserDatas.Add(userData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContentID = new SelectList(db.Contents, "ContentID", "ImagPath", userData.ContentID);
            ViewBag.ContentTypeID = new SelectList(db.ContentTypes, "ContentTypeID", "ContentType", userData.ContentTypeID);
            return View(userData);
        }

        // GET: InnerCircle/UserDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserData userData = db.UserDatas.Find(id);
            if (userData == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContentID = new SelectList(db.Contents, "ContentID", "ImagPath", userData.ContentID);
            ViewBag.ContentTypeID = new SelectList(db.ContentTypes, "ContentTypeID", "ContentType", userData.ContentTypeID);
            return View(userData);
        }

        // POST: InnerCircle/UserDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UDID,ContentID,ContentTypeID,Udata")] UserData userData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContentID = new SelectList(db.Contents, "ContentID", "ImagPath", userData.ContentID);
            ViewBag.ContentTypeID = new SelectList(db.ContentTypes, "ContentTypeID", "ContentType", userData.ContentTypeID);
            return View(userData);
        }

        // GET: InnerCircle/UserDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserData userData = db.UserDatas.Find(id);
            if (userData == null)
            {
                return HttpNotFound();
            }
            return View(userData);
        }

        // POST: InnerCircle/UserDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserData userData = db.UserDatas.Find(id);
            db.UserDatas.Remove(userData);
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
