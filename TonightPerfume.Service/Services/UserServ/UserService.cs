using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Enum;
using TonightPerfume.Domain.Models.User;
using TonightPerfume.Domain.Response;
using TonightPerfume.Domain.Security;
using TonightPerfume.Domain.Viewmodels.UserVM;

namespace TonightPerfume.Service.Services.UserServ
{
    public class UserService : IUserService
    {
        private readonly IRepository<BaseUser> _userRepository;

        public UserService(IRepository<BaseUser> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IBaseResponce<BaseUser>> GetById(uint id)
        {
            try
            {
                var user = await _userRepository.GetById(id);

                if (user == null)
                    return new Response<BaseUser>()
                    {
                        Description = "Not found",
                        StatusCode = StatusCode.OK
                    };

                return new Response<BaseUser>()
                {
                    Result = user,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<BaseUser>()
                {
                    Description = $"[GetUser] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponce<BaseUser>> Register(RegisterDto model)
        {
            try
            {
                var newUser = new BaseUser()
                {
                    Username = model.Username,
                    Password = model.Password
                };
                await _userRepository.Create(newUser);

                return new Response<BaseUser>()
                {
                    Result = newUser,
                    Description = "Пользователь добавлен",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<BaseUser>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponce<string>> Login(LoginDto model)
        {
            var user = ValidateUser(model).Result;
            if (user != null)
            {
                var claims = JwtTokens.CreateClaims(user);
                var jwt = JwtTokens.CreateJwtToken(claims);
                return new Response<string>()
                {
                    Result = new JwtSecurityTokenHandler().WriteToken(jwt),
                    Description = "",
                    StatusCode = StatusCode.OK
                };
            }
            return new Response<string>()
            {
                StatusCode = StatusCode.OK,
                Description = $"Неправильный логин или пароль"
            };
        }

        public async Task<IBaseResponce<List<BaseUser>>> Get()
        {
            try
            {
                var users = await _userRepository.Get().ToListAsync();

                return new Response<List<BaseUser>>()
                {
                    Result = users,
                    Description = "Пользователь добавлен",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<List<BaseUser>>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        private async Task<BaseUser?> ValidateUser(LoginDto model)
        {
            var user = await _userRepository.Get().FirstOrDefaultAsync(x => x.Username == model.Username);
            if(user == null) return null;
            if(user.Password != model.Password) return null;
            return user;
        }

        
    }

    
}
