using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPieShop.Models
{
    public class PieRepository : IPieRepository
    {

        List<Pie> _pies = new List<Pie>();
        public PieRepository()
        {
            _pies.Add(new Pie() {PieId = 1, Name = "Strawberry Pie", Price = 15.95M, CategoryId=1, ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet numquam aspernatur!" });
            _pies.Add(new Pie() { PieId = 2, Name = "Cheese Cake", Price = 15.95M, CategoryId = 2, ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet numquam aspernatur!" });
            _pies.Add(new Pie() { PieId = 3, Name = "Pumpkin Pie", Price = 15.95M, CategoryId = 3, ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet numquam aspernatur!" });
            _pies.Add(new Pie() { PieId = 4, Name = "Chicken Pie", Price = 15.95M, CategoryId = 3, ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet numquam aspernatur!" });
        }

        public IEnumerable<Pie> AllPies => _pies;

        public IEnumerable<Pie> PiesOfTheWeek => _pies.Where(x => x.IsPieOfTheWeek);

        public Pie GetPieById(int id)
        {
            return _pies.FirstOrDefault(x => x.PieId == id);
        }
    }
}
