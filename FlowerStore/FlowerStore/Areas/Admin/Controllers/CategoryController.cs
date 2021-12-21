using FlowerStore.DAL;
using FlowerStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace FlowerStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories.ToListAsync();
            if (categories==null)
            {
                RedirectToAction("Index", "Dashboard");
            }
            return View(categories);

        }

        public async Task<IActionResult> Detail(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category==null)
            {
                return NotFound();

            }
            return View(category);
        }
        
    
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Category category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);   
        }

        [HttpPost]
        public async Task<IActionResult> Update(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var oldcategory = await _context.Categories.FindAsync(category.id);
            oldcategory.Name = category.Name;
            oldcategory.Desc = category.Desc;
             await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete(int id)
        {
            Category category = await _context.Categories.FindAsync(id);
            if (category==null)
            {
                return NotFound();
            }
            return View(category);

        }
        [HttpPost]
        [ActionName("Delete")]

        public async Task<IActionResult> DeleteCategory(int id)
        {
            Category category = await _context.Categories.FindAsync(id);
            _context.Remove(category);
            if (category==null)
            {
                return NotFound();
            }
           await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }

       
    }
}
