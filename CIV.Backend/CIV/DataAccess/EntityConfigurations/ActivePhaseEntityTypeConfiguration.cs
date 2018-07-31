using CIV.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CIV.DataAccess.EntityConfigurations
{
    public class ActivePhaseEntityTypeConfiguration : IEntityTypeConfiguration<ActivePhase>
    {
        public void Configure(EntityTypeBuilder<ActivePhase> builder)
        {
            builder.HasOne(m => m.Phase)
                .WithMany()
                .HasForeignKey(p => p.PhaseId);
            builder.HasMany(typeof(PlayerTurn), "_playerTurns")
                .WithOne();
        }
    }
}
