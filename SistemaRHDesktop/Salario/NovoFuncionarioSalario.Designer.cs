namespace SistemaRHDesktop
{
    partial class NovoFuncionarioSalario
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
            cbFuncionarios = new ComboBox();
            label2 = new Label();
            dtpVigenteEm = new DateTimePicker();
            txtSalario = new TextBox();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(111, 40);
            label1.TabIndex = 0;
            label1.Text = "Salario";
            // 
            // cbFuncionarios
            // 
            cbFuncionarios.FormattingEnabled = true;
            cbFuncionarios.Location = new Point(10, 89);
            cbFuncionarios.Name = "cbFuncionarios";
            cbFuncionarios.Size = new Size(121, 23);
            cbFuncionarios.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(10, 73);
            label2.Name = "label2";
            label2.Size = new Size(62, 13);
            label2.TabIndex = 2;
            label2.Text = "Funcionario";
            // 
            // dtpVigenteEm
            // 
            dtpVigenteEm.Location = new Point(243, 89);
            dtpVigenteEm.Name = "dtpVigenteEm";
            dtpVigenteEm.Size = new Size(209, 23);
            dtpVigenteEm.TabIndex = 3;
            // 
            // txtSalario
            // 
            txtSalario.Location = new Point(137, 89);
            txtSalario.Name = "txtSalario";
            txtSalario.Size = new Size(100, 23);
            txtSalario.TabIndex = 4;
            txtSalario.KeyPress += textBox1_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(243, 73);
            label3.Name = "label3";
            label3.Size = new Size(60, 13);
            label3.TabIndex = 5;
            label3.Text = "Vigente em";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(137, 73);
            label4.Name = "label4";
            label4.Size = new Size(39, 13);
            label4.TabIndex = 6;
            label4.Text = "Salario";
            // 
            // button1
            // 
            button1.Location = new Point(377, 153);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 7;
            button1.Text = "Cadastrar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // NovoFuncionarioSalario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 188);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtSalario);
            Controls.Add(dtpVigenteEm);
            Controls.Add(label2);
            Controls.Add(cbFuncionarios);
            Controls.Add(label1);
            Name = "NovoFuncionarioSalario";
            Text = "Novo salário";
            Load += NovoFuncionarioSalario_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cbFuncionarios;
        private Label label2;
        private DateTimePicker dtpVigenteEm;
        private TextBox txtSalario;
        private Label label3;
        private Label label4;
        private Button button1;
    }
}