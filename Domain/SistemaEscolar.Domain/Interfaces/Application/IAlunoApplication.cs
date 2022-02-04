using SistemaEscolar.Domain.Dto;
using SistemaEscolar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Domain.Interfaces.Application
{
    public interface IAlunoApplication<TContext> : IApplicationBase<TContext, Aluno, int>
                                  where TContext : IUnitOfWork<TContext>
    {
        Aluno UpdateAluno(int id, Aluno entity);
        AlunoDto GetAlunoStatus(int id);
        void DeleteAluno(int id);
    }
}
