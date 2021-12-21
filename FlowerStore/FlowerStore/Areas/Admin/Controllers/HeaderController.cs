using FlowerStore.DAL;
using FlowerStore.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HeaderController : Controller
    {
        private AppDbContext _context;
        private IWebHostEnvironment _env;

        public HeaderController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        [HttpGet]
        public IActionResult Index()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Header _header)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!_header.File.ContentType.Contains("image"))
            {
                ModelState.AddModelError("File", "File is unsupported");
                return View();
            }
            if (_header.File.Length > 1024 * 1000)
            {
                ModelState.AddModelError(nameof(_header.File), "File size cannot be greater than 1 mb");
                return View();
            }
            string fileName = _header.File.FileName;
            string wwwRootPath = _env.WebRootPath;

            var path = Path.Combine(wwwRootPath, "img", fileName);

            FileStream stream = new FileStream(path, FileMode.Create);
            await _header.File.CopyToAsync(stream);
            stream.Close();

            _header.Logo = fileName;

            var header = _context.Headers.FirstOrDefault();

            header.Logo = _header.Logo;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");


            


        }

    }
}
