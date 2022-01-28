using SistemaEscolar.Domain.Acessor;
using SistemaEscolar.Domain.Dto;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Helpers;
using SistemaEscolar.Domain.Interfaces.Repository;
using SistemaEscolar.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Domain.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        #region [ Propriedades ]

        private const string Date_Format = "yyyy-MM-dd HH:mm:ss";
        private const string message = "Usuário Logado com sucesso.";
        private readonly TokenConfiguration _configuration;
        private readonly ITokenService _tokenService;
        private readonly IAutenticacaoRepository _repository;
        private readonly IUser _user;

        #endregion

        #region [ Construtor ]

        public AutenticacaoService(TokenConfiguration configuration,
                                     ITokenService tokenService,
                                     IAutenticacaoRepository repository,
                                     IUser user)
        {
            _configuration = configuration;
            _tokenService = tokenService;
            _repository = repository;
            _user = user;
        }

        #endregion

        #region [ Métodos ]

        public UsuarioIdentity GetUsuarioLogado()
        {
            var usuario = _repository.GetUsuarioByLogin(_user.Name);

            return new UsuarioIdentity(usuario.Id, usuario.Nome, usuario.Login);
        }

        public TokenDto GetAutenticacao(string login, string senha)
        {
            var usuario = _repository.GetUsuarioByLoginSenha(login, senha);

            if (usuario == null) return null;

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Login)
            };

            var accessToken = _tokenService.GenerateAcessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();


            usuario.AtualizarRefreshToken(refreshToken);
            usuario.AtualizarRefreshTokenExpiryTime(DateTime.Now.AddDays(_configuration.DaysToExpiry));

            _repository.UpdateUsuario(usuario);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);


            return new TokenDto(true, createDate.ToString(Date_Format), expirationDate.ToString(Date_Format), accessToken, refreshToken, message);
        }

        #endregion
    }
}
