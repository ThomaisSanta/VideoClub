using System.Web.Mvc;

namespace VideoClub.Areas.MovieRents
{
    public class MovieRentsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "MovieRents";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "MovieRents_default",
                "MovieRents/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}