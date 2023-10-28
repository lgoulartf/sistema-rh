using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaRH.Models;
using SistemaRH.Tabelas;

namespace SistemaRH.Controllers
{
    public class FuncionarioSalariosController : Controller
    {
        FuncionarioSalarioTabela funcionarioSalarioTb = new FuncionarioSalarioTabela();
        FuncionarioTabela funcionarioTb = new FuncionarioTabela();

        // GET: FuncionarioSalarios
        public async Task<IActionResult> Index()
        {
            var funcionarioSalarios = funcionarioSalarioTb.GetFuncionarioSalarios(DateOnly.FromDateTime(DateTime.Now));
            return View(funcionarioSalarios);
                     
        }

        // GET: FuncionarioSalarios/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var funcionarioSalario = funcionarioSalarioTb.GetFuncionarioSalario(id);

            if (funcionarioSalario == null)
            {
                return NotFound();
            }

            return View(funcionarioSalario);
        }

        // GET: FuncionarioSalarios/Create
        public IActionResult Create()
        {
            var funcionarios = funcionarioTb.GetFuncionarios();

            ViewBag.Funcionarios = new SelectList(funcionarios, "Id", "Nome", "IdFuncionario");
            return View();
        }

        public string ValidaFuncionarioSalario(FuncionarioSalario funcionarioSalario)
        {
            string erro = string.Empty;

            if (funcionarioSalario == null)
            {
                erro = "Entidade inválida";
            }

            if (funcionarioSalario.Salario <= 0)
            {
                erro = "Salário inválido";
            }

            if (funcionarioSalario.IdFuncionario <= 0)
            {
                erro = "Funcionário inválido";
            }

            return erro;
        }

        // POST: FuncionarioSalarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdFuncionario,Salario,VigenteEm")] FuncionarioSalario funcionarioSalario)
        {
            string erro = ValidaFuncionarioSalario(funcionarioSalario);

            if (string.IsNullOrWhiteSpace(erro))
            {
                funcionarioSalarioTb.Inserir(funcionarioSalario);

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Erro = erro;

            return View(funcionarioSalario);
        }

        // GET: FuncionarioSalarios/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var funcionarioSalario = funcionarioSalarioTb.GetFuncionarioSalario(id);

            if (funcionarioSalario == null)
            {
                return NotFound();
            }

            return View(funcionarioSalario);
        }

        // POST: FuncionarioSalarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdFuncionario,Salario, VigenteEm")] FuncionarioSalario funcionarioSalario)
        {
            bool funcionarioSalarioExiste = FuncionarioSalarioExiste(id);

            if (!funcionarioSalarioExiste) { return NotFound(); }

            string erro = ValidaFuncionarioSalario(funcionarioSalario);

            if (string.IsNullOrWhiteSpace(erro))
            {
                funcionarioSalarioTb.Atualiza(funcionarioSalario);

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Erro = erro;
            return View(funcionarioSalario);
        }

        // GET: FuncionarioSalarios/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var funcionarioSalario = funcionarioSalarioTb.GetFuncionarioSalario(id);

            if (funcionarioSalario == null)
            {
                return NotFound();
            }

            return View(funcionarioSalario);
        }

        // POST: FuncionarioSalarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool funcionarioSalarioExiste = FuncionarioSalarioExiste(id);

            if (funcionarioSalarioExiste == false)
            {
                return NotFound();
            }

            funcionarioSalarioTb.Deleta(id);

            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioSalarioExiste(int id)
        {
          return funcionarioSalarioTb.GetFuncionarioSalario(id) != null;
        }
    }
}
