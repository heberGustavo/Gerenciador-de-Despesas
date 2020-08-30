using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDespesas.Models
{
    public class Contexto: DbContext
    {
        /*
         * Depois de criar as classes, chama elas aqui
         * para ser mapeada no Banco de Dados.
         */
        public DbSet<Mes> Meses { get; set; }
        public DbSet<Salario> Salarios { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<TipoDespesa> TipoDespesas { get; set; }

        public Contexto(DbContextOptions<Contexto> options): base(options)
        {

        }
    }
}
