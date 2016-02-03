using System.Web.Mvc;

namespace InformationalApplication.Areas.Shop
{
    public class ShopAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Shop";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            // My custom route
            context.MapRoute(
                name: "Shop_default",
                url: "Shop/{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Shop",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
        }
    }
}