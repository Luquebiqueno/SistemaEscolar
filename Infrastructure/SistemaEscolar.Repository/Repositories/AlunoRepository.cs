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
    public class AlunoRepository<TContext> : RepositoryBase<TContext, Aluno, int>, IAlunoRepository<TContext>
                            where TContext : IUnitOfWork<TContext>
    {
        public AlunoRepository(IUnitOfWork<TContext> unitOfWork) : base(unitOfWork) { }
    }
}
