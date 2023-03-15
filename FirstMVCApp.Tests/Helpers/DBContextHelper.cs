using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMVCApp.Tests.Helpers
{
    public class DBContextHelper
    {
        public static ProgrammingClubDataContext GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<ProgrammingClubDataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;
            var databaseContext = new ProgrammingClubDataContext(options);
            databaseContext.Database.EnsureCreated();
            return databaseContext;
        }

        public static AnnouncementModel AddAnnouncement(ProgrammingClubDataContext context, AnnouncementModel announcement)
        {
            context.Add(announcement);
            context.SaveChangesAsync();
            context.Entry(announcement).State = EntityState.Detached;
            return announcement;
        }
    }
}
