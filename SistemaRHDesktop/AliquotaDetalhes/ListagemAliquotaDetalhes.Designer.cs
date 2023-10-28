namespace SistemaRHDesktop.AliquotaDetalhes
{
    partial class ListagemAliquotaDetalhes
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
            btnNovo = new Button();
            btnEditar = new Button();
            listView1 = new ListView();
            btnExcluir = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(461, 29);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(75, 23);
            btnNovo.TabIndex = 17;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(542, 29);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 16;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // listView1
            // 
            listView1.Location = new Point(12, 58);
            listView1.Name = "listView1";
            listView1.Size = new Size(686, 326);
            listView1.TabIndex = 15;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(623, 29);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(75, 23);
            btnExcluir.TabIndex = 14;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(260, 40);
            label1.TabIndex = 13;
            label1.Text = "Aliquota Detalhes";
            // 
            // ListagemAliquotaDetalhes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(708, 396);
            Controls.Add(btnNovo);
            Controls.Add(btnEditar);
            Controls.Add(listView1);
            Controls.Add(btnExcluir);
            Controls.Add(label1);
            Name = "ListagemAliquotaDetalhes";
            Text = "ListagemAliquotaDetalhes";
            Load += ListagemAliquotaDetalhes_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnNovo;
        private Button btnEditar;
        private ListView listView1;
        private Button btnExcluir;
        private Label label1;
    }
}