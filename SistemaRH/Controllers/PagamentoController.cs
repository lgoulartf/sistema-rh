using Microsoft.AspNetCore.Mvc;
using SistemaRH.Models;
using SistemaRH.Tabelas;

namespace SistemaRH.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagamentoController : Controller
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

        [HttpGet("{referencia}")]
        public async Task<IActionResult> Get(DateTime referencia)
        {
            var pagamentos = pagamentoTb.GetPagamentos(referencia);

            return Ok(pagamentos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Pagamento pagamento)
        {
            var pagamentos = CalculaFolhaPagamento(pagamento.DataPagamento, pagamento.DataReferencia);

            foreach (var pagamentoCalculado in pagamentos)
            {
                pagamentoTb.Inserir(pagamentoCalculado);
            }
            
            return Ok();
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
