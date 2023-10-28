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

namespace SistemaRHDesktop.Pagamentos
{
    public partial class ListagemPagamentos : Form
    {
        public ListagemPagamentos()
        {
            InitializeComponent();

            listView1.View = View.Details;

            listView1.Columns.Add("Funcionario", 120);
            listView1.Columns.Add("Salario bruto", 80);
            listView1.Columns.Add("Salario liquido", 120);
            listView1.Columns.Add("Referencia", 80);
            listView1.Columns.Add("Data de pagamento", 120);

            dtpReferencia.Format = DateTimePickerFormat.Custom;
            dtpReferencia.CustomFormat = "MM/yyyy";

            dtpReferencia.Value = DateTime.Now;
        }

        private async Task AtualizaLista()
        {
            var api = new Api();

            var referencia = dtpReferencia.Value.ToString("o");
            var content = await api.Get($"api/Pagamento/{referencia}");

            var data = JsonConvert.DeserializeObject<List<Pagamento>>(content);


            foreach (var item in data)
            {
                var x = new ListViewItem(item.FuncionarioSalario.Funcionario.Nome);
                x.SubItems.Add(item.FuncionarioSalario.Salario.ToString());
                x.SubItems.Add(item.SalarioLiquido.ToString());
                x.SubItems.Add(item.DataReferencia.ToString("MM/yyyy"));
                x.SubItems.Add(item.DataPagamento.ToString());
                x.Tag = item;
                listView1.Items.Add(x);
            }

            listView1.Update();

        }

        private async void ListagemPagamentos_Load(object sender, EventArgs e)
        {
            await AtualizaLista();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var pagamento = new Pagamento()
            {
                DataPagamento = DateOnly.FromDateTime(DateTime.Now),
                DataReferencia = DateOnly.FromDateTime(dtpReferencia.Value)
            };

            var data = JsonConvert.SerializeObject(pagamento);

            var api = new Api();

            try
            {
                await api.Post("api/Pagamento", data);

                MessageBox.Show("Folha gerada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Falha!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                await AtualizaLista();
            }
        }
    }
}
