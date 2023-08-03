using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoClub.Mappings.Profile;

namespace VideoClub.Mappings
{
    public class MapperInit
    {
        public static IMapper Init()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MovieRentProfile());
                cfg.AddProfile(new BookingHistoryProfile());
            });
            configuration.AssertConfigurationIsValid();
            return configuration.CreateMapper();
        }
    }
}