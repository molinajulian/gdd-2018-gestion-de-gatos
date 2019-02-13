namespace PalcoNet.Registro_de_usuario
{
    partial class CambiarContraseña
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
            this.txtContraseña = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtRepetirContraseña = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btn_Cambiar = new MaterialSkin.Controls.MaterialFlatButton();
            this.SuspendLayout();
            // 
            // txtContraseña
            // 
            this.txtContraseña.Depth = 0;
            this.txtContraseña.Hint = "";
            this.txtContraseña.Location = new System.Drawing.Point(78, 103);
            this.txtContraseña.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.PasswordChar = '\0';
            this.txtContraseña.SelectedText = "";
            this.txtContraseña.SelectionLength = 0;
            this.txtContraseña.SelectionStart = 0;
            this.txtContraseña.Size = new System.Drawing.Size(260, 23);
            this.txtContraseña.TabIndex = 6;
            this.txtContraseña.TabStop = false;
            this.txtContraseña.Text = "Nueva contraseña";
            this.txtContraseña.UseSystemPasswordChar = false;
            this.txtContraseña.Click += new System.EventHandler(this.txtContraseña_Click);
            this.txtContraseña.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textContrasena_KeyPress);
            // 
            // txtRepetirContraseña
            // 
            this.txtRepetirContraseña.Depth = 0;
            this.txtRepetirContraseña.Hint = "";
            this.txtRepetirContraseña.Location = new System.Drawing.Point(78, 159);
            this.txtRepetirContraseña.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtRepetirContraseña.Name = "txtRepetirContraseña";
            this.txtRepetirContraseña.PasswordChar = '\0';
            this.txtRepetirContraseña.SelectedText = "";
            this.txtRepetirContraseña.SelectionLength = 0;
            this.txtRepetirContraseña.SelectionStart = 0;
            this.txtRepetirContraseña.Size = new System.Drawing.Size(260, 23);
            this.txtRepetirContraseña.TabIndex = 8;
            this.txtRepetirContraseña.TabStop = false;
            this.txtRepetirContraseña.Text = "Repita su nueva contraseña";
            this.txtRepetirContraseña.UseSystemPasswordChar = false;
            this.txtRepetirContraseña.Click += new System.EventHandler(this.txtRepetirContraseña_Click);
            this.txtRepetirContraseña.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRepetirContraseña_KeyPress);
            // 
            // btn_Cambiar
            // 
            this.btn_Cambiar.AutoSize = true;
            this.btn_Cambiar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_Cambiar.Depth = 0;
            this.btn_Cambiar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Cambiar.Location = new System.Drawing.Point(168, 212);
            this.btn_Cambiar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_Cambiar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_Cambiar.Name = "btn_Cambiar";
            this.btn_Cambiar.Primary = false;
            this.btn_Cambiar.Size = new System.Drawing.Size(72, 36);
            this.btn_Cambiar.TabIndex = 10;
            this.btn_Cambiar.Text = "Cambiar";
            this.btn_Cambiar.UseVisualStyleBackColor = true;
            this.btn_Cambiar.Click += new System.EventHandler(this.btn_Cambiar_Click);
            // 
            // CambiarContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 281);
            this.Controls.Add(this.btn_Cambiar);
            this.Controls.Add(this.txtRepetirContraseña);
            this.Controls.Add(this.txtContraseña);
            this.Name = "CambiarContraseña";
            this.Text = "Cambiar contraseña";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialSingleLineTextField txtContraseña;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtRepetirContraseña;
        private MaterialSkin.Controls.MaterialFlatButton btn_Cambiar;

    }
}