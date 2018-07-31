using CIV.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CIV.DataAccess.EntityConfigurations
{
    public class PlayerTurnOrderEntityTypeConfiguration : IEntityTypeConfiguration<PlayerTurnOrder>
    {
        public void Configure(EntityTypeBuilder<PlayerTurnOrder> builder)
        {
            builder.HasKey("_id");
        }
    }
}
