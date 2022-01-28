using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Domain.Entities
{
    public class UsuarioIdentity
    {
        #region [ Propriedades ]

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }

        #endregion

        #region [ Construtores ]

        public UsuarioIdentity(int id, string nome, string login)
        {
            Id = id;
            Nome = nome;
            Login = login;
        }

        #endregion
    }
}
