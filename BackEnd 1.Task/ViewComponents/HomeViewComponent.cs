using BackEnd_1.Task.DAL;
using BackEnd_1.Task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_1.Task.ViewComponents
{
    public class HomeViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;

        public HomeViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Setting> setting = await _context.Settings.ToListAsync();

            return View(setting);
        }
    }
}
