using SGA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGA.Infra.Data
{
    public static class DbInitializer
    {
        
        public static void Initialize(ClienteContext context)
        {
            if (context.Clientes.Any())
            {
                return; 
            }

            var clientes = new Cliente[]
            {
                new Cliente
                {
                    Nome = "Layane",
                    CPF = "15099999988",
                },
                new Cliente
                {
                    Nome = "Leticia",
                    CPF = "15099999922",
                }
                
            };

            context.AddRange(clientes);

            var contatos = new Contato[]
            {
                new Contato
                {
                    Nome = "Contato 1 ",
                    Telefone = "990909090",
                    Email = "contato1@gmail.com",
                    Cliente = clientes[0]
                },
                 new Contato
                {
                    Nome = "Contato 2 ",
                    Telefone = "990909090",
                    Email = "contato2@gmail.com",
                    Cliente = clientes[1]
                }
            };

            context.AddRange(contatos);

            context.SaveChanges();
        }
    }
}
