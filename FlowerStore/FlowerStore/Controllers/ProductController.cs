using FlowerStore.DAL;
using FlowerStore.Models;
using FlowerStore.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerStore.Controllers
{
    public class ProductController : Controller
    {
        private AppDbContext _context;
        private string searchedStr;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public PartialViewResult LoadMore(int skipCount)
        {
            var product = _context.Products.Skip(skipCount).Take(4).Include(p => p.Category).ToList();
            return PartialView("_ProductPartial", product);
        }
        
        public IActionResult Index()
        {
            var product = _context.Products.Take(4).Include(a=>a.Category).ToList();
            ViewBag.SkipCount = product.Count;
            return View(new ProductViewModel {product=product });
        }

        public async Task<IActionResult> Search(string searchedStr)
        {
            if (string.IsNullOrWhiteSpace(searchedStr))
            {
                return PartialView("_ProductSearchPartial", new List<Product>());
            }
            List<Product> products = await _context.Products
                .Where(p => p.Name.ToLower().Contains(searchedStr.ToLower())).ToListAsync();
            return PartialView("_ProductSearchPartial", products);
        }

    }
}
