using Microsoft.AspNetCore.Mvc;
using mvoy.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvoy.core.Contracts
{
    public interface IUserRepository
    {
        /// <summary>
        /// Register a new record of branch data.
        /// </summary>
        /// <param name="branch">Branch's request</param>
        public Task<bool> CreateUser(User User);

        public IEnumerable<User> getAllUsers();

        /// <summary>
        /// Update a specific record of branch data.
        /// </summary>
        /// <param name="branch">Branch's request</param>
        public Task UpdateUser(User User);

        /// <summary>
        ///  Remove a specific record of branch data.
        /// </summary>
        /// <param name="branch">Branch's request</param>
        public Task<int> RemoveUser(Guid UserId);
    }
}
