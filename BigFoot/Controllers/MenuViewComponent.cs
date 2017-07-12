using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Mvc;


namespace BigFoot.Controllers
{
    public class MenuViewComponent : ViewComponent
    {
        private BigFootEntities db = new BigFootEntities();
        public IViewComponentResult Invoke(int TopUserCount)
        {
            

            return View("MenuView");
        }
        
    }
}