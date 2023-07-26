using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TonightPerfume.Domain.Security
{
    public static class SecurityConfig
    {
        /// <summary>
        /// Время жизни кодов активации, высылаемых по email
        /// </summary>
        //public const int ACTIVATION_EMAIL_LIFETIME = 172800; // 2 дня

        /// <summary>
        /// Время жизни кода для восстановления пароля
        /// </summary>
        //public const int RESTORE_PASSWORD_LIFETIME = 172800; // 2 дня

        /// <summary>
        /// Через какое время доступна повторая отправка активации по email
        /// </summary>
        //public const int ACTIVATION_EMAIL_RESEND_TIMEOUT = 600; // 10 минут

        /// <summary>
        /// Через какое время доступна повторая отправка активации по email
        /// </summary>
        //public const int RESTORE_PASSWORD_RESEND_TIMEOUT = 1800; // 30 минут

        

        //public const string ANALYTICS_TOKEN = "5b52d3ac-ec10-45ef-9f1a-02426a4de096";

        public static TokenValidationParameters GetValidationParameters()
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = ISSUER,
                ValidateAudience = true,
                ValidAudience = AUDIENCE,
                ValidateLifetime = true,
                IssuerSigningKey = GetSymmetricAccessKey(),
                ValidateIssuerSigningKey = true
            };
            
            return tokenValidationParameters;
        }

        public static TokenValidationParameters GetRefreshValidationParameters()
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = ISSUER,
                ValidateAudience = true,
                ValidAudience = AUDIENCE,
                ValidateLifetime = true,
                IssuerSigningKey = GetSymmetricRefreshKey(),
                ValidateIssuerSigningKey = true
            };

            return tokenValidationParameters;
        }

        public const int REFRESH_TOKEN_LIFETIME = 5184000; // 60 дней
        public const int ACCES_TOKEN_LIFETIME = 1800; //3600

        internal const string ACCESS_KEY = "EiVyJh3gGYUfN2XfNe+U5OBdtri10iH56OHicjzufMqoZbfDxZWlB1LSOHVS3bCC";        

        internal const string REFRESH_KEY = "cGgZVjavLKIXWAtbW7NjA4QdShmz48fy7aJ90+hh8G1p0SkFmrDkpULgnZRlBdku";

        public const string ISSUER = "https://localhost:7226"; // издатель токена
        public const string AUDIENCE = "MyAuthClient"; // потребитель токена

        public static SymmetricSecurityKey GetSymmetricAccessKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ACCESS_KEY));
        public static SymmetricSecurityKey GetSymmetricRefreshKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(REFRESH_KEY));
    }


}
