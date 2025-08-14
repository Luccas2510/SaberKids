using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaberKids.Models;

namespace SaberKids.Data.Map
{
    public class CartaoMap : IEntityTypeConfiguration<CartaoModel>
    {
        public void Configure(EntityTypeBuilder<CartaoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NomeCartao).IsRequired();
            builder.Property(x => x.Descricao).IsRequired();
            builder.Property(x => x.NumeroCartao).IsRequired();
            builder.Property(x => x.BandeiraCartao).IsRequired();
            builder.Property(x => x.TipoCartao).IsRequired();
            builder.Property(x => x.CodeCartao).IsRequired();
            builder.Property(x => x.DataVenci).IsRequired();

        }
    }
}
