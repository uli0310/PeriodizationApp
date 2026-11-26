using PeriodizationApp.Core.Entities;

namespace PeriodizationApp.Core.Interfaces
{
    public interface IMesocycleRepository
    {
        Task<Mesocycle?> GetByIdAsync(Guid id);
        Task<IEnumerable<Mesocycle>> GetByUserIdAsync(Guid userId);
        Task<Mesocycle> AddAsync(Mesocycle mesocycle);
    }
}
