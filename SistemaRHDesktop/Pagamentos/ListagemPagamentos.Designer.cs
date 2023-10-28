namespace SistemaRHDesktop.Pagamentos
{
    partial class ListagemPagamentos
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
            listView1 = new ListView();
            button1 = new Button();
            label2 = new Label();
            dtpReferencia = new DateTimePicker();
            btnGerarPdf = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(312, 40);
            label1.TabIndex = 0;
            label1.Text = "Folha de pagamentos";
            // 
            // listView1
            // 
            listView1.Location = new Point(12, 52);
            listView1.Name = "listView1";
            listView1.Size = new Size(989, 386);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            button1.Location = new Point(847, 23);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Gerar folha";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(586, 27);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 4;
            label2.Text = "Referência";
            // 
            // dtpReferencia
            // 
            dtpReferencia.Location = new Point(654, 23);
            dtpReferencia.Name = "dtpReferencia";
            dtpReferencia.Size = new Size(187, 23);
            dtpReferencia.TabIndex = 5;
            // 
            // btnGerarPdf
            // 
            btnGerarPdf.Location = new Point(928, 23);
            btnGerarPdf.Name = "btnGerarPdf";
            btnGerarPdf.Size = new Size(75, 23);
            btnGerarPdf.TabIndex = 6;
            btnGerarPdf.Text = "Gerar PDF";
            btnGerarPdf.UseVisualStyleBackColor = true;
            btnGerarPdf.Click += btnGerarPdf_Click;
            // 
            // ListagemPagamentos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1013, 450);
            Controls.Add(btnGerarPdf);
            Controls.Add(dtpReferencia);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(listView1);
            Controls.Add(label1);
            Name = "ListagemPagamentos";
            Text = "Listagem de pagamentos";
            Load += ListagemPagamentos_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListView listView1;
        private Button button1;
        private Label label2;
        private DateTimePicker dtpReferencia;
        private Button btnGerarPdf;
    }
}