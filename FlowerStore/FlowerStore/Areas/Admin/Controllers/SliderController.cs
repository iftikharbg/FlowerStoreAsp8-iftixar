using FlowerStore.DAL;
using FlowerStore.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private IWebHostEnvironment _env;

        public SliderController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Create(SliderImage sliderImage)
        {
            if (!ModelState.IsValid)
            {
                return View(sliderImage);
            }
            if (!sliderImage.File.ContentType.Contains("image"))
            {
                ModelState.AddModelError("File", "File is unsupported");
                return View();
            }
            if (sliderImage.File.Length > 1024 * 1000)
            {
                ModelState.AddModelError(nameof(sliderImage.File), "File size cannot be greater than 1 mb");
                return View();
            }
            string fileName = sliderImage.File.FileName;
            string wwwRootPath = _env.WebRootPath;

            var path = Path.Combine(wwwRootPath, "img", fileName);

            FileStream stream = new FileStream(path, FileMode.Create);
            await sliderImage.File.CopyToAsync(stream);
            stream.Close();

            sliderImage.Image = fileName;

            await _context.SliderImage.AddAsync(sliderImage);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
