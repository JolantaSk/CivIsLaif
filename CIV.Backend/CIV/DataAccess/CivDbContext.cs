using CIV.DataAccess.EntityConfigurations;
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

            modelBuilder.ApplyConfiguration(new GameEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ActivePhaseEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PhaseEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerTurnOrderEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TurnOrderEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TurnEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerTurnEntityTypeConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
