using BackEnd_1.Task.DAL;
using BackEnd_1.Task.Models;
using BackEnd_1.Task.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd_1.Task.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public IActionResult Index()
        { 
            List<Slider> sliders = _context.Sliders.ToList();
            List<Card> cards = _context.Cards.ToList();


            HomeVM model = new HomeVM
            {
                Sliders = sliders,
                Cards = cards,
            };
            return View(model);
        }
        public HomeController(AppDbContext context)
        {

            _context = context;
        }
    }
}
