using Manager.Domain.Entities;
using Manager.Infra.Context;
using Manager.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ManagerContext _context;

        public UserRepository(ManagerContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = await _context.User
                .Where(x => x.Email.ToLower() == email.ToLower())
                .AsNoTracking()
                .ToListAsync();

            return user.FirstOrDefault();
        }

        public async Task<User> GetByEmail(string email)
        {
            var allUsers = await _context.User
                .Where(x => x.Email.ToLower().Contains(email.ToLower())
                .AsNoTracking()
                .ToListAsync();

            return allUsers;
        }

        public async Task<User> GetByName(string name)
        {
            var allUsers = await _context.User
                .Where(x => x.name.ToLower().Contains(name.ToLower())
                .AsNoTracking()
                .ToListAsync();

            return allUsers;
        }
    }
}
