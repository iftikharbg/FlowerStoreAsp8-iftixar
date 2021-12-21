using FlowerStore.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerStore.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        private AppDbContext _context;

        public ProductViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var product = _context.Products.Include(p => p.Category).ToList();
            return View(product);
         }
        
    }
}
