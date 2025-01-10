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
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context) {
            _context = context;
        }
        public Task<Guid> Create(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return Task.FromResult(order.Id);
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(Guid id)
        {
            var order = await GetById(id);
            if(order != null) {
                _context.Orders.Remove(order);
                _context.SaveChanges();
                return true;
            }
            return false;
            throw new NotImplementedException();
        }

        public async Task<string> GenerateSummary(int days)
        {
            var orders = await GetByDate(days);

            var totalSales = orders.Sum(o => o.ItemsOrdered.Sum(i => i.Price * i.Quantity));
            var numberOfOrders = orders.Count;
            var revenue = totalSales;

            var summary = new StringBuilder();
            summary.Append($"Summary for the last {days} days: ");
            summary.Append($"Total Sales: {totalSales} ");
            summary.Append($"Number of Orders: {numberOfOrders}");
            summary.Append($"Revenue: {revenue} ");

            return summary.ToString();
        }

        public Task<ICollection<Order>> GetAll()
        {
            var order = _context.Orders.Include(x => x.ItemsOrdered).ToList();
            return Task.FromResult((ICollection<Order>)order);
            throw new NotImplementedException();
        }

        public async Task<ICollection<Order>> GetByDate(int days)
        {
            var dateThreshold = DateTime.UtcNow.AddDays(-days);
            var res = _context.Orders
                .Include(x => x.ItemsOrdered)
                                 .Where(order => order.Created >= dateThreshold)
                                 .ToList();
            return res;
        }
        public Task<Order> GetById(Guid id)
        {
            var order = _context.Orders.Include(x => x.ItemsOrdered).FirstOrDefault(x => x.Id == id);
            return Task.FromResult(order);
            throw new NotImplementedException();
        }

        public Task<Guid> Update(Order order)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> UpdateOrderStage(Guid OrderId, string stage)
        {
            var order = await GetById(OrderId);
            order.Stage = stage;
            _context.Orders.Update(order);
            _context.SaveChanges();
            return order.Id;
            throw new NotImplementedException();
        }
    }
}
