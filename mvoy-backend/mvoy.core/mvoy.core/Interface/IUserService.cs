﻿using mvoy.core.Models;
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
        public Task<User> GetUserById(Guid id);
        public Task<User> getUserByEmail(string email);
        public Task<User> SaveUser(User user);
        public Task<int> DeleteUser(Guid userId);
        public Task<int> createContactInfo(UserContactInfo user);
        Task removeContactInfo(int contactInfoId);
    }
}
