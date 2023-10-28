using Newtonsoft.Json;
using SistemaRH.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemaRHDesktop
{
    public partial class ListagemFuncionarioSalarios : Form
    {
        FuncionarioSalario FuncionarioSalarioSelecionado;
        public ListagemFuncionarioSalarios()
        {
            InitializeComponent();

            listView1.View = View.Details;

            listView1.Columns.Add("Nome", 120);
            listView1.Columns.Add("Salario", 80);
            listView1.Columns.Add("Vigente em", 120);
        }

        private async void OnEditarFuncionarioSalario_FormClosed(object sender, EventArgs e)
        {
            await AtualizaLista();
        }

        private async Task AtualizaLista()
        {
            listView1.Items.Clear();

            var api = new Api();

            var content = await api.Get("api/FuncionarioSalario");

            var data = JsonConvert.DeserializeObject<List<FuncionarioSalario>>(content);

            foreach (var item in data)
            {
                var x = new ListViewItem(item.Funcionario.Nome);
                x.SubItems.Add(item.Salario.ToString());
                x.SubItems.Add(item.VigenteEm.ToString());
                x.Tag = item;

                listView1.Items.Add(x);
            }
        }

        private async void OnNovoFuncionarioSalario_FormClosed(object sender, EventArgs e)
        {
            await AtualizaLista();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            var form = new NovoFuncionarioSalario();
            form.FormClosed += OnNovoFuncionarioSalario_FormClosed;
            form.ShowDialog();
        }

        private async void ListagemFuncionarioSalarios_Load(object sender, EventArgs e)
        {
            await AtualizaLista();
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            var form = new EditarFuncionarioSalario(FuncionarioSalarioSelecionado);
            form.FormClosed += OnEditarFuncionarioSalario_FormClosed;
            form.ShowDialog();
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                FuncionarioSalarioSelecionado = listView1.SelectedItems[0].Tag as FuncionarioSalario;
                btnEditar.Enabled = true;
                btnExcluir.Enabled = true;
            }
            else
            {
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
            }
        }

        private async void btnExcluir_Click_1(object sender, EventArgs e)
        {
            try
            {
                var api = new Api();

                await api.Delete($"api/FuncionarioSalario/{FuncionarioSalarioSelecionado.Id}");

                await AtualizaLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Falha!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
