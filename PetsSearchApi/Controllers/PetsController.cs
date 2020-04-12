using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetsSearchApplication.Constants;
using PetsSearchApplication.Interfaces;

namespace PetsSearchApi.Controllers
{
    [ApiController]
    [Route("pets")]
    public class PetsController : ControllerBase
    {
        private readonly IPetsService _service;
        public PetsController(IPetsService service)
        {
            _service = service;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAsync()
        {
            var petsDto = await _service.GetAllAsync(PetTypeEnum.Cat);

            return Ok(petsDto);
        }

        [HttpGet("{category:petTypeEnum}")]
        public async Task<IActionResult> GetProductsByCategory(PetTypeEnum category)
        {
            var petsDto = await _service.GetAllAsync(category);

            return Ok(petsDto);
        }
    }
}
