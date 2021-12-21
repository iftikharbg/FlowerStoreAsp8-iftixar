using FlowerStore.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerStore.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private AppDbContext _context;

        public FooterViewComponent(AppDbContext context)
        {
            _context = context;
                
        }

        public IViewComponentResult Invoke()
        {
            var footer = _context.Footers.FirstOrDefault();
            return View(footer);
        }
    }
}
