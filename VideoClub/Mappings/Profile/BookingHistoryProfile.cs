using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoClub.Areas.Customers.Data;
using VideoClub.Core.Entities;

namespace VideoClub.Mappings.Profile
{
    public class BookingHistoryProfile : AutoMapper.Profile
    {
        public BookingHistoryProfile()
        {
            CreateMap<BookingsHistoryViewModel, BookingHistory>(MemberList.None).ReverseMap();
        }
    }
}