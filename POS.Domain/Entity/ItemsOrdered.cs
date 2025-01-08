using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Entity
{
    public class ItemsOrdered
    {
        public Guid Id { get; set; }
        public Guid ItemID { get; set; }
        public Item Item { get; set; }
        public Guid OrderID { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
