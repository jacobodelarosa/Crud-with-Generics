using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Travels.Application.SeedWork;

namespace Travels.WebApi.SeedWork
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class CrudControllerBase<TDto, TKey> : ControllerBase
    {
        private readonly ICrudServiceBase<TDto, TKey> _crudService;

        public CrudControllerBase(ICrudServiceBase<TDto, TKey> crudService)
            => _crudService = crudService;

        [HttpGet]
        public async Task<IActionResult> GetAsync(TKey id)
        {
            var result = await _crudService.GetAsync(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(TDto dto)
        {
            var result = await _crudService.SaveAsync(dto);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(TKey id)
        {
            var result = await _crudService.DeleteAsync(id);

            return Ok(result);
        }
    }
}
