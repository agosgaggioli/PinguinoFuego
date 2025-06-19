namespace UI
{
    partial class ImputarCobro
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
            dataGridView1 = new DataGridView();
            label1 = new Label();
            comboBox1 = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label5 = new Label();
            button2 = new Button();
            txtMonto = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(43, 465);
            button1.Name = "button1";
            button1.Size = new Size(728, 45);
            button1.TabIndex = 0;
            button1.Text = "Imputar Cobro";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ActiveCaption;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(43, 44);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(728, 150);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.Location = new Point(229, 9);
            label1.Name = "label1";
            label1.Size = new Size(369, 32);
            label1.TabIndex = 2;
            label1.Text = "Facturas:  Pendientes De Cobro";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(287, 281);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(340, 23);
            comboBox1.TabIndex = 3;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(193, 283);
            label2.Name = "label2";
            label2.Size = new Size(75, 21);
            label2.TabIndex = 4;
            label2.Text = "Clientes:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(42, 221);
            label3.Name = "label3";
            label3.Size = new Size(107, 21);
            label3.TabIndex = 5;
            label3.Text = "Monto Total:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(319, 331);
            label4.Name = "label4";
            label4.Size = new Size(60, 21);
            label4.TabIndex = 7;
            label4.Text = "Cobro:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(413, 329);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(129, 23);
            textBox2.TabIndex = 8;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(413, 373);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(129, 23);
            textBox3.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(319, 375);
            label5.Name = "label5";
            label5.Size = new Size(74, 21);
            label5.TabIndex = 9;
            label5.Text = "Metodo:";
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaption;
            button2.Location = new Point(625, 210);
            button2.Name = "button2";
            button2.Size = new Size(146, 32);
            button2.TabIndex = 11;
            button2.Text = "Ver Todas";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(155, 219);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(129, 23);
            txtMonto.TabIndex = 6;
            // 
            // ImputarCobro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(819, 554);
            Controls.Add(button2);
            Controls.Add(textBox3);
            Controls.Add(label5);
            Controls.Add(textBox2);
            Controls.Add(label4);
            Controls.Add(txtMonto);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Name = "ImputarCobro";
            Text = "ImputarCobro";
            Load += ImputarCobro_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private DataGridView dataGridView1;
        private Label label1;
        private ComboBox comboBox1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label5;
        private Button button2;
        private TextBox txtMonto;
    }
}