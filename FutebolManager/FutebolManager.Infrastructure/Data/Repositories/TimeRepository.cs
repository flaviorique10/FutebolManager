using FutebolManager.Core.Interfaces;
using FutebolManager.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace FutebolManager.Infrastructure.Data.Repositories
{
    public class TimeRepository : ITimeRepository
    {
        private readonly AppDbContext _context;

        public TimeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Time time)
        {
            await _context.Times.AddAsync(time);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var time = await _context.Times.FindAsync(id);

            if (time != null)
            {
                _context.Times.Remove(time);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Time>> GetAllAsync()
        {
            return await _context.Times.ToListAsync();
        }

        public async Task<Time> GetByIdAsync(int id)
        {
            return await _context.Times.FindAsync(id);
        }

        public async Task UpdateAsync(Time time)
        {
            _context.Times.Update(time);
            await _context.SaveChangesAsync();
        }
    }
}
