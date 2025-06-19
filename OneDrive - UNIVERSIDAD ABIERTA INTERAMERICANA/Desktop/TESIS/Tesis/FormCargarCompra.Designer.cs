namespace UI
{
    partial class FormCargarCompra
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
            button1 = new Button();
            label4 = new Label();
            txtMonto = new TextBox();
            label1 = new Label();
            cmbProvedor = new ComboBox();
            txtDescripcion = new TextBox();
            label2 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.GradientActiveCaption;
            button1.Location = new Point(39, 246);
            button1.Name = "button1";
            button1.Size = new Size(564, 48);
            button1.TabIndex = 17;
            button1.Text = "Cargar Compra";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(191, 189);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 16;
            label4.Text = "Monto:";
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(252, 181);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(198, 23);
            txtMonto.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(288, 30);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 12;
            label1.Text = "Proveedores:";
            // 
            // cmbProvedor
            // 
            cmbProvedor.FormattingEnabled = true;
            cmbProvedor.Location = new Point(165, 60);
            cmbProvedor.Name = "cmbProvedor";
            cmbProvedor.Size = new Size(314, 23);
            cmbProvedor.TabIndex = 9;
            cmbProvedor.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(252, 123);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(198, 23);
            txtDescripcion.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(165, 131);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 19;
            label2.Text = "Descripcion:";
            // 
            // FormCargarCompra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            ClientSize = new Size(657, 320);
            Controls.Add(label2);
            Controls.Add(txtDescripcion);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(txtMonto);
            Controls.Add(label1);
            Controls.Add(cmbProvedor);
            Name = "FormCargarCompra";
            Text = "FormCargarCompra";
            Load += FormCargarCompra_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label4;
        private TextBox txtMonto;
        private Label label1;
        private ComboBox cmbProvedor;
        private TextBox txtDescripcion;
        private Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}