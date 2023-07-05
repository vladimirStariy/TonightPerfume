using JWT.Algorithms;
using JWT.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TonightPerfume.Domain.Models.User;

namespace TonightPerfume.Domain.Security
{
    public static class JwtTokens
    {
        public static List<Claim> CreateClaims(BaseUser user)
        {
            var claims = new List<Claim>(new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Name, user.Username)
            });

            return claims;
        }

        public static JwtSecurityToken CreateJwtToken(List<Claim> claims)
        {
            return new JwtSecurityToken(
                    issuer: SecurityConfig.ISSUER,
                    audience: SecurityConfig.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(5)),
                    signingCredentials: new SigningCredentials(SecurityConfig.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        }

        //public static object GetValueFromPayload(IHeaderDictionary headers, string key)
        //{
        //    StringValues jwtToken;
        //    headers.TryGetValue("Authorization", out jwtToken);
        //    var payload = GetPayloadFromToken(jwtToken);
        //    return payload[key];
        //}

        //public static object GetValueFromPayload(string accessToken, string key)
        //{
        //    var payload = GetPayloadFromToken("Bearer " + accessToken);
        //    return payload[key];
        //}

        //private static IDictionary<string, object> GetPayloadFromToken(string token)
        //{
        //    return new JwtBuilder()
        //        .WithAlgorithm(new HMACSHA256Algorithm())
        //        .WithSecret(SecurityConfig.KEY)
        //        .MustVerifySignature()
        //        .Decode<IDictionary<string, object>>(token.Split()[1]);
        //}

        //private static string CreateAccessToken(BaseUser user)
        //{
        //    var payload = GetUserData(user);
        //    return CreateJwtToken(SecurityConfig.ACCES_TOKEN_LIFETIME, payload);
        //}

        //public static Dictionary<string, object> GetUserData(BaseUser user)
        //{
        //    var payload = new Dictionary<string, object>
        //    {
        //        { "user_name", user.Username },
        //        { "userId", user.User_ID }
        //        //,
        //        //{ "email_active", user.EmailValidate },
        //        //{ "phone_active", user.NumberValidate },
        //        //{ "email", user.Email },
        //        //{ "defaultAccount", childUser != null ? childUser.DefaultAccount : false },
        //        //{ "phone", user.PhoneNumber },
        //        //{ "perms", perms },
        //        //{ "avatar",  childUser != null ? childUser.Avatar : user.Avatar },
        //        //{ "userType", childUser != null ? childUser.GetType().Name : user.GetType().Name },
        //        //{ "userData", childUser != null ? JsonConvert.SerializeObject(childUser) : "" },
        //    };
        //    return payload;
        //}

        //private static string CreateJwtToken(int lifetime, Dictionary<string, object> payload = null)
        //{
        //    if (payload == null)
        //        payload = new Dictionary<string, object>();
        //    return new JwtBuilder()
        //        .WithAlgorithm(new HMACSHA256Algorithm())
        //        .WithSecret(SecurityConfig.KEY)
        //        .AddClaims(payload)
        //        .AddClaim("exp", DateTimeOffset.UtcNow.AddSeconds(lifetime).ToUnixTimeSeconds())
        //        .Encode();
        //}
    }
}
