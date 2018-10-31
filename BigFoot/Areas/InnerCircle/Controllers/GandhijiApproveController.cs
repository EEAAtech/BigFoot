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
    public class GandhijiApproveController : EAIController
    {
        private BigFootEntities db = new BigFootEntities();

        // GET: InnerCircle/GandhijiApprove
        public ActionResult Index()
        {
            return View(db.UserComments.ToList().OrderByDescending(c => c.Id));
        }


        [HttpPost]
        public bool ShowHide(int id, bool update)
        {
            var user = db.UserComments.Find(id);
            if (TryUpdateModel(user))
            {
                user.IsShow = update;
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}