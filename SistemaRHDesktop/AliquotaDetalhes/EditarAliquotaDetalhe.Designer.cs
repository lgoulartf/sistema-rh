namespace SistemaRHDesktop.AliquotaDetalhes
{
    partial class EditarAliquotaDetalhe
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
            txtBaseCalculo = new TextBox();
            label4 = new Label();
            label2 = new Label();
            txtAliquota = new TextBox();
            btnSalvar = new Button();
            label1 = new Label();
            txtPorcentagem = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // txtBaseCalculo
            // 
            txtBaseCalculo.Location = new Point(134, 94);
            txtBaseCalculo.Name = "txtBaseCalculo";
            txtBaseCalculo.Size = new Size(113, 23);
            txtBaseCalculo.TabIndex = 18;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(134, 76);
            label4.Name = "label4";
            label4.Size = new Size(88, 15);
            label4.TabIndex = 17;
            label4.Text = "Base de cálculo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 76);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 16;
            label2.Text = "Aliquota";
            // 
            // txtAliquota
            // 
            txtAliquota.Location = new Point(12, 94);
            txtAliquota.Name = "txtAliquota";
            txtAliquota.Size = new Size(116, 23);
            txtAliquota.TabIndex = 15;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(291, 137);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(75, 23);
            btnSalvar.TabIndex = 14;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(207, 40);
            label1.TabIndex = 13;
            label1.Text = "Editar detalhe";
            // 
            // txtPorcentagem
            // 
            txtPorcentagem.Location = new Point(253, 94);
            txtPorcentagem.Name = "txtPorcentagem";
            txtPorcentagem.Size = new Size(113, 23);
            txtPorcentagem.TabIndex = 20;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(253, 76);
            label3.Name = "label3";
            label3.Size = new Size(78, 15);
            label3.TabIndex = 19;
            label3.Text = "Porcentagem";
            // 
            // EditarAliquotaDetalhe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(377, 171);
            Controls.Add(txtPorcentagem);
            Controls.Add(label3);
            Controls.Add(txtBaseCalculo);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(txtAliquota);
            Controls.Add(btnSalvar);
            Controls.Add(label1);
            Name = "EditarAliquotaDetalhe";
            Text = "Editar detalhe da alíquota";
            Load += EditarAliquotaDetalhe_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBaseCalculo;
        private Label label4;
        private Label label2;
        private TextBox txtAliquota;
        private Button btnSalvar;
        private Label label1;
        private TextBox txtPorcentagem;
        private Label label3;
    }
}