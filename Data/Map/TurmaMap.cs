using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaberKids.Models;

namespace SaberKids.Data.Map
{
    public class TurmaMap : IEntityTypeConfiguration<TurmaModel>
    {
        public void Configure(EntityTypeBuilder<TurmaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.AnoEscolar).IsRequired().HasMaxLength(255);
        }
    }
}
