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
    public partial class NovoAliquota : Form
    {
        public NovoAliquota()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var aliquota = new SistemaRH.Models.Aliquota()
            {
                Descricao = txtDescricao.Text,
                AnoVigencia = Convert.ToInt32(txtAnoVigente.Text),
                Desconta = ckbDesconta.Checked
            };

            var data = JsonConvert.SerializeObject(aliquota);

            var api = new Api();

            try
            {
                await api.Post("api/Aliquota", data);

                MessageBox.Show("Cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Falha!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
