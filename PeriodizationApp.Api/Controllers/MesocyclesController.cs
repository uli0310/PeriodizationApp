using Microsoft.AspNetCore.Mvc;
using PeriodizationApp.Core.Entities;
using PeriodizationApp.Core.Interfaces;

namespace PeriodizationApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MesocyclesController : ControllerBase
    {
        private readonly IMesocycleRepository _mesocycleRepository;

        public MesocyclesController(IMesocycleRepository mesocycleRepository)
        {
            _mesocycleRepository = mesocycleRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMesocycle(Mesocycle mesocycle)
        {
            var newMesocycle = await _mesocycleRepository.AddAsync(mesocycle);
            return Ok(newMesocycle);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUserId(Guid userId)
        {
            var mesocycles = await _mesocycleRepository.GetByUserIdAsync(userId);
            return Ok(mesocycles);
        }
    }
}
