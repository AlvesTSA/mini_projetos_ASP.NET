using Microsoft.EntityFrameworkCore;
using _000_dev_backend_2025.Models;
using Microsoft.AspNetCore.Mvc;

namespace _000_dev_backend_2025.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly AppDbContext _context;
        public VeiculosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var DadosVeiculos = await _context.Veiculos.ToListAsync();
            return View(DadosVeiculos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Veiculos.Add(veiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(veiculo);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var DadosVeiculo = await _context.Veiculos.FindAsync(id);
            if (DadosVeiculo == null)
            {
                return NotFound();
            }
            return View(DadosVeiculo);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Veiculo DadosVeiculo)
        {
            if (id != DadosVeiculo.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Update(DadosVeiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(DadosVeiculo);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var DadosVeiculo = await _context.Veiculos.FindAsync(id);
            if (DadosVeiculo == null)
            {
                return NotFound();
            }
            return View(DadosVeiculo);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var DadosVeiculo = await _context.Veiculos.FindAsync(id);
            if (DadosVeiculo == null)
            {
                return NotFound();
            }
            return View(DadosVeiculo);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var DadosVeiculo = await _context.Veiculos.FindAsync(id);
            if (id == null)
            {
                return NotFound();
            }
            _context.Veiculos.Remove(DadosVeiculo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
