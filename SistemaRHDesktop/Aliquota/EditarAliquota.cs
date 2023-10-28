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
    public partial class EditarAliquota : Form
    {
        SistemaRH.Models.Aliquota Aliquota { get; set; }
        public EditarAliquota(SistemaRH.Models.Aliquota aliquota)
        {
            InitializeComponent();

            Aliquota = aliquota;
            txtAnoVigente.Text = Aliquota.AnoVigencia.ToString();
            txtDescricao.Text = Aliquota.Descricao;
            ckbDesconta.Checked = Aliquota.Desconta;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Aliquota.Descricao = txtDescricao.Text;
            Aliquota.Desconta = ckbDesconta.Checked;
            Aliquota.AnoVigencia = Convert.ToInt32(txtAnoVigente.Text);

            var data = JsonConvert.SerializeObject(Aliquota);

            var api = new Api();

            try
            {
                await api.Put($"api/Aliquota/{Aliquota.Id}", data);

                MessageBox.Show("Salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Falha!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
