using mvoy.core.Contracts;
using mvoy.core.Models;
using mvoy.data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvoy.data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MvoyContext _context;
        public UserRepository(MvoyContext ctx)
        {
            _context = ctx;
        }
        public async Task<int> CreateUser(User user)
        {
            try
            {
                user.CreationDate = DateTime.Now;
                user.IsDeleted = false;
                _context.users.Add(user);
                var x = await _context.SaveChangesAsync();
                return x;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public IEnumerable<User> getAllUsers()
        {
            try
            {
                var users = _context.users.ToList();
                return users;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<bool> RemoveUser(string UserId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(User User)
        {
            throw new NotImplementedException();
        }
    }
}
