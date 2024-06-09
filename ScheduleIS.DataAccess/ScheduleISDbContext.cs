using Microsoft.EntityFrameworkCore;
using ScheduleIS.Core.Models;
using ScheduleIS.DataAccess.Configurations;
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
        public DbSet<TeacherEntity> Teachers { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TimepairEntity> Timepairs { get; set; }
        public DbSet<SubjectEntity> Subjects { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Group>()
        //        .HasMany(g => g.Schedules)
        //        .WithOne(s => s.Group)
        //        .HasForeignKey(s => s.GroupId);

        //    modelBuilder.Entity<Course>()
        //        .HasMany(c => c.Schedules)
        //        .WithOne(s => s.Course)
        //        .HasForeignKey(s => s.CourseId);


           
        //}
    }
}
