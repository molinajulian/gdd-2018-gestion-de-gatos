namespace PalcoNet.AbmCliente
{
    partial class ModificacionCliente
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
            this.txtCuil = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.comboTiposDoc = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnAlta = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.datePickerFechaNac = new System.Windows.Forms.DateTimePicker();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtNumDoc = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.groupBoxModifCli = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkHabilitado = new System.Windows.Forms.CheckBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.groupBoxModifCli.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCuil
            // 
            this.txtCuil.Location = new System.Drawing.Point(297, 169);
            this.txtCuil.Name = "txtCuil";
            this.txtCuil.Size = new System.Drawing.Size(203, 20);
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
            // comboTiposDoc
            // 
            this.comboTiposDoc.Enabled = false;
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
            this.btnAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlta.Location = new System.Drawing.Point(165, 287);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(178, 40);
            this.btnAlta.TabIndex = 13;
            this.btnAlta.Text = "Modificar Cliente";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(247, 133);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(108, 13);
            this.label15.TabIndex = 29;
            this.label15.Text = "Fecha de Nacimiento";
            // 
            // datePickerFechaNac
            // 
            this.datePickerFechaNac.Location = new System.Drawing.Point(364, 130);
            this.datePickerFechaNac.Name = "datePickerFechaNac";
            this.datePickerFechaNac.Size = new System.Drawing.Size(136, 20);
            this.datePickerFechaNac.TabIndex = 12;
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(64, 169);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(173, 20);
            this.txtTel.TabIndex = 5;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(9, 172);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(49, 13);
            this.label21.TabIndex = 16;
            this.label21.Text = "Teléfono";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(243, 91);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(117, 13);
            this.label22.TabIndex = 15;
            this.label22.Text = "Numero de Documento";
            // 
            // txtNumDoc
            // 
            this.txtNumDoc.Enabled = false;
            this.txtNumDoc.Location = new System.Drawing.Point(364, 88);
            this.txtNumDoc.Name = "txtNumDoc";
            this.txtNumDoc.Size = new System.Drawing.Size(136, 20);
            this.txtNumDoc.TabIndex = 3;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(297, 44);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(203, 20);
            this.txtApellido.TabIndex = 2;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(247, 47);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(44, 13);
            this.label24.TabIndex = 10;
            this.label24.Text = "Apellido";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(9, 133);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(26, 13);
            this.label25.TabIndex = 6;
            this.label25.Text = "Mail";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(62, 130);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(175, 20);
            this.txtMail.TabIndex = 4;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(9, 47);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(44, 13);
            this.label26.TabIndex = 2;
            this.label26.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(62, 44);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(175, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // groupBoxModifCli
            // 
            this.groupBoxModifCli.BackColor = System.Drawing.Color.White;
            this.groupBoxModifCli.Controls.Add(this.button1);
            this.groupBoxModifCli.Controls.Add(this.checkHabilitado);
            this.groupBoxModifCli.Controls.Add(this.txtCuil);
            this.groupBoxModifCli.Controls.Add(this.label14);
            this.groupBoxModifCli.Controls.Add(this.comboTiposDoc);
            this.groupBoxModifCli.Controls.Add(this.label13);
            this.groupBoxModifCli.Controls.Add(this.btnAlta);
            this.groupBoxModifCli.Controls.Add(this.label15);
            this.groupBoxModifCli.Controls.Add(this.datePickerFechaNac);
            this.groupBoxModifCli.Controls.Add(this.txtTel);
            this.groupBoxModifCli.Controls.Add(this.label21);
            this.groupBoxModifCli.Controls.Add(this.label22);
            this.groupBoxModifCli.Controls.Add(this.txtNumDoc);
            this.groupBoxModifCli.Controls.Add(this.txtApellido);
            this.groupBoxModifCli.Controls.Add(this.label24);
            this.groupBoxModifCli.Controls.Add(this.label25);
            this.groupBoxModifCli.Controls.Add(this.txtMail);
            this.groupBoxModifCli.Controls.Add(this.label26);
            this.groupBoxModifCli.Controls.Add(this.txtNombre);
            this.groupBoxModifCli.Location = new System.Drawing.Point(8, 73);
            this.groupBoxModifCli.Name = "groupBoxModifCli";
            this.groupBoxModifCli.Size = new System.Drawing.Size(513, 349);
            this.groupBoxModifCli.TabIndex = 2;
            this.groupBoxModifCli.TabStop = false;
            this.groupBoxModifCli.Text = "Datos del Nuevo Cliente";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(246, 215);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(236, 40);
            this.button1.TabIndex = 38;
            this.button1.Text = "Modificar Domicilio";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkHabilitado
            // 
            this.checkHabilitado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkHabilitado.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.checkHabilitado.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.checkHabilitado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkHabilitado.Location = new System.Drawing.Point(39, 226);
            this.checkHabilitado.Name = "checkHabilitado";
            this.checkHabilitado.Size = new System.Drawing.Size(97, 0);
            this.checkHabilitado.TabIndex = 20;
            this.checkHabilitado.Text = "Habilitado";
            this.checkHabilitado.UseVisualStyleBackColor = true;
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // ModificacionCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 451);
            this.Controls.Add(this.groupBoxModifCli);
            this.Name = "ModificacionCliente";
            this.Text = "Modificacion de Cliente";
            this.groupBoxModifCli.ResumeLayout(false);
            this.groupBoxModifCli.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtCuil;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboTiposDoc;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker datePickerFechaNac;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtNumDoc;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.GroupBox groupBoxModifCli;
        private System.Windows.Forms.CheckBox checkHabilitado;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.Button button1;
    }
}