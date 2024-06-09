using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleIS.DataAccess.Entites;

namespace ScheduleIS.DataAccess.Configurations
{
    public class TeacherConfiguration: IEntityTypeConfiguration<TeacherEntity>
    {
        public void Configure(EntityTypeBuilder<TeacherEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Name)
                .IsRequired();

            builder.Property(b => b.Phone)
                .IsRequired();

            builder.Property(b => b.Email)
                .IsRequired();

            builder.HasMany(c => c.Schedules).WithOne(s => s.Teacher).HasForeignKey(s => s.Id).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
