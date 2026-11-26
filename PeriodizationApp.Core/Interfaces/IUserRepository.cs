using PeriodizationApp.Core.Entities;

namespace PeriodizationApp.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id);
        Task<User> AddAsync(User user);
    }
}
