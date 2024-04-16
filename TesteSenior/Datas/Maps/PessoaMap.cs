using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteSenior.Models;

namespace TesteSenior.Datas.Maps
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(200).IsRequired();
            builder.Property(x => x.cpfCnpj).HasMaxLength(14).IsRequired();
            builder.Property(x => x.Cidade).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Estado).HasMaxLength(100).IsRequired();
        }
    }
}
