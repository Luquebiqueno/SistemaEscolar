using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEscolar.Api.ViewModels;
using SistemaEscolar.Domain.Interfaces.Application;

namespace SistemaEscolar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        #region [ Propriedades ]

        private readonly IAutenticacaoApplication _autenticacaoApplication;

        #endregion

        #region [ Contrutores ]

        public AutenticacaoController(IAutenticacaoApplication autenticacaoApplication)
        {
            _autenticacaoApplication = autenticacaoApplication;
        }

        #endregion

        #region [ Métodos ]

        [HttpPost]
        [AllowAnonymous]
        public IActionResult GetAutenticacao([FromBody] UsuarioLoginViewModel model)
        {
            if (model == null)
                return BadRequest("Invalid client request");

            var token = _autenticacaoApplication.GetAutenticacao(model.Login, model.Senha);

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }

        #endregion
    }
}
