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
            this.button1 = new System.Windows.Forms.Button();
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
            this.btnVolver = new System.Windows.Forms.Button();
            this.grupo_empresa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // grupo_empresa
            // 
            this.grupo_empresa.BackColor = System.Drawing.Color.White;
            this.grupo_empresa.Controls.Add(this.button1);
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
            this.grupo_empresa.Size = new System.Drawing.Size(539, 200);
            this.grupo_empresa.TabIndex = 0;
            this.grupo_empresa.TabStop = false;
            this.grupo_empresa.Text = "Datos de Empresa";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(170, 111);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 40);
            this.button1.TabIndex = 48;
            this.button1.Text = "Registrar Domicilio";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
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
            this.txtMail.Location = new System.Drawing.Point(301, 30);
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
            this.btn_alta_empresa.Location = new System.Drawing.Point(378, 155);
            this.btn_alta_empresa.Name = "btn_alta_empresa";
            this.btn_alta_empresa.Size = new System.Drawing.Size(140, 40);
            this.btn_alta_empresa.TabIndex = 43;
            this.btn_alta_empresa.Text = "Dar de Alta Empresa";
            this.btn_alta_empresa.UseVisualStyleBackColor = true;
            this.btn_alta_empresa.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCuit
            // 
            this.txtCuit.Location = new System.Drawing.Point(301, 76);
            this.txtCuit.Margin = new System.Windows.Forms.Padding(2);
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(143, 20);
            this.txtCuit.TabIndex = 5;
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
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(32, 289);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(128, 40);
            this.btnVolver.TabIndex = 42;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            // 
            // AltaEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 339);
            this.Controls.Add(this.btnVolver);
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
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}