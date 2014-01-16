using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.Framework;

namespace FlowerShop.Models
{
    public class OrderStatus
    {
        public int Id { get; set; }

        [DisplayName("Estatus")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Numero Estatus")]
        [Required]
        public int StatusNumber { get; set; }

    }
}
