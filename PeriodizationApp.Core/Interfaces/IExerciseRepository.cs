using PeriodizationApp.Core.Entities;

namespace PeriodizationApp.Core.Interfaces
{
    public interface IExerciseRepository
    {
        // Traerá todo el catálogo para cuando quieras elegir un ejercicio
        Task<IEnumerable<Exercise>> GetAllAsync();
        Task<Exercise?> GetByIdAsync(Guid id);
        Task<Exercise> AddAsync(Exercise exercise);
    }
}
