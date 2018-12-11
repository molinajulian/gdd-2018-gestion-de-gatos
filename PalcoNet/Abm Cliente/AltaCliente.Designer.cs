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
            this.txtDepto = new System.Windows.Forms.TextBox();
            this.txtCuil = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboTiposDoc = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnAlta = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.datePickerFechaNac = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.txNumero = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txPiso = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txCp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txLocalidad = new System.Windows.Forms.TextBox();
            this.txTelefono = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txDni = new System.Windows.Forms.TextBox();
            this.txApellido = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txCalle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txMail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txNombre = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.txtDepto);
            this.groupBox1.Controls.Add(this.txtCuil);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboTiposDoc);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.btnAlta);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.datePickerFechaNac);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txNumero);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txPiso);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txCp);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txLocalidad);
            this.groupBox1.Controls.Add(this.txTelefono);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txDni);
            this.groupBox1.Controls.Add(this.txApellido);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txCalle);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txMail);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txNombre);
            this.groupBox1.Location = new System.Drawing.Point(12, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(513, 373);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Nuevo Cliente";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtDepto
            // 
            this.txtDepto.Location = new System.Drawing.Point(472, 239);
            this.txtDepto.Name = "txtDepto";
            this.txtDepto.Size = new System.Drawing.Size(27, 20);
            this.txtDepto.TabIndex = 38;
            // 
            // txtCuil
            // 
            this.txtCuil.Location = new System.Drawing.Point(297, 169);
            this.txtCuil.Name = "txtCuil";
            this.txtCuil.Size = new System.Drawing.Size(203, 20);
            this.txtCuil.TabIndex = 36;
            this.txtCuil.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
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
            this.button1.Location = new System.Drawing.Point(12, 285);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 40);
            this.button1.TabIndex = 35;
            this.button1.Text = "Dar de Alta Tarjeta";
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
            this.comboTiposDoc.SelectedIndexChanged += new System.EventHandler(this.comboTiposDoc_SelectedIndexChanged);
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
            this.btnAlta.Location = new System.Drawing.Point(311, 321);
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
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(271, 242);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Número";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // txNumero
            // 
            this.txNumero.Location = new System.Drawing.Point(321, 239);
            this.txNumero.Name = "txNumero";
            this.txNumero.Size = new System.Drawing.Size(43, 20);
            this.txNumero.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(370, 242);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Piso";
            // 
            // txPiso
            // 
            this.txPiso.Location = new System.Drawing.Point(403, 239);
            this.txPiso.Name = "txPiso";
            this.txPiso.Size = new System.Drawing.Size(27, 20);
            this.txPiso.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(436, 242);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Dpto";
            // 
            // txCp
            // 
            this.txCp.Location = new System.Drawing.Point(415, 203);
            this.txCp.Name = "txCp";
            this.txCp.Size = new System.Drawing.Size(51, 20);
            this.txCp.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(388, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "CP";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 206);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Localidad";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // txLocalidad
            // 
            this.txLocalidad.Location = new System.Drawing.Point(62, 203);
            this.txLocalidad.Name = "txLocalidad";
            this.txLocalidad.Size = new System.Drawing.Size(320, 20);
            this.txLocalidad.TabIndex = 6;
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
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
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
            // 
            // txApellido
            // 
            this.txApellido.Location = new System.Drawing.Point(250, 44);
            this.txApellido.Name = "txApellido";
            this.txApellido.Size = new System.Drawing.Size(132, 20);
            this.txApellido.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Calle";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txCalle
            // 
            this.txCalle.Location = new System.Drawing.Point(62, 239);
            this.txCalle.Name = "txCalle";
            this.txCalle.Size = new System.Drawing.Size(203, 20);
            this.txCalle.TabIndex = 8;
            this.txCalle.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(200, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Apellido";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mail";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txMail
            // 
            this.txMail.Location = new System.Drawing.Point(62, 130);
            this.txMail.Name = "txMail";
            this.txMail.Size = new System.Drawing.Size(175, 20);
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
            this.txNombre.Size = new System.Drawing.Size(132, 20);
            this.txNombre.TabIndex = 1;
            this.txNombre.TextChanged += new System.EventHandler(this.txNombre_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(323, 478);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(178, 40);
            this.button2.TabIndex = 39;
            this.button2.Text = "Volver";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // AltaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 530);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AltaCliente";
            this.Text = "AltaCliente";
            this.Load += new System.EventHandler(this.AltaCliente_Load);
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txCalle;
        private System.Windows.Forms.TextBox txTelefono;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txDni;
        private System.Windows.Forms.TextBox txApellido;
        private System.Windows.Forms.TextBox txCp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txLocalidad;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txNumero;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txPiso;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker datePickerFechaNac;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboTiposDoc;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCuil;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtDepto;
    }
}