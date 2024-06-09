using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleIS.Core.Models;
using ScheduleIS.DataAccess.Entites;

namespace ScheduleIS.DataAccess.Configurations
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<ScheduleEntity>
    {
        public void Configure(EntityTypeBuilder<ScheduleEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Date)        
                .IsRequired();

            builder.HasOne(s => s.Group)
            .WithMany(g => g.Schedules)
            .HasForeignKey(s => s.GroupId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.Course)
                .WithMany(c => c.Schedules)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.Timepair)
                .WithMany(c => c.Schedules)
                .HasForeignKey(s => s.TimepairId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.Teacher)
                .WithMany(c => c.Schedules)
                .HasForeignKey(s => s.TeacherId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
