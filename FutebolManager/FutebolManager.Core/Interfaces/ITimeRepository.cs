using FutebolManager.Core.Model;

namespace FutebolManager.Core.Interfaces
{
    public interface ITimeRepository
    {
        Task<List<Time>> GetAllAsync();
        Task<Time> GetByIdAsync(int id);
        Task AddAsync(Time time);
        Task UpdateAsync(Time time);
        Task DeleteAsync(int id);
    }
}
