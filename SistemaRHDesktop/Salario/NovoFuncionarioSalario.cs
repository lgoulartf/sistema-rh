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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRHDesktop
{
    public partial class NovoFuncionarioSalario : Form
    {
        public NovoFuncionarioSalario()
        {
            InitializeComponent();

            dtpVigenteEm.Format = DateTimePickerFormat.Custom;
            dtpVigenteEm.CustomFormat = "dd/MM/yyyy";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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
            var funcionarioSalario = new FuncionarioSalario
            {
                IdFuncionario = Convert.ToInt32(cbFuncionarios.SelectedValue),
                VigenteEm = DateOnly.FromDateTime(dtpVigenteEm.Value)
            };
            decimal salario;
            decimal.TryParse(txtSalario.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out salario);


            funcionarioSalario.Salario = salario;

            try
            {
                var api = new Api();

                var data = JsonConvert.SerializeObject(funcionarioSalario);

                await api.Post("api/FuncionarioSalario", data);

                MessageBox.Show("Cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Falha!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void NovoFuncionarioSalario_Load(object sender, EventArgs e)
        {
            var api = new Api();

            var result = await api.Get("api/Funcionario");

            var funcionarios = JsonConvert.DeserializeObject<List<Funcionario>>(result);

            cbFuncionarios.DataSource = funcionarios;
            cbFuncionarios.ValueMember = "Id";
            cbFuncionarios.DisplayMember = "Nome";
        }
    }
}
