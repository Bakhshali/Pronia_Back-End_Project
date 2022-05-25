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
            return Json("Create");
        }
        public IActionResult Detail(int id)
        {
            return Json(id);
        }
        public IActionResult Edit(int id)
        {
            return Json(id);
        }
        public IActionResult Delete(int id)
        {
            return Json(id);
        }
    }
}
