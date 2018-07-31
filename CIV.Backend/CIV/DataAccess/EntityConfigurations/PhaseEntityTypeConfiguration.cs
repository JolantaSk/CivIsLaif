using CIV.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace CIV.DataAccess.EntityConfigurations
{
    public class PhaseEntityTypeConfiguration : IEntityTypeConfiguration<Phase>
    {
        public void Configure(EntityTypeBuilder<Phase> builder)
        {
            builder.HasOne(p => p.NextPhase)
                .WithOne()
                .HasForeignKey<Phase>(p => p.NextPhaseId)
                .IsRequired(false);

            //var phases = new[]
            //{
            //    "Start of the turn",
            //    "Trade",
            //    "City management",
            //    "Movement",
            //    "Research"
            //};
            //builder.HasData(Phase.Create(phases).All());
        }
    }
}
