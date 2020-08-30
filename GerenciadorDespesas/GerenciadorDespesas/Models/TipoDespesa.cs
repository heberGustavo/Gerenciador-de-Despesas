using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorDespesas.Models
{
    public class TipoDespesa
    {
        public int TipoDespesaId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(50, ErrorMessage = "Use menos caracteres.")]
        public string Nome { get; set; }

        public ICollection<Despesa> Despesas { get; set; }
    }
}
