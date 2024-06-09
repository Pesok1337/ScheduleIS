using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleIS.DataAccess.Entites;

namespace ScheduleIS.DataAccess.Configurations
{
    public class TimepairConfiguration: IEntityTypeConfiguration<TimepairEntity>
    {
        public void Configure(EntityTypeBuilder<TimepairEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.StartPair)
                .IsRequired();

            builder.Property(b => b.EndPair)
                .IsRequired();

            builder.HasMany(g => g.Schedules)
            .WithOne(s => s.Timepair)
            .HasForeignKey(s => s.Id).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
