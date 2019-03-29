using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria", "dbo");
            builder.HasKey(x => x.CategoriaId);
            builder.Property(x => x.Nome);
            builder.Property(x => x.Descricao);


            builder.HasMany(x => x.Produtos)
            .WithOne(x => x.Categoria)
            .HasForeignKey(x => x.CategoriaId);
        }
    }
}
