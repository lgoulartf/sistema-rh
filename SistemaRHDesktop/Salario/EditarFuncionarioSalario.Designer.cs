namespace SistemaRHDesktop
{
    partial class EditarFuncionarioSalario
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
            dtpVigenteEm = new DateTimePicker();
            btnSalvar = new Button();
            txtFuncionario = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtSalario = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(199, 40);
            label1.TabIndex = 0;
            label1.Text = "Editar Salário";
            // 
            // dtpVigenteEm
            // 
            dtpVigenteEm.Location = new Point(284, 94);
            dtpVigenteEm.Name = "dtpVigenteEm";
            dtpVigenteEm.Size = new Size(200, 23);
            dtpVigenteEm.TabIndex = 1;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(409, 123);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(75, 23);
            btnSalvar.TabIndex = 2;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += button1_Click;
            // 
            // txtFuncionario
            // 
            txtFuncionario.Location = new Point(12, 94);
            txtFuncionario.Name = "txtFuncionario";
            txtFuncionario.Size = new Size(147, 23);
            txtFuncionario.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 76);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 4;
            label2.Text = "Funcionário";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(284, 76);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 5;
            label3.Text = "Vigente em";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(165, 76);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 7;
            label4.Text = "Salário";
            // 
            // txtSalario
            // 
            txtSalario.Location = new Point(165, 94);
            txtSalario.Name = "txtSalario";
            txtSalario.Size = new Size(113, 23);
            txtSalario.TabIndex = 12;
            txtSalario.KeyPress += txtSalario_KeyPress;
            // 
            // EditarFuncionarioSalario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtSalario);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtFuncionario);
            Controls.Add(btnSalvar);
            Controls.Add(dtpVigenteEm);
            Controls.Add(label1);
            Name = "EditarFuncionarioSalario";
            Text = "EditarFuncionarioSalario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtpVigenteEm;
        private Button btnSalvar;
        private TextBox txtFuncionario;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtSalario;
    }
}