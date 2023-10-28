namespace SistemaRHDesktop.Aliquota
{
    partial class EditarAliquota
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
            ckbDesconta = new CheckBox();
            label2 = new Label();
            txtAnoVigente = new TextBox();
            button1 = new Button();
            label4 = new Label();
            txtDescricao = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // ckbDesconta
            // 
            ckbDesconta.AutoSize = true;
            ckbDesconta.Location = new Point(224, 101);
            ckbDesconta.Name = "ckbDesconta";
            ckbDesconta.Size = new Size(75, 19);
            ckbDesconta.TabIndex = 25;
            ckbDesconta.Text = "Desconta";
            ckbDesconta.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(118, 83);
            label2.Name = "label2";
            label2.Size = new Size(64, 13);
            label2.TabIndex = 24;
            label2.Text = "Ano vigente";
            // 
            // txtAnoVigente
            // 
            txtAnoVigente.Location = new Point(118, 99);
            txtAnoVigente.Name = "txtAnoVigente";
            txtAnoVigente.Size = new Size(100, 23);
            txtAnoVigente.TabIndex = 23;
            // 
            // button1
            // 
            button1.Location = new Point(224, 148);
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
            label4.Location = new Point(12, 83);
            label4.Name = "label4";
            label4.Size = new Size(55, 13);
            label4.TabIndex = 21;
            label4.Text = "Descrição";
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(12, 99);
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(100, 23);
            txtDescricao.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(134, 40);
            label1.TabIndex = 19;
            label1.Text = "Aliquota";
            // 
            // EditarAliquota
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(313, 184);
            Controls.Add(ckbDesconta);
            Controls.Add(label2);
            Controls.Add(txtAnoVigente);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(txtDescricao);
            Controls.Add(label1);
            Name = "EditarAliquota";
            Text = "EditarAliquota";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox ckbDesconta;
        private Label label2;
        private TextBox txtAnoVigente;
        private Button button1;
        private Label label4;
        private TextBox txtDescricao;
        private Label label1;
    }
}