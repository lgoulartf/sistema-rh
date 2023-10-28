using SistemaRHDesktop.Aliquota;
using SistemaRHDesktop.AliquotaDetalhes;
using SistemaRHDesktop.Pagamentos;

namespace SistemaRHDesktop
{
    public partial class TelaInicial : Form
    {
        public TelaInicial()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ListagemFuncionarios();
            form.Show();
            form.BringToFront();
        }

        private void cadastroDeSalariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ListagemFuncionarioSalarios();
            form.Show();
            form.BringToFront();
        }

        private void cadastroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new ListagemAliquotas();
            form.Show();
            form.BringToFront();
        }

        private void cadastroDeDetalhesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ListagemAliquotaDetalhes();
            form.Show();
            form.BringToFront();
        }

        private void gerarPagamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ListagemPagamentos();
            form.Show();
            form.BringToFront();
        }
    }
}