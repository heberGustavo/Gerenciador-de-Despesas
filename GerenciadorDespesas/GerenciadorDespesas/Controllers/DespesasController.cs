﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GerenciadorDespesas.Models;
using X.PagedList;

namespace GerenciadorDespesas.Controllers
{
    public class DespesasController : Controller
    {
        private readonly Contexto _context;

        public DespesasController(Contexto context)
        {
            _context = context;
        }

        // GET: Despesas
        public async Task<IActionResult> Index(int? pagina)
        {

            const int itensPagina = 10;
            /*
             * Se a pagina tem algum valor - Recebe o valor da pagina,
             * senão recebera o valor 1
             */
            int numeroPagina = (pagina ?? 1);
                                                                                                      //Chave e nome do campo
            ViewData["Meses"] = new SelectList(_context.Meses.Where(x => x.MesId == x.Salarios.MesId), "MesId", "Nome");

            var contexto = _context.Despesas.Include(d => d.Mes).Include(d => d.TipoDespesa).OrderBy(d => d.MesId);
            return View(await contexto.ToPagedListAsync(numeroPagina, itensPagina));
        }

        // GET: Despesas/Create
        public IActionResult Create()
        {
            ViewData["MesId"] = new SelectList(_context.Meses, "MesId", "Nome");
            ViewData["TipoDespesaId"] = new SelectList(_context.TipoDespesas, "TipoDespesaId", "Nome");
            return View();
        }

        // POST: Despesas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DespesaId,Valor,MesId,TipoDespesaId")] Despesa despesa)
        {
            if (ModelState.IsValid)
            {
                TempData["Confirmacao"] = "Despesa cadastrada com sucesso!";

                _context.Add(despesa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MesId"] = new SelectList(_context.Meses, "MesId", "Nome", despesa.MesId);
            ViewData["TipoDespesaId"] = new SelectList(_context.TipoDespesas, "TipoDespesaId", "Nome", despesa.TipoDespesaId);
            return View(despesa);
        }

        // GET: Despesas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despesa = await _context.Despesas.FindAsync(id);
            if (despesa == null)
            {
                return NotFound();
            }
            ViewData["MesId"] = new SelectList(_context.Meses, "MesId", "Nome", despesa.MesId);
            ViewData["TipoDespesaId"] = new SelectList(_context.TipoDespesas, "TipoDespesaId", "Nome", despesa.TipoDespesaId);
            return View(despesa);
        }

        // POST: Despesas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DespesaId,Valor,MesId,TipoDespesaId")] Despesa despesa)
        {
            if (id != despesa.DespesaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TempData["Confirmacao"] = "Despesa atualizada com sucesso!";
                    _context.Update(despesa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DespesaExists(despesa.DespesaId))
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
            ViewData["MesId"] = new SelectList(_context.Meses, "MesId", "Nome", despesa.MesId);
            ViewData["TipoDespesaId"] = new SelectList(_context.TipoDespesas, "TipoDespesaId", "Nome", despesa.TipoDespesaId);
            return View(despesa);
        }

        // POST: Despesas/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            TempData["Confirmacao"] = "Despesa excluida com sucesso!";

            var despesa = await _context.Despesas.FindAsync(id);
            _context.Despesas.Remove(despesa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DespesaExists(int id)
        {
            return _context.Despesas.Any(e => e.DespesaId == id);
        }
    }
}
