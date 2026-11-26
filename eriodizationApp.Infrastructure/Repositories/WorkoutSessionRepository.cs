using Microsoft.EntityFrameworkCore;
using PeriodizationApp.Core.Entities;
using PeriodizationApp.Core.Interfaces;

namespace PeriodizationApp.Infrastructure.Repositories
{
    public class WorkoutSessionRepository : IWorkoutSessionRepository
    {
        private readonly ApplicationDbContext _context;

        public WorkoutSessionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<WorkoutSession?> GetByIdAsync(Guid id)
        {
            return await _context.WorkoutSessions.FindAsync(id);
        }

        public async Task<IEnumerable<WorkoutSession>> GetByMesocycleIdAsync(Guid mesocycleId)
        {
            return await _context.WorkoutSessions
                .Where(ws => ws.MesocycleId == mesocycleId)
                .OrderBy(ws => ws.ScheduledDate)
                .ToListAsync();
        }

        public async Task<WorkoutSession> AddAsync(WorkoutSession session)
        {
            await _context.WorkoutSessions.AddAsync(session);
            await _context.SaveChangesAsync();
            return session;
        }

        public async Task<bool> UpdateAsync(WorkoutSession session)
        {
            var existing = await _context.WorkoutSessions.FindAsync(session.Id);
            if (existing == null) return false;

            existing.Name = session.Name;
            existing.ScheduledDate = DateTime.SpecifyKind(session.ScheduledDate, DateTimeKind.Utc);
            existing.CompletedDate = session.CompletedDate.HasValue
                ? DateTime.SpecifyKind(session.CompletedDate.Value, DateTimeKind.Utc)
                : null;
            existing.ReadinessScore = session.ReadinessScore;
            existing.SessionRPE = session.SessionRPE;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _context.WorkoutSessions.FindAsync(id);
            if (existing == null) return false;

            _context.WorkoutSessions.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
