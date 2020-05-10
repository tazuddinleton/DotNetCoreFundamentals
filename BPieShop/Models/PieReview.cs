using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BPieShop.Models
{
    public class PieReview
    {
        public int PieReviewId { get; set; }
        public int PieId { get; set; }        
        public string Comment { get; set; }
        public int? ReviewedBy { get; set; }
        public DateTime DateReviewed { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }

        public Pie Pie { get; set; }
    }
}
