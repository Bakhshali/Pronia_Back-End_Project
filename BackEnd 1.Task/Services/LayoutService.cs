using BackEnd_1.Task.DAL;
using BackEnd_1.Task.Models;
using BackEnd_1.Task.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<BasketVM> GetBasket()
        {
            string basketStr = _httpContextAccessor.HttpContext.Request.Cookies["Basket"];
            BasketVM basketData = new BasketVM();

            if (!string.IsNullOrEmpty(basketStr))
            {
                List<BasketCookiesItemsVM> basket = JsonConvert.DeserializeObject<List<BasketCookiesItemsVM>>(basketStr);

                //List<Plant> query = await _context.Plants.Include(p=>p.PlantImages).ToListAsync();

                var query = _context.Plants.Include(p => p.PlantImages).AsQueryable();

                foreach (BasketCookiesItemsVM item in basket)
                {
                    Plant existedPlant = query.FirstOrDefault(p =>p.Id == item.Id);

                    if (existedPlant != null)
                    {
                       

                        BasketItemVM basketItemVM = new BasketItemVM
                        {
                            Plant = existedPlant,
                            Count = item.Count,
                        };

                        basketData.BasketItems.Add(basketItemVM);

                        
                    }

                }

                decimal total = default;

                foreach (BasketItemVM item in basketData.BasketItems)
                {
                    total += item.Count * item.Plant.Price;
                }

                basketData.TotalPrice = total;
                basketData.Count = basketData.BasketItems.Count;


                return basketData;
            }
            else
            {
                return null;
            }
        }

        }
}
