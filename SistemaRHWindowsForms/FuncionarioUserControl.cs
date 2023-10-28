using SistemaRH.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRHWindowsForms
{
    public partial class FuncionarioUserControl : UserControl
    {
        FuncionariosController funcionariosController;
        public FuncionarioUserControl()
        {
            InitializeComponent();

            funcionariosController = new FuncionariosController();
        }

        private void FuncionarioUserControl_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            funcionariosController.Index();
        }
    }
}
