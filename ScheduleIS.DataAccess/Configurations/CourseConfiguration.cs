using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleIS.DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleIS.DataAccess.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<CourseEntity>
    {
        public void Configure(EntityTypeBuilder<CourseEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Name)
                .IsRequired();
            
            builder.Property(b => b.Description)
                .IsRequired();

            builder.Property(b => b.Duration)
                .IsRequired();

            builder.Property(b => b.Status)
                .IsRequired();

            builder.HasMany(c => c.Schedules).WithOne(s => s.Course).HasForeignKey(s => s.Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
