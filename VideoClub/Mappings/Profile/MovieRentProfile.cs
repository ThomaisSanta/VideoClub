using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoClub.Areas.MovieRents.Data;
using VideoClub.Core.Entities;

namespace VideoClub.Mappings.Profile
{
    public class MovieRentProfile : AutoMapper.Profile
    {
        public MovieRentProfile()
        {
            CreateMap<MovieRentViewModel, MovieRent>(MemberList.None).ReverseMap();
        }
    }
}