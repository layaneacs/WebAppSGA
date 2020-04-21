using Microsoft.EntityFrameworkCore;
using SGA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGA.Infra.Data
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options) : base(options) // Contrutor obrigatorio para funcionar o entity
        {

        }

        public DbSet<Cliente> Clientes { get; set; } // Mapear a classe que será a tabela no nosso banco
        public DbSet<Contato> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Responsável pela config do EntityFramework
        {
            modelBuilder.Entity<Cliente>().ToTable("Cliente"); //  Mapear como ToTable(tb_cliente.) NÃO INDICADO
            modelBuilder.Entity<Contato>().ToTable("Contato");

            // Faremos logo mais, usando o mapping
            #region Configurações Cliente
            modelBuilder.Entity<Cliente>().Property(e => e.CPF)
                .HasColumnType("varchar(11)")
                .IsRequired();

            modelBuilder.Entity<Cliente>().Property(e => e.Nome)
                .HasColumnType("varchar(200)")
                .IsRequired();
            #endregion

            #region Configurações Contato
            modelBuilder.Entity<Contato>().Property(e => e.Nome)
                .HasColumnType("varchar(200)")
                .IsRequired();

            modelBuilder.Entity<Contato>().Property(e => e.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();

            modelBuilder.Entity<Contato>().Property(e => e.Telefone)
                .HasColumnType("varchar(15)");
            #endregion



        }
    }
}
