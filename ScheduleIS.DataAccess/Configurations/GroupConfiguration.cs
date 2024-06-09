using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleIS.DataAccess.Entites;

namespace ScheduleIS.DataAccess.Configurations
{
    public class GroupConfiguration: IEntityTypeConfiguration<GroupEntity>
    {
        public void Configure(EntityTypeBuilder<GroupEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Name)
                .IsRequired();

            builder.HasMany(g => g.Schedules)
            .WithOne(s => s.Group)
            .HasForeignKey(s => s.Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
