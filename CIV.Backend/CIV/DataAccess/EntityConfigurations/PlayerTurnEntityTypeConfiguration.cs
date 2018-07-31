using CIV.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CIV.DataAccess.EntityConfigurations
{
    public class PlayerTurnEntityTypeConfiguration : IEntityTypeConfiguration<PlayerTurn>
    {
        public void Configure(EntityTypeBuilder<PlayerTurn> builder)
        {
            builder.HasOne(t => t.Player)
                .WithMany()
                .HasForeignKey(t => t.PlayerId);
        }
    }
}
