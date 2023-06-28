using mvoy.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvoy.core.Interface
{
    public interface IUserService
    {
        public IEnumerable<User> GetAllUsers();
        public Task<int> SaveUser(User user);
        public Task<int> DeleteUser(string userId);
    }
}
