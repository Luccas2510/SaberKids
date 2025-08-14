using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaberKids.Models;

namespace SaberKids.Data.Map
{
    public class CartaoPagamentoMap : IEntityTypeConfiguration<CartaoPagamentoModel>
    {
        public void Configure(EntityTypeBuilder<CartaoPagamentoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CartaoId).IsRequired();
            builder.Property(x => x.PagamentoId).IsRequired();
        }
    }
}
