using Netflix_n_Chill.Business.Abstractions;
using Netflix_n_Chill.Configurations;
using Netflix_n_Chill.Data.ValueObject;
using Netflix_n_Chill.Repository;
using Netflix_n_Chill.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Netflix_n_Chill.Business.Implementations
{
    public class LoginBussiness : ILoginBussiness
    {
        public const string date_format = "yyyy-MM-dd:mm:ss";
        private TokenConfiguration _config;
        private IUserRepository _repository { get; set; }
        public readonly ITokenService _tokenService;

        public LoginBussiness(TokenConfiguration config,
                              IUserRepository repository,
                              ITokenService tokenService)
        {
            _config = config;
            _repository = repository;
            _tokenService = tokenService;
        }

        public TokenVO ValidateCredentials(UsersVO userCredentials)
        {
            //valida as credenciais no banco
            var user = _repository.ValidateCredentials(userCredentials);

            //se retornou nulo, a validacao deu errado
            if (user == null) return null;
            //se nao, criamos uma lista de claims com jti
            //e com o username unico
            // jti eh uma sigla q significa Json Token Identifier
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Username)
            };

            user.AccessToken = _tokenService.GenerateAccessToken(claims);
            user.RefreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshTokenExpireTime = DateTime.Now.AddDays(_config.DaysToExpire);

            return new TokenVO(true,
                               DateTime.Now.ToString(date_format),
                               user.RefreshTokenExpireTime.ToString(date_format),
                               user.AccessToken,
                               user.RefreshToken
                               );
        }
    }
}
