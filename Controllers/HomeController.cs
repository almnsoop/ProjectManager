using Microsoft.AspNetCore.Mvc;
using ProjectManager.Models;
using System.Diagnostics;
using ProjectManager.Data;

namespace ProjectManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context; // أضفنا هذا السطر
                                                // تعديل الباني (Constructor) ليستقبل قاعدة البيانات
        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // سحب الإحصائيات الحية وإرسالها للشاشة
            ViewBag.TotalClients = _context.Clients.Count();
            ViewBag.TotalWebsites = _context.Websites.Count();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
