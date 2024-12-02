using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGHackathon.DAL.Entities.Identity
{
    public class ApplicationUser:IdentityUser
    {
        public string Role { get; set; }
        public string? Address {  get; set; }
        public ICollection<Product> Products { get; set; } // A user can have many products (for Farmer)
        public ICollection<Order> PlacedOrders { get; set; } //wholesaler
        public ICollection<Order> ReceivedOrders { get; set; } //farmer
        public ICollection<Shipment> Shipments { get; set; } // A user can manage many shipments (for ShippingCompany)
        public ICollection<Rating> RatingsGiven { get; set; } // Ratings a user gives
        public ICollection<Rating> RatingsReceived { get; set; }

    }
}
