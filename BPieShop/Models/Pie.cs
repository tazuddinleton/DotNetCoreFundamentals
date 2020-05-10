using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BPieShop.Models
{
    public class Pie
    {
        public int PieId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string AllergyInformation { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool IsPieOfTheWeek { get; set; }
        public bool InStock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<PieReview> Reviews { get; set; }

        public Pie()
        {
            Reviews = new List<PieReview>();

           
        }
        public double GetRating()
        {
            var group = Reviews.GroupBy(x => x.Rating).ToList();            
            double weight = 0;
            double totalOccurance = 0;
            group.ForEach(x =>
            {
                weight += x.Key * x.Count();
                totalOccurance += x.Count();
            });

            var result = Math.Ceiling(weight / (totalOccurance > 0 ? totalOccurance : 1));
            return result;
        }
    }
}
