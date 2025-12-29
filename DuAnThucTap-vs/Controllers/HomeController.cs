using System.Diagnostics;
using DuAnThucTap_vs.Models;
using Microsoft.AspNetCore.Mvc;

namespace DuAnThucTap_vs.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact() => View();

        public IActionResult Project()
        {
            return View();
        }

        public IActionResult Service()
        {
            return View();
        }

        public IActionResult News()
        {
            return View();
        }

        public IActionResult Recruitment()
        {
            return View();
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
