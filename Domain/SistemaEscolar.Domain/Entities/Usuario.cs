using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Domain.Entities
{
    public class Usuario : EntityBase<int>
    {
        #region [ Propriedades ]

        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

        #endregion

        #region [ Construtores ]

        public Usuario()
        {

        }

        public Usuario(int id, string nome, string login)
        {
            AtualizarId(id);
            AtualizarNome(nome);
            AtualizarLogin(login);
        }

        #endregion

        #region [ Métodos ]

        public override void AtualizarId(int id) => this.Id = id;
        public void AtualizarSenha(string senha) => this.Senha = senha;
        public void AtualizarLogin(string login) => this.Login = login;
        public void AtualizarNome(string nome) => this.Nome = nome;
        public void AtualizarRefreshToken(string refreshToken) => this.RefreshToken = refreshToken;
        public void AtualizarRefreshTokenExpiryTime(DateTime refreshTokenExpiryTime) => this.RefreshTokenExpiryTime = refreshTokenExpiryTime;

        #endregion
    }
}
