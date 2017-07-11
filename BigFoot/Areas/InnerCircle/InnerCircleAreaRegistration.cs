using System.Web.Mvc;

namespace BigFoot.Areas.InnerCircle
{
    public class InnerCircleAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "InnerCircle";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "InnerCircle_default",
                "InnerCircle/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}