using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
   public  class PedidoEntregaConfiguration : IEntityTypeConfiguration<PedidoEntrega>
    {
        public void Configure(EntityTypeBuilder<PedidoEntrega> builder)
        {
            builder.ToTable("PedidoEntrega", "dbo");
            builder.HasKey(x => x.PedidoEntregaId);
            builder.Property(x => x.PedidoId);
            builder.Property(x => x.Logradouro);
            builder.Property(x => x.Numero);
            builder.Property(x => x.Complemento);
            builder.Property(x => x.Bairro);
            builder.Property(x => x.Cidade);
            builder.Property(x => x.Estado);
            builder.Property(x => x.CEP);

            builder.HasOne(x => x.Pedido)
          .WithOne(x => x.PedidoEntrega);
        }
    }
}
