using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces.Repository;
using SistemaEscolar.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Repository.Repositories
{
    public class AutenticacaoRepository : IAutenticacaoRepository
    {
        #region [ Propriedades ]

        private readonly SistemaEscolarContext _context;
        private DbSet<Usuario> _dataSet;

        #endregion

        #region [ Contrutores ]

        public AutenticacaoRepository(SistemaEscolarContext context)
        {
            _context = context;
            _dataSet = _context.Set<Usuario>();
        }

        #endregion

        #region [ Métodos ]

        public Usuario GetUsuarioByLogin(string login) => _dataSet.FirstOrDefault(x => x.Login.Equals(login));
        public Usuario GetUsuarioByLoginSenha(string login, string senha) => _dataSet.FirstOrDefault(x => x.Login.Equals(login) && x.Senha.Equals(senha));

        public void UpdateUsuario(Usuario usuario)
        {
            _dataSet.Update(usuario);
            _context.Commit();
        }

        #endregion
    }
}
