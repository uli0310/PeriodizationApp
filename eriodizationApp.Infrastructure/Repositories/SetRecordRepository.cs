using Microsoft.EntityFrameworkCore;
using PeriodizationApp.Core.Entities;
using PeriodizationApp.Core.Interfaces;

namespace PeriodizationApp.Infrastructure.Repositories
{
    public class SetRecordRepository : ISetRecordRepository
    {
        private readonly ApplicationDbContext _context;

        public SetRecordRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SetRecord>> GetAllAsync(Guid? userId = null)
        {
            var query = _context.SetRecords.AsQueryable();
            if (userId.HasValue && userId.Value != Guid.Empty)
            {
                query = query.Where(sr =>
                    sr.UserId == userId.Value ||
                    (sr.UserId == null && sr.WorkoutSession != null && sr.WorkoutSession.Mesocycle != null && sr.WorkoutSession.Mesocycle.UserId == userId.Value));
            }

            return await query
                .OrderBy(sr => sr.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<SetRecord>> GetBySessionIdAsync(Guid sessionId)
        {
            return await _context.SetRecords
                .Where(sr => sr.WorkoutSessionId == sessionId)
                .OrderBy(sr => sr.SetNumber)
                .ThenBy(sr => sr.Id)
                .ToListAsync();
        }

        public async Task<SetRecord> AddAsync(SetRecord setRecord)
        {
            setRecord.Calculate1RM();

            await _context.SetRecords.AddAsync(setRecord);
            await _context.SaveChangesAsync();
            return setRecord;
        }

        public async Task<IEnumerable<SetRecord>> GetByExerciseAsync(Guid exerciseId, Guid? userId = null)
        {
            var query = _context.SetRecords
                .Where(record => record.ExerciseId == exerciseId);

            if (userId.HasValue && userId.Value != Guid.Empty)
            {
                query = query.Where(sr =>
                    sr.UserId == userId.Value ||
                    (sr.UserId == null && sr.WorkoutSession != null && sr.WorkoutSession.Mesocycle != null && sr.WorkoutSession.Mesocycle.UserId == userId.Value));
            }

            return await query
                .OrderBy(record => record.Id)
                .ToListAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var record = await _context.SetRecords.FindAsync(id);
            if (record == null) return false;

            _context.SetRecords.Remove(record);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
