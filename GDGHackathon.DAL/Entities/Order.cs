using GDGHackathon.DAL.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGHackathon.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string WholesalerId { get; set; }
        public string FarmerId { get; set; }
        public int QuantityOrdered { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public Product Product { get; set; }
        public ApplicationUser Wholesaler { get; set; }
        public ApplicationUser Farmer { get; set; }
        public Payment Payment { get; set; } // Payment for the order
        public Shipment Shipment { get; set; } // Shipment associated with the order
    }

}
