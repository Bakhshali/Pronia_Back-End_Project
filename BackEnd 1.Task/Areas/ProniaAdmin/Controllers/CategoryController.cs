using BackEnd_1.Task.DAL;
using BackEnd_1.Task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd_1.Task.Areas.ProniaAdmin.Controllers
{
    [Area("ProniaAdmin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _contex;
        
        public CategoryController(AppDbContext contex)
        {
            _contex = contex;
        }

        public async Task <IActionResult> Index()
        {
            List<Category> categories = await _contex.Categories.ToListAsync();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(Category category)
        {
            await _contex.Categories.AddAsync(category);
            await _contex.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int id )
        {
            Category category = await _contex.Categories.FirstOrDefaultAsync(s=>s.Id==id);
            if(category==null) return NotFound();
            return View(category);
        }
        public async Task<IActionResult>  Edit(int id)
        {
            Category category = await _contex.Categories.FirstOrDefaultAsync(s=>s.Id == id);
            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(int id, Category category)
        {
            Category existedCategory = await _contex.Categories.FirstOrDefaultAsync(s => s.Id == id);
            {
                if (existedCategory == null) return NotFound();
                if(id != existedCategory.Id) return BadRequest();
                existedCategory.Name = category.Name;

                await _contex.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
                
        }
        public IActionResult Delete(int id)
        {

            return Json(id);
        }
       
    }
}
