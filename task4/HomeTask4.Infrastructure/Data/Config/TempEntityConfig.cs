using HomeTask4.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeTask4.Infrastructure.Data.Config
{
    public class TempEntityConfig : IEntityTypeConfiguration<TempEntity>
    {
        public void Configure(EntityTypeBuilder<TempEntity> builder)
        {
            builder
                .HasKey(x => x.Id);
        }
    }
}
