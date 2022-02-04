using SistemaEscolar.Domain.Dto;
using SistemaEscolar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Domain.Interfaces.Service
{
    public interface IAlunoService<TContext> : IServiceBase<TContext, Aluno, int>
                              where TContext : IUnitOfWork<TContext>
    {
        Aluno UpdateAluno(int id, Aluno entity);
        AlunoDto GetAlunoStatus(int id);
        void DeleteAluno(int id);
    }
}
