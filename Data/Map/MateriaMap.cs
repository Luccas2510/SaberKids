using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaberKids.Models;

namespace SaberKids.Data.Map
{
    public class MateriaMap : IEntityTypeConfiguration<MateriaModel>
    {
        public void Configure(EntityTypeBuilder<MateriaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(1000);
        }
    }
}
