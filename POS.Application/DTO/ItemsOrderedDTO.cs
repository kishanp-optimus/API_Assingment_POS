using POS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.DTO
{
    public class ItemsOrderedDTO
    {
        public Guid ItemID { get; set; }
        public Guid OrderID { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
