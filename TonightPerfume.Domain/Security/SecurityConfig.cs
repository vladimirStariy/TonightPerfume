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

        /// <summary>
        /// Время жизни access токена
        /// </summary>
        //public const int ACCES_TOKEN_LIFETIME = 3600; //3600

        //public const string ANALYTICS_TOKEN = "5b52d3ac-ec10-45ef-9f1a-02426a4de096";

        /// <summary>
        /// Время жизни refresh токена
        /// </summary>
        //public const int REFRESH_TOKEN_LIFETIME = 5184000; // 60 дней

        /// <summary>
        /// Секретный ключ для генерации jwt токенов
        /// </summary>
        internal const string KEY = "yCAR8jCVJATVN6rSKvqxur7UeCVzHaZCD3THYLuEzHWkuAwVkNeXvbCcy3RUPKVpx5vcE2mZ2kvBV35jkpjzjbPuge44yqP42JFknNmsRnqzgfBbBzURQUzjThafktmJbNew2UjqXfXcLu5t6Xgp4JugnyW2yScBneYCfWwpXyHktTC4RUPkKz33x77HnATsPeGkhKu4yGrMFQjjBrpdUpe6PmzdTqpn5q5BKS3E7VxM5UBBMhYGrhau3S9pWpjT";

        public const string ISSUER = "MyAuthServer"; // издатель токена
        public const string AUDIENCE = "MyAuthClient"; // потребитель токена

        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }


}
