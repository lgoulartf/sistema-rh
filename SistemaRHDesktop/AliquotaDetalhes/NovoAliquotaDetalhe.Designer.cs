namespace SistemaRHDesktop.AliquotaDetalhes
{
    partial class NovoAliquotaDetalhe
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
            label2 = new Label();
            txtPorcentagem = new TextBox();
            button1 = new Button();
            label4 = new Label();
            txtBaseCalculo = new TextBox();
            label1 = new Label();
            cbxAliquota = new ComboBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(245, 82);
            label2.Name = "label2";
            label2.Size = new Size(70, 13);
            label2.TabIndex = 24;
            label2.Text = "Porcentagem";
            // 
            // txtPorcentagem
            // 
            txtPorcentagem.Location = new Point(245, 98);
            txtPorcentagem.Name = "txtPorcentagem";
            txtPorcentagem.Size = new Size(100, 23);
            txtPorcentagem.TabIndex = 23;
            txtPorcentagem.KeyPress += txtPorcentagem_KeyPress;
            // 
            // button1
            // 
            button1.Location = new Point(270, 146);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 22;
            button1.Text = "Cadastrar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(139, 82);
            label4.Name = "label4";
            label4.Size = new Size(83, 13);
            label4.TabIndex = 21;
            label4.Text = "Base de cálculo";
            // 
            // txtBaseCalculo
            // 
            txtBaseCalculo.Location = new Point(139, 98);
            txtBaseCalculo.Name = "txtBaseCalculo";
            txtBaseCalculo.Size = new Size(100, 23);
            txtBaseCalculo.TabIndex = 20;
            txtBaseCalculo.KeyPress += txtBaseCalculo_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(247, 40);
            label1.TabIndex = 19;
            label1.Text = "Aliquota Detalhe";
            // 
            // cbxAliquota
            // 
            cbxAliquota.FormattingEnabled = true;
            cbxAliquota.Location = new Point(12, 98);
            cbxAliquota.Name = "cbxAliquota";
            cbxAliquota.Size = new Size(121, 23);
            cbxAliquota.TabIndex = 25;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 82);
            label3.Name = "label3";
            label3.Size = new Size(47, 13);
            label3.TabIndex = 26;
            label3.Text = "Alíquota";
            // 
            // NovoAliquotaDetalhe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(357, 179);
            Controls.Add(label3);
            Controls.Add(cbxAliquota);
            Controls.Add(label2);
            Controls.Add(txtPorcentagem);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(txtBaseCalculo);
            Controls.Add(label1);
            Name = "NovoAliquotaDetalhe";
            Text = "NovoAliquotaDetalhe";
            Load += NovoAliquotaDetalhe_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private TextBox txtPorcentagem;
        private Button button1;
        private Label label4;
        private TextBox txtBaseCalculo;
        private Label label1;
        private ComboBox cbxAliquota;
        private Label label3;
    }
}