using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using hrms_min_ASP_Net_Core_Project.Models;

namespace hrms_min_ASP_Net_Core_Project.Controllers
{
    public class EmployeeDepartmentsController : Controller
    {
        private readonly AppDBContext _context;

        public EmployeeDepartmentsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: EmployeeDepartments
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.EmployeeDepartments.Include(e => e.Department).Include(e => e.Employee);
            return View(await appDBContext.ToListAsync());
        }

        // GET: EmployeeDepartments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDepartment = await _context.EmployeeDepartments
                .Include(e => e.Department)
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeDepartment == null)
            {
                return NotFound();
            }

            return View(employeeDepartment);
        }

        // GET: EmployeeDepartments/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name");
            return View();
        }

        // POST: EmployeeDepartments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,DepartmentId,Branch")] EmployeeDepartment employeeDepartment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeDepartment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", employeeDepartment.DepartmentId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name", employeeDepartment.EmployeeId);
            return View(employeeDepartment);
        }

        // GET: EmployeeDepartments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDepartment = await _context.EmployeeDepartments.FindAsync(id);
            if (employeeDepartment == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", employeeDepartment.DepartmentId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name", employeeDepartment.EmployeeId);
            return View(employeeDepartment);
        }

        // POST: EmployeeDepartments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,DepartmentId,Branch")] EmployeeDepartment employeeDepartment)
        {
            if (id != employeeDepartment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeDepartment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeDepartmentExists(employeeDepartment.Id))
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
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", employeeDepartment.DepartmentId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name", employeeDepartment.EmployeeId);
            return View(employeeDepartment);
        }

        // GET: EmployeeDepartments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDepartment = await _context.EmployeeDepartments
                .Include(e => e.Department)
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeDepartment == null)
            {
                return NotFound();
            }

            return View(employeeDepartment);
        }

        // POST: EmployeeDepartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeDepartment = await _context.EmployeeDepartments.FindAsync(id);
            if (employeeDepartment != null)
            {
                _context.EmployeeDepartments.Remove(employeeDepartment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeDepartmentExists(int id)
        {
            return _context.EmployeeDepartments.Any(e => e.Id == id);
        }
    }
}
