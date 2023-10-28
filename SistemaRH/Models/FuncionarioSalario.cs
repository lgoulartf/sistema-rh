using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaRH.Models
{
    public class FuncionarioSalario
    {
        public int Id { get; set; }

        public int IdFuncionario { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal Salario { get; set; }

        [NotMapped]
        public DateOnly VigenteEm { get; set; }

        public Funcionario Funcionario { get; set; }
    }
}
