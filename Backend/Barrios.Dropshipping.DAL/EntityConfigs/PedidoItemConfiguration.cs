using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
   public  class PedidoItemConfiguration : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("PedidoItem", "dbo");
            builder.HasKey(x => x.PedidoItemId);
            builder.Property(x => x.PedidoId);
            builder.Property(x => x.ProdutoId);
            builder.Property(x => x.Quantidade);
            builder.Property(x => x.PrecoUnitario);
            builder.Property(x => x.ValorTotal);


            builder.HasOne(x => x.Pedido)
        .WithMany(x => x.PedidoItens)
        .HasForeignKey(x => x.PedidoId);

            builder.HasOne(x => x.Produto)
        .WithMany(x => x.PedidoItens)
        .HasForeignKey(x => x.ProdutoId);

            builder.HasOne(x => x.PedidoItemFornecedor)
            .WithOne(x => x.PedidoItem);
        }
    }
}
