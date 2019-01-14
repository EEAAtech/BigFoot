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
    public class BlogAdminController : EAIController
    {
        

        // GET: InnerCircle/Blog Admin
        public ActionResult Index()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
