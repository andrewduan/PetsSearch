using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            var petsDto = await _service.GetAllAsync();

            return Ok(petsDto);
        }
    }
}
