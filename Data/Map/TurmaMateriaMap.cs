using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaberKids.Models;

namespace SaberKids.Data.Map
{
    public class TurmaMateriaMap : IEntityTypeConfiguration<TurmaMateriaModel>
    {
        public void Configure(EntityTypeBuilder<TurmaMateriaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TurmaId).IsRequired();
            builder.Property(x => x.MateriaId).IsRequired();
        }
    }
}
