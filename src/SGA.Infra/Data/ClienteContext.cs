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

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Responsável pela config do EntityFramework
        {
            modelBuilder.Entity<Cliente>().ToTable("Tb_cliente"); //  Mapea como tb_cliente. NÃO INDICADO
        }
    }
}
