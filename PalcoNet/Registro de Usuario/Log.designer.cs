namespace PalcoNet.Login_e_Inicio
{
    partial class Log
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Log));
            this.textUsuario = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.textContrasena = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btn_login = new MaterialSkin.Controls.MaterialFlatButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // textUsuario
            // 
            this.textUsuario.Depth = 0;
            this.textUsuario.Hint = "";
            this.textUsuario.Location = new System.Drawing.Point(59, 126);
            this.textUsuario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textUsuario.MouseState = MaterialSkin.MouseState.HOVER;
            this.textUsuario.Name = "textUsuario";
            this.textUsuario.PasswordChar = '\0';
            this.textUsuario.SelectedText = "";
            this.textUsuario.SelectionLength = 0;
            this.textUsuario.SelectionStart = 0;
            this.textUsuario.Size = new System.Drawing.Size(408, 28);
            this.textUsuario.TabIndex = 0;
            this.textUsuario.Text = "Nombre de Usuario";
            this.textUsuario.UseSystemPasswordChar = false;
            this.textUsuario.Click += new System.EventHandler(this.textUsuario_Click);
            // 
            // textContrasena
            // 
            this.textContrasena.Depth = 0;
            this.textContrasena.Hint = "";
            this.textContrasena.Location = new System.Drawing.Point(59, 192);
            this.textContrasena.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textContrasena.MouseState = MaterialSkin.MouseState.HOVER;
            this.textContrasena.Name = "textContrasena";
            this.textContrasena.PasswordChar = '\0';
            this.textContrasena.SelectedText = "";
            this.textContrasena.SelectionLength = 0;
            this.textContrasena.SelectionStart = 0;
            this.textContrasena.Size = new System.Drawing.Size(408, 28);
            this.textContrasena.TabIndex = 1;
            this.textContrasena.TabStop = false;
            this.textContrasena.Text = "Contraseña";
            this.textContrasena.UseSystemPasswordChar = false;
            this.textContrasena.Click += new System.EventHandler(this.textContrasena_Click);
            this.textContrasena.Enter += new System.EventHandler(this.textContrasena_Enter);
            this.textContrasena.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textContrasena_KeyPress);
            // 
            // btn_login
            // 
            this.btn_login.AutoSize = true;
            this.btn_login.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_login.Depth = 0;
            this.btn_login.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_login.Location = new System.Drawing.Point(604, 150);
            this.btn_login.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.btn_login.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_login.Name = "btn_login";
            this.btn_login.Primary = false;
            this.btn_login.Size = new System.Drawing.Size(67, 36);
            this.btn_login.TabIndex = 2;
            this.btn_login.Text = "LOG In";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 126);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(17, 192);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 290);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.textContrasena);
            this.Controls.Add(this.textUsuario);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Log";
            this.Text = "Log";
            this.Enter += new System.EventHandler(this.btn_login_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialSingleLineTextField textUsuario;
        private MaterialSkin.Controls.MaterialSingleLineTextField textContrasena;
        private MaterialSkin.Controls.MaterialFlatButton btn_login;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}