using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmmaProject.Data;
using EmmaProject.Models;
using System.Diagnostics.Metrics;
using MVC_Music.Utilities;

namespace EmmaProject.Controllers
{
    public class InventoriesController : Controller
    {
        private readonly EmmaProjectContext _context;

        public InventoriesController(EmmaProjectContext context)
        {
            _context = context;
        }

        // GET: Inventories
        public async Task<IActionResult> Index(string UPCSearch, string NameSearch, int? page, int? pageSizeID, string actionButton, string sortDirection = "asc", string sortField = "PricePurchasedCost")
        {
            string[] sortOptions = new[] { "UPC", "Name", "Price (Retail)"};

            var inventories = _context.Inventories
                .Include(m => m.Prices).ThenInclude(p => p.Supplier)
                .AsNoTracking();

            if (!String.IsNullOrEmpty(UPCSearch))
            {
                inventories = inventories.Where(m => m.UPC_ID.ToUpper().Contains(UPCSearch.ToUpper()));
            }
            if (!String.IsNullOrEmpty(NameSearch))
            {
                inventories = inventories.Where(m => m.InvName.ToUpper().Contains(NameSearch.ToUpper()));
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
            if (sortField == "UPC")
            {
                if (sortDirection == "asc")
                {
                    inventories = inventories.OrderBy(m => m.UPC_ID);
                }
                else if (sortDirection == "desc")
                {
                    inventories = inventories.OrderByDescending(m => m.UPC_ID);
                }
            }
            else if (sortField == "Name")
            {
                if (sortDirection == "asc")
                {
                    inventories = inventories.OrderBy(m => m.InvName);
                }
                else if (sortDirection == "desc")
                {
                    inventories = inventories.OrderByDescending(m => m.InvName);
                }
            }
            else if (sortField == "Price (Retail)")
            {
                if (sortDirection == "asc")
                {
                    inventories = inventories.OrderBy(m => (double)m.InvAdjustedPrice);
                }
                else if (sortDirection == "desc")
                {
                    inventories = inventories.OrderByDescending(m => (double)m.InvAdjustedPrice);
                }
            }
            ViewData["sortField"] = sortField;
            ViewData["sortDirection"] = sortDirection;

            int pageSize = PageSizeHelper.SetPageSize(HttpContext, pageSizeID, "Inventories");
            ViewData["pageSizeID"] = PageSizeHelper.PageSizeList(pageSize);
            var pagedData = await PaginatedList<Inventory>.CreateAsync(inventories.AsNoTracking(), page ?? 1, pageSize);

            return View(pagedData);
        }

        // GET: Inventories/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null || _context.Inventories == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventories
                .FirstOrDefaultAsync(m => m.UPC_ID == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // GET: Inventories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UPC_ID,InvName,InvSize,InvQuantity,InvAdjustedPrice,InvMarkupPrice,InvCurrent")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventory);
        }

        // GET: Inventories/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null || _context.Inventories == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventories.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UPC_ID,InvName,InvSize,InvQuantity,InvAdjustedPrice,InvMarkupPrice,InvCurrent")] Inventory inventory)
        {
            if (id != inventory.UPC_ID)
                return NotFound();
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(inventory);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!InventoryExists(inventory.UPC_ID))
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
            }
            return View(inventory);
        }

        // GET: Inventories/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null || _context.Inventories == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventories
                .FirstOrDefaultAsync(m => m.UPC_ID == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Inventories == null)
            {
                return Problem("Entity set 'EmmaProjectContext.Inventories'  is null.");
            }
            var inventory = await _context.Inventories.FindAsync(id);
            if (inventory != null)
            {
                _context.Inventories.Remove(inventory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventoryExists(string id)
        {
          return _context.Inventories.Any(e => e.UPC_ID == id);
        }
    }
}
