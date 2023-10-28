using Microsoft.AspNetCore.Mvc;
using SistemaRH.Tabelas;

namespace SistemaRH.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AliquotaDetalheController : Controller
{
    AliquotaDetalheTabela aliquotaDetalheTabela = new AliquotaDetalheTabela();

    private string ValidaAliquotaDetalhe(AliquotaDetalhe aliquotaDetalhe){
        if (aliquotaDetalhe == null)
        {
            return "AliquotaDetalhe inválido";
        }

        if (aliquotaDetalhe.IdAliquota <= 0)
        {
            return "Aliquota obrigatório";
        }

        if (aliquotaDetalhe.BaseCalculo <= 0)
        {
            return "Base de calculo é inválido";
        }

        if (aliquotaDetalhe.Porcentagem <= 0)
        {
            return "Porcentagem é inválido";
        }

        return string.Empty;
    }

    [HttpPost]
    public IActionResult Post(AliquotaDetalhe aliquotaDetalhe)
    {
        string erro = ValidaAliquotaDetalhe(aliquotaDetalhe);

        if (string.IsNullOrWhiteSpace(erro))
        {
            int id = aliquotaDetalheTabela.Inserir(aliquotaDetalhe);

            aliquotaDetalhe.Id = id;

            return Ok(aliquotaDetalhe);
        }

        return BadRequest(erro);
    }

    [HttpGet]
    public IActionResult Get()
    {

        var detalhes = aliquotaDetalheTabela.GetAliquotaDetalhes(DateTime.Now.Year);

        return Ok(detalhes);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Id inválido");
        }

        AliquotaDetalhe AliquotaDetalhe = aliquotaDetalheTabela.GetAliquotaDetalhe(id);

        return Ok(AliquotaDetalhe);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, AliquotaDetalhe AliquotaDetalhe)
    {

        if (id <= 0)
        {
            return BadRequest("Id inválido");
        }

        AliquotaDetalhe AliquotaDetalheExiste = aliquotaDetalheTabela.GetAliquotaDetalhe(id);

        if (AliquotaDetalheExiste == null)
        {
            return BadRequest("Não encontrado");
        }

        AliquotaDetalhe.Id = id;

        string erro = ValidaAliquotaDetalhe(AliquotaDetalhe);

        if (string.IsNullOrWhiteSpace(erro))
        {
            aliquotaDetalheTabela.Atualiza(AliquotaDetalhe);

            return Ok(AliquotaDetalhe);
        }
        

        return Ok(AliquotaDetalhe);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {

        if (id <= 0)
        {
            return BadRequest("Id inválido");
        }

        AliquotaDetalhe AliquotaDetalhe = aliquotaDetalheTabela.GetAliquotaDetalhe(id);

        if (AliquotaDetalhe == null)
        {
            return BadRequest("Não encontrado");
        }
        
        aliquotaDetalheTabela.Deleta(id);

        return Ok();
    }
}
