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
    public class ItemRepository : IItemsRepository
    {
        private readonly ApplicationDbContext _context;
        public ItemRepository(ApplicationDbContext context) {
            _context = context;
        }
        public Task<Guid> Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return Task.FromResult(item.Id);
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            var item = _context.Items.FirstOrDefault(x => x.Id == id);
            if (item != null) {
                _context.Items.Remove(item);
                _context.SaveChanges();
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
            throw new NotImplementedException();
        }

        public Task<ICollection<Item>> GetAll()
        {
            var items = _context.Items.Include(x => x.ItemsOrdered).ToList();
            return Task.FromResult((ICollection<Item>)items);
        }

        public Task<Item> GetById(Guid id)
        {
            var item = _context.Items.Include(x => x.ItemsOrdered).FirstOrDefault(x => x.Id == id);
            return Task.FromResult(item);
            throw new NotImplementedException();
        }

        public Task<Guid> Update(Item item)
        {
            _context.Items.Update(item);
            return Task.FromResult(item.Id);
        }
    }
}
