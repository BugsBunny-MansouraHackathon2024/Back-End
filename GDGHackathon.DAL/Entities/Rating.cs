using GDGHackathon.DAL.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGHackathon.DAL.Entities
{
    public class Rating
    {
        public int RatingId { get; set; }
        public string RatedByUserId { get; set; }
        public string RatedUserId { get; set; }
        public int RatingValue { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }

        public ApplicationUser RatedByUser { get; set; }
        public ApplicationUser RatedUser { get; set; }
    }
}
