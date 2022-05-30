using BackEnd_1.Task.Areas.Extensisons;
using BackEnd_1.Task.DAL;
using BackEnd_1.Task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd_1.Task.Areas.ProniaAdmin.Controllers
{
    [Area("ProniaAdmin")]
    public class PlantController : Controller
    {
        private readonly AppDbContext _context;

        public PlantController(AppDbContext context)
        {
            _context=context;
        }

        public async Task<IActionResult> Index()
        {

            List<Plant> plants = await _context.Plants.Include(p => p.PlantImages).ToListAsync();
            return View(plants);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Sizes = await _context.Sizes.ToListAsync();
            ViewBag.Colors = await _context.Colors.ToListAsync();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Create(Plant plant)
        {
            ViewBag.Sizes = await _context.Sizes.ToListAsync();
            ViewBag.Colors = await _context.Colors.ToListAsync();
            if(!ModelState.IsValid) return View();

            if (plant.MainImage==null || plant.AnotherImages==null)
            {
                ModelState.AddModelError("","Please choose image");
                return View();

            }

            if (plant.MainImage.IsOkey(1))
            {
                ModelState.AddModelError("MainImage", "Please choose image file and max 1Mb length image");
                return View();
            }

            foreach (var another in plant.AnotherImages)
            {
                if (another.IsOkey(1))
                {
                    ModelState.AddModelError("MainImage", "Please choose image file and max 1Mb length image");
                    return View();
                }
            }
            return Content("okkkeeyy");
        }
    }
}
