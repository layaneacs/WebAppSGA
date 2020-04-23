using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGA.Infra.EntityConfig
{
    public class ProfissaoMapConfig : IEntityTypeConfiguration<Profissao>
    {
        public void Configure(EntityTypeBuilder<Profissao> builder)
        {
            builder.Property(e => e.Nome)
               .HasColumnType("varchar(200)")
               .IsRequired();

            builder.Property(e => e.CBO)
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder.Property(e => e.Descricao)
                .HasColumnType("varchar(1000)")
                .IsRequired();
        }
    }
}
