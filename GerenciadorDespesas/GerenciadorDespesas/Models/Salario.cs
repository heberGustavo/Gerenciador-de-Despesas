using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorDespesas.Models
{
    public class Salario
    {
        public int SalarioId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "Valor inválido.")]
        public double Valor { get; set; }

        public int MesId { get; set; }
        public Mes Meses { get; set; }


    }
}
