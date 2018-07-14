using CIV.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CIV.DataAccess
{
    public class CivDbContext: IdentityDbContext<Player>
    {
        public CivDbContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var gameModel  = modelBuilder.Entity<Game>();

            gameModel
                .HasMany(g => g.Players)
                .WithOne();
            gameModel.Ignore(g => g.PlayerUserNames);
            gameModel.HasOne(g => g.Creator)
                .WithMany()
                .IsRequired(true);

            var naivgation = gameModel.Metadata.FindNavigation(nameof(Game.Players));
            naivgation.SetField("_players");
            naivgation.SetPropertyAccessMode(PropertyAccessMode.Field);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
