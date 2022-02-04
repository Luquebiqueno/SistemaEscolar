using SistemaEscolar.Domain.Dto;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Domain.Interfaces.Application;
using SistemaEscolar.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Application.ServiceApplications
{
    public class AlunoApplication<TContext> : ApplicationBase<TContext, Aluno, int>, IAlunoApplication<TContext>
                             where TContext : IUnitOfWork<TContext>
    {
        #region [ Propriedades ]

        private new readonly IAlunoService<TContext> _service;

        #endregion

        #region [ Construtor ]

        public AlunoApplication(IUnitOfWork<TContext> context, IAlunoService<TContext> service) : base(context, service)
        {
            _service = service;
        }

        #endregion

        #region [ Métodos ]

        public Aluno UpdateAluno(int id, Aluno entity)
        {
            _service.UpdateAluno(id, entity);
            _unitOfWork.Commit();

            return entity;
        }

        public void DeleteAluno(int id)
        {
            _service.DeleteAluno(id);
            _unitOfWork.Commit();
        }

        public AlunoDto GetAlunoStatus(int id) => _service.GetAlunoStatus(id);

        #endregion
    }
}
