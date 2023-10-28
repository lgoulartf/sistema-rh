using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaRH.Models;
using SistemaRH;

namespace SistemaRH.Data
{
    public class SistemaRHContext : DbContext
    {
        public SistemaRHContext (DbContextOptions<SistemaRHContext> options)
            : base(options)
        {
        }

        public DbSet<SistemaRH.Models.Aliquota> Aliquota { get; set; } = default!;

        public DbSet<SistemaRH.Models.Funcionario> Funcionario { get; set; } = default!;

        public DbSet<SistemaRH.AliquotaDetalhe> AliquotaDetalhe { get; set; } = default!;

        public DbSet<SistemaRH.Models.FuncionarioSalario> FuncionarioSalario { get; set; } = default!;

        public DbSet<SistemaRH.Models.Pagamento> Pagamento { get; set; } = default!;
    }
}
