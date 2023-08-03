using System.Web.Mvc;

namespace VideoClub.Areas.BookingsHistory
{
    public class BookingsHistoryAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BookingHistory";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BookingsHistory_default",
                "BookingsHistory/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}