using Microsoft.AspNetCore.Mvc;
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
        public async Task<bool> CreateUser(User user)
        {
            try
            {
                _context.users.Add(user);
                
                return await _context.SaveChangesAsync()==1;
            }
            catch (Exception ex)
            {
                return false;
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

        public async Task<int> RemoveUser(Guid UserId)
        {
            try
            {
                try
                {
                    User user = await _context.users.FindAsync(UserId);
                    _context.users.Remove(user);
                    _context.SaveChanges();
                    return 1;
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task UpdateUser(User User)
        {
            throw new NotImplementedException();
        }
    }
}
