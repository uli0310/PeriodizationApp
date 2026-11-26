using PeriodizationApp.Core.Entities;

namespace PeriodizationApp.Core.Interfaces
{
    public interface ISetRecordRepository
    {
        Task<IEnumerable<SetRecord>> GetAllAsync();
        Task<IEnumerable<SetRecord>> GetBySessionIdAsync(Guid sessionId);
        Task<SetRecord> AddAsync(SetRecord setRecord);
        Task<IEnumerable<SetRecord>> GetByExerciseAsync(Guid exerciseId);
        Task<bool> DeleteAsync(Guid id);
    }
}
