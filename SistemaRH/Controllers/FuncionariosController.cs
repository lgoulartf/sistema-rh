using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SistemaRH.Models;
using SistemaRH.Tabelas;

namespace SistemaRH.Controllers
{
    public class FuncionariosController : Controller
    {
        FuncionarioTabela funcionarioTb = new();
        PagamentoTabela pagamentoTb = new();

        // GET: Funcionarios
        public IActionResult Index()
        {
            var funcionarios = funcionarioTb.GetFuncionarios();
            return View(funcionarios);
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var funcionario = funcionarioTb.GetFuncionario(id);

            return View(funcionario);
            
        }

        // GET: Funcionarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DataAdmissao")] Funcionario funcionario)
        {
            string erro = ValidaFuncionario(funcionario);

            if (string.IsNullOrWhiteSpace(erro))
            {
                int id = funcionarioTb.Inserir(funcionario);

                funcionario.Id = id;

                return RedirectToAction(nameof(Index));
            }

            ViewBag.ErrorMessage = erro;
            return View();
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var funcionario = funcionarioTb.GetFuncionario(id);

            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Nome,DataAdmissao")] Funcionario funcionario)
        {
            if (id <= 0)
            {
                return BadRequest("Id inválido");
            }

            Funcionario funcionarioExiste = funcionarioTb.GetFuncionario(id);

            if (funcionarioExiste == null)
            {
                return BadRequest("Não encontrado");
            }

            funcionario.Id = id;

            string erro = ValidaFuncionario(funcionario);

            if (string.IsNullOrWhiteSpace(erro))
            {
                funcionarioTb.Atualiza(funcionario);

                return RedirectToAction(nameof(Index));
            }

            return View(funcionario);
            
        }

        // GET: Funcionarios/Delete/5
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id inválido");
            }

            var funcionario = funcionarioTb.GetFuncionario(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id inválido");
            }

            Funcionario funcionario = funcionarioTb.GetFuncionario(id);

            if (funcionario == null)
            {
                
                return View();
            }

            bool funcionarioTemPagamento = pagamentoTb.FuncionarioTemPagamento(funcionario.Id);

            if (funcionarioTemPagamento)
            {
                ModelState.AddModelError<Funcionario>(x => x.Id, "Funcionário possúi pagamentos realizados");
                return View(funcionario);
            }

            funcionarioTb.Deleta(id);

            return RedirectToAction(nameof(Index));
        }

        private string ValidaFuncionario(Funcionario funcionario)
        {
            if (funcionario == null)
            {
                return "Usuário inválido";
            }

            if (string.IsNullOrWhiteSpace(funcionario.Nome))
            {
                return "Nome é obrigatório";
            }

            return string.Empty;
        }
    }
}
