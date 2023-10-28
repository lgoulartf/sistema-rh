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
    public partial class NovoAliquotaDetalhe : Form
    {
        public NovoAliquotaDetalhe()
        {
            InitializeComponent();
        }

        private void txtBaseCalculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            };
        }

        private void txtPorcentagem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            };
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            decimal baseCalculo;
            decimal.TryParse(txtBaseCalculo.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out baseCalculo);

            float porcentagem;
            float.TryParse(txtPorcentagem.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out porcentagem);

            var aliquotaDetalhe = new AliquotaDetalhe
            {
                IdAliquota = Convert.ToInt32(cbxAliquota.SelectedValue),
                BaseCalculo = baseCalculo,
                Porcentagem = porcentagem,
            };

            var data = JsonConvert.SerializeObject(aliquotaDetalhe);

            var api = new Api();

            try
            {
                await api.Post("api/AliquotaDetalhe", data);

                MessageBox.Show("Cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Falha!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void NovoAliquotaDetalhe_Load(object sender, EventArgs e)
        {
            var api = new Api();

            var content = await api.Get("api/Aliquota");

            var data = JsonConvert.DeserializeObject<List<SistemaRH.Models.Aliquota>>(content);

            cbxAliquota.DataSource = data;
            cbxAliquota.ValueMember = "Id";
            cbxAliquota.DisplayMember = "Descricao";

            cbxAliquota.Update();
        }
    }
}
