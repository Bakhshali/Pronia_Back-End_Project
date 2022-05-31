using BackEnd_1.Task.Areas.Extensisons;
using BackEnd_1.Task.DAL;
using BackEnd_1.Task.Models;
using BackEnd_1.Task.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_1.Task.Areas.ProniaAdmin.Controllers
{
    [Area("ProniaAdmin")]
    public class PlantController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public PlantController(AppDbContext context,IWebHostEnvironment environment)
        {
            _context=context;
            _environment = environment;
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

            plant.PlantImages = new List<PlantImage>();

            PlantImage mainImage = new PlantImage
            {
                ImagePath = await plant.MainImage.FileExists(_environment.WebRootPath,@"assets\images\website-images"),
                IsMain = true,
                Plant = plant
            };

            plant.PlantImages.Add(mainImage);


            foreach (var another in plant.AnotherImages)
            {
                PlantImage animg = new PlantImage
                {
                    ImagePath = await another.FileExists(_environment.WebRootPath, @"assets\images\website-images"),
                    IsMain=false,
                    Plant = plant
                };

                plant.PlantImages.Add(animg);
            }
            await _context.Plants.AddAsync(plant);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Sizes = await _context.Sizes.ToListAsync();
            ViewBag.Colors = await _context.Colors.ToListAsync();
            Plant plant = await _context.Plants.Include(p=>p.PlantImages).FirstOrDefaultAsync(p=>p.Id ==id);
            if (plant == null) return NotFound();
            return View(plant);     
             
           
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult>Edit(int id,Plant plant)
        {
            ViewBag.Sizes = await _context.Sizes.ToListAsync();
            ViewBag.Colors = await _context.Colors.ToListAsync();

            Plant existed = await _context.Plants.Include(p => p.PlantImages).FirstOrDefaultAsync(p=>p.Id==id);
            if (existed == null) return NotFound();

            if (plant.AnotherIMGid==null && plant.AnotherImages==null)
            {
                ModelState.AddModelError(" ", "You can not delete all images without adding another image");
                return View(existed);
            }


            List<PlantImage> removeImage = existed.PlantImages.Where(p=>p.IsMain==false && !plant.AnotherIMGid.Contains(p.Id)).ToList();

            existed.PlantImages.RemoveAll(p => removeImage.Any(ri => ri.Id == p.Id));


            foreach ( var item in removeImage)
            {
                FileUtilities.FileDelete(_environment.WebRootPath, @"assets\images\website-images", item.ImagePath);
            }

            foreach (var item in plant.AnotherImages)
            {
                PlantImage plantImage = new PlantImage
                {
                    ImagePath = await item.FileExists(_environment.WebRootPath, @"assets\images\website-images"),
                    IsMain = false,
                    PlantId = existed.Id
                };

                existed.PlantImages.Add(plantImage);


            }
                
            _context.Entry(existed).CurrentValues.SetValues(plant);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int id)
        {
            Models.Plant plant = await _context.Plants.Include(p=>p.PlantImages).FirstOrDefaultAsync(p=>p.Id == id);
            if (plant == null) return NotFound();
            return View(plant);
        }


        public async Task<IActionResult> Delete(int id)
        {
            Models.Plant plant = await _context.Plants.Include(p=>p.PlantImages).FirstOrDefaultAsync(p=>p.Id == id);
            if (plant == null) return NotFound();
            return View(plant);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]

        public async Task<IActionResult> Delete(Models.Plant plant)
        {
            return View(plant);
        }
    }
}
