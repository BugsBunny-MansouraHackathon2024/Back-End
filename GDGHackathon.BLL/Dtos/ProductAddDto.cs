using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGHackathon.BLL.Dtos
{
    public class ProductAddDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
         
        public DateTime HarvestDate { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        

    }
}
