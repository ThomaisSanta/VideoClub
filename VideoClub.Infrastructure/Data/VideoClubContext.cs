using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Core.Entities;

namespace VideoClub.Infrastructure.Data
{
    public class VideoClubContext : IdentityDbContext<ApplicationUser>
    {
        //Enable-Migrations -ContextTypeName VideoClub.Data.VideoClubContext -MigrationsDirectory Data\Migrations
        //Add-Migration -ConfigurationTypeName VideoClub.Data.Migrations.Configuration Initial
        //Update-Database -ConfigurationTypeName VideoClub.Data.Migrations.Configuration -Verbose
        public VideoClubContext() : base("VideoClubContext") { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Copy> Copy { get; set; }
        public DbSet<MovieRent> MovieRent { get; set; }
        public DbSet<BookingHistory> BookingsHistory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public static VideoClubContext Create()
        {
            return new VideoClubContext();

        }
    }
}
