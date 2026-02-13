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
    public class EmployeemetnTypesController : Controller
    {
        private readonly AppDBContext _context;

        public EmployeemetnTypesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: EmployeemetnTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeemetnTypes.ToListAsync());
        }

        // GET: EmployeemetnTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeemetnType = await _context.EmployeemetnTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeemetnType == null)
            {
                return NotFound();
            }

            return View(employeemetnType);
        }

        // GET: EmployeemetnTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeemetnTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeementType")] EmployeemetnType employeemetnType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeemetnType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeemetnType);
        }

        // GET: EmployeemetnTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeemetnType = await _context.EmployeemetnTypes.FindAsync(id);
            if (employeemetnType == null)
            {
                return NotFound();
            }
            return View(employeemetnType);
        }

        // POST: EmployeemetnTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeementType")] EmployeemetnType employeemetnType)
        {
            if (id != employeemetnType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeemetnType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeemetnTypeExists(employeemetnType.Id))
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
            return View(employeemetnType);
        }

        // GET: EmployeemetnTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeemetnType = await _context.EmployeemetnTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeemetnType == null)
            {
                return NotFound();
            }

            return View(employeemetnType);
        }

        // POST: EmployeemetnTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeemetnType = await _context.EmployeemetnTypes.FindAsync(id);
            if (employeemetnType != null)
            {
                _context.EmployeemetnTypes.Remove(employeemetnType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeemetnTypeExists(int id)
        {
            return _context.EmployeemetnTypes.Any(e => e.Id == id);
        }
    }
}
