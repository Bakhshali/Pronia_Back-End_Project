using BackEnd_1.Task.DAL;
using BackEnd_1.Task.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BackEnd_1.Task.Services
{
    public class LayoutService
    {
        private readonly AppDbContext _context;

        public LayoutService(AppDbContext context)
        {
            _context = context; 
        }

        public async Task<Setting> GetDatas()
        {
            return await _context.Settings.FirstOrDefaultAsync();
        }
    }
}
