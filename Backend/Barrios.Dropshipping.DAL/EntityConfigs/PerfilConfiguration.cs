using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class PerfilConfiguration : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.ToTable("Perfil", "dbo");
            builder.HasKey(x => x.PerfilId);
            builder.Property(x => x.Nome);

            builder.HasMany(x => x.Usuarios)
            .WithOne(x => x.Perfil)
            .HasForeignKey(x => x.PerfilId);
        }
    }
}
