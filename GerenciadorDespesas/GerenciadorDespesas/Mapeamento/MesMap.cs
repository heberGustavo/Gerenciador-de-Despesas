using GerenciadorDespesas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDespesas.Mapeamento
{
    public class MesMap : IEntityTypeConfiguration<Mes>
    {
        public void Configure(EntityTypeBuilder<Mes> builder)
        {
            builder.HasKey(m => m.MesId);
            //Chava primaria inserida manualmente
            builder.Property(m => m.MesId).ValueGeneratedNever();

            builder.Property(m => m.Nome).HasMaxLength(50).IsRequired();

            //Relação com Despesa                                                          //Quando um mês for excluido, todas as despesas relacionadas a esse mes tmb é excluido
            builder.HasMany(m => m.Despesas).WithOne(m => m.Mes).HasForeignKey(m => m.MesId).OnDelete(DeleteBehavior.Cascade);

            //Relação com Salario
            builder.HasOne(m => m.Salarios).WithOne(m => m.Meses).OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Mes");
        }
    }
}
