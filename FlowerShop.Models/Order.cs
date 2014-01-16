using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int Invoice { get; set; }

        public bool IsDelivery { get; set; }

        public string DeliveryName { get; set; }

        public string DeliveryAddress { get; set; }

        public string DeliveryPhone { get; set; }

        public bool? ContactDelivery { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public DateTime DeliveryHour { get; set; }

        public int OrderStatusId { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public int? DriverId { get; set; }

        public Driver Driver { get; set; }

        public ICollection<OrderStatusChange> OrderStatusChanges { get; set; }
    }
}
