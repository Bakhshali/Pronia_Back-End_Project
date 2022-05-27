using BackEnd_1.Task.DAL;
using BackEnd_1.Task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd_1.Task.Areas.ProniaAdmin.Controllers
{
    [Area("ProniaAdmin")]

    public class SliderController : Controller
    {
        private readonly AppDbContext _context;

        public SliderController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Slider> slider = await _context.Sliders.ToListAsync();

            return View(slider);
        }


        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {
            
            if (!ModelState.IsValid) return View();

            if (!slider.Photo.ContentType.Contains("image"))
            {
                ModelState.AddModelError("Photo", "This file not image file, please choose image file");
                return View();
            }

            if(slider.Photo.Length > 1024 * 1024)
            {
                ModelState.AddModelError("Photo", "Please choose image file which 1 MB");
            }
            
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Detail(int id)
        {
            Slider slider = await _context.Sliders.FirstOrDefaultAsync(sl=>sl.Id == id);
            if (slider==null)
            {
                return NotFound();
            }

            return View(slider);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Slider slider = await _context.Sliders.FirstOrDefaultAsync(sl=>sl.Id == id);
            if(slider==null)return NotFound();

            return View(slider);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]

        public async Task<IActionResult> DeleteSize(int id)
        {
            Slider slider = await _context.Sliders.FirstOrDefaultAsync(sl=>sl.Id == id);

            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Edit(int id)
        {
            Slider slider = await _context.Sliders.FirstOrDefaultAsync(sl=>sl.Id==id);

            if(slider == null) return NotFound();

            return View(slider);
            
        }

        [HttpPost]

        public async Task<IActionResult> Edit (int id, Slider slider)
        {
            Slider existedSlider = await _context.Sliders.FirstOrDefaultAsync(sl=>sl.Id==id);

            if (slider == null) return NotFound();
            if (id != existedSlider.Id) return BadRequest();
            existedSlider.Title = slider.Title;
            existedSlider.Subtitle = slider.Subtitle;
            existedSlider.Discount = slider.Discount;
            existedSlider.Title = slider.Title;
            existedSlider.DiscoverURL = slider.DiscoverURL;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));


        }
    }
}
