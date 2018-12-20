namespace PalcoNet.AbmEmpresa
{
    partial class AltaEmpresa
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
            this.components = new System.ComponentModel.Container();
            this.grupo_empresa = new System.Windows.Forms.GroupBox();
            this.labelAclaracion = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.labelContraseña = new System.Windows.Forms.Label();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.buttonAltaDomicilio = new System.Windows.Forms.Button();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_alta_empresa = new System.Windows.Forms.Button();
            this.txtCuit = new System.Windows.Forms.TextBox();
            this.txtRazon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.epProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.grupo_empresa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // grupo_empresa
            // 
            this.grupo_empresa.BackColor = System.Drawing.Color.White;
            this.grupo_empresa.Controls.Add(this.labelAclaracion);
            this.grupo_empresa.Controls.Add(this.txtUsuario);
            this.grupo_empresa.Controls.Add(this.txtContraseña);
            this.grupo_empresa.Controls.Add(this.labelContraseña);
            this.grupo_empresa.Controls.Add(this.labelUsuario);
            this.grupo_empresa.Controls.Add(this.buttonAltaDomicilio);
            this.grupo_empresa.Controls.Add(this.txtTel);
            this.grupo_empresa.Controls.Add(this.label6);
            this.grupo_empresa.Controls.Add(this.txtMail);
            this.grupo_empresa.Controls.Add(this.label4);
            this.grupo_empresa.Controls.Add(this.btn_alta_empresa);
            this.grupo_empresa.Controls.Add(this.txtCuit);
            this.grupo_empresa.Controls.Add(this.txtRazon);
            this.grupo_empresa.Controls.Add(this.label2);
            this.grupo_empresa.Controls.Add(this.label1);
            this.grupo_empresa.Location = new System.Drawing.Point(9, 84);
            this.grupo_empresa.Margin = new System.Windows.Forms.Padding(2);
            this.grupo_empresa.Name = "grupo_empresa";
            this.grupo_empresa.Padding = new System.Windows.Forms.Padding(2);
            this.grupo_empresa.Size = new System.Drawing.Size(539, 250);
            this.grupo_empresa.TabIndex = 0;
            this.grupo_empresa.TabStop = false;
            this.grupo_empresa.Text = "Datos de Empresa";
            this.grupo_empresa.Enter += new System.EventHandler(this.grupo_empresa_Enter);
            // 
            // labelAclaracion
            // 
            this.labelAclaracion.AutoSize = true;
            this.labelAclaracion.Location = new System.Drawing.Point(26, 174);
            this.labelAclaracion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAclaracion.Name = "labelAclaracion";
            this.labelAclaracion.Size = new System.Drawing.Size(175, 13);
            this.labelAclaracion.TabIndex = 53;
            this.labelAclaracion.Text = "* Su nombre de usuario será su Cuit";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(85, 126);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(143, 20);
            this.txtUsuario.TabIndex = 52;
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(323, 126);
            this.txtContraseña.Margin = new System.Windows.Forms.Padding(2);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(139, 20);
            this.txtContraseña.TabIndex = 51;
            this.txtContraseña.Click += new System.EventHandler(this.txtContraseña_Click);
            // 
            // labelContraseña
            // 
            this.labelContraseña.AutoSize = true;
            this.labelContraseña.Location = new System.Drawing.Point(255, 129);
            this.labelContraseña.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelContraseña.Name = "labelContraseña";
            this.labelContraseña.Size = new System.Drawing.Size(61, 13);
            this.labelContraseña.TabIndex = 50;
            this.labelContraseña.Text = "Contraseña";
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Location = new System.Drawing.Point(20, 129);
            this.labelUsuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(43, 13);
            this.labelUsuario.TabIndex = 49;
            this.labelUsuario.Text = "Usuario";
            // 
            // buttonAltaDomicilio
            // 
            this.buttonAltaDomicilio.Location = new System.Drawing.Point(164, 198);
            this.buttonAltaDomicilio.Name = "buttonAltaDomicilio";
            this.buttonAltaDomicilio.Size = new System.Drawing.Size(178, 40);
            this.buttonAltaDomicilio.TabIndex = 48;
            this.buttonAltaDomicilio.Text = "Registrar Domicilio";
            this.buttonAltaDomicilio.UseVisualStyleBackColor = true;
            this.buttonAltaDomicilio.Click += new System.EventHandler(this.buttonAltaDomicilio_Click);
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(85, 76);
            this.txtTel.Margin = new System.Windows.Forms.Padding(2);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(143, 20);
            this.txtTel.TabIndex = 47;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 79);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 46;
            this.label6.Text = "Telefono";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(323, 30);
            this.txtMail.Margin = new System.Windows.Forms.Padding(2);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(139, 20);
            this.txtMail.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(259, 33);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Mail";
            // 
            // btn_alta_empresa
            // 
            this.btn_alta_empresa.Location = new System.Drawing.Point(380, 198);
            this.btn_alta_empresa.Name = "btn_alta_empresa";
            this.btn_alta_empresa.Size = new System.Drawing.Size(140, 40);
            this.btn_alta_empresa.TabIndex = 43;
            this.btn_alta_empresa.Text = "Dar de Alta Empresa";
            this.btn_alta_empresa.UseVisualStyleBackColor = true;
            this.btn_alta_empresa.Click += new System.EventHandler(this.btn_alta_empresa_Click);
            // 
            // txtCuit
            // 
            this.txtCuit.Location = new System.Drawing.Point(323, 76);
            this.txtCuit.Margin = new System.Windows.Forms.Padding(2);
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(139, 20);
            this.txtCuit.TabIndex = 5;
            this.txtCuit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCuit_KeyPress);
            // 
            // txtRazon
            // 
            this.txtRazon.Location = new System.Drawing.Point(85, 30);
            this.txtRazon.Margin = new System.Windows.Forms.Padding(2);
            this.txtRazon.Name = "txtRazon";
            this.txtRazon.Size = new System.Drawing.Size(143, 20);
            this.txtRazon.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cuit";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Razon Social";
            // 
            // epProvider
            // 
            this.epProvider.ContainerControl = this;
            // 
            // AltaEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 345);
            this.Controls.Add(this.grupo_empresa);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AltaEmpresa";
            this.Text = "Alta de Empresa";
            this.grupo_empresa.ResumeLayout(false);
            this.grupo_empresa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grupo_empresa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCuit;
        private System.Windows.Forms.TextBox txtRazon;
        private System.Windows.Forms.ErrorProvider epProvider;
        private System.Windows.Forms.Button btn_alta_empresa;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonAltaDomicilio;
        private System.Windows.Forms.Label labelAclaracion;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Label labelContraseña;
        private System.Windows.Forms.Label labelUsuario;
    }
}