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
    public class UsuarioApplication<TContext> : ApplicationBase<TContext, Usuario, int>, IUsuarioApplication<TContext>
                               where TContext : IUnitOfWork<TContext>
    {
        #region [ Propriedades ]

        private new readonly IUsuarioService<TContext> _service;

        #endregion

        #region [ Construtor ]

        public UsuarioApplication(IUnitOfWork<TContext> context, IUsuarioService<TContext> service) : base(context, service)
        {
            _service = service;
        }

        #endregion

        #region [ Métodos ]

        public Usuario GetUsuarioLogado() => _service.GetUsuarioLogado();

        public Usuario UpdateUsuario(int id, Usuario entity)
        {
            _service.UpdateUsuario(id, entity);

            _unitOfWork.Commit();

            return entity;
        }

        #endregion
    }
}
