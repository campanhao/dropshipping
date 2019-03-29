using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class FormaPagamentoConfiguration : IEntityTypeConfiguration<FormaPagamento>
    {
        public void Configure(EntityTypeBuilder<FormaPagamento> builder)
        {
            builder.ToTable("FormaPagamento", "dbo");
            builder.HasKey(x => x.FormaPagamentoId);
            builder.Property(x => x.Nome);


            builder.HasMany(x => x.Pedidos)
            .WithOne(x => x.FormaPagamento)
            .HasForeignKey(x => x.FormaPagamentoId);
        }
    }
}
