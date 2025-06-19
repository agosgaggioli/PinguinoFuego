namespace UI
{
    partial class FormCargarVenta
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
            cmbCliente = new ComboBox();
            cmbVendedor = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            label4 = new Label();
            button1 = new Button();
            label5 = new Label();
            dgvVehiculos = new DataGridView();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvVehiculos).BeginInit();
            SuspendLayout();
            // 
            // cmbCliente
            // 
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(190, 121);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(180, 23);
            cmbCliente.TabIndex = 0;
            cmbCliente.SelectedIndexChanged += cmbCliente_SelectedIndexChanged;
            // 
            // cmbVendedor
            // 
            cmbVendedor.FormattingEnabled = true;
            cmbVendedor.Location = new Point(442, 121);
            cmbVendedor.Name = "cmbVendedor";
            cmbVendedor.Size = new Size(180, 23);
            cmbVendedor.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(249, 94);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 3;
            label1.Text = "Clientes:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(494, 94);
            label2.Name = "label2";
            label2.Size = new Size(71, 15);
            label2.TabIndex = 4;
            label2.Text = "Vendedores:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(325, 430);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(180, 23);
            textBox1.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(398, 401);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 7;
            label4.Text = "Monto:";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(135, 532);
            button1.Name = "button1";
            button1.Size = new Size(528, 50);
            button1.TabIndex = 8;
            button1.Text = "Cargar Venta";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label5.Location = new Point(325, 9);
            label5.Name = "label5";
            label5.Size = new Size(161, 32);
            label5.TabIndex = 9;
            label5.Text = "Cargar Venta";
            // 
            // dgvVehiculos
            // 
            dgvVehiculos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVehiculos.Location = new Point(48, 206);
            dgvVehiculos.Name = "dgvVehiculos";
            dgvVehiculos.Size = new Size(731, 150);
            dgvVehiculos.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(398, 176);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 11;
            label3.Text = "Vehiculo:";
            // 
            // FormCargarVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(848, 622);
            Controls.Add(label3);
            Controls.Add(dgvVehiculos);
            Controls.Add(label5);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbVendedor);
            Controls.Add(cmbCliente);
            Name = "FormCargarVenta";
            Text = "FormCargarVenta";
            Load += FormCargarVenta_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVehiculos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbCliente;
        private ComboBox cmbVendedor;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Label label4;
        private Button button1;
        private Label label5;
        private DataGridView dgvVehiculos;
        private Label label3;
    }
}