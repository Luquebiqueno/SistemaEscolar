using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Domain.Entities
{
    public class Aluno : EntityBase<int>
    {
        #region [ Propriedades ]

        public string Nome { get; set; }
        public long? Telefone { get; set; }
        public decimal Media { get; set; }

        #endregion

        #region [ Construtores ]

        public Aluno()
        {

        }

        public Aluno(int id, string nome, long? telefone, decimal media)
        {
            AtualizarId(id);
            AtualizarNome(nome);
            AtualizarTelefone(telefone);
            AtualizarMedia(media);
        }

        #endregion

        #region [ Métodos ]

        public override void AtualizarId(int id) => this.Id = id;
        public void AtualizarNome(string nome) => this.Nome = nome;
        public void AtualizarTelefone(long? telefone) => this.Telefone = telefone;
        public void AtualizarMedia(decimal media) => this.Media = media;

        #endregion
    }
}
