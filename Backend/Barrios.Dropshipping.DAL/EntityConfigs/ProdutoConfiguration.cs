using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto", "dbo");
            builder.HasKey(x => x.ProdutoId);
            builder.Property(x => x.CodProdFornec);
            builder.Property(x => x.Nome);
            builder.Property(x => x.Descricao);
            builder.Property(x => x.Imagem);
            builder.Property(x => x.Preco);
            builder.Property(x => x.EmEstoque);
            builder.Property(x => x.Ativo);
            builder.Property(x => x.FornecedorId);
            builder.Property(x => x.CategoriaId);

            builder.HasMany(x => x.PedidoItens)
        .WithOne(x => x.Produto)
        .HasForeignKey(x => x.ProdutoId);

            builder.HasOne(x => x.Fornecedor)
         .WithMany(x => x.Produtos)
         .HasForeignKey(x => x.FornecedorId);

            builder.HasOne(x => x.Categoria)
         .WithMany(x => x.Produtos)
         .HasForeignKey(x => x.CategoriaId);
        }
    }
}
