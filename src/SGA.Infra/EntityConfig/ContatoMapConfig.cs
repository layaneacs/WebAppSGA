using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGA.Infra.EntityConfig
{
    public class ContatoMapConfig : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder
                .HasOne(c => c.Cliente) // 1 contato só tem 1 cliente, só que cliente tem muito contato
                .WithMany(c => c.Contatos)
                .HasForeignKey(c => c.ClienteId)
                .HasPrincipalKey(c => c.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(e => e.Nome)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(e => e.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(e => e.Telefone)
                .HasColumnType("varchar(15)");
        }
    }
}
