using System.ComponentModel;

namespace SistemaRH.Models;

public class Pagamento
{
    public int Id { get; set;}
    
    [DisplayName("Data de pagamento")]
    public DateOnly DataPagamento { get; set; }
    
    [DisplayName("Data de referência")]
    public DateOnly DataReferencia { get; set; }
    
    public int IdFuncionarioSalario { get; set; }
    
    [DisplayName("Salário líquido")]
    public decimal SalarioLiquido { get; set; }

    public FuncionarioSalario FuncionarioSalario {  set; get; }
}