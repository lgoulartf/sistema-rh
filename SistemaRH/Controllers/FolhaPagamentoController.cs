using Microsoft.AspNetCore.Mvc;
using SistemaRH.Models;
using SistemaRH.Tabelas;
using System.Data.SqlClient;

namespace SistemaRH.Controllers;

[ApiController]
[Route("[controller]")]
public class FolhaPagamentoController : ControllerBase
{
    FuncionarioTabela funcionarioTabela = new();
    AliquotaTabela aliquotaTabela = new();
    AliquotaDetalheTabela aliquotaDetalheTabela = new();
    PagamentoTabela pagamentoTabela = new();


    //private List<Pagamento> CalculaFolhaPagamento() {
    //    List<Funcionario> funcionarios = funcionarioTabela.GetFuncionarios();

    //    List<Aliquota> aliquotas = aliquotaTabela.GetAliquotas();

    //    List<Pagamento> folhaPagamentos = new();

    //    foreach (var funcionario in funcionarios)
    //    {
    //        Pagamento pagamento = new()
    //        {
    //            SalarioLiquido = funcionario.Salario,
    //            DataPagamento = DateOnly.FromDateTime(DateTime.Now),
    //            IdFuncionario = funcionario.Id
    //        };

    //        foreach (var aliquota in aliquotas.Where(x => x.AnoVigencia == DateTime.Now.Year && x.Desconta == true))
    //        {
    //            aliquota.AliquotaDetalhes = aliquotaDetalheTabela.GetAliquotaDetalhesPorIdAliquota(aliquota.Id);

    //            foreach (var aliquotaDetalhe in aliquota.AliquotaDetalhes)
    //            {
    //                if (funcionario.Salario <= aliquotaDetalhe.BaseCalculo)
    //                {
    //                    pagamento.SalarioLiquido -= pagamento.SalarioLiquido * (decimal)aliquotaDetalhe.Porcentagem / 100; 
    //                }
    //            }
    //        }

    //        folhaPagamentos.Add(pagamento);
    //    }

    //    return folhaPagamentos;
    //}

    //[HttpPost]
    //public IActionResult Post()
    //{
    //    List<Pagamento> folhaPagamentos = CalculaFolhaPagamento();

    //    foreach (var pagamento in folhaPagamentos)
    //    {
    //        int id = pagamentoTabela.Inserir(pagamento.DataPagamento, pagamento.IdFuncionario, pagamento.SalarioLiquido);

    //        pagamento.Id = id;
    //    }
        
    //    return Ok(folhaPagamentos);
    //}

    // [HttpGet("{id}")]
    // public IActionResult Get(int id)
    // {
    //     if (id <= 0)
    //     {
    //         return BadRequest("Id inválido");
    //     }

    //     FolhaPagamento FolhaPagamento = GetFolhaPagamento(id);

    //     return Ok(FolhaPagamento);
    // }

    // [HttpPut("{id}")]
    // public IActionResult Put(int id, FolhaPagamento FolhaPagamento)
    // {

    //     if (id <= 0)
    //     {
    //         return BadRequest("Id inválido");
    //     }

    //     FolhaPagamento FolhaPagamentoExiste = GetFolhaPagamento(id);

    //     if (FolhaPagamentoExiste == null)
    //     {
    //         return BadRequest("Não encontrado");
    //     }

    //     FolhaPagamento.Id = id;

    //     string erro = ValidaFolhaPagamento(FolhaPagamento);

    //     if (string.IsNullOrWhiteSpace(erro))
    //     {
    //         Atualiza(FolhaPagamento);

    //         return Ok(FolhaPagamento);
    //     }
        

    //     return Ok(FolhaPagamento);
    // }

    // [HttpDelete("{id}")]
    // public IActionResult Delete(int id)
    // {

    //     if (id <= 0)
    //     {
    //         return BadRequest("Id inválido");
    //     }

    //     FolhaPagamento FolhaPagamento = GetFolhaPagamento(id);

    //     if (FolhaPagamento == null)
    //     {
    //         return BadRequest("Não encontrado");
    //     }
        
    //     Deleta(id);

    //     return Ok();
    // }

    // private void Deleta(int id) {
    //     try
    //     {
    //         connection.Open();

    //         SqlCommand sqlCommand = new SqlCommand(@$"delete from tbFolhaPagamentos where id = @id;", connection);
            
    //         sqlCommand.Parameters.AddWithValue("@id", id);

    //         sqlCommand.ExecuteScalar();
    //         sqlCommand.Dispose();    
    //     }
    //     catch (Exception)
    //     {
    //         throw new Exception("Erro ao atualizar dados");
    //     }
    //     finally {
    //         connection.Close();
    //     }
    // }

    // private void Atualiza(FolhaPagamento FolhaPagamento) {
    //     try
    //     {
    //         connection.Open();

    //         SqlCommand sqlCommand = new SqlCommand(@$"update tbFolhaPagamentos set nome = @nome, salario = @salario where id = @id;", connection);
            
    //         sqlCommand.Parameters.AddWithValue("@nome", FolhaPagamento.Nome);
    //         sqlCommand.Parameters.AddWithValue("@salario", FolhaPagamento.Salario);
    //         sqlCommand.Parameters.AddWithValue("@id", FolhaPagamento.Id);

    //         sqlCommand.ExecuteScalar();
    //         sqlCommand.Dispose();    
    //     }
    //     catch (Exception)
    //     {
    //         throw new Exception("Erro ao atualizar dados");
    //     }
    //     finally {
    //         connection.Close();
    //     }
    // }

    // private FolhaPagamento GetFolhaPagamento(int id) {
    //     try
    //     {
    //         connection.Open();

    //         SqlCommand sqlCommand = new SqlCommand(@$"select * from tbFolhaPagamentos where id = @id", connection);
    //         sqlCommand.Parameters.AddWithValue("@id", id);
    //         SqlDataReader reader = sqlCommand.ExecuteReader();

    //         string nome = string.Empty;
    //         decimal salario = 0;

    //         while (reader.Read()){
    //             nome = reader[1].ToString();
    //             salario =  Convert.ToDecimal(reader[2]);
    //             break;
    //         }

    //         sqlCommand.Dispose();
    //         reader.Close();

    //         if (nome == string.Empty && salario == 0)
    //         {
    //             return null;
    //         }

    //         FolhaPagamento FolhaPagamento = new FolhaPagamento(nome, salario)
    //         {
    //             Id = id
    //         };

    //         return FolhaPagamento;
    //     }
    //     catch (System.Exception)
    //     {
    //         throw new Exception("Erro ao tentar recuperar dados");
    //     }
    //     finally {
    //         connection.Close();
    //     }
    // }
}
