using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
   public  class PedidoFornecedorConfiguration : IEntityTypeConfiguration<PedidoItemFornecedor>
    {
        public void Configure(EntityTypeBuilder<PedidoItemFornecedor> builder)
        {
            builder.ToTable("PedidoItemFornecedor", "dbo");
            builder.HasKey(x => x.PedidoItemFornecedorId);
            builder.Property(x => x.CodPedidoItemFornec);
            builder.Property(x => x.PedidoItemId);
            builder.Property(x => x.FornecedorId);
            builder.Property(x => x.StatusId);
            builder.Property(x => x.UltimaAtualizacao);
            builder.Property(x => x.Observacao);

            builder.HasOne(x => x.Status)
        .WithMany(x => x.PedidoFornecedores)
        .HasForeignKey(x => x.StatusId);

            builder.HasOne(x => x.Fornecedor)
        .WithMany(x => x.PedidoFornecedores)
        .HasForeignKey(x => x.FornecedorId);

            builder.HasOne(x => x.PedidoItem)
        .WithOne(x => x.PedidoItemFornecedor);
        }
    }
}
