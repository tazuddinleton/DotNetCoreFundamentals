using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BPieShop.Models;
using BPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BPieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly IPieCategoryRepository _pieCategoryRepository;


        public HomeController(IPieRepository pieRepository, IPieCategoryRepository pieCategoryRepository)
        {
            _pieRepository = pieRepository;
            _pieCategoryRepository = pieCategoryRepository;
        }

        public IActionResult Index(string category)
        {
            var data = new PiesLiestViewModel();
            Func<Pie, bool> searchByCategory = pie => pie.CategoryId == _pieCategoryRepository.GetByName(category).CategoryId;

            if (string.IsNullOrEmpty(category))
                data.Pies = _pieRepository.AllPies;
            else
                data.Pies = _pieRepository.AllPies.Where(searchByCategory);

            
            ViewBag.Categories = _pieCategoryRepository.Categories;
            
            return View(data);
        }

        [HttpGet]
        public IActionResult PieDetail(int id)
        {
            ViewBag.Categories = _pieCategoryRepository.Categories;
            return View(_pieRepository.GetPieById(id));
        }
    }
}