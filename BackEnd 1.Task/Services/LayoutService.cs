using BackEnd_1.Task.DAL;
using BackEnd_1.Task.Models;
using BackEnd_1.Task.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace BackEnd_1.Task.Services
{
    public class LayoutService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LayoutService(AppDbContext context,IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Setting> GetDatas()
        {
            return await _context.Settings.FirstOrDefaultAsync();
        }

        public BasketVM GetBasket()
        {
            string basketStr = _httpContextAccessor.HttpContext.Request.Cookies["Basket"];
            

            if (!string.IsNullOrEmpty(basketStr))
            {
                BasketVM basket = JsonConvert.DeserializeObject<BasketVM>(basketStr);
                return basket;
            }
            else
            {
                return null;
            }
        }

        }
}
