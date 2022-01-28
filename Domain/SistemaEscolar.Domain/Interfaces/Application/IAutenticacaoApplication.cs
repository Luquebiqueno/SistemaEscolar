using SistemaEscolar.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Domain.Interfaces.Application
{
    public interface IAutenticacaoApplication
    {
        TokenDto GetAutenticacao(string login, string senha);
    }
}
