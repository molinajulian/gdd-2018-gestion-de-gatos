namespace PalcoNet.AbmCliente
{
    partial class AltaCliente
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRegistrarDomicilio = new System.Windows.Forms.Button();
            this.txtCuil = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboTiposDoc = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnAlta = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.datePickerFechaNac = new System.Windows.Forms.DateTimePicker();
            this.txTelefono = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txDni = new System.Windows.Forms.TextBox();
            this.txApellido = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txMail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txNombre = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.labelAclaracion = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.labelContraseña = new System.Windows.Forms.Label();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.labelAclaracion);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.txtContraseña);
            this.groupBox1.Controls.Add(this.labelContraseña);
            this.groupBox1.Controls.Add(this.labelUsuario);
            this.groupBox1.Controls.Add(this.btnRegistrarDomicilio);
            this.groupBox1.Controls.Add(this.txtCuil);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboTiposDoc);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.btnAlta);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.datePickerFechaNac);
            this.groupBox1.Controls.Add(this.txTelefono);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txDni);
            this.groupBox1.Controls.Add(this.txApellido);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txMail);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txNombre);
            this.groupBox1.Location = new System.Drawing.Point(12, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(513, 400);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Nuevo Cliente";
            // 
            // btnRegistrarDomicilio
            // 
            this.btnRegistrarDomicilio.Location = new System.Drawing.Point(297, 284);
            this.btnRegistrarDomicilio.Name = "btnRegistrarDomicilio";
            this.btnRegistrarDomicilio.Size = new System.Drawing.Size(178, 40);
            this.btnRegistrarDomicilio.TabIndex = 38;
            this.btnRegistrarDomicilio.Text = "Agregar Domicilio";
            this.btnRegistrarDomicilio.UseVisualStyleBackColor = true;
            this.btnRegistrarDomicilio.Click += new System.EventHandler(this.btnRegistrarDomicilio_Click);
            // 
            // txtCuil
            // 
            this.txtCuil.Location = new System.Drawing.Point(315, 169);
            this.txtCuil.Name = "txtCuil";
            this.txtCuil.Size = new System.Drawing.Size(185, 20);
            this.txtCuil.TabIndex = 36;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(247, 172);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 13);
            this.label14.TabIndex = 37;
            this.label14.Text = "CUIL";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 284);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 40);
            this.button1.TabIndex = 35;
            this.button1.Text = "Agregar Tarjeta";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboTiposDoc
            // 
            this.comboTiposDoc.FormattingEnabled = true;
            this.comboTiposDoc.Location = new System.Drawing.Point(116, 88);
            this.comboTiposDoc.Name = "comboTiposDoc";
            this.comboTiposDoc.Size = new System.Drawing.Size(121, 21);
            this.comboTiposDoc.TabIndex = 34;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 91);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 13);
            this.label13.TabIndex = 32;
            this.label13.Text = "Tipo de Documento";
            // 
            // btnAlta
            // 
            this.btnAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnAlta.Location = new System.Drawing.Point(297, 354);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(178, 40);
            this.btnAlta.TabIndex = 13;
            this.btnAlta.Text = "Dar de Alta Cliente";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.boton_alta_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(247, 133);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "Fecha de Nacimiento";
            // 
            // datePickerFechaNac
            // 
            this.datePickerFechaNac.Location = new System.Drawing.Point(364, 130);
            this.datePickerFechaNac.Name = "datePickerFechaNac";
            this.datePickerFechaNac.Size = new System.Drawing.Size(136, 20);
            this.datePickerFechaNac.TabIndex = 12;
            // 
            // txTelefono
            // 
            this.txTelefono.Location = new System.Drawing.Point(64, 169);
            this.txTelefono.Name = "txTelefono";
            this.txTelefono.Size = new System.Drawing.Size(173, 20);
            this.txTelefono.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Teléfono";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(243, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Numero de Documento";
            // 
            // txDni
            // 
            this.txDni.Location = new System.Drawing.Point(364, 88);
            this.txDni.Name = "txDni";
            this.txDni.Size = new System.Drawing.Size(136, 20);
            this.txDni.TabIndex = 3;
            this.txDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txDni_KeyPress);
            // 
            // txApellido
            // 
            this.txApellido.Location = new System.Drawing.Point(315, 44);
            this.txApellido.Name = "txApellido";
            this.txApellido.Size = new System.Drawing.Size(185, 20);
            this.txApellido.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(256, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Apellido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mail";
            // 
            // txMail
            // 
            this.txMail.Location = new System.Drawing.Point(64, 130);
            this.txMail.Name = "txMail";
            this.txMail.Size = new System.Drawing.Size(173, 20);
            this.txMail.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre";
            // 
            // txNombre
            // 
            this.txNombre.Location = new System.Drawing.Point(62, 44);
            this.txNombre.Name = "txNombre";
            this.txNombre.Size = new System.Drawing.Size(175, 20);
            this.txNombre.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 487);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(178, 40);
            this.button2.TabIndex = 39;
            this.button2.Text = "Volver";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelAclaracion
            // 
            this.labelAclaracion.AutoSize = true;
            this.labelAclaracion.Location = new System.Drawing.Point(18, 254);
            this.labelAclaracion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAclaracion.Name = "labelAclaracion";
            this.labelAclaracion.Size = new System.Drawing.Size(263, 13);
            this.labelAclaracion.TabIndex = 58;
            this.labelAclaracion.Text = "* Su nombre de usuario será su número de documento";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(64, 206);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(173, 20);
            this.txtUsuario.TabIndex = 57;
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(315, 206);
            this.txtContraseña.Margin = new System.Windows.Forms.Padding(2);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(171, 20);
            this.txtContraseña.TabIndex = 56;
            this.txtContraseña.Click += new System.EventHandler(this.txtContraseña_Click);
            this.txtContraseña.TextChanged += new System.EventHandler(this.txtContraseña_TextChanged);
            // 
            // labelContraseña
            // 
            this.labelContraseña.AutoSize = true;
            this.labelContraseña.Location = new System.Drawing.Point(247, 209);
            this.labelContraseña.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelContraseña.Name = "labelContraseña";
            this.labelContraseña.Size = new System.Drawing.Size(61, 13);
            this.labelContraseña.TabIndex = 55;
            this.labelContraseña.Text = "Contraseña";
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Location = new System.Drawing.Point(12, 209);
            this.labelUsuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(43, 13);
            this.labelUsuario.TabIndex = 54;
            this.labelUsuario.Text = "Usuario";
            // 
            // AltaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 552);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AltaCliente";
            this.Text = "AltaCliente";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txMail;
        private System.Windows.Forms.TextBox txTelefono;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txDni;
        private System.Windows.Forms.TextBox txApellido;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker datePickerFechaNac;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboTiposDoc;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCuil;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnRegistrarDomicilio;
        private System.Windows.Forms.Label labelAclaracion;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Label labelContraseña;
        private System.Windows.Forms.Label labelUsuario;
    }
}