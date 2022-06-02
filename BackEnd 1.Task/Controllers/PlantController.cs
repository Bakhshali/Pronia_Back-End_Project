using BackEnd_1.Task.DAL;
using BackEnd_1.Task.Models;
using BackEnd_1.Task.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_1.Task.Controllers
{
    public class PlantController : Controller
    {
        private readonly AppDbContext _context;

        public PlantController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AddBasket(int id)
        {
            Plant plant = await _context.Plants.FirstOrDefaultAsync(pc => pc.Id == id);
            if (plant == null) return NotFound();


            string basketStr = HttpContext.Request.Cookies["Basket"];

            BasketVM basketvm;

            string itemstr;

            if (string.IsNullOrEmpty(basketStr))
            {
                basketvm = new BasketVM();
                BasketItemVM basketitem = new BasketItemVM
                {
                    Plant = plant,
                    Count = 1,
                };
                basketvm.BasketItems.Add(basketitem);
                itemstr = JsonConvert.SerializeObject(basketitem);
            }

            else
            {


                basketvm = JsonConvert.DeserializeObject<BasketVM>(basketStr);

                BasketItemVM basketitem = basketvm.BasketItems.FirstOrDefault(bi => bi.Plant.Id == id);

                if (basketitem == null)
                {

                    BasketItemVM item = new BasketItemVM
                    {
                        Plant = plant,
                        Count = 1,
                    };

                    basketvm.BasketItems.Add(item);
                }
                else
                {
                    basketitem.Count++;
                }
                decimal total = default;
                foreach (BasketItemVM item in basketvm.BasketItems)
                {
                    total += item.Count * item.Plant.Price;
                }
                basketvm.TotalPrice = total;
                basketvm.Count = basketvm.BasketItems.Count;

                itemstr = JsonConvert.SerializeObject(basketvm);
            }

            HttpContext.Response.Cookies.Append("Basket", itemstr);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult ShowBasket()
        {
            
            return Content(HttpContext.Request.Cookies["Basket"]);


        }
    }
}
