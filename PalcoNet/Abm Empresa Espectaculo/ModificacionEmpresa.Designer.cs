namespace PagoAgilFrba.AbmEmpresa
{
    partial class ModificacionEmpresa
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
            this.check_box_habilitacion = new System.Windows.Forms.CheckBox();
            this.btn_modificar_empresa = new System.Windows.Forms.Button();
            this.combo_rubros = new System.Windows.Forms.ComboBox();
            this.tx_direccion = new System.Windows.Forms.TextBox();
            this.tx_cuit = new System.Windows.Forms.TextBox();
            this.tx_nombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_atras = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.grupo_empresa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // grupo_empresa
            // 
            this.grupo_empresa.BackColor = System.Drawing.Color.White;
            this.grupo_empresa.Controls.Add(this.check_box_habilitacion);
            this.grupo_empresa.Controls.Add(this.btn_modificar_empresa);
            this.grupo_empresa.Controls.Add(this.combo_rubros);
            this.grupo_empresa.Controls.Add(this.tx_direccion);
            this.grupo_empresa.Controls.Add(this.tx_cuit);
            this.grupo_empresa.Controls.Add(this.tx_nombre);
            this.grupo_empresa.Controls.Add(this.label4);
            this.grupo_empresa.Controls.Add(this.label3);
            this.grupo_empresa.Controls.Add(this.label2);
            this.grupo_empresa.Controls.Add(this.label1);
            this.grupo_empresa.Location = new System.Drawing.Point(12, 98);
            this.grupo_empresa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grupo_empresa.Name = "grupo_empresa";
            this.grupo_empresa.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grupo_empresa.Size = new System.Drawing.Size(960, 170);
            this.grupo_empresa.TabIndex = 1;
            this.grupo_empresa.TabStop = false;
            this.grupo_empresa.Text = "Datos de Empresa";
            // 
            // check_box_habilitacion
            // 
            this.check_box_habilitacion.AutoSize = true;
            this.check_box_habilitacion.Location = new System.Drawing.Point(720, 38);
            this.check_box_habilitacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.check_box_habilitacion.Name = "check_box_habilitacion";
            this.check_box_habilitacion.Size = new System.Drawing.Size(93, 21);
            this.check_box_habilitacion.TabIndex = 9;
            this.check_box_habilitacion.Text = "Habilitada";
            this.check_box_habilitacion.UseVisualStyleBackColor = true;
            // 
            // btn_modificar_empresa
            // 
            this.btn_modificar_empresa.Location = new System.Drawing.Point(457, 128);
            this.btn_modificar_empresa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_modificar_empresa.Name = "btn_modificar_empresa";
            this.btn_modificar_empresa.Size = new System.Drawing.Size(97, 36);
            this.btn_modificar_empresa.TabIndex = 8;
            this.btn_modificar_empresa.Text = "Modificar";
            this.btn_modificar_empresa.UseVisualStyleBackColor = true;
            this.btn_modificar_empresa.Click += new System.EventHandler(this.btn_modificar_empresa_Click);
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
            // tx_cuit
            // 
            this.tx_cuit.Location = new System.Drawing.Point(108, 86);
            this.tx_cuit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tx_cuit.Name = "tx_cuit";
            this.tx_cuit.ReadOnly = true;
            this.tx_cuit.Size = new System.Drawing.Size(175, 22);
            this.tx_cuit.TabIndex = 5;
            // 
            // tx_nombre
            // 
            this.tx_nombre.Location = new System.Drawing.Point(108, 41);
            this.tx_nombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tx_nombre.Name = "tx_nombre";
            this.tx_nombre.Size = new System.Drawing.Size(175, 22);
            this.tx_nombre.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(329, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Rubro:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(329, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Direccion:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cuit:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // btn_atras
            // 
            this.btn_atras.Location = new System.Drawing.Point(17, 286);
            this.btn_atras.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_atras.Name = "btn_atras";
            this.btn_atras.Size = new System.Drawing.Size(97, 36);
            this.btn_atras.TabIndex = 9;
            this.btn_atras.Text = "Atras";
            this.btn_atras.UseVisualStyleBackColor = true;
            this.btn_atras.Click += new System.EventHandler(this.btn_atras_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ModificacionEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 342);
            this.Controls.Add(this.btn_atras);
            this.Controls.Add(this.grupo_empresa);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ModificacionEmpresa";
            this.Text = "Modificacion de empresa";
            this.grupo_empresa.ResumeLayout(false);
            this.grupo_empresa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grupo_empresa;
        private System.Windows.Forms.Button btn_modificar_empresa;
        private System.Windows.Forms.ComboBox combo_rubros;
        private System.Windows.Forms.TextBox tx_direccion;
        private System.Windows.Forms.TextBox tx_cuit;
        private System.Windows.Forms.TextBox tx_nombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_atras;
        private System.Windows.Forms.CheckBox check_box_habilitacion;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}