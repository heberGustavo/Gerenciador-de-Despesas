using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GerenciadorDespesas.Models;

namespace GerenciadorDespesas.Controllers
{
    public class SalariosController : Controller
    {
        private readonly Contexto _context;

        public SalariosController(Contexto context)
        {
            _context = context;
        }

        // GET: Salarios
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Salarios.Include(s => s.Meses);
            return View(await contexto.ToListAsync());
        }


        // GET: Salarios/Create
        public IActionResult Create()
        {
            ViewData["MesId"] = new SelectList(_context.Meses.Where(x => x.MesId != x.Salarios.MesId), "MesId", "Nome");
            return View();
        }

        // POST: Salarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalarioId,Valor,MesId")] Salario salario)
        {
            if (ModelState.IsValid)
            {
                TempData["Confirmacao"] = "Salário cadastrado com sucesso!.";

                _context.Add(salario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MesId"] = new SelectList(_context.Meses.Where(x => x.MesId != x.Salarios.MesId), "MesId", "Nome", salario.MesId);
            return View(salario);
        }

        // GET: Salarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salario = await _context.Salarios.FindAsync(id);
            if (salario == null)
            {
                return NotFound();
            }
            ViewData["MesId"] = new SelectList(_context.Meses.Where(x => x.MesId == salario.MesId), "MesId", "Nome", salario.MesId);
            return View(salario);
        }

        // POST: Salarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalarioId,Valor,MesId")] Salario salario)
        {
            if (id != salario.SalarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salario);
                    await _context.SaveChangesAsync();

                    TempData["Confirmacao"] = "Salário atualizado com sucesso!.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalarioExists(salario.SalarioId))
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
            ViewData["MesId"] = new SelectList(_context.Meses.Where(x => x.MesId == salario.MesId), "MesId", "Nome", salario.MesId);
            return View(salario);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            TempData["Confirmacao"] = "Salário excluido com sucesso!.";

            var salario = await _context.Salarios.FindAsync(id);
            _context.Salarios.Remove(salario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalarioExists(int id)
        {
            return _context.Salarios.Any(e => e.SalarioId == id);
        }
    }
}
