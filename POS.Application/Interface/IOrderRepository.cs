using POS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Interface
{
    public interface IOrderRepository
    {
        public Task<Guid> Create(Order order);
        public Task<Order> GetById(Guid id);
        public Task<ICollection<Order>> GetAll();
        public Task<Guid> Update(Order order);
        public Task<bool> Delete(Guid id);
        public Task<Guid> UpdateOrderStage(Guid id, string stage);
    }
}
