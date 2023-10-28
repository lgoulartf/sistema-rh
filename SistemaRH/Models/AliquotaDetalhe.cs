using SistemaRH.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SistemaRH;

public class AliquotaDetalhe {
    public int Id { get; set; }
    public int IdAliquota { get; set; }

    [DisplayFormat(DataFormatString = "{0:N2}")]
    [DisplayName("Base de cálculo")]
    public decimal BaseCalculo { get; set; }

    public float Porcentagem { get; set; }

    [DisplayName("Alíquota")]
    public Aliquota Aliquota { get; set; }
}