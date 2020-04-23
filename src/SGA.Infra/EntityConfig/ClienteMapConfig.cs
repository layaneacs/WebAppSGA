using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGA.Infra.EntityConfig
{
    public class ClienteMapConfig : IEntityTypeConfiguration<Cliente>
    {
        // vai implementar a interface IEntityTypeConfiguration = para configurar o Fluent Api - 
        public void Configure(EntityTypeBuilder<Cliente> builder)  
         // Implementção obrigatória do IEntityTypeConfiguration
        {
            // Não preciso deixar explicito ( modelBuilder.Entity<Cliente>() ) como lá no ClienteContext            
            builder.HasKey(c => c.ClienteId);

            builder
                .HasMany(c => c.Contatos)
                .WithOne(c => c.Cliente)
                .HasForeignKey(c => c.ClienteId)
                .HasPrincipalKey(c => c.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Endereco) // clientes tem um endereço, com um cliente...
                .WithOne(x => x.Cliente)
                .HasForeignKey<Endereco>(x => x.ClienteId);
           
            builder.Property(e => e.CPF)
                .HasColumnType("varchar(11)")
                .IsRequired();

            builder.Property(e => e.Nome)
                .HasColumnType("varchar(200)")
                .IsRequired();
        }
    }
}
