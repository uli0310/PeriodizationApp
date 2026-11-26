using Microsoft.EntityFrameworkCore;
using PeriodizationApp.Core.Entities;
using PeriodizationApp.Core.Interfaces;

namespace PeriodizationApp.Infrastructure.Repositories
{
    public class MesocycleRepository : IMesocycleRepository
    {
        private readonly ApplicationDbContext _context;

        public MesocycleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Mesocycle?> GetByIdAsync(Guid id)
        {
            return await _context.Mesocycles.FindAsync(id);
        }

        public async Task<IEnumerable<Mesocycle>> GetByUserIdAsync(Guid userId)
        {
            return await _context.Mesocycles
                .Where(m => m.UserId == userId)
                .ToListAsync();
        }

        public async Task<Mesocycle> AddAsync(Mesocycle mesocycle)
        {
            await _context.Mesocycles.AddAsync(mesocycle);
            await _context.SaveChangesAsync();
            return mesocycle;
        }
    }
}
