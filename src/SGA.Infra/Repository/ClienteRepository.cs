using SGA.ApplicationCore.Entity;
using SGA.ApplicationCore.Interfaces.Repositories;
using SGA.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGA.Infra.Repository
{
    public class ClienteRepository : EFRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ClienteContext dbContext ) :  base(dbContext)
        {

        }


        /*

        // sobrescrita do metodo.. apenas as que estão com o virtual.. 
        public override Cliente Adicionar(Cliente entity)
        {
            //  return base.Adicionar(entity);           
            var verificaResuldo = "";
            _dbContext.Set<Cliente>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }   
        */


        public Cliente ObterPorProfissao(int clienteId)
        {
            return Buscar(x=>x.ProfissoesClientes.Any(p => p.ClienteId == clienteId)).FirstOrDefault();
        }
    }
}
