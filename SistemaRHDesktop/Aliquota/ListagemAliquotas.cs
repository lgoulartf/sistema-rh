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

namespace SistemaRHDesktop.Aliquota
{
    public partial class ListagemAliquotas : Form
    {
        SistemaRH.Models.Aliquota AliquotaSelecionada { get; set; }

        public ListagemAliquotas()
        {
            InitializeComponent();

            listView1.View = View.Details;

            listView1.Columns.Add("Descrição", 120);
            listView1.Columns.Add("Desconta", 80);
            listView1.Columns.Add("Ano vigente", 80);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private async void ListagemAliquotas_Load(object sender, EventArgs e)
        {
            await AtualizaLista();
        }

        private async Task AtualizaLista()
        {
            listView1.Items.Clear();

            var api = new Api();

            var content = await api.Get("api/Aliquota");

            var data = JsonConvert.DeserializeObject<List<SistemaRH.Models.Aliquota>>(content);

            foreach (var item in data)
            {
                var x = new ListViewItem(item.Descricao);
                x.SubItems.Add(item.Desconta.ToString());
                x.SubItems.Add(item.AnoVigencia.ToString());
                x.Tag = item;

                listView1.Items.Add(x);
            }

            listView1.Update();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            var form = new NovoAliquota();
            form.FormClosed += OnNovoAliquota_FormClosed;
            form.ShowDialog();
        }

        private async void OnNovoAliquota_FormClosed(object sender, FormClosedEventArgs e)
        {
            await AtualizaLista();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var form = new EditarAliquota(AliquotaSelecionada);
            form.FormClosed += OnEditarAliquota_FormClosed;
            form.ShowDialog();
        }

        private async void OnEditarAliquota_FormClosed(object sender, FormClosedEventArgs e)
        {
            await AtualizaLista();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                AliquotaSelecionada = listView1.SelectedItems[0].Tag as SistemaRH.Models.Aliquota;
                btnEditar.Enabled = true;
                btnExcluir.Enabled = true;
            } else
            {
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
            }
        }

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                var api = new Api();

                await api.Delete($"api/Aliquota/{AliquotaSelecionada.Id}");

                await AtualizaLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Falha!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
