using GDGHackathon.DAL.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGHackathon.DAL.Entities
{
    public class Shipment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string ShippingCompanyId { get; set; }
        public DateTime ShipmentDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string Status { get; set; }

        public Order Order { get; set; }
        public ApplicationUser ShippingCompany { get; set; }
    }
}
