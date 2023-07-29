using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                _context.ChangeTracker.Clear();
                return false;
            }
        }

        public async Task<int> CreateUserContactInfo(UserContactInfo UserInfo)
        {
            try
            {
                _context.usersContactInfo.Add(UserInfo);

                await _context.SaveChangesAsync();
                return UserInfo.Id;
            }
            catch (Exception ex)
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

        public async Task<User> getUserByEmailAsync(string _email)
        {
            try
            {
                User user = _context.users.Where((ee)=>ee.email == _email).FirstOrDefault();
                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User> getUserByIdAsync(Guid id)
        {
            try
            {
                User user = await _context.users.FindAsync(id);
                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task removeContactInfo(int contactInfoId)
        {
            try
            {
                UserContactInfo ci = await _context.usersContactInfo.FindAsync(contactInfoId);
                ////_context.Entry(ci).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                ci.isDeleted = true;
                _context.Update(ci);
                _context.SaveChanges();
                //_context.Entry(ci).State = EntityState.Deleted;
                //_context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
