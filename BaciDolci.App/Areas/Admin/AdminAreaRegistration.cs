using System.Web.Mvc;
using System.Web.Routing;
using BaciDolci.App.Attributes;

namespace BaciDolci.App.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.Routes.MapMvcAttributeRoutes();

            //context.MapRoute(
              //  "Admin_default",
                //"Admin/{controller}/{action}/{id}",
                //new { action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}