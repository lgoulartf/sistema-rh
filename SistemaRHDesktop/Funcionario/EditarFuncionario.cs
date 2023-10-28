using Newtonsoft.Json;
using SistemaRH.Models;

namespace SistemaRHDesktop
{
    public partial class EditarFuncionario : Form
    {
        Funcionario Funcionario { get; set; }
        public EditarFuncionario(Funcionario funcionario)
        {
            Funcionario = funcionario;
            InitializeComponent();

            txtNome.Text = funcionario.Nome;

            dtpDataAdmissao.Format = DateTimePickerFormat.Custom;
            dtpDataAdmissao.CustomFormat = "dd/MM/yyyy";

            dtpDataAdmissao.Value = funcionario.DataAdmissao.ToDateTime(TimeOnly.MinValue);
        }

        async void btnSalvar_Click(object sender, EventArgs e)
        {
            var funcionario = new Funcionario
            {
                Id = Funcionario.Id,
                Nome = txtNome.Text,
                DataAdmissao = DateOnly.FromDateTime(dtpDataAdmissao.Value)
            };

            var data = JsonConvert.SerializeObject(funcionario);

            var api = new Api();

            try
            {
                await api.Put($"api/Funcionario/{Funcionario.Id}", data);

                MessageBox.Show("Atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Falha!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
