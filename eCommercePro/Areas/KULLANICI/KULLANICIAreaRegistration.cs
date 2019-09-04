using System.Web.Mvc;

namespace eCommercePro.Areas.KULLANICI
{
    public class KULLANICIAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "KULLANICI";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "KULLANICI_default",
                "KULLANICI/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}