using System.Web.Mvc;

namespace VideoClub.Areas.BookingHistory
{
    public class BookingHistoryAreaRegistration : AreaRegistration 
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
                "BookingHistory_default",
                "BookingHistory/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}