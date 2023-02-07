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
using System.Diagnostics.Metrics;

namespace EmmaProject.Controllers
{
    public class PricesController : Controller
    {
        private readonly EmmaProjectContext _context;

        public PricesController(EmmaProjectContext context)
        {
            _context = context;
        }

        // GET: Prices
        public async Task<IActionResult> Index(string id, string UPC_ID, int? page, int? pageSizeID, string actionButton, string sortDirection = "asc", string sortField = "PricePurchasedCost")
        {
            PopulateDropDownLists();

            string[] sortOptions = new[] { "Purchase Date", "Purchase Cost", "Stock", "Supplier" };

            var prices = _context.Prices
                .Where(p => p.UPC_ID == id)
                .Include(p => p.Inventory)
                .Include(p => p.Supplier)
                .AsNoTracking();

            if (string.IsNullOrWhiteSpace(id))
            {
                prices = _context.Prices
                    .Where(p => p.UPC_ID == UPC_ID)
                    .Include(p => p.Inventory)
                    .Include(p => p.Supplier)
                    .AsNoTracking();
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
            if (sortField == "Supplier")
            {
                if (sortDirection == "asc")
                {
                    prices = prices.OrderBy(m => m.Supplier.SupName);
                }
                else if (sortDirection == "desc")
                {
                    prices = prices.OrderByDescending(m => m.Supplier.SupName);
                }
            }
            else if (sortField == "Purchase Cost")
            {
                if (sortDirection == "asc")
                {
                    prices = prices.OrderBy(m => (double)m.PricePurchasedCost);
                }
                else if (sortDirection == "desc")
                {
                    prices = prices.OrderByDescending(m => (double)m.PricePurchasedCost);
                }
            }
            else if (sortField == "Purchase Date")
            {
                if (sortDirection == "asc")
                {
                    prices = prices.OrderBy(m => m.PricePurchasedDate);
                }
                else if (sortDirection == "desc")
                {
                    prices = prices.OrderByDescending(m => m.PricePurchasedDate);
                }
            }
            else if (sortField == "Stock")
            {
                if (sortDirection == "asc")
                {
                    prices = prices.OrderBy(m => m.PriceCount);
                }
                else if (sortDirection == "desc")
                {
                    prices = prices.OrderByDescending(m => m.PriceCount);
                }
            }
            ViewData["sortField"] = sortField;
            ViewData["sortDirection"] = sortDirection;

            int pageSize = PageSizeHelper.SetPageSize(HttpContext, pageSizeID, "Inventories");
            ViewData["pageSizeID"] = PageSizeHelper.PageSizeList(pageSize);
            var pagedData = await PaginatedList<Price>.CreateAsync(prices.AsNoTracking(), page ?? 1, pageSize);

            return View(pagedData);
        }

        // GET: Prices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Prices == null)
            {
                return NotFound();
            }

            var price = await _context.Prices
                .Include(p => p.Inventory)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.PriceID == id);
            if (price == null)
            {
                return NotFound();
            }

            return View(price);
        }

        // GET: Prices/Create
        public IActionResult Create()
        {
            ViewData["UPC_ID"] = new SelectList(_context.Inventories, "UPC_ID", "UPC_ID");
            PopulateDropDownLists();
            return View();
        }

        // POST: Prices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PricePurchasedCost,PricePurchasedDate,PriceCount,SupID")] Price price)
        {
            if (ModelState.IsValid)
            {
                _context.Add(price);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { price.UPC_ID });
            }
            ViewData["UPC_ID"] = new SelectList(_context.Inventories, "UPC_ID", "UPC_ID", price.UPC_ID);
            PopulateDropDownLists(price);
            return RedirectToAction("Index", new { price.UPC_ID });
        }

        // GET: Prices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Prices == null)
            {
                return NotFound();
            }

            var price = await _context.Prices.FindAsync(id);
            if (price == null)
            {
                return NotFound();
            }
            ViewData["UPC_ID"] = new SelectList(_context.Inventories, "UPC_ID", "UPC_ID", price.UPC_ID);
            PopulateDropDownLists(price); 
            return View(price);
        }

        // POST: Prices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PriceID,UPC_ID,PricePurchasedCost,PricePurchasedDate,PriceCount,SupID")] Price price)
        {
            if (id != price.PriceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(price);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PriceExists(price.PriceID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                string test = price.UPC_ID;
                return RedirectToAction("Index", new { price.UPC_ID });
            }
            ViewData["UPC_ID"] = new SelectList(_context.Inventories, "UPC_ID", "UPC_ID", price.UPC_ID);
            PopulateDropDownLists(price);
            return RedirectToAction("Index", new { price.UPC_ID });
        }

        // GET: Prices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Prices == null)
            {
                return NotFound();
            }

            var price = await _context.Prices
                .Include(p => p.Inventory)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.PriceID == id);
            if (price == null)
            {
                return NotFound();
            }

            return View(price);
        }

        // POST: Prices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Prices == null)
            {
                return Problem("Entity set 'EmmaProjectContext.Prices'  is null.");
            }
            var price = await _context.Prices.FindAsync(id);
            if (price != null)
            {
                _context.Prices.Remove(price);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private SelectList SupplierList(int? selectedId)
        {
            return new SelectList(_context
                .Suppliers
                .OrderBy(m => m.SupName), "SupID", "SupName", selectedId);
        }
        private void PopulateDropDownLists(Price price = null)
        {
            ViewData["SupID"] = SupplierList(price?.SupID);
        }
        private bool PriceExists(int id)
        {
          return _context.Prices.Any(e => e.PriceID == id);
        }
    }
}
