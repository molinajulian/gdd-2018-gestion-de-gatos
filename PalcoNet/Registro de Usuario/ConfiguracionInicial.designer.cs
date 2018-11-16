namespace PalcoNet.Login_e_Inicio
{
    partial class ConfiguracionInicial
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
            this.combo_roles = new System.Windows.Forms.ComboBox();
            this.combo_sucursales = new System.Windows.Forms.ComboBox();
            this.btn_rol_aceptado = new MaterialSkin.Controls.MaterialFlatButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // combo_roles
            // 
            this.combo_roles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_roles.FormattingEnabled = true;
            this.combo_roles.Location = new System.Drawing.Point(108, 118);
            this.combo_roles.Name = "combo_roles";
            this.combo_roles.Size = new System.Drawing.Size(183, 21);
            this.combo_roles.TabIndex = 1;
            this.combo_roles.SelectedValueChanged += new System.EventHandler(this.combo_roles_SelectedValueChanged);
            // 
            // combo_sucursales
            // 
            this.combo_sucursales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_sucursales.FormattingEnabled = true;
            this.combo_sucursales.Location = new System.Drawing.Point(108, 184);
            this.combo_sucursales.Name = "combo_sucursales";
            this.combo_sucursales.Size = new System.Drawing.Size(183, 21);
            this.combo_sucursales.TabIndex = 2;
            // 
            // btn_rol_aceptado
            // 
            this.btn_rol_aceptado.AutoSize = true;
            this.btn_rol_aceptado.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_rol_aceptado.Depth = 0;
            this.btn_rol_aceptado.Location = new System.Drawing.Point(161, 247);
            this.btn_rol_aceptado.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_rol_aceptado.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_rol_aceptado.Name = "btn_rol_aceptado";
            this.btn_rol_aceptado.Primary = false;
            this.btn_rol_aceptado.Size = new System.Drawing.Size(73, 36);
            this.btn_rol_aceptado.TabIndex = 3;
            this.btn_rol_aceptado.Text = "aceptar";
            this.btn_rol_aceptado.UseVisualStyleBackColor = true;
            this.btn_rol_aceptado.Click += new System.EventHandler(this.btn_rol_aceptado_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(159, 101);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Selecionar Rol";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(146, 167);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Seleccionar Sucursal";
            // 
            // ConfiguracionInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 317);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_rol_aceptado);
            this.Controls.Add(this.combo_sucursales);
            this.Controls.Add(this.combo_roles);
            this.Name = "ConfiguracionInicial";
            this.Text = "Inicio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfiguracionInicial_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox combo_roles;
        private System.Windows.Forms.ComboBox combo_sucursales;
        private MaterialSkin.Controls.MaterialFlatButton btn_rol_aceptado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

    }
}