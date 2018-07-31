using CIV.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CIV.DataAccess.EntityConfigurations
{
    public class TurnEntityTypeConfiguration : IEntityTypeConfiguration<Turn>
    {
        public void Configure(EntityTypeBuilder<Turn> builder)
        {
            builder.Ignore(t => t.Finished);
        }
    }
}
