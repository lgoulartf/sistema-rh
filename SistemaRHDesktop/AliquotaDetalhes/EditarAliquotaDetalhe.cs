using Newtonsoft.Json;
using SistemaRH;
using SistemaRH.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRHDesktop.AliquotaDetalhes
{
    public partial class EditarAliquotaDetalhe : Form
    {
        AliquotaDetalhe AliquotaDetalhe { get; set; }

        public EditarAliquotaDetalhe(AliquotaDetalhe aliquotaDetalhe)
        {
            InitializeComponent();

            AliquotaDetalhe = aliquotaDetalhe;

            txtAliquota.Text = aliquotaDetalhe.Aliquota.Descricao;
            txtAliquota.Enabled = false;

            txtBaseCalculo.Text = AliquotaDetalhe.BaseCalculo.ToString();
            txtPorcentagem.Text = AliquotaDetalhe.Porcentagem.ToString();
        }

        private void EditarAliquotaDetalhe_Load(object sender, EventArgs e)
        {

        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            decimal baseCalculo;
            decimal.TryParse(txtBaseCalculo.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out baseCalculo);

            float porcentagem;
            float.TryParse(txtPorcentagem.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out porcentagem);

            AliquotaDetalhe.Porcentagem = porcentagem;
            AliquotaDetalhe.BaseCalculo = baseCalculo;

            var data = JsonConvert.SerializeObject(AliquotaDetalhe);

            var api = new Api();

            try
            {
                await api.Put($"api/AliquotaDetalhe/{AliquotaDetalhe.Id}", data);

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
