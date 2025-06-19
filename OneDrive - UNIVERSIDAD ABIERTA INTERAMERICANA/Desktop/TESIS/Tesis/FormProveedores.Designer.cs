namespace UI
{
    partial class FormProveedores
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
            components = new System.ComponentModel.Container();
            txtIdElim = new TextBox();
            label4 = new Label();
            button2 = new Button();
            dataGridView1 = new DataGridView();
            txtDireccion = new TextBox();
            txtContacto = new TextBox();
            txtRazonSocial = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            toolTip1 = new ToolTip(components);
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtIdElim
            // 
            txtIdElim.Location = new Point(402, 330);
            txtIdElim.Name = "txtIdElim";
            txtIdElim.Size = new Size(100, 23);
            txtIdElim.TabIndex = 21;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(316, 338);
            label4.Name = "label4";
            label4.Size = new Size(80, 15);
            label4.TabIndex = 20;
            label4.Text = "Id  Proveedor:";
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaption;
            button2.Location = new Point(562, 325);
            button2.Name = "button2";
            button2.Size = new Size(226, 40);
            button2.TabIndex = 19;
            button2.Text = "Eliminar Proveedor";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.InactiveCaption;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(316, 53);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(472, 247);
            dataGridView1.TabIndex = 18;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(87, 125);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(100, 23);
            txtDireccion.TabIndex = 17;
            // 
            // txtContacto
            // 
            txtContacto.Location = new Point(87, 88);
            txtContacto.Name = "txtContacto";
            txtContacto.Size = new Size(100, 23);
            txtContacto.TabIndex = 16;
            // 
            // txtRazonSocial
            // 
            txtRazonSocial.Location = new Point(87, 53);
            txtRazonSocial.Name = "txtRazonSocial";
            txtRazonSocial.Size = new Size(100, 23);
            txtRazonSocial.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 128);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 14;
            label3.Text = "Direccion:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 91);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 13;
            label2.Text = "Contacto:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 61);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 12;
            label1.Text = "Razon Social:";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.GradientInactiveCaption;
            button1.Location = new Point(8, 177);
            button1.Name = "button1";
            button1.Size = new Size(226, 40);
            button1.TabIndex = 11;
            button1.Text = "Registrar Proveedor";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label5.Location = new Point(35, 9);
            label5.Name = "label5";
            label5.Size = new Size(177, 25);
            label5.TabIndex = 22;
            label5.Text = "Cargar Proveedor:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label6.Location = new Point(464, 9);
            label6.Name = "label6";
            label6.Size = new Size(174, 25);
            label6.TabIndex = 23;
            label6.Text = "Lista Proveedores:";
            // 
            // FormProveedores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 417);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txtIdElim);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(txtDireccion);
            Controls.Add(txtContacto);
            Controls.Add(txtRazonSocial);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "FormProveedores";
            Text = "FormProveedores";
            Load += FormProveedores_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtIdElim;
        private Label label4;
        private Button button2;
        private DataGridView dataGridView1;
        private TextBox txtDireccion;
        private TextBox txtContacto;
        private TextBox txtRazonSocial;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button button1;
        private ToolTip toolTip1;
        private Label label5;
        private Label label6;
    }
}