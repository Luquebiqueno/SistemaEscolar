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
    public class UsuarioController : ControllerBase
    {
        #region [ Propriedades ]

        private readonly IUsuarioApplication<SistemaEscolarContext> _application;
        private readonly IMapper _mapper;

        #endregion

        #region [ Contrutores ]

        public UsuarioController(IUsuarioApplication<SistemaEscolarContext> application, IMapper mapper)
        {
            _application = application;
            _mapper = mapper;
        }

        #endregion

        #region [ Métodos ]

        [HttpGet]
        public IActionResult GetUsuario()
        {
            var usuario = _application.GetAll();
            var usuarioMapper = _mapper.Map<IEnumerable<UsuarioViewModel>>(usuario);

            return Ok(usuarioMapper);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUsuarioById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = _application.GetById(id);
            var usuarioMapper = _mapper.Map<UsuarioViewModel>(usuario);
            if (usuarioMapper == null)
                return NotFound();

            return Ok(usuarioMapper);
        }

        [HttpGet]
        [Route("UsuarioLogado")]
        public IActionResult GetUsuarioLogado()
        {
            var usuario = _application.GetUsuarioLogado();
            var usuarioMapper = _mapper.Map<UsuarioViewModel>(usuario);

            if (usuarioMapper == null)
                return NotFound();

            return Ok(usuarioMapper);
        }

        [HttpPost]
        public IActionResult CreateUsuario([FromBody] UsuarioViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model == null)
                return BadRequest();

            var usuario = model.Model();

            _application.Create(usuario);

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateUsuario([FromRoute] int id, [FromBody] UsuarioViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = model.Model();

            _application.UpdateUsuario(id, usuario);
            return Ok();

        }

        //[HttpDelete("{id}")]
        //public IActionResult DeleteUsuario(int id)
        //{
        //    _application.Delete(id);
        //    return Ok();
        //}

        #endregion
    }
}
