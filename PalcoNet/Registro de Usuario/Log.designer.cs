namespace PalcoNet.Registro_de_usuario
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
            this.combo_roles = new System.Windows.Forms.ComboBox();
            this.comboTiposDoc = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // textUsuario
            // 
            this.textUsuario.Depth = 0;
            this.textUsuario.Hint = "";
            this.textUsuario.Location = new System.Drawing.Point(87, 170);
            this.textUsuario.MouseState = MaterialSkin.MouseState.HOVER;
            this.textUsuario.Name = "textUsuario";
            this.textUsuario.PasswordChar = '\0';
            this.textUsuario.SelectedText = "";
            this.textUsuario.SelectionLength = 0;
            this.textUsuario.SelectionStart = 0;
            this.textUsuario.Size = new System.Drawing.Size(306, 23);
            this.textUsuario.TabIndex = 0;
            this.textUsuario.Text = "Nombre de Usuario";
            this.textUsuario.UseSystemPasswordChar = false;
            this.textUsuario.Click += new System.EventHandler(this.textUsuario_Click);
            this.textUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textUsuario_KeyPress);
            // 
            // textContrasena
            // 
            this.textContrasena.Depth = 0;
            this.textContrasena.Hint = "";
            this.textContrasena.Location = new System.Drawing.Point(87, 222);
            this.textContrasena.MouseState = MaterialSkin.MouseState.HOVER;
            this.textContrasena.Name = "textContrasena";
            this.textContrasena.PasswordChar = '\0';
            this.textContrasena.SelectedText = "";
            this.textContrasena.SelectionLength = 0;
            this.textContrasena.SelectionStart = 0;
            this.textContrasena.Size = new System.Drawing.Size(306, 23);
            this.textContrasena.TabIndex = 1;
            this.textContrasena.TabStop = false;
            this.textContrasena.Text = "Contraseña";
            this.textContrasena.UseSystemPasswordChar = false;
            this.textContrasena.Click += new System.EventHandler(this.textContrasena_Click);
            this.textContrasena.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textContrasena_KeyPress);
            // 
            // btn_login
            // 
            this.btn_login.AutoSize = true;
            this.btn_login.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_login.Depth = 0;
            this.btn_login.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_login.Location = new System.Drawing.Point(204, 276);
            this.btn_login.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_login.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_login.Name = "btn_login";
            this.btn_login.Primary = false;
            this.btn_login.Size = new System.Drawing.Size(55, 36);
            this.btn_login.TabIndex = 2;
            this.btn_login.Text = "LOG In";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(30, 170);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(30, 222);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 23);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // combo_roles
            // 
            this.combo_roles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_roles.FormattingEnabled = true;
            this.combo_roles.Location = new System.Drawing.Point(87, 118);
            this.combo_roles.Name = "combo_roles";
            this.combo_roles.Size = new System.Drawing.Size(137, 21);
            this.combo_roles.TabIndex = 5;
            this.combo_roles.SelectedIndexChanged += new System.EventHandler(this.combo_roles_SelectedIndexChanged);
            // 
            // comboTiposDoc
            // 
            this.comboTiposDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTiposDoc.FormattingEnabled = true;
            this.comboTiposDoc.Location = new System.Drawing.Point(254, 118);
            this.comboTiposDoc.Name = "comboTiposDoc";
            this.comboTiposDoc.Size = new System.Drawing.Size(139, 21);
            this.comboTiposDoc.TabIndex = 6;
            // 
            // Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 350);
            this.Controls.Add(this.comboTiposDoc);
            this.Controls.Add(this.combo_roles);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.textContrasena);
            this.Controls.Add(this.textUsuario);
            this.Name = "Log";
            this.Text = "Log";
            this.Load += new System.EventHandler(this.Log_Load);
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
        private System.Windows.Forms.ComboBox combo_roles;
        private System.Windows.Forms.ComboBox comboTiposDoc;
    }
}