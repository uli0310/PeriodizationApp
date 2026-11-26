using Microsoft.AspNetCore.Mvc;
using PeriodizationApp.Core.Entities;
using PeriodizationApp.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace PeriodizationApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SetRecordsController : ControllerBase
    {
        private readonly ISetRecordRepository _setRepository;

        public SetRecordsController(ISetRecordRepository setRepository)
        {
            _setRepository = setRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] Guid? userId = null)
        {
            var sets = await _setRepository.GetAllAsync(userId);
            return Ok(sets);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSetRecord(SetRecord setRecord)
        {
            if (setRecord.Id == Guid.Empty)
            {
                setRecord.Id = Guid.NewGuid();
            }

            var newSet = await _setRepository.AddAsync(setRecord);
            return Ok(newSet);
        }

        [HttpGet("session/{sessionId:guid}")]
        public async Task<IActionResult> GetBySessionId(Guid sessionId)
        {
            var sets = await _setRepository.GetBySessionIdAsync(sessionId);
            return Ok(sets);
        }

        [HttpGet("exercise/{exerciseId:guid}")]
        public async Task<IActionResult> GetExerciseHistory(Guid exerciseId, [FromQuery] Guid? userId = null)
        {
            try
            {
                var history = await _setRepository.GetByExerciseAsync(exerciseId, userId);
                return Ok(history);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener el historial: {ex.Message}");
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteSetRecord(Guid id)
        {
            var deleted = await _setRepository.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
