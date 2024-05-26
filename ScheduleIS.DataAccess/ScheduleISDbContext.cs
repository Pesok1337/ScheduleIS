using Microsoft.EntityFrameworkCore;
using ScheduleIS.DataAccess.Entites;

namespace ScheduleIS.DataAccess
{
    public class ScheduleISDbContext : DbContext
    {
        public ScheduleISDbContext(DbContextOptions<ScheduleISDbContext> options) : base(options) 
        {

        }
        public DbSet<ScheduleEntity> Schedules { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<GroupEntity> Groups { get; set; }
        public DbSet<StudentEntity> Students { get; set; }

        //protected override void onmodelcreating(modelbuilder modelbuilder)
        //{
        //    modelbuilder.applyconfiguration(new scheduleconfiguration());
        //}
    }
}
