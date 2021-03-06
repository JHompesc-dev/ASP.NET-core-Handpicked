﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using B2Handpicked.DomainModel;
using B2Handpicked.Infrastructure;
using Microsoft.AspNetCore.Authorization;

namespace B2Handpicked.UI.Controllers {
    [Authorize]
    public class InvoicesController : Controller {
        private readonly ApplicationDbContext _context;

        public InvoicesController(ApplicationDbContext context) {
            _context = context;
        }

        // GET: Invoices
        public async Task<IActionResult> Index() {
            var applicationDbContext = _context.Invoices.Include(i => i.Customer).Include(i => i.Label);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Invoices/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var invoice = await _context.Invoices
                .Include(i => i.Customer)
                .Include(i => i.Label)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoice == null) {
                return NotFound();
            }

            return View(invoice);
        }

        // GET: Invoices/Create
        public IActionResult Create() {
            ViewData["CustomerId"] = _context.Customers;
            ViewData["LabelId"] = _context.Labels;
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,Value,Date,CustomerId,LabelId")] Invoice invoice) {
            if (ModelState.IsValid) {
                _context.Add(invoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = _context.Customers;
            ViewData["LabelId"] = _context.Labels;
            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null) {
                return NotFound();
            }
            ViewData["CustomerId"] = _context.Customers;
            ViewData["LabelId"] = _context.Labels;
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,Value,Date,CustomerId,LabelId")] Invoice invoice) {
            if (id != invoice.Id) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(invoice);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!InvoiceExists(invoice.Id)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = _context.Customers;
            ViewData["LabelId"] = _context.Labels;
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var invoice = await _context.Invoices
                .Include(i => i.Customer)
                .Include(i => i.Label)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoice == null) {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var invoice = await _context.Invoices.FindAsync(id);
            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceExists(int id) {
            return _context.Invoices.Any(e => e.Id == id);
        }
    }
}
