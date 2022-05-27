using BackEnd_1.Task.DAL;
using BackEnd_1.Task.Models;
using BackEnd_1.Task.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_1.Task.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public async Task<IActionResult> Index()
        { 
            HomeVM model = new HomeVM
            {
                Sliders = await _context.Sliders.ToListAsync(),
                Cards = await _context.Cards.ToListAsync(),
                Plants = await _context.Plants.Include(p=>p.PlantImages).ToListAsync(),
            };
            return View(model);
        }
        public HomeController(AppDbContext context)
        {

            _context = context;
        }
    }
}
