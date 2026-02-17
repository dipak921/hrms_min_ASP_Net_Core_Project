using hrms_min_ASP_Net_Core_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace hrms_min_ASP_Net_Core_Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDBContext _context;
        public AccountController(AppDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var admin = _context.Admins.FirstOrDefault(a => a.Username == username && a.Password == password);

            if(admin != null)
            {
                HttpContext.Session.SetString("AdminUser", admin.Username);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Invalid username or password.";
            return View("Index");
        }
        
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("AdminUser");
            return RedirectToAction("Index");
        }
        
    }
}

