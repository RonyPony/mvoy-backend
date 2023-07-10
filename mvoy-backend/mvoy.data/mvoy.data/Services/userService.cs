using mvoy.core.Contracts;
using mvoy.core.Interface;
using mvoy.core.Models;
using mvoy.data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvoy.data.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        
        public UserService(IUserRepository rep) 
        {
            _repo= rep;
        }

        public Task<int> createContactInfo(UserContactInfo user)
        {
            return _repo.CreateUserContactInfo(user);
        }

        public Task<int> DeleteUser(Guid userId)
        {
           return _repo.RemoveUser(userId);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _repo.getAllUsers();
        }


        public Task removeContactInfo(int contactInfoId)
        {
            return _repo.removeContactInfo(contactInfoId);
        }

        public async Task<bool> SaveUser(User user)
        {
            return await _repo.CreateUser(user);
        }

        async Task<int> IUserService.DeleteUser(Guid userId)
        {
            return await _repo.RemoveUser(userId);
        }
    }
}
