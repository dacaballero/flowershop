using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Models
{
    public class OrderStatusChange
    {
        public int Id { get; set; }

        public DateTime DateChanged { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int OrderStatusId { get; set; }

        public OrderStatus OrderStatus { get; set; }

    }
}
