using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TonightPerfume.Domain.Models;

namespace TonightPerfume.Domain.Security
{
    public static class JwtTokens
    {
        public static IEnumerable<Claim> CreateUserClaims(BaseUser user)
        {
            var claims = new List<Claim>(new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Name, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, user.User_ID.ToString())
            });

            return claims;
        }

        public static JwtSecurityToken CreateJwtToken(IEnumerable<Claim> claims, string tokenType)
        {
            return new JwtSecurityToken(
                    issuer: SecurityConfig.ISSUER,
                    audience: SecurityConfig.AUDIENCE,
                    claims: claims,
                    expires: tokenType == "access" ? DateTime.UtcNow.AddHours(1) : DateTime.UtcNow.AddDays(30),
                    signingCredentials: new SigningCredentials
                    (
                        tokenType == "access" ? SecurityConfig.GetSymmetricAccessKey() : SecurityConfig.GetSymmetricRefreshKey(), 
                        SecurityAlgorithms.HmacSha256
                    ));
        }

        public static uint GetPayloadUser(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var claims = handler.ValidateToken(token, SecurityConfig.GetRefreshValidationParameters(), out var tokenSecure);
            var id = Convert.ToUInt32(claims.Claims.Where(x => x.Type == "jti").Select(x => x.Value).FirstOrDefault());
            return id;
        }

        public static string CreateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public static Dictionary<string, string> GeneratePairTokens(BaseUser user)
        {
            var claims = CreateUserClaims(user);
            var accessJwt = CreateJwtToken(claims, "access");
            var refreshJwt = CreateJwtToken(claims, "refresh");
            var accessToken = new JwtSecurityTokenHandler().WriteToken(accessJwt);
            var refreshToken = new JwtSecurityTokenHandler().WriteToken(refreshJwt);
            return new Dictionary<string, string>
            {
                { "refreshToken", refreshToken },
                { "accessToken", accessToken },
            };
        }

        public static object GetValueFromPayload(ClaimsPrincipal principal, string key)
        {
            try
            {
                var claims = principal.Claims;
                if(claims != null)
                {
                    return claims.Where(x => x.Type == key).Select(x => x.Value).FirstOrDefault();
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public static ClaimsPrincipal? ValidateToken(string? token, string type)
        {
            var tokenValidationParameters = new TokenValidationParameters();
            if (type == "access")
                tokenValidationParameters = SecurityConfig.GetValidationParameters();
            else
                tokenValidationParameters = SecurityConfig.GetRefreshValidationParameters();

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
                if (securityToken is not JwtSecurityToken jwtSecurityToken ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    throw new SecurityTokenException("Invalid token");
                return principal;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
