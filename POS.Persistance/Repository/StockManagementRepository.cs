using POS.Application.Interface;
using POS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Persistance.Repository
{
    internal class StockManagementRepository : IStockManagementRepository
    {
        public bool StockDeduction(ItemsOrdered ItemOrdered)
        {
            // Find the particular item in the database, and if the quantity is greater than the quantity to be deducted, deduct the quantity and return true
            // Otherwise, return false
            throw new NotImplementedException();
        }
    }
}
