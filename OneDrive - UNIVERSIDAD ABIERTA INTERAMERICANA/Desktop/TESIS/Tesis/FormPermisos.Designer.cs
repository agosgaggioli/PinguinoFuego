namespace UI
{
    partial class FormPermisos
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
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            textBox2 = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(113, 35);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(230, 23);
            textBox1.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 38);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 7;
            label1.Text = "Nombre:";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(53, 91);
            button1.Name = "button1";
            button1.Size = new Size(290, 51);
            button1.TabIndex = 6;
            button1.Text = "Crear Permiso";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.InactiveCaption;
            button2.Location = new Point(169, 159);
            button2.Name = "button2";
            button2.Size = new Size(174, 29);
            button2.TabIndex = 9;
            button2.Text = "Eliminar Permiso";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(94, 165);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(47, 23);
            textBox2.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 173);
            label2.Name = "label2";
            label2.Size = new Size(20, 15);
            label2.TabIndex = 11;
            label2.Text = "Id:";
            // 
            // FormPermisos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(408, 241);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "FormPermisos";
            Text = "FormPermisos";
            Load += FormPermisos_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private Button button2;
        private TextBox textBox2;
        private Label label2;
    }
}