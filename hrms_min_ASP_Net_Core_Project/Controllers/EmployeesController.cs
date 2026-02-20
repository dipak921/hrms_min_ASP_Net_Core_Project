using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using hrms_min_ASP_Net_Core_Project.Models;
using System.Reflection;
using Microsoft.AspNetCore.Http;

namespace hrms_min_ASP_Net_Core_Project.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AppDBContext _context;

        public EmployeesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index(string searchString, string designationFilter,int page = 1)
        {
            int pageSize = 5;
            var designationsList = await _context.Employees.Select(e => e.Desigantion)
                .Distinct()
                .OrderBy(d => d)
                .ToListAsync();
            var employees = from e in _context.Employees  select e;

            if(!string.IsNullOrEmpty(designationFilter))
            {
                employees = employees.Where(e => e.Desigantion == designationFilter);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(e => e.Name.Contains(searchString)|| e.Desigantion.Contains(searchString));
            }

            ViewBag.DesignationFilter = new SelectList(designationsList);
            ViewBag.CurrentFilter = searchString;
            ViewBag.SelectedDesignation = designationFilter;

            int totalItems = await employees.CountAsync();

            employees = employees.OrderBy(e => e.Name);

            var paginatedEmployees = await employees .OrderBy(e => e.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling(totalItems/(double) pageSize);

            return View(paginatedEmployees);

            //return View(await _context.Employees.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Desigantion,JoingDate,Salary,ProfileImage")] Employee employee, IFormFile? ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    var extension = Path.GetExtension(ImageFile.FileName).ToLower();
                    if (extension is ".jpg" or ".jpeg" or ".png" or ".webp" or ".pdf")
                    {
                        var fileName = Guid.NewGuid().ToString() + extension;
                        var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image", fileName);

                        using (var stream = new FileStream(imagePath, FileMode.Create))
                        {
                            await ImageFile.CopyToAsync(stream);
                        }
                        employee.ProfileImage = fileName;
                    }
                }

                _context.Add(employee);
                await _context.SaveChangesAsync();
                TempData["InsertMessage"] = "Employee created successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee employee, IFormFile? ImageFile)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingEmployee = await _context.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
                    if (existingEmployee == null)
                    {
                        return NotFound();
                    }
                    if (ImageFile != null && ImageFile.Length > 0)
                    {
                        var extension = Path.GetExtension(ImageFile.FileName).ToLower();

                        if (extension is ".jpg" or ".jpeg" or ".png" or ".webp" or ".pdf")
                        {                
                            var fileName = Guid.NewGuid().ToString() + extension;
                            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image", fileName);

                            using (var stream = new FileStream(imagePath, FileMode.Create))
                            {
                                await ImageFile.CopyToAsync(stream);
                            }
                            employee.ProfileImage = fileName;
                        }

                    }
                    else
                    {
                        employee.ProfileImage = existingEmployee.ProfileImage;
                    }


                        _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }

            await _context.SaveChangesAsync();
            TempData["DeleteMessage"] = "This Employee get ou in my Company";
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
