using SistemaEscolar.Domain.Dto;
using SistemaEscolar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Domain.Interfaces.Service
{
    public interface IAutenticacaoService
    {
        UsuarioIdentity GetUsuarioLogado();
        TokenDto GetAutenticacao(string login, string senha);
    }
}
