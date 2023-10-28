using Microsoft.AspNetCore.Mvc;
using SistemaRH.Models;
using SistemaRH.Tabelas;

namespace SistemaRH.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AliquotaController : Controller
{
    AliquotaTabela aliquotaTabela = new();
    AliquotaDetalheTabela aliquotaDetalheTb = new ();

    private string ValidaAliquota(Aliquota aliquota){
        if (aliquota == null)
        {
            return "Aliquota inválido";
        }

        if (string.IsNullOrWhiteSpace(aliquota.Descricao))
        {
            return "Descrição é obrigatório";
        }

        if (aliquota.AnoVigencia < DateTime.Now.Year)
        {
            return "Ano de vigência inválido";
        }

        return string.Empty;
    }

    [HttpPost]
    public IActionResult Post(Aliquota aliquota)
    {
        string erro = ValidaAliquota(aliquota);

        if (string.IsNullOrWhiteSpace(erro))
        {
            int id = aliquotaTabela.Inserir(aliquota.Descricao, aliquota.AnoVigencia, aliquota.Desconta);

            aliquota.Id = id;

            return Ok(aliquota);
        }

        return BadRequest(erro);
    }

    [HttpGet]
    public IActionResult Get()
    {
        var aliquotas = aliquotaTabela.GetAliquotas();

        return Ok(aliquotas);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Id inválido");
        }

        Aliquota Aliquota = aliquotaTabela.GetAliquota(id);

        return Ok(Aliquota);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Aliquota aliquota)
    {

        if (id <= 0)
        {
            return BadRequest("Id inválido");
        }

        Aliquota AliquotaExiste = aliquotaTabela.GetAliquota(id);

        if (AliquotaExiste == null)
        {
            return BadRequest("Não encontrado");
        }

        aliquota.Id = id;

        string erro = ValidaAliquota(aliquota);

        if (string.IsNullOrWhiteSpace(erro))
        {
            aliquotaTabela.Atualiza(aliquota);

            return Ok(aliquota);
        }
        

        return Ok(aliquota);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {

        if (id <= 0)
        {
            return BadRequest("Id inválido");
        }

        Aliquota Aliquota = aliquotaTabela.GetAliquota(id);

        if (Aliquota == null)
        {
            return BadRequest("Não encontrado");
        }

        var detalhes = aliquotaDetalheTb.GetAliquotaDetalhesPorIdAliquota(id);

        if (detalhes.Count > 0)
        {
            return BadRequest("Essa alíquota possúi detalhes cadastrados.");
        }
        
        aliquotaTabela.Deleta(id);

        return Ok();
    }
}
