using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("Status", "dbo");
            builder.HasKey(x => x.StatusId);
            builder.Property(x => x.Nome);
            builder.Property(x => x.Descricao);


            builder.HasMany(x => x.PedidoFornecedores)
            .WithOne(x => x.Status)
            .HasForeignKey(x => x.StatusId);
        }
    }
}
