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

        //private readonly AppDbContext _context;

        //public PlantController(AppDbContext context)
        //{
        //    _context = context;
        //}

        //public async Task<IActionResult> DeleteBasket(int id)
        //{            
        //    string basketStr = HttpContext.Request.Cookies["Basket"];

        //    List<BasketCookiesItemsVM> basketvm;

        //    if (!string.IsNullOrEmpty(basketStr))
        //    {

        //        basketvm = JsonConvert.DeserializeObject<List<BasketCookiesItemsVM>>(basketStr);

        //        BasketCookiesItemsVM existedCookie = basketvm.FirstOrDefault(ec => ec.Id == id);

        //        if (existedCookie != null)
        //        {

        //            basketvm.Remove(existedCookie);
        //            basketStr = JsonConvert.SerializeObject(basketvm);
        //        }

        //    }

        //    HttpContext.Response.Cookies.Append("Basket", basketStr);

        //    return RedirectToAction("Index", "Home");

        //}

        //private readonly AppDbContext _context;

        //public PlantController(AppDbContext context)
        //{
        //    _context = context;
        //}

        //public async Task<IActionResult> AddBasket(int id)
        //{
        //    string basketStr = HttpContext.Request.Cookies["Cart"];

        //    Plant plant = await _context.Plants.FirstOrDefaultAsync(pl=>pl.Id == id);
        //    if(plant == null) return NotFound();

        //    List<BasketCookiesItemsVM> basket;

        //    if (string.IsNullOrEmpty(basketStr))
        //    {
        //        basket = new List<BasketCookiesItemsVM>();

        //        BasketCookiesItemsVM cookie = new BasketCookiesItemsVM
        //        {
        //            Id = plant.Id,
        //            Count = 1
        //        };

        //        basket.Add(cookie);

        //        basketStr = JsonConvert.SerializeObject(basket);



        //    }

        //    else
        //    {
        //        basket = JsonConvert.DeserializeObject<List<BasketCookiesItemsVM>>(basketStr);

        //        BasketCookiesItemsVM existedCookie = basket.FirstOrDefault(bc=>bc.Id == plant.Id);

        //        if(existedCookie == null)

        //        {
        //            BasketCookiesItemsVM cookie = new BasketCookiesItemsVM
        //            {
        //                Id = plant.Id,
        //                Count = 1
        //            };

        //            basket.Add(cookie);



        //        }

        //        else
        //        {
        //            existedCookie.Count++;
        //        }

        //        basketStr = JsonConvert.SerializeObject(basket);


        //    }
        //    HttpContext.Response.Cookies.Append("Cart", basketStr);

        //    return RedirectToAction("Index", "Home");
        //}

        private readonly AppDbContext _context;

        public PlantController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AddBASKET(int id)
        {
            Plant plant = await _context.Plants.FirstOrDefaultAsync(pl=>pl.Id == id);
            if (plant == null) return NotFound();

            string basketStr = HttpContext.Request.Cookies["Cart"];

            List<BasketCookiesItemsVM> basket;

            if (string.IsNullOrEmpty(basketStr))
            {
                basket = new List<BasketCookiesItemsVM>();

                BasketCookiesItemsVM basketCookie = new BasketCookiesItemsVM
                {
                    Id = plant.Id,
                    Count = 1
                };

                basket.Add(basketCookie);

                basketStr = JsonConvert.SerializeObject(basket);



            }

            else
            {
                basket = JsonConvert.DeserializeObject<List<BasketCookiesItemsVM>>(basketStr);

                BasketCookiesItemsVM existedCookie = basket.FirstOrDefault(ec=>ec.Id == plant.Id);

                if (existedCookie == null)
                {
                    BasketCookiesItemsVM cookie = new BasketCookiesItemsVM
                    {
                        Id = plant.Id,
                        Count = 1
                    };

                    basket.Add(cookie);

                }

                else
                {
                    existedCookie.Count++;
                }

                basketStr = JsonConvert.SerializeObject(basket);

                
            }

            HttpContext.Response.Cookies.Append("Cart",basketStr);

            return RedirectToAction("Index","Home");

        }
    }
}
