using Microsoft.AspNetCore.Mvc;
using PeriodizationApp.Core.Entities;
using PeriodizationApp.Core.Interfaces;

namespace PeriodizationApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutSessionsController : ControllerBase
    {
        private readonly IWorkoutSessionRepository _sessionRepository;

        public WorkoutSessionsController(IWorkoutSessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var session = await _sessionRepository.GetByIdAsync(id);
            if (session == null) return NotFound();
            return Ok(session);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSession(WorkoutSession session)
        {
            if (session.Id == Guid.Empty)
            {
                session.Id = Guid.NewGuid();
            }

            session.ScheduledDate = DateTime.SpecifyKind(session.ScheduledDate, DateTimeKind.Utc);
            if (session.CompletedDate.HasValue)
            {
                session.CompletedDate = DateTime.SpecifyKind(session.CompletedDate.Value, DateTimeKind.Utc);
            }

            var newSession = await _sessionRepository.AddAsync(session);
            return Ok(newSession);
        }

        [HttpGet("mesocycle/{mesocycleId:guid}")]
        public async Task<IActionResult> GetByMesocycleId(Guid mesocycleId)
        {
            var sessions = await _sessionRepository.GetByMesocycleIdAsync(mesocycleId);
            return Ok(sessions);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateSession(Guid id, WorkoutSession session)
        {
            if (id != session.Id) return BadRequest();
            var updated = await _sessionRepository.UpdateAsync(session);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteSession(Guid id)
        {
            var deleted = await _sessionRepository.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
