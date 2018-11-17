namespace PagoAgilFrba.AbmEmpresa
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
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tx_verificador = new System.Windows.Forms.TextBox();
            this.tx_tipo = new System.Windows.Forms.TextBox();
            this.btn_alta_empresa = new System.Windows.Forms.Button();
            this.combo_rubros = new System.Windows.Forms.ComboBox();
            this.tx_direccion = new System.Windows.Forms.TextBox();
            this.tx_cuit_numero = new System.Windows.Forms.TextBox();
            this.tx_nombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_volver = new System.Windows.Forms.Button();
            this.epProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.grupo_empresa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // grupo_empresa
            // 
            this.grupo_empresa.BackColor = System.Drawing.Color.White;
            this.grupo_empresa.Controls.Add(this.label6);
            this.grupo_empresa.Controls.Add(this.label5);
            this.grupo_empresa.Controls.Add(this.tx_verificador);
            this.grupo_empresa.Controls.Add(this.tx_tipo);
            this.grupo_empresa.Controls.Add(this.btn_alta_empresa);
            this.grupo_empresa.Controls.Add(this.combo_rubros);
            this.grupo_empresa.Controls.Add(this.tx_direccion);
            this.grupo_empresa.Controls.Add(this.tx_cuit_numero);
            this.grupo_empresa.Controls.Add(this.tx_nombre);
            this.grupo_empresa.Controls.Add(this.label4);
            this.grupo_empresa.Controls.Add(this.label3);
            this.grupo_empresa.Controls.Add(this.label2);
            this.grupo_empresa.Controls.Add(this.label1);
            this.grupo_empresa.Location = new System.Drawing.Point(12, 103);
            this.grupo_empresa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grupo_empresa.Name = "grupo_empresa";
            this.grupo_empresa.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grupo_empresa.Size = new System.Drawing.Size(719, 170);
            this.grupo_empresa.TabIndex = 0;
            this.grupo_empresa.TabStop = false;
            this.grupo_empresa.Text = "Datos de Empresa";
            
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(262, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(103, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "-";
            // 
            // tx_verificador
            // 
            this.tx_verificador.Location = new System.Drawing.Point(281, 88);
            this.tx_verificador.Name = "tx_verificador";
            this.tx_verificador.Size = new System.Drawing.Size(38, 22);
            this.tx_verificador.TabIndex = 10;
            // 
            // tx_tipo
            // 
            this.tx_tipo.Location = new System.Drawing.Point(59, 88);
            this.tx_tipo.Name = "tx_tipo";
            this.tx_tipo.Size = new System.Drawing.Size(38, 22);
            this.tx_tipo.TabIndex = 9;
            // 
            // btn_alta_empresa
            // 
            this.btn_alta_empresa.Location = new System.Drawing.Point(267, 128);
            this.btn_alta_empresa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_alta_empresa.Name = "btn_alta_empresa";
            this.btn_alta_empresa.Size = new System.Drawing.Size(145, 36);
            this.btn_alta_empresa.TabIndex = 8;
            this.btn_alta_empresa.Text = "Ingresar Empresa";
            this.btn_alta_empresa.UseVisualStyleBackColor = true;
            this.btn_alta_empresa.Click += new System.EventHandler(this.btn_alta_empresa_Click);
            // 
            // combo_rubros
            // 
            this.combo_rubros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_rubros.FormattingEnabled = true;
            this.combo_rubros.Location = new System.Drawing.Point(423, 91);
            this.combo_rubros.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.combo_rubros.Name = "combo_rubros";
            this.combo_rubros.Size = new System.Drawing.Size(233, 24);
            this.combo_rubros.TabIndex = 7;
            // 
            // tx_direccion
            // 
            this.tx_direccion.Location = new System.Drawing.Point(423, 38);
            this.tx_direccion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tx_direccion.Name = "tx_direccion";
            this.tx_direccion.Size = new System.Drawing.Size(233, 22);
            this.tx_direccion.TabIndex = 6;
            // 
            // tx_cuit_numero
            // 
            this.tx_cuit_numero.Location = new System.Drawing.Point(122, 88);
            this.tx_cuit_numero.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tx_cuit_numero.Name = "tx_cuit_numero";
            this.tx_cuit_numero.Size = new System.Drawing.Size(131, 22);
            this.tx_cuit_numero.TabIndex = 5;
            // 
            // tx_nombre
            // 
            this.tx_nombre.Location = new System.Drawing.Point(59, 41);
            this.tx_nombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tx_nombre.Name = "tx_nombre";
            this.tx_nombre.Size = new System.Drawing.Size(175, 22);
            this.tx_nombre.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(353, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Rubro:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(341, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Direccion:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cuit:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // btn_volver
            // 
            this.btn_volver.Location = new System.Drawing.Point(39, 283);
            this.btn_volver.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_volver.Name = "btn_volver";
            this.btn_volver.Size = new System.Drawing.Size(97, 36);
            this.btn_volver.TabIndex = 9;
            this.btn_volver.Text = "Atras";
            this.btn_volver.UseVisualStyleBackColor = true;
            this.btn_volver.Click += new System.EventHandler(this.btn_volver_Click);
            // 
            // epProvider
            // 
            this.epProvider.ContainerControl = this;
            // 
            // AltaEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 364);
            this.Controls.Add(this.btn_volver);
            this.Controls.Add(this.grupo_empresa);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AltaEmpresa";
            this.Text = "Alta de Empresa";
           
            this.grupo_empresa.ResumeLayout(false);
            this.grupo_empresa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grupo_empresa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_alta_empresa;
        private System.Windows.Forms.ComboBox combo_rubros;
        private System.Windows.Forms.TextBox tx_direccion;
        private System.Windows.Forms.TextBox tx_cuit_numero;
        private System.Windows.Forms.TextBox tx_nombre;
        private System.Windows.Forms.Button btn_volver;
        private System.Windows.Forms.ErrorProvider epProvider;
        private System.Windows.Forms.TextBox tx_verificador;
        private System.Windows.Forms.TextBox tx_tipo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}