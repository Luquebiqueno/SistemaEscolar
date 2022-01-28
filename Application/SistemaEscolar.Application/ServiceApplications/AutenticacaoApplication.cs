using SistemaEscolar.Domain.Dto;
using SistemaEscolar.Domain.Interfaces.Application;
using SistemaEscolar.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Application.ServiceApplications
{
    public class AutenticacaoApplication : IAutenticacaoApplication
    {
        #region [ Propriedades ]

        private readonly IAutenticacaoService _autenticacaoService;

        #endregion

        #region [ Construtores ]

        public AutenticacaoApplication(IAutenticacaoService autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;
        }

        #endregion

        #region [ Métodos ]

        public TokenDto GetAutenticacao(string login, string senha) => _autenticacaoService.GetAutenticacao(login, senha);

        #endregion
    }
}
