using GDGHackathon.DAL.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGHackathon.DAL.Entities
{
    public class Product
    {
      
        public int Id { get; set; }
        public string Name { get; set; }
         
        public int Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
        public string Description { get; set; }
        public DateTime HarvestDate { get; set; }
        public string ImageUrl { get; set; }

        [ForeignKey("Farmer")]
        public string? FarmerId { get; set; }
        public ApplicationUser Farmer { get; set; }
        
    }
}
