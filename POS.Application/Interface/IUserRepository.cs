using POS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Interface
{
    public interface IUserRepository
    {
        Task<Guid> CreateUser(User user);
        Task<Guid> UpdateUser(User user);
        Task<bool> DeleteUser(Guid id);
        Task<User> GetUserById(Guid id);
        Task<ICollection<User>> GetAllUsers();
        Task<ICollection<Order>> GetAllOrdersOfUser(Guid id);
        // I could also create a new entity and return that.
        //Task<ICollection<Order>> GenerateReport(Guid id);
    }
}
