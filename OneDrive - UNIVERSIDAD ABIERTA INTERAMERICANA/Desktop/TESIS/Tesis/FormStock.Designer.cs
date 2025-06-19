namespace UI
{
    partial class FormStock
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
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(35, 30);
            button1.Name = "button1";
            button1.Size = new Size(230, 55);
            button1.TabIndex = 0;
            button1.Text = "Stock";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FormStock
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(319, 122);
            Controls.Add(button1);
            Name = "FormStock";
            Text = "FormStock";
            Load += FormStock_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
    }
}