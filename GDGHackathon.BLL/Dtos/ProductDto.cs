using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGHackathon.BLL.Dtos
{
    public class ProductDto
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime HarvestDate { get; set; }
        public string ImageUrl { get; set; }

        [ForeignKey("Farmer")]
        public string FarmerId { get; set; }


    }
}
