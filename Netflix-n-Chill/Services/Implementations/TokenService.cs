using Microsoft.IdentityModel.Tokens;
using Netflix_n_Chill.Configurations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Netflix_n_Chill.Services.Implementations
{
    public class TokenService : ITokenService
    {
        private TokenConfiguration _config { get; set; }
        public TokenService(TokenConfiguration config)
        {
            _config = config;
        }
        /// <summary>
        /// existem 3 tipos de claims num payload
        /// reservados -> nao obrigatorios, porem recomendados 
        /// (issuer, IssueAt, expiration, subject, pub/priv claims)
        /// publicos 
        /// privados
        /// </summary>
        /// <param name="claims"></param>
        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Secret));
            var signInCred = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var options = new JwtSecurityToken(
                issuer: _config.Issuer,
                audience: _config.Audience,
                claims: claims,
                signingCredentials: signInCred,
                expires: DateTime.Now.AddMinutes(_config.Minutes));

            return new JwtSecurityTokenHandler().WriteToken(options);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];

            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var validationParams = new TokenValidationParameters()
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Secret))
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken secToken;

            ClaimsPrincipal principal = tokenHandler.ValidateToken(token, validationParams, out secToken);

            var jwtToken = secToken as JwtSecurityToken;

            if (jwtToken != null ||
                !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                                            StringComparison.InvariantCulture))
            {
                throw new SecurityTokenException("Invalid token!");
            }

            return principal;
        }
    }
}
