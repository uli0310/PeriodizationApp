using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeriodizationApp.Core.Entities;
using PeriodizationApp.Infrastructure;

namespace PeriodizationApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MesocycleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MesocycleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Mesocycle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mesocycle>>> GetMesocycles()
        {
            return await _context.Mesocycles.ToListAsync();
        }

        // GET: api/Mesocycle/user/{userId}
        [HttpGet("user/{userId:guid}")]
        public async Task<ActionResult<IEnumerable<Mesocycle>>> GetByUserId(Guid userId)
        {
            return await _context.Mesocycles
                .Where(m => m.UserId == userId)
                .ToListAsync();
        }

        // GET: api/Mesocycle/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Mesocycle>> GetMesocycle(Guid id)
        {
            var mesocycle = await _context.Mesocycles.FindAsync(id);

            if (mesocycle == null)
            {
                return NotFound();
            }

            return mesocycle;
        }

        // POST: api/Mesocycle
        [HttpPost]
        public async Task<ActionResult<Mesocycle>> PostMesocycle(Mesocycle mesocycle)
        {
            if (mesocycle.Id == Guid.Empty)
            {
                mesocycle.Id = Guid.NewGuid();
            }

            mesocycle.StartDate = DateTime.SpecifyKind(mesocycle.StartDate, DateTimeKind.Utc);
            mesocycle.EndDate = DateTime.SpecifyKind(mesocycle.EndDate, DateTimeKind.Utc);

            _context.Mesocycles.Add(mesocycle);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMesocycle), new { id = mesocycle.Id }, mesocycle);
        }

        // PUT: api/Mesocycle/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> PutMesocycle(Guid id, Mesocycle mesocycle)
        {
            if (id != mesocycle.Id)
            {
                return BadRequest("El ID de la URL no coincide con el ID del mesociclo.");
            }

            mesocycle.StartDate = DateTime.SpecifyKind(mesocycle.StartDate, DateTimeKind.Utc);
            mesocycle.EndDate = DateTime.SpecifyKind(mesocycle.EndDate, DateTimeKind.Utc);

            _context.Entry(mesocycle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await MesocycleExistsAsync(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // DELETE: api/Mesocycle/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteMesocycle(Guid id)
        {
            var mesocycle = await _context.Mesocycles.FindAsync(id);
            if (mesocycle == null)
            {
                return NotFound();
            }

            // Desvincular series de las sesiones de este mesociclo para conservar el historial de fuerza del atleta
            var sessionIds = await _context.WorkoutSessions
                .Where(ws => ws.MesocycleId == id)
                .Select(ws => ws.Id)
                .ToListAsync();

            if (sessionIds.Any())
            {
                var linkedSets = await _context.SetRecords
                    .Where(sr => sr.WorkoutSessionId.HasValue && sessionIds.Contains(sr.WorkoutSessionId.Value))
                    .ToListAsync();

                foreach (var set in linkedSets)
                {
                    set.WorkoutSessionId = null;
                }
            }

            _context.Mesocycles.Remove(mesocycle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> MesocycleExistsAsync(Guid id)
        {
            return await _context.Mesocycles.AnyAsync(e => e.Id == id);
        }
    }
}
