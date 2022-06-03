using BackEnd_1.Task.DAL;
using BackEnd_1.Task.Models;
using BackEnd_1.Task.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
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




        public IActionResult DeleteBasket(int id)
        {

            if (Request.Cookies["Basket"] != null)
            {
                Response.Cookies.Delete("Basket");
            }

              return RedirectToAction("Index", "Home");
        }




        public async Task<IActionResult> AddBasket(int id)
        {
            Plant plant = await _context.Plants.FirstOrDefaultAsync(pc => pc.Id == id);
            if (plant == null) return NotFound();


            string basketStr = HttpContext.Request.Cookies["Basket"];

            List<BasketCookiesItemsVM> basketvm;





            if (string.IsNullOrEmpty(basketStr))
            {
                basketvm = new List<BasketCookiesItemsVM>();

                BasketCookiesItemsVM cookie = new BasketCookiesItemsVM
                {
                    Id = plant.Id,
                    Count = 1

                };


                basketvm.Add(cookie);
                basketStr = JsonConvert.SerializeObject(basketvm);
            }

            else
            {


                basketvm = JsonConvert.DeserializeObject<List<BasketCookiesItemsVM>>(basketStr);

                BasketCookiesItemsVM existedCookie = basketvm.FirstOrDefault(ec => ec.Id == plant.Id);

                if (existedCookie == null)
                {

                    BasketCookiesItemsVM cookie = new BasketCookiesItemsVM
                    {
                        Id = plant.Id,
                        Count = 1

                    };

                    basketvm.Add(cookie);
                }
                else
                {
                    existedCookie.Count++;
                }




                basketStr = JsonConvert.SerializeObject(basketvm);
            }

            HttpContext.Response.Cookies.Append("Basket", basketStr);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult ShowBasket()
        {

            return Content(HttpContext.Request.Cookies["Basket"]);


        }
    }
}
