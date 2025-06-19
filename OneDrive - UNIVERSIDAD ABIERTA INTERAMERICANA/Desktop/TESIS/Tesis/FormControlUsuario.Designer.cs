namespace UI
{
    partial class FormControlUsuario
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
            comboBox1 = new ComboBox();
            treeView1 = new TreeView();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            button5 = new Button();
            label3 = new Label();
            label9 = new Label();
            button6 = new Button();
            button7 = new Button();
            txtNombre = new TextBox();
            txtContrasenia = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(33, 92);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(166, 23);
            comboBox1.TabIndex = 0;
            // 
            // treeView1
            // 
            treeView1.Location = new Point(870, 92);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(411, 304);
            treeView1.TabIndex = 3;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(260, 92);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(166, 23);
            comboBox2.TabIndex = 4;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(565, 92);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(166, 23);
            comboBox3.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(294, 270);
            button1.Name = "button1";
            button1.Size = new Size(93, 40);
            button1.TabIndex = 6;
            button1.Text = "Eliminar Rol";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(294, 224);
            button2.Name = "button2";
            button2.Size = new Size(93, 40);
            button2.TabIndex = 7;
            button2.Text = "Crear Rol";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(659, 224);
            button3.Name = "button3";
            button3.Size = new Size(91, 40);
            button3.TabIndex = 8;
            button3.Text = "Asociar Permiso a Rol";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(659, 270);
            button4.Name = "button4";
            button4.Size = new Size(91, 40);
            button4.TabIndex = 9;
            button4.Text = "Desasociar Permiso a Rol";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(33, 57);
            label1.Name = "label1";
            label1.Size = new Size(120, 32);
            label1.TabIndex = 10;
            label1.Text = "Usuarios:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(260, 57);
            label2.Name = "label2";
            label2.Size = new Size(58, 32);
            label2.TabIndex = 11;
            label2.Text = "Rol:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(966, 47);
            label4.Name = "label4";
            label4.Size = new Size(0, 32);
            label4.TabIndex = 13;
            // 
            // button5
            // 
            button5.Location = new Point(988, 402);
            button5.Name = "button5";
            button5.Size = new Size(91, 40);
            button5.TabIndex = 14;
            button5.Text = "Asociar Rol a Usuario";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(565, 57);
            label3.Name = "label3";
            label3.Size = new Size(114, 32);
            label3.TabIndex = 12;
            label3.Text = "Pemisos:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(966, 47);
            label9.Name = "label9";
            label9.Size = new Size(226, 32);
            label9.TabIndex = 19;
            label9.Text = "Usuario con Roles:";
            // 
            // button6
            // 
            button6.Location = new Point(560, 224);
            button6.Name = "button6";
            button6.Size = new Size(93, 40);
            button6.TabIndex = 21;
            button6.Text = "Crear Permiso";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(560, 270);
            button7.Name = "button7";
            button7.Size = new Size(93, 40);
            button7.TabIndex = 20;
            button7.Text = "Eliminar Permiso";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(1002, 522);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 22;
            // 
            // txtContrasenia
            // 
            txtContrasenia.Location = new Point(1002, 571);
            txtContrasenia.Name = "txtContrasenia";
            txtContrasenia.Size = new Size(100, 23);
            txtContrasenia.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(896, 489);
            label5.Name = "label5";
            label5.Size = new Size(149, 17);
            label5.TabIndex = 24;
            label5.Text = "Usuarios Seleccionado:";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(916, 525);
            label6.Name = "label6";
            label6.Size = new Size(62, 17);
            label6.TabIndex = 25;
            label6.Text = "Nombre:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(897, 577);
            label7.Name = "label7";
            label7.Size = new Size(81, 17);
            label7.TabIndex = 26;
            label7.Text = "Contraseña:";
            // 
            // button8
            // 
            button8.Location = new Point(1154, 534);
            button8.Name = "button8";
            button8.Size = new Size(93, 40);
            button8.TabIndex = 27;
            button8.Text = "Desencriptar";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new Point(71, 224);
            button9.Name = "button9";
            button9.Size = new Size(93, 40);
            button9.TabIndex = 29;
            button9.Text = "Crear Usuario";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.Location = new Point(71, 270);
            button10.Name = "button10";
            button10.Size = new Size(93, 40);
            button10.TabIndex = 28;
            button10.Text = "Eliminar Usuario";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button11
            // 
            button11.Location = new Point(1101, 402);
            button11.Name = "button11";
            button11.Size = new Size(91, 40);
            button11.TabIndex = 30;
            button11.Text = "Deasociar Rol a Usuario";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // FormControlUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(1293, 617);
            Controls.Add(button11);
            Controls.Add(button9);
            Controls.Add(button10);
            Controls.Add(button8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txtContrasenia);
            Controls.Add(txtNombre);
            Controls.Add(button6);
            Controls.Add(button7);
            Controls.Add(label9);
            Controls.Add(button5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(treeView1);
            Controls.Add(comboBox1);
            Name = "FormControlUsuario";
            Text = "FormControlUsuario";
            Load += FormControlUsuario_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private TreeView treeView1;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label1;
        private Label label2;
        private Label label4;
        private Button button5;
        private Label label3;
        private Label label9;
        private Button button6;
        private Button button7;
        private TextBox txtNombre;
        private TextBox txtContrasenia;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
    }
}