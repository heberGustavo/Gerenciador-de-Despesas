using GerenciadorDespesas.Models;
using GerenciadorDespesas.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDespesas.ViewComponents
{
    public class EstatisticaViewComponent : ViewComponent
    {
        private readonly Contexto _contexto;

        public EstatisticaViewComponent(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            EstatisticaViewModel estatistica = new EstatisticaViewModel();

            estatistica.QuantidadeDespesas = _contexto.Despesas.Count();
            estatistica.MaiorDespesa = _contexto.Despesas.Max(x => x.Valor);
            estatistica.MenorDespesa = _contexto.Despesas.Min(x => x.Valor);

            return View(estatistica);
        }
    }
}
