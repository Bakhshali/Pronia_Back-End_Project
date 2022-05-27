using BackEnd_1.Task.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace BackEnd_1.Task.Areas.ProniaAdmin.Controllers
{

    [Area("ProniaAdmin")]
    public class ColorController : Controller
    {
        private readonly AppDbContext _context;

        public ColorController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            List<Models.Color> color =  await _context.Colors.ToListAsync();
            return View(color);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Models.Color color)
        {
            await _context.Colors.AddAsync(color);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int id)
        {
            Models.Color color = await _context.Colors.FirstOrDefaultAsync(c=>c.Id == id);
            if(color == null) return NotFound();
            return View(color);
        }
        public async Task<IActionResult> Edit(int id)
        {
            Models.Color color = await _context.Colors.FirstOrDefaultAsync(c=>c.Id==id);
            if(color==null) return NotFound();
            return View(color);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Edit(int id, Models.Color color)
        {
            Models.Color existedColor = await _context.Colors.FirstOrDefaultAsync(c => c.Id == id);
            {
                if(existedColor==null) return NotFound();
                if(id != existedColor.Id) return BadRequest();                
                existedColor.Name = color.Name;
               

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            Models.Color color = await _context.Colors.FirstOrDefaultAsync(c=>c.Id == id);
            if (color == null) return NotFound();
            return View(color);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteColor(int id)
        {
            Models.Color color = await _context.Colors.FirstOrDefaultAsync(c=>c.Id == id);
            if(color==null) return NotFound();
            _context.Colors.Remove(color);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
