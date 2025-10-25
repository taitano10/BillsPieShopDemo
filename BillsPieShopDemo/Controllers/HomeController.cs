using BillsPieShopDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace BillsPieShopDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;
        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public IActionResult Index()
        {
            var piesOfTheWeek = _pieRepository.PiesOfTheWeek;
            var homeViewModel = new ViewModels.HomeViewModel(piesOfTheWeek);
            return View(homeViewModel);
        }
    }
}
