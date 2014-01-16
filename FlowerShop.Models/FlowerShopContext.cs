using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Models
{
    public class FlowerShopContext : DbContext
    {
        public DbSet<Driver> Drivers { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderStatus> OrderStatuses { get; set; }

        public DbSet<OrderStatusChange> OrderStatusChanges { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderStatusChange>().HasRequired(x => x.Order).WithMany(t => t.OrderStatusChanges).HasForeignKey(
                x => x.OrderId).WillCascadeOnDelete(false);
            modelBuilder.Entity<OrderStatusChange>().HasRequired(x => x.OrderStatus).WithMany().HasForeignKey(
                x => x.OrderStatusId).WillCascadeOnDelete(false);
        }
    }
}
