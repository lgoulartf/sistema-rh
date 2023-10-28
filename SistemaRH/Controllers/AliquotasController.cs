using Microsoft.AspNetCore.Mvc;
using SistemaRH.Models;
using SistemaRH.Tabelas;

namespace SistemaRH.Controllers
{
    public class AliquotasController : Controller
    {
        AliquotaTabela aliquotaTb = new();

        // GET: Aliquotas
        public async Task<IActionResult> Index()
        {
            List<Aliquota> aliquotas = aliquotaTb.GetAliquotas();
            return View(aliquotas);
        }

        // GET: Aliquotas/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id inválido");
            }

            Aliquota aliquota = aliquotaTb.GetAliquota(id);
            if (aliquota == null)
            {
                return NotFound();
            }

            return View(aliquota);
        }

        // GET: Aliquotas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aliquotas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AnoVigencia,Descricao,Desconta")] Aliquota aliquota)
        {
            string erro = ValidaAliquota(aliquota);

            if (string.IsNullOrWhiteSpace(erro))
            {
                int id = aliquotaTb.Inserir(aliquota.Descricao, aliquota.AnoVigencia, aliquota.Desconta);

                aliquota.Id = id;

                return RedirectToAction(nameof(Index));
            }

            return View(aliquota);
        }

        // GET: Aliquotas/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var aliquota = aliquotaTb.GetAliquota(id);

            if (aliquota == null)
            {
                return NotFound();
            }

            return View(aliquota);
        }

        // POST: Aliquotas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AnoVigencia,Descricao,Desconta")] Aliquota aliquota)
        {
            if (id != aliquota.Id)
            {
                return NotFound();
            }

            var erro = ValidaAliquota(aliquota);

            if (!string.IsNullOrWhiteSpace(erro))
            {
                ViewBag.ErrorMessage = erro;
                return View(aliquota);
            }

            aliquotaTb.Atualiza(aliquota);

            return RedirectToAction(nameof(Index));
            
        }

        // GET: Aliquotas/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var aliquota = aliquotaTb.GetAliquota(id);

            
            if (aliquota == null)
            {
                return NotFound();
            }

            return View(aliquota);
        }

        // POST: Aliquotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool aliquotaExiste = AliquotaExiste(id);
            if (aliquotaExiste == false)
            {
                return Problem("Aliquota nao existe");
            }

            aliquotaTb.Deleta(id);

            return RedirectToAction(nameof(Index));
        }

        private bool AliquotaExiste(int id)
        {
            return aliquotaTb.GetAliquota(id) != null;
        }

        private string ValidaAliquota(Aliquota aliquota)
        {
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
    }
}
