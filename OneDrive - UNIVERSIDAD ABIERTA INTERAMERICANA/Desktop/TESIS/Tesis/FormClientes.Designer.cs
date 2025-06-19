namespace UI
{
    partial class FormClientes
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtApellido = new TextBox();
            txtNombre = new TextBox();
            txtDireccion = new TextBox();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            label4 = new Label();
            txtdnielim = new TextBox();
            label5 = new Label();
            txtDni = new TextBox();
            label6 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(8, 208);
            button1.Name = "button1";
            button1.Size = new Size(226, 40);
            button1.TabIndex = 0;
            button1.Text = "Registrar Cliente";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 50);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 1;
            label1.Text = "Nombre:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 80);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 2;
            label2.Text = "Apellido:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 117);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 3;
            label3.Text = "Direccion:";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(87, 80);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(100, 23);
            txtApellido.TabIndex = 4;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(87, 47);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 5;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(87, 114);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(100, 23);
            txtDireccion.TabIndex = 6;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(316, 42);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(472, 247);
            dataGridView1.TabIndex = 7;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.GradientActiveCaption;
            button2.Location = new Point(562, 314);
            button2.Name = "button2";
            button2.Size = new Size(226, 40);
            button2.TabIndex = 8;
            button2.Text = "Eliminar Cliente";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(316, 327);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 9;
            label4.Text = "Id Cliente:";
            // 
            // txtdnielim
            // 
            txtdnielim.Location = new Point(382, 324);
            txtdnielim.Name = "txtdnielim";
            txtdnielim.Size = new Size(100, 23);
            txtdnielim.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 159);
            label5.Name = "label5";
            label5.Size = new Size(27, 15);
            label5.TabIndex = 11;
            label5.Text = "DNI";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(87, 159);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(100, 23);
            txtDni.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label6.Location = new Point(40, 9);
            label6.Name = "label6";
            label6.Size = new Size(133, 21);
            label6.TabIndex = 13;
            label6.Text = "Agregar Cliente:";
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label7.Location = new Point(493, 9);
            label7.Name = "label7";
            label7.Size = new Size(114, 21);
            label7.TabIndex = 14;
            label7.Text = "Lista Clientes:";
            // 
            // FormClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 395);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(txtDni);
            Controls.Add(label5);
            Controls.Add(txtdnielim);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(txtDireccion);
            Controls.Add(txtNombre);
            Controls.Add(txtApellido);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "FormClientes";
            Text = "FormClientes";
            Load += FormClientes_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtApellido;
        private TextBox txtNombre;
        private TextBox txtDireccion;
        private DataGridView dataGridView1;
        private Button button2;
        private Label label4;
        private TextBox txtdnielim;
        private Label label5;
        private TextBox txtDni;
        private Label label6;
        private Label label7;
    }
}