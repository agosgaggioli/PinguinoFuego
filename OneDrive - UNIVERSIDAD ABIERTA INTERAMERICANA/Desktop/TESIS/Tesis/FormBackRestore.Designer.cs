namespace UI
{
    partial class FormBackRestore
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
            listBox1 = new ListBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(30, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(312, 244);
            listBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.InactiveCaption;
            button1.Location = new Point(30, 283);
            button1.Name = "button1";
            button1.Size = new Size(312, 23);
            button1.TabIndex = 1;
            button1.Text = "Realizar Back Up";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaption;
            button2.Location = new Point(30, 332);
            button2.Name = "button2";
            button2.Size = new Size(312, 23);
            button2.TabIndex = 2;
            button2.Text = "Realizar Restore";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // FormBackRestore
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(391, 398);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Name = "FormBackRestore";
            Text = "FormBackRestore";
            Load += FormBackRestore_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox1;
        private Button button1;
        private Button button2;
    }
}