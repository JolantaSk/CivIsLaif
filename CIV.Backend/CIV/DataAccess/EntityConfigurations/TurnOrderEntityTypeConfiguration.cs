using CIV.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CIV.DataAccess.EntityConfigurations
{
    public class TurnOrderEntityTypeConfiguration : IEntityTypeConfiguration<TurnOrder>
    {
        public void Configure(EntityTypeBuilder<TurnOrder> builder)
        {
            builder.HasMany(typeof(PlayerTurnOrder), "_turnOrders")
                .WithOne();

            builder.Ignore(o => o.First);
            builder.Ignore(o => o.Players);
        }
    }
}
