using SistemaEscolar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Domain.Interfaces.Repository
{
    public interface IAlunoRepository<TContext> : IRepositoryBase<TContext, Aluno, int>
                                where TContext  : IUnitOfWork<TContext>
    {
    }
}
