namespace SistemaRHDesktop
{
    partial class TelaInicial
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            funcionariosToolStripMenuItem = new ToolStripMenuItem();
            cadastroToolStripMenuItem = new ToolStripMenuItem();
            cadastroDeSalariosToolStripMenuItem = new ToolStripMenuItem();
            aliquotasToolStripMenuItem = new ToolStripMenuItem();
            cadastroToolStripMenuItem1 = new ToolStripMenuItem();
            cadastroDeDetalhesToolStripMenuItem = new ToolStripMenuItem();
            pagamentosToolStripMenuItem = new ToolStripMenuItem();
            gerarPagamentosToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { funcionariosToolStripMenuItem, aliquotasToolStripMenuItem, pagamentosToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1422, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // funcionariosToolStripMenuItem
            // 
            funcionariosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cadastroToolStripMenuItem, cadastroDeSalariosToolStripMenuItem });
            funcionariosToolStripMenuItem.Name = "funcionariosToolStripMenuItem";
            funcionariosToolStripMenuItem.Size = new Size(87, 20);
            funcionariosToolStripMenuItem.Text = "Funcionarios";
            // 
            // cadastroToolStripMenuItem
            // 
            cadastroToolStripMenuItem.Name = "cadastroToolStripMenuItem";
            cadastroToolStripMenuItem.Size = new Size(179, 22);
            cadastroToolStripMenuItem.Text = "Cadastro";
            cadastroToolStripMenuItem.Click += cadastroToolStripMenuItem_Click;
            // 
            // cadastroDeSalariosToolStripMenuItem
            // 
            cadastroDeSalariosToolStripMenuItem.Name = "cadastroDeSalariosToolStripMenuItem";
            cadastroDeSalariosToolStripMenuItem.Size = new Size(179, 22);
            cadastroDeSalariosToolStripMenuItem.Text = "Cadastro de salarios";
            cadastroDeSalariosToolStripMenuItem.Click += cadastroDeSalariosToolStripMenuItem_Click;
            // 
            // aliquotasToolStripMenuItem
            // 
            aliquotasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cadastroToolStripMenuItem1, cadastroDeDetalhesToolStripMenuItem });
            aliquotasToolStripMenuItem.Name = "aliquotasToolStripMenuItem";
            aliquotasToolStripMenuItem.Size = new Size(69, 20);
            aliquotasToolStripMenuItem.Text = "Aliquotas";
            // 
            // cadastroToolStripMenuItem1
            // 
            cadastroToolStripMenuItem1.Name = "cadastroToolStripMenuItem1";
            cadastroToolStripMenuItem1.Size = new Size(184, 22);
            cadastroToolStripMenuItem1.Text = "Cadastro";
            cadastroToolStripMenuItem1.Click += cadastroToolStripMenuItem1_Click;
            // 
            // cadastroDeDetalhesToolStripMenuItem
            // 
            cadastroDeDetalhesToolStripMenuItem.Name = "cadastroDeDetalhesToolStripMenuItem";
            cadastroDeDetalhesToolStripMenuItem.Size = new Size(184, 22);
            cadastroDeDetalhesToolStripMenuItem.Text = "Cadastro de detalhes";
            cadastroDeDetalhesToolStripMenuItem.Click += cadastroDeDetalhesToolStripMenuItem_Click;
            // 
            // pagamentosToolStripMenuItem
            // 
            pagamentosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gerarPagamentosToolStripMenuItem });
            pagamentosToolStripMenuItem.Name = "pagamentosToolStripMenuItem";
            pagamentosToolStripMenuItem.Size = new Size(85, 20);
            pagamentosToolStripMenuItem.Text = "Pagamentos";
            // 
            // gerarPagamentosToolStripMenuItem
            // 
            gerarPagamentosToolStripMenuItem.Name = "gerarPagamentosToolStripMenuItem";
            gerarPagamentosToolStripMenuItem.Size = new Size(180, 22);
            gerarPagamentosToolStripMenuItem.Text = "Listagem";
            gerarPagamentosToolStripMenuItem.Click += gerarPagamentosToolStripMenuItem_Click;
            // 
            // TelaInicial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1422, 653);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "TelaInicial";
            Text = "Tela inicial";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem funcionariosToolStripMenuItem;
        private ToolStripMenuItem cadastroToolStripMenuItem;
        private ToolStripMenuItem cadastroDeSalariosToolStripMenuItem;
        private ToolStripMenuItem aliquotasToolStripMenuItem;
        private ToolStripMenuItem cadastroToolStripMenuItem1;
        private ToolStripMenuItem cadastroDeDetalhesToolStripMenuItem;
        private ToolStripMenuItem pagamentosToolStripMenuItem;
        private ToolStripMenuItem gerarPagamentosToolStripMenuItem;
    }
}