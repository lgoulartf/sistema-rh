﻿using Microsoft.AspNetCore.Mvc;
using SistemaRH.Models;
using SistemaRH.Tabelas;

namespace SistemaRH.Controllers
{
    public class PagamentosController : Controller
    {
        PagamentoTabela pagamentoTb = new();
        AliquotaDetalheTabela aliquotaDetalheTb = new();
        FuncionarioSalarioTabela funcionarioSalarioTb = new();

        // GET: Pagamentoes
        public async Task<IActionResult> Index()
        {
            var pagamentos = pagamentoTb.GetPagamentos();
            return View(pagamentos);
        }

        // GET: Pagamentoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pagamentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DataPagamento, DataReferencia")] Pagamento pagamento)
        {
            var pagamentos = CalculaFolhaPagamento(pagamento.DataPagamento, pagamento.DataReferencia);

            foreach (var pagamentoCalculado in pagamentos)
            {
                pagamentoTb.Inserir(pagamentoCalculado);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private List<Pagamento> CalculaFolhaPagamento(DateOnly dataPagamento, DateOnly dataReferencia)
        {
            List<FuncionarioSalario> funcionarios = funcionarioSalarioTb.GetFuncionarioSalarios(dataPagamento);

            List<AliquotaDetalhe> aliquotas = aliquotaDetalheTb.GetAliquotaDetalhes(dataPagamento.Year);

            List<Pagamento> folhaPagamentos = new();

            foreach (var funcionarioSalario in funcionarios)
            {
                Pagamento pagamento = new()
                {
                    SalarioLiquido = funcionarioSalario.Salario,
                    DataPagamento = dataPagamento,
                    DataReferencia = dataReferencia,
                    IdFuncionarioSalario = funcionarioSalario.Id,
                };

                foreach (var aliquotaDetalhes in aliquotas.Where(x => x.Aliquota.AnoVigencia == DateTime.Now.Year && x.Aliquota.Desconta == true))
                {
                    if (funcionarioSalario.Salario <= aliquotaDetalhes.BaseCalculo)
                    {
                        pagamento.SalarioLiquido -= pagamento.SalarioLiquido * (decimal)aliquotaDetalhes.Porcentagem / 100;
                    }
                }

                folhaPagamentos.Add(pagamento);
            }

            return folhaPagamentos;
        }
    }
}
