using Autofac;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac.Extensions.DependencyInjection;
using Autofac.Integration.Mvc;
using AutoMapper;
using VideoClub.Common.Services;
using VideoClub.Core.Interfaces;
using VideoClub.Infrastructure.Data;
using VideoClub.Mappings;

namespace VideoClub.App_Start
{
    public class DependencyConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            //IMapper
            //builder.Register(c => MapperInit.Init()).AsSelf().SingleInstance();
            //builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve)).As<IMapper>().InstancePerLifetimeScope();

            //DbContext
            builder.RegisterType<VideoClubContext>().As<VideoClubContext>().InstancePerRequest();

            //Services
            builder.RegisterType<MovieService>().As<IMovieService>().InstancePerRequest();
            builder.RegisterType<CopyService>().As<ICopyService>().InstancePerRequest();
            builder.RegisterType<MovieRentService>().As<IMovieRentService>().InstancePerRequest();
            builder.RegisterType<BookingHistoryService>().As<IBookingHistoryService>().InstancePerRequest();
            builder.RegisterType<PaginationService>().As<IPaginationService>().InstancePerRequest();

            //Controllers         
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}