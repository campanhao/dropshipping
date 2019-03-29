using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class UsuarioEnderecoConfiguration : IEntityTypeConfiguration<UsuarioEndereco>
    {
        public void Configure(EntityTypeBuilder<UsuarioEndereco> builder)
        {
            builder.ToTable("UsuarioEndereco", "dbo");
            builder.HasKey(x => x.UsuarioEnderecoId);
            builder.Property(x => x.UsuarioId);
            builder.Property(x => x.Logradouro);
            builder.Property(x => x.Numero);
            builder.Property(x => x.Complemento);
            builder.Property(x => x.Bairro);
            builder.Property(x => x.Cidade);
            builder.Property(x => x.Estado);
            builder.Property(x => x.CEP);

            builder.HasOne(x => x.Usuario)
            .WithMany(x => x.UsuarioEnderecos)
            .HasForeignKey(x => x.UsuarioId);
        }
    }
}
