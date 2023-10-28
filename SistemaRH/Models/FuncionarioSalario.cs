using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaRH.Models
{
    public class FuncionarioSalario
    {
        public int Id { get; set; }

        public int IdFuncionario { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [DisplayName("Salário")]
        public decimal Salario { get; set; }

        [NotMapped]
        [DisplayName("Vigente em")]
        public DateOnly VigenteEm { get; set; }

        [DisplayName("Funcionário")]
        public Funcionario Funcionario { get; set; }
    }
}
