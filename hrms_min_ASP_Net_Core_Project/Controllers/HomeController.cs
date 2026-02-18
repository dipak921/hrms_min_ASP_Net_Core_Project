using hrms_min_ASP_Net_Core_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace hrms_min_ASP_Net_Core_Project.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<AppDBContext> context)
        //{
        //    _context = _context;
        //}
        private readonly AppDBContext _context;
        public HomeController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalEmployee = _context.Employees.Count();
            ViewBag.TotalDepartment = _context.Departments.Count();
            ViewBag.TotalEmployeeDepartment = _context.EmployeeDepartments.Count();
            ViewBag.TotalCitys = _context.Cities.Count();
   
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
