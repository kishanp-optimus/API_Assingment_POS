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
    public class ItemOrderedRepository : IItemsOrderedRepository
    {
        private readonly ApplicationDbContext _context;
        public ItemOrderedRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Guid> Create(ItemsOrdered itemsOrdered)
        {
            _context.ItemsOrdered.Add(itemsOrdered);
            return Task.FromResult(itemsOrdered.Id);
        }

        public Task<bool> Delete(Guid id)
        {
            var ItemOrdered = _context.ItemsOrdered.FirstOrDefault(x => x.Id == id);
            if (ItemOrdered != null) { 
                _context.ItemsOrdered.Remove(ItemOrdered);
                _context.SaveChanges();
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
            throw new NotImplementedException();
        }
    }
}
