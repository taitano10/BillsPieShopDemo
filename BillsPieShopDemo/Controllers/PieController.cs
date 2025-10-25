using BillsPieShopDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace BillsPieShopDemo.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List()
        {
            var pies = _pieRepository.AllPies;
            return View(pies);
        }
    }
}
