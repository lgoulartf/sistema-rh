using Azure;
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

namespace SistemaRHDesktop
{
    public partial class ListagemFuncionarios : Form
    {
        Funcionario FuncionarioSelecionado;
        public ListagemFuncionarios()
        {
            InitializeComponent();

            listView1.View = View.Details;

            listView1.Columns.Add("Nome");
            listView1.Columns.Add("Data de Admissao", 120);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var form = new EditarFuncionario(FuncionarioSelecionado);
            form.FormClosed += OnEditarFuncionario_FormClosed;
            form.ShowDialog();
        }

        private async void OnEditarFuncionario_FormClosed(object sender, EventArgs e)
        {
            await AtualizaLista();
        }

        private async Task AtualizaLista()
        {
            listView1.Items.Clear();

            var api = new Api();

            var content = await api.Get("api/Funcionario");

            var data = JsonConvert.DeserializeObject<List<Funcionario>>(content);

            foreach (var item in data)
            {
                var x = new ListViewItem(item.Nome);
                x.SubItems.Add(item.DataAdmissao.ToString());
                x.Tag = item;
                listView1.Items.Add(x);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                FuncionarioSelecionado = listView1.SelectedItems[0].Tag as Funcionario;
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            var form = new NovoFuncionario();
            form.FormClosed += OnNovoFuncionario_FormClosed;
            form.ShowDialog();

        }

        private async void OnNovoFuncionario_FormClosed(object sender, EventArgs e)
        {
            await AtualizaLista();
        }

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                var api = new Api();

                await api.Delete($"api/Funcionario/{FuncionarioSelecionado.Id}");

                await AtualizaLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Falha!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ListagemFuncionarios_Load(object sender, EventArgs e)
        {
            await AtualizaLista();
        }
    }
}
