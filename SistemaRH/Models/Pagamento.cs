namespace SistemaRH.Models;

public class Pagamento
{
    public int Id { get; set;}
    public DateOnly DataPagamento { get; set; }
    public DateOnly DataReferencia { get; set; }
    public int IdFuncionarioSalario { get; set; }
    public decimal SalarioLiquido { get; set; }

    public FuncionarioSalario FuncionarioSalario {  set; get; }
}