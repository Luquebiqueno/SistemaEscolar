using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Repository.Repositories
{
    public class UsuarioRepository<TContext> : RepositoryBase<TContext, Usuario, int>, IUsuarioRepository<TContext>
                              where TContext : IUnitOfWork<TContext>
    {
        public UsuarioRepository(IUnitOfWork<TContext> unitOfWork) : base(unitOfWork) { }
    }
}
