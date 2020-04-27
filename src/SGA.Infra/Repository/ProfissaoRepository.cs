using SGA.ApplicationCore.Entity;
using SGA.ApplicationCore.Interfaces.Repositories;
using SGA.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGA.Infra.Repository
{
    public class ProfissaoRepository : EFRepository<Profissao>, IProfissaoRepository
    {
        public ProfissaoRepository(ClienteContext dbContext ) :  base(dbContext)
        {

        }
        
    }
}
