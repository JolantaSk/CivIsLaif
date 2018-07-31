using CIV.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CIV.DataAccess.EntityConfigurations
{
    public class GameEntityTypeConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder
                .HasMany(g => g.Players)
                .WithOne();
            builder.Ignore(g => g.PlayerUserNames);
            builder.Ignore(g => g.IsStarted);
            builder.HasOne(g => g.Creator)
                .WithMany()
                .IsRequired(true)
                .HasForeignKey(g => g.CreatorId);

            var navigation = builder.Metadata.FindNavigation(nameof(Game.Players));
            navigation.SetField("_players");
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            navigation = builder.Metadata.FindNavigation(nameof(Game.Pauses));
            navigation.SetField("_pauses");
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
