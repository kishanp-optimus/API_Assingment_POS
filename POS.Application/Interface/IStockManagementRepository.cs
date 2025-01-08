using POS.Application.DTO;
using POS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Interface
{
    public interface IStockManagementRepository
    {
        bool StockDeduction(ItemsOrdered ItemOrdered);
    }
}
