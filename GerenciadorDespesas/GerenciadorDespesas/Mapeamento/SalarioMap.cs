using GerenciadorDespesas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDespesas.Mapeamento
{
    public class SalarioMap : IEntityTypeConfiguration<Salario>
    {
        public void Configure(EntityTypeBuilder<Salario> builder)
        {
            builder.HasKey(s => s.SalarioId);
            builder.Property(s => s.Valor).IsRequired();

            //FK
            builder.HasOne(s => s.Meses).WithOne(s => s.Salarios).HasForeignKey<Salario>(s => s.MesId);

            builder.ToTable("Salario");
        }
    }
}
