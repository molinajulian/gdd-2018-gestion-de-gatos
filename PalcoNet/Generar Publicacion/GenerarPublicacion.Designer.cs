namespace PalcoNet.GenerarPublicacion
{
    partial class GenerarPublicacion
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
            this.lbl_nombre_rol = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.group_alta_rol = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.btn_alta_publicacion = new System.Windows.Forms.Button();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbGrado = new System.Windows.Forms.ComboBox();
            this.txtDepto = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txPiso = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.btn_volver = new System.Windows.Forms.Button();
            this.group_alta_rol.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_nombre_rol
            // 
            this.lbl_nombre_rol.AutoSize = true;
            this.lbl_nombre_rol.Location = new System.Drawing.Point(22, 33);
            this.lbl_nombre_rol.Name = "lbl_nombre_rol";
            this.lbl_nombre_rol.Size = new System.Drawing.Size(63, 13);
            this.lbl_nombre_rol.TabIndex = 0;
            this.lbl_nombre_rol.Text = "Descripcion";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(93, 33);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(417, 20);
            this.txtDescripcion.TabIndex = 1;
            // 
            // group_alta_rol
            // 
            this.group_alta_rol.BackColor = System.Drawing.Color.White;
            this.group_alta_rol.Controls.Add(this.button1);
            this.group_alta_rol.Controls.Add(this.label13);
            this.group_alta_rol.Controls.Add(this.btn_alta_publicacion);
            this.group_alta_rol.Controls.Add(this.cmbEstado);
            this.group_alta_rol.Controls.Add(this.txtUsername);
            this.group_alta_rol.Controls.Add(this.label12);
            this.group_alta_rol.Controls.Add(this.label5);
            this.group_alta_rol.Controls.Add(this.cmbGrado);
            this.group_alta_rol.Controls.Add(this.txtDepto);
            this.group_alta_rol.Controls.Add(this.label11);
            this.group_alta_rol.Controls.Add(this.txtNumero);
            this.group_alta_rol.Controls.Add(this.label10);
            this.group_alta_rol.Controls.Add(this.txPiso);
            this.group_alta_rol.Controls.Add(this.label9);
            this.group_alta_rol.Controls.Add(this.txtCp);
            this.group_alta_rol.Controls.Add(this.label7);
            this.group_alta_rol.Controls.Add(this.label8);
            this.group_alta_rol.Controls.Add(this.txtLocalidad);
            this.group_alta_rol.Controls.Add(this.label6);
            this.group_alta_rol.Controls.Add(this.txtCalle);
            this.group_alta_rol.Controls.Add(this.txtDescripcion);
            this.group_alta_rol.Controls.Add(this.lbl_nombre_rol);
            this.group_alta_rol.Location = new System.Drawing.Point(36, 76);
            this.group_alta_rol.Name = "group_alta_rol";
            this.group_alta_rol.Size = new System.Drawing.Size(538, 468);
            this.group_alta_rol.TabIndex = 3;
            this.group_alta_rol.TabStop = false;
            this.group_alta_rol.Text = "Datos de Publicacion";
            this.group_alta_rol.Enter += new System.EventHandler(this.group_alta_rol_Enter);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(176, 299);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 39);
            this.button1.TabIndex = 58;
            this.button1.Text = "Registrar Sectores";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(248, 170);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 13);
            this.label13.TabIndex = 57;
            this.label13.Text = "Estado";
            // 
            // btn_alta_publicacion
            // 
            this.btn_alta_publicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_alta_publicacion.Location = new System.Drawing.Point(224, 360);
            this.btn_alta_publicacion.Name = "btn_alta_publicacion";
            this.btn_alta_publicacion.Size = new System.Drawing.Size(113, 44);
            this.btn_alta_publicacion.TabIndex = 0;
            this.btn_alta_publicacion.Text = "Generar";
            this.btn_alta_publicacion.UseVisualStyleBackColor = true;
            this.btn_alta_publicacion.Click += new System.EventHandler(this.btn_alta_publicacion_Click);
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(299, 167);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(121, 21);
            this.cmbEstado.TabIndex = 56;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(172, 211);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(121, 20);
            this.txtUsername.TabIndex = 55;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(34, 214);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(132, 13);
            this.label12.TabIndex = 54;
            this.label12.Text = "Username del responsable";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 53;
            this.label5.Text = "Grado";
            // 
            // cmbGrado
            // 
            this.cmbGrado.FormattingEnabled = true;
            this.cmbGrado.Location = new System.Drawing.Point(93, 167);
            this.cmbGrado.Name = "cmbGrado";
            this.cmbGrado.Size = new System.Drawing.Size(121, 21);
            this.cmbGrado.TabIndex = 52;
            // 
            // txtDepto
            // 
            this.txtDepto.Location = new System.Drawing.Point(495, 121);
            this.txtDepto.Name = "txtDepto";
            this.txtDepto.Size = new System.Drawing.Size(27, 20);
            this.txtDepto.TabIndex = 51;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(294, 124);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 50;
            this.label11.Text = "Número";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(344, 121);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(43, 20);
            this.txtNumero.TabIndex = 42;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(393, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 49;
            this.label10.Text = "Piso";
            // 
            // txPiso
            // 
            this.txPiso.Location = new System.Drawing.Point(426, 121);
            this.txPiso.Name = "txPiso";
            this.txPiso.Size = new System.Drawing.Size(27, 20);
            this.txPiso.TabIndex = 43;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(459, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 48;
            this.label9.Text = "Dpto";
            // 
            // txtCp
            // 
            this.txtCp.Location = new System.Drawing.Point(421, 85);
            this.txtCp.Name = "txtCp";
            this.txtCp.Size = new System.Drawing.Size(101, 20);
            this.txtCp.TabIndex = 40;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(393, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 47;
            this.label7.Text = "CP";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 46;
            this.label8.Text = "Localidad";
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(93, 85);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(281, 20);
            this.txtLocalidad.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 45;
            this.label6.Text = "Calle";
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(93, 121);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(195, 20);
            this.txtCalle.TabIndex = 41;
            // 
            // btn_volver
            // 
            this.btn_volver.Location = new System.Drawing.Point(61, 550);
            this.btn_volver.Name = "btn_volver";
            this.btn_volver.Size = new System.Drawing.Size(83, 44);
            this.btn_volver.TabIndex = 4;
            this.btn_volver.Text = "Volver";
            this.btn_volver.UseVisualStyleBackColor = true;
            this.btn_volver.Click += new System.EventHandler(this.btn_volver_Click);
            // 
            // GenerarPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 606);
            this.Controls.Add(this.btn_volver);
            this.Controls.Add(this.group_alta_rol);
            this.Name = "GenerarPublicacion";
            this.Text = "Generar Publicacion";
            this.group_alta_rol.ResumeLayout(false);
            this.group_alta_rol.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_nombre_rol;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.GroupBox group_alta_rol;
        private System.Windows.Forms.Button btn_alta_publicacion;
        private System.Windows.Forms.Button btn_volver;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbGrado;
        private System.Windows.Forms.TextBox txtDepto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txPiso;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.Button button1;
    }
}