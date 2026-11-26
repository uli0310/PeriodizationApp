using Microsoft.EntityFrameworkCore;
using PeriodizationApp.Core.Entities;
using PeriodizationApp.Core.Interfaces;

namespace PeriodizationApp.Infrastructure.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly ApplicationDbContext _context;

        public ExerciseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Exercise>> GetAllAsync()
        {
            return await _context.Exercises.ToListAsync();
        }

        public async Task<Exercise?> GetByIdAsync(Guid id)
        {
            return await _context.Exercises.FindAsync(id);
        }

        public async Task<Exercise> AddAsync(Exercise exercise)
        {
            await _context.Exercises.AddAsync(exercise);
            await _context.SaveChangesAsync();
            return exercise;
        }
    }
}