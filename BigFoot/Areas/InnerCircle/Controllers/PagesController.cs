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

            ViewBag.PageData = pages;
            ViewBag.ContentTypeID = new SelectList(db.ContentTypes, "ContentTypeID", "ContentType");
            ViewBag.con = db.Contents.Where(c => c.PageID == id).OrderBy(c=>c.Position).ThenBy(c=>c.ContentID).Include(c => c.UserDatas);

            return View("Details");
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

        /// <summary>
        /// Methods of CONTENT start here
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateContent([Bind(Include = "ContentID,PageID,UploadedFile,Position")] Models.PageImages content)
        {
            if (ModelState.IsValid)
            {
                if (content.UploadedFile != null)
                {
                    string fn = content.UploadedFile.FileName.Substring(content.UploadedFile.FileName.LastIndexOf('\\') + 1);
                    fn = content.PageID + "_" + fn;
                    string SavePath = System.IO.Path.Combine(Server.MapPath("~/Pictures/"), fn);
                    content.UploadedFile.SaveAs(SavePath);

                    //System.Drawing.Bitmap upimg = new System.Drawing.Bitmap(content.UploadedFile.InputStream);
                    //System.Drawing.Bitmap svimg = MyExtensions.CropUnwantedBackground(upimg);
                    //svimg.Save(System.IO.Path.Combine(Server.MapPath("~/" + db.Config.FirstOrDefault().ImageSavePath), fn));

                    Content con = new Content
                    {
                        PageID = content.PageID,
                        ImagPath = fn,
                        Position = (byte)content.Position         
                    };

                    db.Contents.Add(con);
                    db.SaveChanges();
                    return RedirectToAction("Details", new { id = content.PageID });
                }
                else
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
           
            return RedirectToAction("Details", new { id = content.PageID });
        }

        public ActionResult ContentShift(int id)
        {
            //Shifting downwards and then ordering by the position
            var c = db.Contents.Find(id);
            c.Position++;
            db.Entry(c).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Details", new { id = c.PageID});
        }

        public ActionResult ContentDelete(int id)
        {
            var c = db.Contents.Find(id);
            int PageID = (int)c.PageID;
            //Honor this only if there is no text. This prevents accedental deletions
            if (!db.UserDatas.Any(u => u.ContentID == id))
            {
                db.Contents.Remove(c);
                db.SaveChanges();
            }
            return RedirectToAction("Details", new { id = PageID });

        }

        /// <summary>
        /// Methods of USERDATA are here
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUserData([Bind(Include = "UDID,ContentID,ContentTypeID,Udata")] UserData userData)
        {
            int PageID = (int) db.Contents.FirstOrDefault(c => c.ContentID == userData.ContentID).PageID;
            if (ModelState.IsValid)
            {
                db.UserDatas.Add(userData);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = PageID });
            }
                        
            return RedirectToAction("Details", new { id = PageID });
        }

        public ActionResult UserDataDelete(int id)
        {
            var c = db.UserDatas.Find(id);
            int PageID = (int)c.Content.PageID;
            db.UserDatas.Remove(c);
            db.SaveChanges();
            
            return RedirectToAction("Details", new { id = PageID });

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
