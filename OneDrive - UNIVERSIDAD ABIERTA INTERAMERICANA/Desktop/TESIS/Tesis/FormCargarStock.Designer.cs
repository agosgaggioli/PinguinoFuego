namespace UI
{
    partial class FormCargarStock
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
            txtVersion = new TextBox();
            txtMarca = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtPrecio = new TextBox();
            label4 = new Label();
            label5 = new Label();
            txtChasis = new TextBox();
            txtPatente = new TextBox();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            label6 = new Label();
            txtIdNuevoVehiculo = new TextBox();
            label7 = new Label();
            txtIdNuevoPrecio = new TextBox();
            label8 = new Label();
            txtAño = new TextBox();
            txtEliminarId = new TextBox();
            label9 = new Label();
            button3 = new Button();
            label10 = new Label();
            label11 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(36, 374);
            button1.Name = "button1";
            button1.Size = new Size(238, 46);
            button1.TabIndex = 0;
            button1.Text = "Cargar Stock";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(47, 131);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 1;
            label1.Text = "Version:";
            // 
            // txtVersion
            // 
            txtVersion.Location = new Point(121, 123);
            txtVersion.Name = "txtVersion";
            txtVersion.Size = new Size(241, 23);
            txtVersion.TabIndex = 2;
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(121, 82);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(241, 23);
            txtMarca.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 90);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 4;
            label2.Text = "Marca:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 228);
            label3.Name = "label3";
            label3.Size = new Size(83, 15);
            label3.TabIndex = 5;
            label3.Text = "Precio de lista:";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(121, 225);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(190, 23);
            txtPrecio.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 285);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 7;
            label4.Text = "Kilometros:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(46, 325);
            label5.Name = "label5";
            label5.Size = new Size(50, 15);
            label5.TabIndex = 8;
            label5.Text = "Patente:";
            // 
            // txtChasis
            // 
            txtChasis.Location = new Point(121, 277);
            txtChasis.Name = "txtChasis";
            txtChasis.Size = new Size(127, 23);
            txtChasis.TabIndex = 9;
            // 
            // txtPatente
            // 
            txtPatente.Location = new Point(121, 322);
            txtPatente.Name = "txtPatente";
            txtPatente.Size = new Size(127, 23);
            txtPatente.TabIndex = 10;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(385, 82);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(824, 203);
            dataGridView1.TabIndex = 11;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.GradientActiveCaption;
            button2.Location = new Point(792, 313);
            button2.Name = "button2";
            button2.Size = new Size(238, 39);
            button2.TabIndex = 12;
            button2.Text = "Modificar Precio";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(543, 315);
            label6.Name = "label6";
            label6.Size = new Size(65, 15);
            label6.TabIndex = 13;
            label6.Text = "IdVehiculo:";
            // 
            // txtIdNuevoVehiculo
            // 
            txtIdNuevoVehiculo.Location = new Point(631, 307);
            txtIdNuevoVehiculo.Name = "txtIdNuevoVehiculo";
            txtIdNuevoVehiculo.Size = new Size(100, 23);
            txtIdNuevoVehiculo.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(543, 351);
            label7.Name = "label7";
            label7.Size = new Size(83, 15);
            label7.TabIndex = 15;
            label7.Text = "Precio de lista:";
            // 
            // txtIdNuevoPrecio
            // 
            txtIdNuevoPrecio.Location = new Point(632, 343);
            txtIdNuevoPrecio.Name = "txtIdNuevoPrecio";
            txtIdNuevoPrecio.Size = new Size(100, 23);
            txtIdNuevoPrecio.TabIndex = 16;
            txtIdNuevoPrecio.TextChanged += txtIdNuevoPrecio_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(48, 180);
            label8.Name = "label8";
            label8.Size = new Size(32, 15);
            label8.TabIndex = 17;
            label8.Text = "Año:";
            // 
            // txtAño
            // 
            txtAño.Location = new Point(121, 177);
            txtAño.Name = "txtAño";
            txtAño.Size = new Size(100, 23);
            txtAño.TabIndex = 18;
            // 
            // txtEliminarId
            // 
            txtEliminarId.Location = new Point(631, 425);
            txtEliminarId.Name = "txtEliminarId";
            txtEliminarId.Size = new Size(100, 23);
            txtEliminarId.TabIndex = 20;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(543, 433);
            label9.Name = "label9";
            label9.Size = new Size(65, 15);
            label9.TabIndex = 19;
            label9.Text = "IdVehiculo:";
            // 
            // button3
            // 
            button3.BackColor = SystemColors.GradientActiveCaption;
            button3.Location = new Point(792, 414);
            button3.Name = "button3";
            button3.Size = new Size(238, 42);
            button3.TabIndex = 21;
            button3.Text = "Eliminar Vehiculo";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label10.Location = new Point(121, 25);
            label10.Name = "label10";
            label10.Size = new Size(158, 25);
            label10.TabIndex = 22;
            label10.Text = "Cargar Vehiculo:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label11.Location = new Point(746, 25);
            label11.Name = "label11";
            label11.Size = new Size(138, 25);
            label11.TabIndex = 23;
            label11.Text = "Lista Vehiculo:";
            // 
            // FormCargarStock
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1257, 497);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(button3);
            Controls.Add(txtEliminarId);
            Controls.Add(label9);
            Controls.Add(txtAño);
            Controls.Add(label8);
            Controls.Add(txtIdNuevoPrecio);
            Controls.Add(label7);
            Controls.Add(txtIdNuevoVehiculo);
            Controls.Add(label6);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(txtPatente);
            Controls.Add(txtChasis);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtPrecio);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtMarca);
            Controls.Add(txtVersion);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "FormCargarStock";
            Text = "FormCargarStock";
            Load += FormCargarStock_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private TextBox txtVersion;
        private TextBox txtMarca;
        private Label label2;
        private Label label3;
        private TextBox txtPrecio;
        private Label label4;
        private Label label5;
        private TextBox txtChasis;
        private TextBox txtPatente;
        private DataGridView dataGridView1;
        private Button button2;
        private Label label6;
        private TextBox txtIdNuevoVehiculo;
        private Label label7;
        private TextBox txtIdNuevoPrecio;
        private Label label8;
        private TextBox txtAño;
        private TextBox txtEliminarId;
        private Label label9;
        private Button button3;
        private Label label10;
        private Label label11;
    }
}