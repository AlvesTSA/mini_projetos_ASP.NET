﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _000_dev_backend_2025.Models;
using Microsoft.AspNetCore.Authorization;

namespace _000_dev_backend_2025.Controllers
{
    [Authorize] 
    public class ConsumosController : Controller
    {
        private readonly AppDbContext _context;

        public ConsumosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Consumos
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Consumos.Include(c => c.Veiculo);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Consumos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumo = await _context.Consumos
                .Include(c => c.Veiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consumo == null)
            {
                return NotFound();
            }

            return View(consumo);
        }

        // GET: Consumos/Create
        public IActionResult Create()
        {
            ViewData["IdVeiculo"] = new SelectList(_context.Veiculos, "Id", "Nome");
            return View();
        }

        // POST: Consumos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdProduto,DataConsumo,Descricao,ValorTotal,Km,Tipo,IdVeiculo")] Consumo consumo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consumo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdVeiculo"] = new SelectList(_context.Veiculos, "Id", "Nome", consumo.IdVeiculo);
            return View(consumo);
        }

        // GET: Consumos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumo = await _context.Consumos.FindAsync(id);
            if (consumo == null)
            {
                return NotFound();
            }
            ViewData["IdVeiculo"] = new SelectList(_context.Veiculos, "Id", "Nome", consumo.IdVeiculo);
            return View(consumo);
        }

        // POST: Consumos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdProduto,DataConsumo,Descricao,ValorTotal,Km,Tipo,IdVeiculo")] Consumo consumo)
        {
            if (id != consumo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consumo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsumoExists(consumo.Id))
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
            ViewData["IdVeiculo"] = new SelectList(_context.Veiculos, "Id", "Nome", consumo.IdVeiculo);
            return View(consumo);
        }

        // GET: Consumos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumo = await _context.Consumos
                .Include(c => c.Veiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consumo == null)
            {
                return NotFound();
            }

            return View(consumo);
        }

        // POST: Consumos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consumo = await _context.Consumos.FindAsync(id);
            if (consumo != null)
            {
                _context.Consumos.Remove(consumo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsumoExists(int id)
        {
            return _context.Consumos.Any(e => e.Id == id);
        }
    }
}
