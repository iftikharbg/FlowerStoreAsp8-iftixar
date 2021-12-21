using FlowerStore.DAL;
using FlowerStore.Models;
using FlowerStore.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerStore.Controllers
{
    public class HomeController : Controller
    { private AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
       
        public IActionResult Index()
        {
            
            var slider = _context.Sliders.FirstOrDefault();

            var valentine = _context.Valentines.FirstOrDefault();

            var products = _context.Products.OrderBy(p => p.Category).ToList();

            var categories = _context.Categories.ToList();

            var subscribeTables = _context.subscribeTables.FirstOrDefault();

            var experts = _context.Experts.ToList();

            var title = _context.Titles.FirstOrDefault();

            var worker = _context.Workers.FirstOrDefault();

            var blog = _context.Blogs.FirstOrDefault();

            var images = _context.Images.ToList();

            var hashtag = _context.Hashtags.FirstOrDefault();

            List<BlogItems> blogItems = _context.BlogItems.ToList();

            List<ListItem> listItems = _context.LitsItems.ToList();

            List<SliderImage> sliderImages = _context.SliderImage.ToList();

            ViewBag.SkipCount = products.Count;

            return View(new HomeViewModel {slider=slider,valentine=valentine,listItem=listItems,product=products, category=categories,subscribeTable=subscribeTables,experts=experts,title=title,worker=worker,blog=blog,BlogItems=blogItems,Images=images,Hashtag=hashtag,sliderImages=sliderImages });
        }

       
    }
}
