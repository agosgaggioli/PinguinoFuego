namespace UI
{
    partial class ImputarPago
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
            txtMonto = new TextBox();
            label2 = new Label();
            label3 = new Label();
            textBox2 = new TextBox();
            label4 = new Label();
            textBox3 = new TextBox();
            comboBox1 = new ComboBox();
            label5 = new Label();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.GradientActiveCaption;
            button1.Location = new Point(11, 617);
            button1.Name = "button1";
            button1.Size = new Size(776, 54);
            button1.TabIndex = 0;
            button1.Text = "Imputar Pago";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ActiveCaption;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 57);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(776, 222);
            dataGridView1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(234, 22);
            label1.Name = "label1";
            label1.Size = new Size(346, 32);
            label1.TabIndex = 2;
            label1.Text = "Detalles: Pendientes De Pago";
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(140, 304);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(168, 23);
            txtMonto.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(11, 306);
            label2.Name = "label2";
            label2.Size = new Size(107, 21);
            label2.TabIndex = 4;
            label2.Text = "Monto Total:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(389, 429);
            label3.Name = "label3";
            label3.Size = new Size(53, 21);
            label3.TabIndex = 6;
            label3.Text = "Pago:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(337, 463);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(168, 23);
            textBox2.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(379, 505);
            label4.Name = "label4";
            label4.Size = new Size(74, 21);
            label4.TabIndex = 8;
            label4.Text = "Metodo:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(337, 541);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(168, 23);
            textBox3.TabIndex = 7;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(296, 379);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(244, 23);
            comboBox1.TabIndex = 9;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(362, 342);
            label5.Name = "label5";
            label5.Size = new Size(109, 21);
            label5.TabIndex = 10;
            label5.Text = "Proveedores:";
            // 
            // button2
            // 
            button2.BackColor = SystemColors.GradientActiveCaption;
            button2.Location = new Point(570, 304);
            button2.Name = "button2";
            button2.Size = new Size(218, 26);
            button2.TabIndex = 11;
            button2.Text = "Ver todas";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // ImputarPago
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(831, 709);
            Controls.Add(button2);
            Controls.Add(label5);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(txtMonto);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Name = "ImputarPago";
            Text = "ImputarPago";
            Load += ImputarPago_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private DataGridView dataGridView1;
        private Label label1;
        private TextBox txtMonto;
        private Label label2;
        private Label label3;
        private TextBox textBox2;
        private Label label4;
        private TextBox textBox3;
        private ComboBox comboBox1;
        private Label label5;
        private Button button2;
    }
}