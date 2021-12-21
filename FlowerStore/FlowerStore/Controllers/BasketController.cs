using FlowerStore.DAL;
using FlowerStore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerStore.Controllers
{
    public class BasketController : Controller
    {
        private AppDbContext _context;

        public BasketController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AddToBasket(int id)
        {

            Product product = await _context.Products.FindAsync(id);

            List<BasketItem> basket = new List<BasketItem>();

            List<BasketItem> newbasket = new List<BasketItem>();

            List<BasketItem> finalbasket = new List<BasketItem>();

            List<BasketItem> oldbasket = null;
            if (!String.IsNullOrEmpty(Request.Cookies["basket"]))
            {
                oldbasket = JsonConvert.DeserializeObject<List<BasketItem>>(Request.Cookies["basket"]);
               
                if (oldbasket.Find(p=>p.product.id==product.id)!=null)
                {
                    oldbasket.Find(p => p.product.id == product.id).Count++;
                }
                else
                {
                    basket.Add(new BasketItem { product = product, Count = 1 });
                    
                }
                newbasket = basket.Concat(oldbasket).ToList();
            }
            else
            {
                newbasket.Add(new BasketItem { product = product, Count = 1 });
            }

            //if (oldbasket != null)
            //{
            //  
            //}
            //else
            //{
            //    basket.Add(new BasketItem { product = product, Count = 1 });
            //}




            foreach (var item in newbasket)
            {
                if (_context.Products.Find(item.product.id)!=null)
                {
                    finalbasket.Add(item);
                }
                else
                {
                    Response.Cookies.Append("basket", JsonConvert.SerializeObject(finalbasket));
                }
                
            }


            Response.Cookies.Append("basket", JsonConvert.SerializeObject(finalbasket));


            return Content("okey");
        }
        public IActionResult GetBasket()
        {
            return Content(Request.Cookies["basket"]);
        }

        public IActionResult GetBasketCount()
        {
            if (!string.IsNullOrEmpty(Request.Cookies["basket"]))
            {
                return Content(JsonConvert.DeserializeObject<List<BasketItem>>(Request.Cookies["basket"]).Count.ToString());
            }
            return Content("0");
        }


    }
}
