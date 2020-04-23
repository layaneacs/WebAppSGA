using Microsoft.EntityFrameworkCore;
using SGA.ApplicationCore.Entity;
using SGA.Infra.EntityConfig;
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
            modelBuilder.Entity<Endereco>().ToTable("Endereco");
            modelBuilder.Entity<Profissao>().ToTable("Profissao");
            modelBuilder.Entity<ProfissaoCliente>().ToTable("ProfissaoCliente");         


            // essa class tem que CHAMAR essas configurações.....           

            #region Configurações Cliente
            /* Fluent Api */
            //modelBuilder.Entity<Cliente>()
            //.HasKey(c => c.ClienteId);

            /*Cliente tem muitos contatos*/
            //modelBuilder.Entity<Cliente>()
            // .HasMany(c => c.Contatos)
            // .WithOne(c=> c.Cliente)
            //.HasForeignKey(c => c.ClienteId)
            // .HasPrincipalKey(c => c.ClienteId);                

            // Config iniciais
            // modelBuilder.Entity<Cliente>().Property(e => e.CPF)
            //.HasColumnType("varchar(11)")
            //.IsRequired();

            // modelBuilder.Entity<Cliente>().Property(e => e.Nome)
            // .HasColumnType("varchar(200)")
            // .IsRequired();

            #endregion


            #region Configurações Contato
            /* Posso tbm fazer a relação Contato ~ Cliente aqui

            modelBuilder.Entity<Contato>()
                .HasOne(c => c.Cliente) // 1 contato só tem 1 cliente, só que cliente tem muito contato
                .WithMany(c => c.Contatos)
                .HasForeignKey(c=> c.ClienteId)
                .HasPrincipalKey(c => c.ClienteId);

            modelBuilder.Entity<Contato>().Property(e => e.Nome)
                .HasColumnType("varchar(200)")
                .IsRequired();

            modelBuilder.Entity<Contato>().Property(e => e.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();

            modelBuilder.Entity<Contato>().Property(e => e.Telefone)
                .HasColumnType("varchar(15)");
                */
            #endregion


            #region Configurações Profissão
            /*
            modelBuilder.Entity<Profissao>().Property(e => e.Nome)
                .HasColumnType("varchar(200)")
                .IsRequired();

            modelBuilder.Entity<Profissao>().Property(e => e.CBO)
                .HasColumnType("varchar(10)")
                .IsRequired();

            modelBuilder.Entity<Profissao>().Property(e => e.Descricao)
                .HasColumnType("varchar(1000)")
                .IsRequired();

            */
            #endregion


            #region Configurações Endereco

            /*
            modelBuilder.Entity<Endereco>().Property(e => e.Bairro)
                .HasColumnType("varchar(200)")
                .IsRequired();

            modelBuilder.Entity<Endereco>().Property(e => e.CEP)
                .HasColumnType("varchar(15)")
                .IsRequired();

            modelBuilder.Entity<Endereco>().Property(e => e.Logradouro)
                .HasColumnType("varchar(200)")
                .IsRequired();

            modelBuilder.Entity<Endereco>().Property(e => e.Referencia)
                .HasColumnType("varchar(400)");

            */
            #endregion


            #region configurações ProfissãoCliente
            /*
            modelBuilder.Entity<ProfissaoCliente>().HasKey(c => c.Id);

            modelBuilder.Entity<ProfissaoCliente>()
                .HasOne(pc => pc.Cliente)
                .WithMany(c => c.ProfissoesClientes)
                .HasForeignKey(c => c.ClienteId);
            
            modelBuilder.Entity<ProfissaoCliente>()
                .HasOne(pc => pc.Profissao)
                .WithMany(c => c.ProfissoesClientes)
                .HasForeignKey(c => c.ProfissaoId);
            */
            #endregion

            #region Configurações Menu
            /*
           modelBuilder.Entity<Menu>()
                .HasMany(m => m.SubMenu) // tem muitos submenus
                .WithOne()// e o sub menu tem apenas um Menu
                .HasForeignKey(m => m.MenuId);
            */
            #endregion

            modelBuilder.ApplyConfiguration(new ClienteMapConfig());
            modelBuilder.ApplyConfiguration(new ContatoMapConfig());
            modelBuilder.ApplyConfiguration(new ProfissaoMapConfig());
            modelBuilder.ApplyConfiguration(new EnderecoMapConfig());
            modelBuilder.ApplyConfiguration(new ProfissaoClienteMapConfig());
            modelBuilder.ApplyConfiguration(new MenuMapConfig());


        }
    }
}
