using SistemaEscolar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Domain.Interfaces.Repository
{
    public interface IAutenticacaoRepository
    {
        Usuario GetUsuarioByLogin(string login);
        Usuario GetUsuarioByLoginSenha(string login, string senha);
        void UpdateUsuario(Usuario usuario);
    }
}
