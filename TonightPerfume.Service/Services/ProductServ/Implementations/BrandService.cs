using Microsoft.AspNetCore.Http;
using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Enum;
using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Response;
using TonightPerfume.Service.Services.ProductServ.Interfaces;

namespace TonightPerfume.Service.Services.ProductServ.Implementations
{
    public class BrandService : IBrandService
    {
        private readonly IRepository<Brand> _brandRepository;

        public BrandService(IRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<IBaseResponce<Brand>> Create(IFormFile file, Brand model)
        {
            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/SiteImages/Brands");

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                FileInfo fileInfo = new FileInfo(file.FileName);
                string fileNameWithPath = Path.Combine(path, file.FileName);
                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                
                model.ImagePath = $"SiteImages/Brands/{file.FileName}";

                await _brandRepository.Create(model);
                
                return new Response<Brand>()
                {
                    Result = model,
                    Description = "Пользователь добавлен",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<Brand>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponce<List<Brand>>> Get()
        {
            try
            {
                var brands = _brandRepository.Get();

                if (!brands.Any())
                {
                    return new Response<List<Brand>>()
                    {
                        Description = "Not found",
                        StatusCode = StatusCode.OK
                    };
                }

                return new Response<List<Brand>>()
                {
                    Result = brands.ToList(),
                    Description = "Объект добавлен",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<List<Brand>>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponce<List<Brand>>> GetSomeBrands(int count)
        {
            try
            {
                var brands = _brandRepository.Get().ToList().OrderBy(x => x.Name).Take(count);

                if (!brands.Any())
                {
                    return new Response<List<Brand>>()
                    {
                        Description = "Not found",
                        StatusCode = StatusCode.OK
                    };
                }

                return new Response<List<Brand>>()
                {
                    Result = brands.ToList(),
                    Description = "Объект добавлен",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<List<Brand>>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponce<List<Brand>>> GetSortedBrands()
        {
            try
            {
                var brands = _brandRepository.Get().ToList().OrderBy(x => x.Name);

                if (!brands.Any())
                {
                    return new Response<List<Brand>>()
                    {
                        Description = "Not found",
                        StatusCode = StatusCode.OK
                    };
                }

                return new Response<List<Brand>>()
                {
                    Result = brands.ToList(),
                    Description = "Объект добавлен",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<List<Brand>>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }
    }
}
