using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Domain.Interfaces.Repository;
using SistemaEscolar.Domain.Interfaces.Service;
using SistemaEscolar.Domain.Services.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Domain.Services
{
    public class UsuarioService<TContext> : ServiceBase<TContext, Usuario, int>, IUsuarioService<TContext>
                           where TContext : IUnitOfWork<TContext>
    {
        #region [ Propriedades ]

        private new readonly IRepositoryBase<TContext, Usuario, int> _repository;
        private readonly IUsuarioLogado _usuarioLogado;

        #endregion

        #region [ Construtor ]

        public UsuarioService(IRepositoryBase<TContext, Usuario, int> repository,
                              IUsuarioLogado usuarioLogado) : base(repository)
        {
            _repository = repository;
            _usuarioLogado = usuarioLogado;
        }

        #endregion

        #region [ Métodos ]

        public override Usuario Create(Usuario entity)
        {
            entity.AtualizarNome(entity.Nome);
            entity.AtualizarLogin(entity.Login);    
            entity.AtualizarSenha(entity.Senha);    

            return base.Create(entity);
        }
        public Usuario GetUsuarioLogado()
        {
            return _repository.GetById(_usuarioLogado.Usuario.Id);
        }

        public Usuario UpdateUsuario(int id, Usuario entity)
        {
            var aluno = _repository.Exists(id);

            aluno.AtualizarNome(entity.Nome);
            aluno.AtualizarLogin(entity.Login);

            return base.Update(aluno);
        }

        #endregion

    }
}
