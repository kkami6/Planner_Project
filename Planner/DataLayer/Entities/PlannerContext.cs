using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class PlannerContext: DbContext
    {
        public PlannerContext(DbContextOptions<PlannerContext> options) : base(options) { }

        public DbSet<ActivityEntity> Activities { get; set; }
        public DbSet<AppointmentActivityEntity> AppointmentActivities { get; set; }
        public DbSet<BirthdayActivityEntity> BirthdayActivities { get; set; }
        public DbSet<TaskActivityEntity> TaskActivities { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserActivityEntity> UserActivities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(PlannerContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}
