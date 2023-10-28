using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaRH.Models;

public class Funcionario {
    public Funcionario()
    {

    }
    public Funcionario(DateOnly dataAdmissao, string nome)
    {
        Nome = nome;

        if (dataAdmissao == default)
        {
            DataAdmissao = DateOnly.FromDateTime(DateTime.Now);
        }
        else
        {
            DataAdmissao = dataAdmissao;
        }
        
    }
    
    public int Id { get; set;}

    public string Nome { get; set;}

    [NotMapped]
    public DateOnly DataAdmissao { get; set; }
}