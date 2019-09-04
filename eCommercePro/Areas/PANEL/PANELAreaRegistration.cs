using System.Web.Mvc;

namespace eCommercePro.Areas.PANEL
{
    public class PANELAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PANEL";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PANEL_default",
                "PANEL/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}