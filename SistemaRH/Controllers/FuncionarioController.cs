using Microsoft.AspNetCore.Mvc;
using SistemaRH.Models;
using SistemaRH.Tabelas;

namespace SistemaRH.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FuncionarioController : Controller
{
    FuncionarioTabela funcionarioTabela = new();
    FuncionarioSalarioTabela funcionarioSalarioTabela = new();

    [HttpGet]
    public IActionResult Listar(){
        List<Funcionario> funcionarios = funcionarioTabela.GetFuncionarios();
        
        return Ok(funcionarios);
    }

    [HttpPost]
    public IActionResult Post(Funcionario funcionario)
    {
        string erro = ValidaCreate(funcionario);

        if (string.IsNullOrWhiteSpace(erro))
        {
            int id = funcionarioTabela.Inserir(funcionario);

            funcionario.Id = id;

            return Ok(funcionario);
        }

        return BadRequest(erro);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Id inválido");
        }

        Funcionario funcionario = funcionarioTabela.GetFuncionario(id);

        return Ok(funcionario);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Funcionario funcionario)
    {
        if (id <= 0)
        {
            return BadRequest("Id inválido");
        }

        Funcionario funcionarioExiste = funcionarioTabela.GetFuncionario(id);

        if (funcionarioExiste == null)
        {
            return BadRequest("Não encontrado");
        }

        funcionario.Id = id;

        string erro = ValidaUpdate(funcionario);

        if (!string.IsNullOrWhiteSpace(erro))
            return BadRequest(erro);

        funcionarioTabela.Atualiza(funcionario);

        return Ok(funcionario);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Id inválido");
        }

        Funcionario funcionario = funcionarioTabela.GetFuncionario(id);

        if (funcionario == null)
        {
            return BadRequest("Não encontrado");
        }

        var erro = ValidaDelete(id);

        if (!string.IsNullOrEmpty(erro)) return BadRequest(erro);
        
        funcionarioTabela.Deleta(id);

        return Ok();
    }

    public string Valida(Funcionario funcionario)
    {
        if (funcionario == null)
        {
            return "Funcionário não informado";
        }

        if (string.IsNullOrWhiteSpace(funcionario.Nome))
        {
            return "Nome não informado";
        }

        return string.Empty;
    }

    public string ValidaDelete(int id)
    {
        var funcionarioSalario = funcionarioSalarioTabela.GetFuncionarioSalarioPorFuncionarioId(id);

        if (funcionarioSalario != null)
            return "Não é possível excluir um funcionário com salário cadastrado";

        return string.Empty;
    }

    public string ValidaCreate(Funcionario funcionario)
    {
        var erro = Valida(funcionario);

        if (!string.IsNullOrWhiteSpace(erro))
            return erro;

        return string.Empty;
    }

    public string ValidaUpdate(Funcionario funcionario)
    {
        var erro = Valida(funcionario);

        if (!string.IsNullOrWhiteSpace(erro))
            return erro;

        return string.Empty;
    }
}