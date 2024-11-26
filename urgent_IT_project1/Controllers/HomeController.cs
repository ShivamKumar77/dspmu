using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using urgent_IT_project1.Models;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace urgent_IT_project1.Controllers
{
   
    public class HomeController : Controller
    {
        PlacementContext _context;
        public HomeController(PlacementContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult portfolio()
        {
            return View();
        }
        public IActionResult placement_cources()
        {
            return View(_context.Courses.ToList());
        }

        public IActionResult internship()
        {
            return View();
        }
        public IActionResult our_main_services()
        {
            return View();
        }
        public IActionResult Application_Development()
        {
            return View();
        }
        public IActionResult Software_Development()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        
        public IActionResult Shipping_And_Delivery()
        { 
            return View();
        }
        public IActionResult Privacy_Policy()
        {
            return View();
        }
        public IActionResult TermCondition()
        {
            return View();
        }
        public IActionResult Cencel_Refund()
        {
            return View();
        }
        public IActionResult Digital_Marketing()
        {
            return View();
        }
        public IActionResult Responsive_Website_Design()
        {
            return View();
        }
        public IActionResult Custom_Website_Design()
        {
            return View();
        }
        public IActionResult Brandcraft_logo_Design()
        {
            return View();
        }
        public IActionResult E_Commerce_Website_Development()
        {
            return View();
        }
        public IActionResult Website_maintenance()
        {
            return View();
        }
        public IActionResult Website_Redesign_Services()
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
