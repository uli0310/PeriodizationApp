using PeriodizationApp.Core.Entities;

namespace PeriodizationApp.Core.Interfaces
{
    public interface IWorkoutSessionRepository
    {
        Task<WorkoutSession?> GetByIdAsync(Guid id);
        Task<IEnumerable<WorkoutSession>> GetByMesocycleIdAsync(Guid mesocycleId);
        Task<WorkoutSession> AddAsync(WorkoutSession session);
        Task<bool> UpdateAsync(WorkoutSession session);
        Task<bool> DeleteAsync(Guid id);
    }
}
