namespace SistemaRHDesktop
{
    partial class ListagemFuncionarioSalarios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnExcluir = new Button();
            listView1 = new ListView();
            btnEditar = new Button();
            btnNovo = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(124, 40);
            label1.TabIndex = 0;
            label1.Text = "Salarios";
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(626, 25);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(75, 23);
            btnExcluir.TabIndex = 1;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click_1;
            // 
            // listView1
            // 
            listView1.Location = new Point(15, 52);
            listView1.Name = "listView1";
            listView1.Size = new Size(686, 326);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged_1;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(545, 25);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 3;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click_1;
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(464, 25);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(75, 23);
            btnNovo.TabIndex = 4;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // ListagemFuncionarioSalarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(713, 390);
            Controls.Add(btnNovo);
            Controls.Add(btnEditar);
            Controls.Add(listView1);
            Controls.Add(btnExcluir);
            Controls.Add(label1);
            Name = "ListagemFuncionarioSalarios";
            Text = "ListagemFuncionarioSalarios";
            Load += ListagemFuncionarioSalarios_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnExcluir;
        private ListView listView1;
        private Button btnEditar;
        private Button btnNovo;
    }
}