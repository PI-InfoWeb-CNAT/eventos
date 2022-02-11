using System.Web.Mvc;

namespace W_Dev.Areas.Checkin
{
    public class CheckinAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Checkin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Checkin_default",
                "Checkin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}