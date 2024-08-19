using CustomerServiceApp.WebAPI.Database;
using CustomerServiceApp.WebAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CustomerServiceApp.WebAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CustomerServiceAppDBContext _context;

        public UserRepository(CustomerServiceAppDBContext context)
        {
            _context = context;
        }

        public async Task<User> GetByIdAsync(int userId)
        {
            return await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Employee)
                .FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Employee)
                .ToListAsync();
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int userId)
        {
            //soft delete implemented
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                user.Valid = false;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
