using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SaberKids.Models;

namespace SaberKids.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NomeResp).IsRequired().HasMaxLength(255);
            builder.Property(x => x.NomeAluno).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(180);
            builder.Property(x => x.Senha).IsRequired();
            builder.Property(x => x.DataNasci).IsRequired();
            builder.Property(x => x.CPF).IsRequired();
        }
    }
}
