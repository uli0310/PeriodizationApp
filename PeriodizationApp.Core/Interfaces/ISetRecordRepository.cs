using PeriodizationApp.Core.Entities;

namespace PeriodizationApp.Core.Interfaces
{
    public interface ISetRecordRepository
    {
        Task<IEnumerable<SetRecord>> GetAllAsync(Guid? userId = null);
        Task<IEnumerable<SetRecord>> GetBySessionIdAsync(Guid sessionId);
        Task<SetRecord> AddAsync(SetRecord setRecord);
        Task<IEnumerable<SetRecord>> GetByExerciseAsync(Guid exerciseId, Guid? userId = null);
        Task<bool> DeleteAsync(Guid id);
    }
}
