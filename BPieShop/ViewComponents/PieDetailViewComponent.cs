using BPieShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPieShop.ViewComponents
{
    public class PieDetailViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke(Pie pie)
        {
            return View(pie);
        }
    }
}
