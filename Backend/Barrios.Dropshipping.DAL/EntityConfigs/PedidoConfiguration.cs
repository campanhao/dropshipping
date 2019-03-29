using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
   public  class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido", "dbo");
            builder.HasKey(x => x.PedidoId);
            builder.Property(x => x.UsuarioId);
            builder.Property(x => x.FormaPagamentoId);
            builder.Property(x => x.Data);
            builder.Property(x => x.ValorTotal);

            builder.HasMany(x => x.PedidoItens)
            .WithOne(x => x.Pedido)
            .HasForeignKey(x => x.PedidoId);

            builder.HasOne(x => x.PedidoEntrega)
                .WithOne(x => x.Pedido);

            builder.HasOne(x => x.FormaPagamento)
          .WithMany(x => x.Pedidos)
          .HasForeignKey(x => x.FormaPagamentoId);
        }
    }
}
