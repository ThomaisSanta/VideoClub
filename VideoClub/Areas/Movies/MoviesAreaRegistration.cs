﻿using System.Web.Mvc;

namespace VideoClub.Areas.Movies
{
    public class MoviesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Movies";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Movies_default",
                "Movies/{controller}/{action}/{id}",
                new { controller = "Movies", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}