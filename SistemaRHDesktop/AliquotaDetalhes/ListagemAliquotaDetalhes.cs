using Newtonsoft.Json;
using SistemaRH;
using SistemaRHDesktop.Aliquota;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRHDesktop.AliquotaDetalhes
{
    public partial class ListagemAliquotaDetalhes : Form
    {
        AliquotaDetalhe AliquotaDetalheSelecionado { get; set; }

        public ListagemAliquotaDetalhes()
        {
            InitializeComponent();

            listView1.View = View.Details;

            listView1.Columns.Add("Aliquota", 80);
            listView1.Columns.Add("Base de cálculo", 80);
            listView1.Columns.Add("Porcentagem", 80);
        }

        private async void ListagemAliquotaDetalhes_Load(object sender, EventArgs e)
        {
            await AtualizaLista();
        }

        private async Task AtualizaLista()
        {
            listView1.Items.Clear();

            var api = new Api();

            var content = await api.Get("api/AliquotaDetalhe");

            var data = JsonConvert.DeserializeObject<List<AliquotaDetalhe>>(content);

            foreach (var item in data)
            {
                var x = new ListViewItem(item.Aliquota.Descricao);
                x.SubItems.Add(item.BaseCalculo.ToString());
                x.SubItems.Add(item.Porcentagem.ToString());
                x.Tag = item;

                listView1.Items.Add(x);
            }

            listView1.Update();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            var form = new NovoAliquotaDetalhe();
            form.FormClosed += OnNovoAliquotaDetalhe_FormClosed;
            form.ShowDialog();
        }

        private async void OnNovoAliquotaDetalhe_FormClosed(object sender, FormClosedEventArgs e)
        {
            await AtualizaLista();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                AliquotaDetalheSelecionado = listView1.SelectedItems[0].Tag as AliquotaDetalhe;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var form = new EditarAliquotaDetalhe(AliquotaDetalheSelecionado);
            form.FormClosed += OnNovoAliquotaDetalhe_FormClosed;
            form.ShowDialog();
        }

        private async void OnEditarAliquotaDetalhe_FormClosed(object sender, FormClosedEventArgs e)
        {
            await AtualizaLista();
        }

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                var api = new Api();

                await api.Delete($"api/AliquotaDetalhe/{AliquotaDetalheSelecionado.Id}");

                await AtualizaLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Falha!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
