using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaberKids.Models;

namespace SaberKids.Data.Map
{
    public class PagamentoMap : IEntityTypeConfiguration<PagamentoModel>
    {
        public void Configure(EntityTypeBuilder<PagamentoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Anual).IsRequired();
            builder.Property(x => x.Mensal).IsRequired();
        }
    }
}
