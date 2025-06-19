
namespace UI
{
    partial class login
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            btnLogin = new Button();
            label1 = new Label();
            label2 = new Label();
            txtUs = new TextBox();
            txtCont = new TextBox();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(92, 180);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(221, 23);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Iniciar Sesion";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 61);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 1;
            label1.Text = "Usuario:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 113);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 2;
            label2.Text = "Contraseña:";
            // 
            // txtUs
            // 
            txtUs.Location = new Point(130, 58);
            txtUs.Name = "txtUs";
            txtUs.Size = new Size(167, 23);
            txtUs.TabIndex = 3;
            // 
            // txtCont
            // 
            txtCont.Location = new Point(130, 110);
            txtCont.Name = "txtCont";
            txtCont.Size = new Size(167, 23);
            txtCont.TabIndex = 4;
            // 
            // login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(txtCont);
            Controls.Add(txtUs);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnLogin);
            Name = "login";
            Size = new Size(377, 228);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Label label1;
        private Label label2;
        private TextBox txtUs;
        private TextBox txtCont;
    }
}
