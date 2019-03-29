using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace DAL
{
    public class FornecedorConfiguration : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("Fornecedor", "dbo");
            builder.HasKey(x => x.FornecedorId);
            builder.Property(x => x.Nome);
            builder.Property(x => x.CNPJ);
            builder.Property(x => x.Ativo);
            builder.Property(x => x.Usuario);
            builder.Property(x => x.Senha);

            builder.HasMany(x => x.PedidoFornecedores)
         .WithOne(x => x.Fornecedor)
         .HasForeignKey(x => x.FornecedorId);

            builder.HasMany(x => x.Produtos)
        .WithOne(x => x.Fornecedor)
        .HasForeignKey(x => x.FornecedorId);
        }
    }
}
