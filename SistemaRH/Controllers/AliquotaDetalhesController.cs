using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaRH.Tabelas;

namespace SistemaRH.Controllers
{
    public class AliquotaDetalhesController : Controller
    {
        AliquotaDetalheTabela aliquotaDetalheTb = new();
        AliquotaTabela aliquotaTb = new();

        // GET: AliquotaDetalhes
        public async Task<IActionResult> Index()
        {
            var aliquotaDetalhes = aliquotaDetalheTb.GetAliquotaDetalhes(DateTime.Now.Year);
            return View(aliquotaDetalhes);
        }

        // GET: AliquotaDetalhes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var aliquotaDetalhe = aliquotaDetalheTb.GetAliquotaDetalhe(id);

            if (aliquotaDetalhe == null)
            {
                return NotFound();
            }

            return View(aliquotaDetalhe);
        }

        // GET: AliquotaDetalhes/Create
        public IActionResult Create()
        {
            var aliquotas = aliquotaTb.GetAliquotas();
            ViewBag.Aliquotas = aliquotas;
            ViewBag.Aliquotas = new SelectList(aliquotas, "Id", "Descricao", "IdAliquota");
            return View();
        }

        // POST: AliquotaDetalhes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdAliquota,BaseCalculo,Porcentagem")] AliquotaDetalhe aliquotaDetalhe)
        {
            string erro = ValidaAliquotaDetalhe(aliquotaDetalhe);

            if (!string.IsNullOrWhiteSpace(erro))
            {
                ViewBag.ErrorMessage = erro;
                return View();
            }

            aliquotaDetalheTb.Inserir(aliquotaDetalhe);

            return RedirectToAction(nameof(Index));
        }

        // GET: AliquotaDetalhes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var aliquotaDetalhe = aliquotaDetalheTb.GetAliquotaDetalhe(id);

            if (aliquotaDetalhe == null)
            {
                return NotFound();
            }

            return View(aliquotaDetalhe);
        }

        // POST: AliquotaDetalhes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdAliquota,BaseCalculo,Porcentagem, Aliquota")] AliquotaDetalhe aliquotaDetalhe)
        {
            if (id != aliquotaDetalhe.Id)
            {
                return NotFound();
            }

            bool aliquotaDetalheExiste = AliquotaDetalheExiste(id);

            string erro = ValidaAliquotaDetalhe(aliquotaDetalhe);

            if (!string.IsNullOrWhiteSpace(erro)) 
            {
                ViewBag.ErrorMessage = erro; 
                return View(aliquotaDetalhe);
            }

            aliquotaDetalheTb.Atualiza(aliquotaDetalhe);

            return RedirectToAction(nameof(Index));
        }

        // GET: AliquotaDetalhes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var aliquotaDetalhe = aliquotaDetalheTb.GetAliquotaDetalhe(id);

            if (aliquotaDetalhe == null)
            {
                return NotFound();
            }

            return View(aliquotaDetalhe);
        }

        // POST: AliquotaDetalhes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool aliquotaDetalheExiste = AliquotaDetalheExiste(id);

            if (aliquotaDetalheExiste == false)
            {
                return NotFound();
            }

            aliquotaDetalheTb.Deleta(id);

            return RedirectToAction(nameof(Index));
        }

        private bool AliquotaDetalheExiste(int id)
        {
            return aliquotaDetalheTb.GetAliquotaDetalhe(id) != null;
        }

        private string ValidaAliquotaDetalhe(AliquotaDetalhe aliquotaDetalhe)
        {
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
    }
}
