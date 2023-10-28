using Newtonsoft.Json;
using SistemaRH.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRHDesktop
{
    public partial class EditarFuncionarioSalario : Form
    {
        FuncionarioSalario FuncionarioSalario { get; set; }
        public EditarFuncionarioSalario(FuncionarioSalario funcionarioSalario)
        {
            InitializeComponent();

            FuncionarioSalario = funcionarioSalario;

            txtFuncionario.Text = funcionarioSalario.Funcionario.Nome;
            txtFuncionario.Enabled = false;

            txtSalario.Text = funcionarioSalario.Salario.ToString();

            dtpVigenteEm.Format = DateTimePickerFormat.Custom;
            dtpVigenteEm.CustomFormat = "dd/MM/yyyy";
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var api = new Api();

            decimal salario;
            decimal.TryParse(txtSalario.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out salario);

            FuncionarioSalario.Salario = salario;

            try
            {
                var data = System.Text.Json.JsonSerializer.Serialize(FuncionarioSalario);
                await api.Put($"api/FuncionarioSalario/{FuncionarioSalario.Id}", data);

                MessageBox.Show("Salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Falha!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSalario_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
