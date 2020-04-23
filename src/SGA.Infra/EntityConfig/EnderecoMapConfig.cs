using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGA.Infra.EntityConfig
{
    public class EnderecoMapConfig : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.Property(e => e.Bairro)
              .HasColumnType("varchar(200)")
              .IsRequired();

            builder.Property(e => e.CEP)
                .HasColumnType("varchar(15)")
                .IsRequired();

            builder.Property(e => e.Logradouro)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(e => e.Referencia)
                .HasColumnType("varchar(400)");
        }
    }
}
