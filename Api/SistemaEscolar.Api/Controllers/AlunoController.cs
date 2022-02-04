using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEscolar.Api.ViewModels;
using SistemaEscolar.Domain.Interfaces.Application;
using SistemaEscolar.Repository.Context;

namespace SistemaEscolar.Api.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        #region [ Propriedades ]

        private readonly IAlunoApplication<SistemaEscolarContext> _application;
        private readonly IMapper _mapper;

        #endregion

        #region [ Contrutores ]

        public AlunoController(IAlunoApplication<SistemaEscolarContext> application, IMapper mapper)
        {
            _application = application;
            _mapper = mapper;
        }

        #endregion

        #region [ Métodos ]

        [HttpGet]
        public IActionResult GetAluno()
        {
            var alunos = _application.GetAll();
            var alunosMapper = _mapper.Map<IEnumerable<AlunoViewModel>>(alunos);

            return Ok(alunosMapper);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUsuarioById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var aluno = _application.GetById(id);
            var alunoMapper = _mapper.Map<AlunoViewModel>(aluno);

            if (alunoMapper == null)
                return NotFound();

            return Ok(alunoMapper);
        }

        [HttpGet]
        [Route("AlunoStatus/{id}")]
        public IActionResult GetAlunoStatus(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var aluno = _application.GetAlunoStatus(id);

            if (aluno == null)
                return NotFound();

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult CreateAluno([FromBody] AlunoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model == null)
                return BadRequest();

            var aluno = model.Model();

            _application.Create(aluno);

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateAluno([FromRoute] int id, [FromBody] AlunoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var aluno = model.Model();

            _application.UpdateAluno(id, aluno);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteAluno/{id}")]
        public IActionResult DeleteAluno(int id)
        {
            _application.DeleteAluno(id);
            return Ok();
        }

        #endregion
    }
}
