using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BigFoot;
using ImageResizer;

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

            cont = db.Contents.Where(c => c.PageID == 11).OrderBy(c => c.Position);
                     
            return View("Mirabai", cont);


        }

        public ActionResult Information()
        {
            ViewBag.Message = "All you need to know.";

            IEnumerable<BigFoot.Content> cont;

            cont = db.Contents.Where(c => c.PageID == 12).OrderBy(c => c.Position);

            return View("Information", cont);


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

        public ActionResult Gandhiji(int? id)
        {
            ViewBag.Message = "150 Years Of Gandhiji";


            ViewBag.user = db.UserComments.Where(d => d.IsShow == true).OrderBy(c => c.Id).ToList();
            return View("Gandhiji");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Gandhiji([Bind(Include = "Id,Name,PhoneNumber,Email,Comments,Path,UploadedFile")] UsercommentsImage usercomments)
        {
            if (ModelState.IsValid)
            {
                if (usercomments.UploadedFile != null)
                {
                    string fn = usercomments.UploadedFile.FileName.Substring(usercomments.UploadedFile.FileName.LastIndexOf('\\') + 1);
                    fn = usercomments.Id + "_" + fn;
                    string DestPath = System.IO.Path.Combine(Server.MapPath("~/Pictures/"), "Small-" + fn);
                    
                    ResizeSettings resizeSetting = new ResizeSettings
                    {                        
                        Width = 324,                        
                        Format = "jpg"
                    };
                    
                    UserComments img = new UserComments
                    {
                        Id = usercomments.Id,
                        Name = usercomments.Name,
                        PhoneNumber = usercomments.PhoneNumber,
                        Email = usercomments.Email,
                        Comment = usercomments.Comments.Substring(0,Math.Min(995,usercomments.Comments.Length)),
                        Path = "Small-" + fn,
                        Ip= Get_Ip()
                    };

                    ImageBuilder.Current.Build(usercomments.UploadedFile, DestPath, resizeSetting);

                    db.UserComments.Add(img);
                    db.SaveChanges();
                    return RedirectToAction("Gandhiji");
                }
                else
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            return RedirectToAction("Gandhiji");
        }


        public string Get_Ip()
        {
            string IP = String.Empty;

            System.Web.HttpContext current = System.Web.HttpContext.Current;

            string IPAddress = current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(IPAddress))
            {
                string[] valAddress = IPAddress.Split('.');
                if (valAddress.Length != 0)
                {
                    IP =valAddress[0].ToString();
                }
            }

            if (IP.Length<1)
                IP = current.Request.ServerVariables["REMOTE_ADDR"];

            return IP.Length > 49 ? IP.Substring(0, 49) : IP;

        }
    }
}