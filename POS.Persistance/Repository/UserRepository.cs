using Microsoft.EntityFrameworkCore;
using POS.Application.Interface;
using POS.Domain.Entity;
using POS.Persistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Persistance.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) {
            _context = context;
        }
        public Task<Guid> CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return Task.FromResult(user.Id);
        }

        public Task<bool> DeleteUser(Guid UserId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == UserId);
            if (user != null) {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
            throw new NotImplementedException();
        }

        //public Task<ICollection<Order>> GenerateReport(Guid id)
        //{
        //    var report = _context.Users.Include(x => x.Orders).FirstOrDefault(x => x.Id == id);
        //    return Task.FromResult((ICollection<Order>)report.Orders.ToList());
        //    throw new NotImplementedException();
        //}

        public Task<ICollection<Order>> GetAllOrdersOfUser(Guid userId)
        {
            var user = _context.Users.Include(x => x.Orders).FirstOrDefault(x => x.Id == userId);
            if (user != null)
            {
                return Task.FromResult(user.Orders.ToList() as ICollection<Order>);
            }
            return Task.FromResult<ICollection<Order>>(null);
        }

        public Task<ICollection<User>> GetAllUsers()
        {
            var users = _context.Users.Include(x => x.Orders).ToList();
            return Task.FromResult((ICollection<User>)users);
            throw new NotImplementedException();
        }

        public Task<User> GetUserById(Guid id)
        {
            var user = _context.Users.Include(x => x.Orders).FirstOrDefault(x => x.Id == id);
            return Task.FromResult(user);
            throw new NotImplementedException();
        }

        public Task<Guid> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
