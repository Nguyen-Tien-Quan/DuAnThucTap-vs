using DuAnThucTap_vs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace DuAnThucTap_vs.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        // ✅ Inject DbContext
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Project(int page = 1)
        {
            int pageSize = 7;

            var totalProjects = _context.Projects
                .Where(p => p.IsActive == true)
                .Count();

            var projects = _context.Projects
                .Where(p => p.IsActive == true)
                .OrderByDescending(p => p.ProjectId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalProjects / pageSize);

            return View(projects); // Views/Home/Project.cshtml
        }

        public IActionResult ProjectDetail(int id)
        {
            var project = _context.Projects
                .FirstOrDefault(p => p.ProjectId == id && p.IsActive == true);

            if (project == null)
                return NotFound();

            return View(project); // Views/Home/ProjectDetail.cshtml
        }



        public IActionResult Service()
        {
            return View();
        }

        // 🔥 TRANG TIN TỨC – LOAD DB
        public IActionResult News(int page = 1)
        {
            int pageSize = 5; // số tin / trang

            var totalNews = _context.News.Count();

            var newsList = _context.News
                .OrderByDescending(n => n.CreatedDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalNews / pageSize);

            return View(newsList);
        }


        public IActionResult Recruitment()
        {
            return View();
        }

        public IActionResult NewsDetail(int id)
        {
            var news = _context.News.FirstOrDefault(n => n.NewsId == id);

            if (news == null)
            {
                return NotFound();
            }

            return View(news); // 👉 Views/Home/NewsDetail.cshtml
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
