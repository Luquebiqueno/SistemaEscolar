using SistemaEscolar.Domain.Dto;
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
    public class AlunoService<TContext> : ServiceBase<TContext, Aluno, int>, IAlunoService<TContext>
                         where TContext : IUnitOfWork<TContext>
    {
        #region [ Propriedades ]

        private new readonly IRepositoryBase<TContext, Aluno, int> _repository;
        private readonly IUsuarioLogado _usuarioLogado;

        #endregion

        #region [ Construtor ]

        public AlunoService(IRepositoryBase<TContext, Aluno, int> repository,
                            IUsuarioLogado usuarioLogado) : base(repository)
        {
            _repository = repository;
            _usuarioLogado = usuarioLogado;
        }

        #endregion

        #region [ Métodos ]

        public override IEnumerable<Aluno> GetAll()
        {
            return base.GetAll().Where(x => x.Ativo).ToList();
        }
        public override Aluno Create(Aluno entity)
        {
            entity.AtualizarNome(entity.Nome);
            entity.AtualizarTelefone(entity.Telefone);
            entity.AtualizarMedia(entity.Media);
            entity.AtualizarDataCadastro();
            entity.AtualizarUsuarioCadastro(_usuarioLogado.Usuario != null ? _usuarioLogado.Usuario.Id : 1);
            entity.Ativar();

            return base.Create(entity);
        }

        public Aluno UpdateAluno(int id, Aluno entity)
        {
            var aluno = _repository.Exists(id);

            aluno.AtualizarNome(entity.Nome);
            aluno.AtualizarTelefone(entity.Telefone);
            aluno.AtualizarMedia(entity.Media);
            aluno.AtualizarDataAlteracao();
            aluno.AtualizarUsuarioAlteracao(_usuarioLogado.Usuario != null ? _usuarioLogado.Usuario.Id : 1);

            return base.Update(aluno);
        }

        public void DeleteAluno(int id)
        {
            var aluno = _repository.Exists(id);

            aluno.Inativar();
            aluno.AtualizarDataAlteracao();
            aluno.AtualizarUsuarioAlteracao(_usuarioLogado.Usuario != null ? _usuarioLogado.Usuario.Id : 1);

            base.Update(aluno);
        }

        public AlunoDto GetAlunoStatus(int id)
        {
            var aluno = _repository.Exists(id);

            var alunoDto = new AlunoDto
            {
                Media = aluno.Media,
                Nome = aluno.Nome
            };

            if (aluno.Media < 5)
            {
                alunoDto.Status = "Reprovado";
            }
            else if (aluno.Media >= 5 && aluno.Media < 6)
            {
                alunoDto.Status = "Em Recuperação";
            }
            else
            {
                alunoDto.Status = "Aprovado";
            }

            return alunoDto;
        }

        #endregion
    }
}
