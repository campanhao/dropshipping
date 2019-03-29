using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario", "dbo");
            builder.HasKey(x => x.UsuarioId);
            builder.Property(x => x.PerfilId);
            builder.Property(x => x.Nome);
            builder.Property(x => x.Email);
            builder.Property(x => x.Telefone);
            builder.Property(x => x.Cpf);
            builder.Property(x => x.Senha);

            builder.HasMany(x => x.UsuarioEnderecos)
            .WithOne(x => x.Usuario)
            .HasForeignKey(x => x.UsuarioId);

            builder.HasMany(x => x.Pedidos)
            .WithOne(x => x.Usuario)
            .HasForeignKey(x => x.UsuarioId);
        }
    }
}
