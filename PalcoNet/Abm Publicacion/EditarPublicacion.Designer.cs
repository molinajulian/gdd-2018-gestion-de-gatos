namespace PalcoNet.AbmPublicaciones
{
    partial class EditarPublicacion
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtpRealizacion = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpVencimiento = new System.Windows.Forms.DateTimePicker();
            this.txtEspectTitulo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbRubro = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.btn_alta_publicacion = new System.Windows.Forms.Button();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbGrado = new System.Windows.Forms.ComboBox();
            this.btn_volver = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.group_alta_rol.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_nombre_rol
            // 
            this.lbl_nombre_rol.AutoSize = true;
            this.lbl_nombre_rol.Location = new System.Drawing.Point(18, 30);
            this.lbl_nombre_rol.Name = "lbl_nombre_rol";
            this.lbl_nombre_rol.Size = new System.Drawing.Size(63, 13);
            this.lbl_nombre_rol.TabIndex = 0;
            this.lbl_nombre_rol.Text = "Descripcion";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(96, 30);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(395, 20);
            this.txtDescripcion.TabIndex = 1;
            // 
            // group_alta_rol
            // 
            this.group_alta_rol.BackColor = System.Drawing.Color.White;
            this.group_alta_rol.Controls.Add(this.label13);
            this.group_alta_rol.Controls.Add(this.cmbEstado);
            this.group_alta_rol.Controls.Add(this.txtUsername);
            this.group_alta_rol.Controls.Add(this.label12);
            this.group_alta_rol.Controls.Add(this.label5);
            this.group_alta_rol.Controls.Add(this.cmbGrado);
            this.group_alta_rol.Controls.Add(this.txtDescripcion);
            this.group_alta_rol.Controls.Add(this.lbl_nombre_rol);
            this.group_alta_rol.Location = new System.Drawing.Point(36, 76);
            this.group_alta_rol.Name = "group_alta_rol";
            this.group_alta_rol.Size = new System.Drawing.Size(510, 253);
            this.group_alta_rol.TabIndex = 3;
            this.group_alta_rol.TabStop = false;
            this.group_alta_rol.Text = "Datos de Publicacion";
            this.group_alta_rol.Enter += new System.EventHandler(this.group_alta_rol_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 69;
            this.label1.Text = "Fecha de realizacion";
            // 
            // dtpRealizacion
            // 
            this.dtpRealizacion.Location = new System.Drawing.Point(193, 108);
            this.dtpRealizacion.Name = "dtpRealizacion";
            this.dtpRealizacion.Size = new System.Drawing.Size(213, 20);
            this.dtpRealizacion.TabIndex = 68;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 67;
            this.label4.Text = "Fecha de vencimiento";
            // 
            // dtpVencimiento
            // 
            this.dtpVencimiento.Location = new System.Drawing.Point(193, 146);
            this.dtpVencimiento.Name = "dtpVencimiento";
            this.dtpVencimiento.Size = new System.Drawing.Size(213, 20);
            this.dtpVencimiento.TabIndex = 66;
            // 
            // txtEspectTitulo
            // 
            this.txtEspectTitulo.Location = new System.Drawing.Point(69, 30);
            this.txtEspectTitulo.Name = "txtEspectTitulo";
            this.txtEspectTitulo.Size = new System.Drawing.Size(399, 20);
            this.txtEspectTitulo.TabIndex = 65;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 64;
            this.label3.Text = "Titulo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 63;
            this.label2.Text = "Rubro";
            // 
            // cmbRubro
            // 
            this.cmbRubro.FormattingEnabled = true;
            this.cmbRubro.Location = new System.Drawing.Point(193, 63);
            this.cmbRubro.Name = "cmbRubro";
            this.cmbRubro.Size = new System.Drawing.Size(121, 21);
            this.cmbRubro.TabIndex = 62;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(24, 197);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(198, 39);
            this.button2.TabIndex = 59;
            this.button2.Text = "Editar Domicilio";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(270, 197);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 39);
            this.button1.TabIndex = 58;
            this.button1.Text = "Editar Sectores";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(320, 69);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 13);
            this.label13.TabIndex = 57;
            this.label13.Text = "Estado";
            // 
            // btn_alta_publicacion
            // 
            this.btn_alta_publicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_alta_publicacion.Location = new System.Drawing.Point(489, 345);
            this.btn_alta_publicacion.Name = "btn_alta_publicacion";
            this.btn_alta_publicacion.Size = new System.Drawing.Size(132, 67);
            this.btn_alta_publicacion.TabIndex = 0;
            this.btn_alta_publicacion.Text = "Confirmar";
            this.btn_alta_publicacion.UseVisualStyleBackColor = true;
            this.btn_alta_publicacion.Click += new System.EventHandler(this.btn_alta_publicacion_Click);
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(371, 66);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(121, 21);
            this.cmbEstado.TabIndex = 56;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(371, 108);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(121, 20);
            this.txtUsername.TabIndex = 55;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(233, 111);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(132, 13);
            this.label12.TabIndex = 54;
            this.label12.Text = "Username del responsable";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 53;
            this.label5.Text = "Grado";
            // 
            // cmbGrado
            // 
            this.cmbGrado.FormattingEnabled = true;
            this.cmbGrado.Location = new System.Drawing.Point(96, 69);
            this.cmbGrado.Name = "cmbGrado";
            this.cmbGrado.Size = new System.Drawing.Size(121, 21);
            this.cmbGrado.TabIndex = 52;
            // 
            // btn_volver
            // 
            this.btn_volver.Location = new System.Drawing.Point(57, 368);
            this.btn_volver.Name = "btn_volver";
            this.btn_volver.Size = new System.Drawing.Size(83, 44);
            this.btn_volver.TabIndex = 4;
            this.btn_volver.Text = "Volver";
            this.btn_volver.UseVisualStyleBackColor = true;
            this.btn_volver.Click += new System.EventHandler(this.btn_volver_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpRealizacion);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpVencimiento);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtEspectTitulo);
            this.groupBox1.Controls.Add(this.cmbRubro);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(567, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(484, 253);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Epectaculo";
            // 
            // EditarPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 427);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_alta_publicacion);
            this.Controls.Add(this.btn_volver);
            this.Controls.Add(this.group_alta_rol);
            this.Name = "EditarPublicacion";
            this.Text = "Editar Publicacion";
            this.group_alta_rol.ResumeLayout(false);
            this.group_alta_rol.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbRubro;
        private System.Windows.Forms.TextBox txtEspectTitulo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpVencimiento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpRealizacion;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}