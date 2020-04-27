using SGA.ApplicationCore.Entity;
using SGA.ApplicationCore.Interfaces.Repositories;
using SGA.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGA.Infra.Repository
{
    public class ContatoRepository : EFRepository<Contato>, IContatoRepository
    {
        public ContatoRepository(ClienteContext dbContext ) :  base(dbContext)
        {

        }
        
    }
}
