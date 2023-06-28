using mvoy.core.Contracts;
using mvoy.core.Interface;
using mvoy.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvoy.data.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        public Task<bool> DeleteUser(string userId)
        {
           return _repo.RemoveUser(userId);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _repo.getAllUsers();
        }

        public async Task<int> SaveUser(User user)
        {
            return await _repo.CreateUser(user);
        }

        Task<int> IUserService.DeleteUser(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
