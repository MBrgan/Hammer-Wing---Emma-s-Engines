using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmmaProject.Data;
using EmmaProject.Models;
using MVC_Music.Utilities;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace EmmaProject.Controllers
{
    public class CustomersController : Controller
    {
        private readonly EmmaProjectContext _context;

        public CustomersController(EmmaProjectContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index(string FirstSearch, string LastSearch, int? page, int? pageSizeID, string actionButton, string sortDirection = "asc", string sortField = "PricePurchasedCost")
        {
            string[] sortOptions = new[] { "First Name", "Last Name" };

            var customers = _context.Customers
                .AsNoTracking();

            if (!String.IsNullOrEmpty(FirstSearch))
            {
                customers = customers.Where(m => m.CustFirst.ToUpper().Contains(FirstSearch.ToUpper()));
            }
            if (!String.IsNullOrEmpty(LastSearch))
            {
                customers = customers.Where(m => m.CustLast.ToUpper().Contains(LastSearch.ToUpper()));
            }

            if (!String.IsNullOrEmpty(actionButton))
            {
                page = 1; //reset page to start
                if (sortOptions.Contains(actionButton))
                {
                    if (actionButton == sortField)
                    {
                        sortDirection = sortDirection == "asc" ? "desc" : "asc";
                    }
                    sortField = actionButton;
                }
            }
            if (sortField == "First Name")
            {
                if (sortDirection == "asc")
                {
                    customers = customers.OrderBy(m => m.CustFirst);
                }
                else if (sortDirection == "desc")
                {
                    customers = customers.OrderByDescending(m => m.CustFirst);
                }
            }
            else if (sortField == "Last Name")
            {
                if (sortDirection == "asc")
                {
                    customers = customers.OrderBy(m => m.CustLast);
                }
                else if (sortDirection == "desc")
                {
                    customers = customers.OrderByDescending(m => m.CustLast);
                }
            }
            ViewData["sortField"] = sortField;
            ViewData["sortDirection"] = sortDirection;

            int pageSize = PageSizeHelper.SetPageSize(HttpContext, pageSizeID, "Inventories");
            ViewData["pageSizeID"] = PageSizeHelper.PageSizeList(pageSize);
            var pagedData = await PaginatedList<Customer>.CreateAsync(customers.AsNoTracking(), page ?? 1, pageSize);

            return View(pagedData);
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustFirst,CustLast,CustPhone,CustAddress,CustCity,CustProvince,CustPostal")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustID,CustFirst,CustLast,CustPhone,CustAddress,CustCity,CustProvince,CustPostal")] Customer customer)
        {
            if (id != customer.CustID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustID))
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
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Customers == null)
            {
                return Problem("Entity set 'EmmaProjectContext.Customers'  is null.");
            }
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
          return _context.Customers.Any(e => e.CustID == id);
        }
    }
}
