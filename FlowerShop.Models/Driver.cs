using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.Framework;

namespace FlowerShop.Models
{
    public class Driver
    {
        public int Id { get; set; }

        [DisplayName("Nombre")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Telefono")]
        [Required]
        public string PhoneNumber { get; set; }

        [DisplayName("Numero Taxi")]
        [Required]
        public string CarNumber { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateModified { get; set; }

        public int UserId { get; set; }

        //public User User { get; set; }

        public bool Active { get; set; }
    }
}
