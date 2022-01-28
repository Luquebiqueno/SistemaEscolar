using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Domain.Services.Utils
{
    public class UsuarioLogado : IUsuarioLogado
    {
        #region [ Propriedades ]

        private readonly IAutenticacaoService _oAuth;

        #endregion

        #region [ Construtores ]

        public UsuarioLogado(IAutenticacaoService oAuth)
        {
            _oAuth = oAuth;
        }

        #endregion

        #region [ Métodos ]

        public UsuarioIdentity Usuario => _oAuth.GetUsuarioLogado();

        #endregion
    }
}
