using Newtonsoft.Json;
using SistemaRH.Models;

namespace SistemaRHDesktop
{
    public partial class NovoFuncionario : Form
    {
        public NovoFuncionario()
        {
            InitializeComponent();

            dtpDataAdmissao.Format = DateTimePickerFormat.Custom;
            dtpDataAdmissao.CustomFormat = "dd/MM/yyyy";
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var funcionario = new Funcionario()
            {
                Nome = txtNome.Text,
                DataAdmissao = DateOnly.FromDateTime(dtpDataAdmissao.Value)
            };

            var data = JsonConvert.SerializeObject(funcionario);

            var api = new Api();

            try
            {
                await api.Post("api/Funcionario", data);

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
