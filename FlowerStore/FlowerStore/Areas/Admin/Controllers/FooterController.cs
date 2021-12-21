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
    public class FooterController : Controller
    {
        private AppDbContext _context;
        private IWebHostEnvironment _env;

        public FooterController(AppDbContext context,IWebHostEnvironment env)
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
        public async Task<IActionResult> Index(Footer _footer)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!_footer.File.ContentType.Contains("image"))
            {
                ModelState.AddModelError("File", "File is unsupported");
                return View();
            }
            if (_footer.File.Length > 1024 * 1000)
            {
                ModelState.AddModelError(nameof(_footer.File), "File size cannot be greater than 1 mb");
                return View();
            }
            string fileName = _footer.File.FileName;
            string wwwRootPath = _env.WebRootPath;

            var path = Path.Combine(wwwRootPath, "img", fileName);

            FileStream stream = new FileStream(path, FileMode.Create);
            await _footer.File.CopyToAsync(stream);
            stream.Close();

            _footer.Logo = fileName;

            

          

           
            var footer = _context.Footers.FirstOrDefault();

            footer.Logo = _footer.Logo;
            footer.FacebookUrl = _footer.FacebookUrl;
            footer.LinkedinUrl = _footer.LinkedinUrl;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

           

            
           
        }
    }
}
