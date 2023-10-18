using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Enum;
using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Response;
using TonightPerfume.Domain.Security;
using TonightPerfume.Domain.Viewmodels.UserVM;

namespace TonightPerfume.Service.Services.AccountServ
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<BaseUser> _userRepository;

        private readonly ITokenRepository<RefreshToken> _tokenRepository;

        public AccountService(IRepository<BaseUser> userRepository, ITokenRepository<RefreshToken> tokenRepository)
        {
            _userRepository = userRepository;
            _tokenRepository = tokenRepository;
        }

        public async Task<IBaseResponce<IDictionary<string, string>>> Login(LoginByNumDto model)
        {
            var user = await ValidateUser(model);
            if (user != null)
            {
                var result = PasswordHashing.GetPasswordHashAndSalt(model.Password, user.Salt);
                if (user.Password != result["hash"])
                {
                    return new Response<IDictionary<string, string>>()
                    {
                        StatusCode = StatusCode.IncorrectPassword,
                        Description = $"Неправильный пароль"
                    };
                }
                else
                {
                    var tokens = JwtTokens.GeneratePairTokens(user);
                    await _tokenRepository.Create(new RefreshToken()
                    {
                        Token = tokens["refreshToken"],
                        DeviceData = model.DeviceData,
                        User_ID = user.User_ID
                    });

                    return new Response<IDictionary<string, string>>()
                    {
                        Result = tokens,
                        Description = "",
                        StatusCode = StatusCode.OK
                    };
                }
            }

            return new Response<IDictionary<string, string>>()
            {
                StatusCode = StatusCode.IncorrectData,
                Description = $"Неправильный логин или пароль"
            };
        }

        public async Task<IBaseResponce<string>> RegisterBySms(string phone)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                string base_url = "https://userarea.sms-assistent.by/api/v1/send_sms/plain";

                string password = SecurityConfig.GetRandomPassword(10);
                string message = $"Ваш пароль: {password}";

                string url = $"{base_url}?user={SecurityConfig.SMS_LOGIN}" +
                                       $"&password={SecurityConfig.SMS_PASSWORD}" +
                                       $"&recipient=298426400" +
                                       $"&message={message}" +
                                       $"&sender={SecurityConfig.SMS_SENDER}";
                
                using var request = new HttpRequestMessage(HttpMethod.Get, url);
                using var response = await httpClient.SendAsync(request);
                string responseText = await response.Content.ReadAsStringAsync();

                var result = PasswordHashing.GetPasswordHashAndSalt(password);

                var newUser = new BaseUser()
                {
                    Username = phone,
                    Phone = phone,
                    Password = result["hash"],
                    Salt = result["salt"]
                };
                await _userRepository.Create(newUser);

                return new Response<string>()
                {
                    Result = responseText,
                    Description = "Пользователь добавлен",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<string>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponce<IDictionary<string, string>>> RefreshToken(string token)
        {
            try
            {
                if (token == null)
                    return new Response<IDictionary<string, string>>()
                    {
                        StatusCode = StatusCode.InternalServerError,
                        Description = $"Unauthorized"
                    };

                var validated = JwtTokens.ValidateToken(token, "refresh");
                var _token = await _tokenRepository.GetById(token);
                if (validated == null || _token == null)
                    return new Response<IDictionary<string, string>>()
                    {
                        StatusCode = StatusCode.InternalServerError,
                        Description = $"Unauthorized"
                    };

                var userId = JwtTokens.GetValueFromPayload(validated, "jti");
                var user = await _userRepository.GetById(Convert.ToUInt32(userId));

                var tokens = JwtTokens.GeneratePairTokens(user);


                var oldToken = await _tokenRepository.GetById(token);
                await _tokenRepository.Update(oldToken, new RefreshToken()
                {
                    Token = tokens["refreshToken"],
                    DeviceData = oldToken.DeviceData,
                    User_ID = user.User_ID
                });

                return new Response<IDictionary<string, string>>()
                {
                    Result = tokens,
                    Description = "Token refreshed",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<IDictionary<string, string>>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponce<string>> Logout(string token)
        {
            try 
            {
                var delToken = await _tokenRepository.GetById(token);
                await _tokenRepository.Delete(delToken);
                return new Response<string>()
                {
                    Result = delToken.Token,
                    Description = "Пользователь добавлен",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<string>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        private async Task<BaseUser?> ValidateUser(LoginByNumDto model)
        {
            var user = _userRepository.Get().FirstOrDefault(x => x.Phone == model.Phone);
            if (user == null) return null;
            return user;
        }
    }
}
