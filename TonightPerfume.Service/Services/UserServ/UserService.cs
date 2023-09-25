using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Enum;
using TonightPerfume.Domain.Models;
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

        public async Task<IBaseResponce<List<BaseUser>>> Get()
        {
            try
            {
                var users = _userRepository.Get().ToList();

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
    }
}
