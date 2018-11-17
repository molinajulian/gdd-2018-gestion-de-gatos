namespace PagoAgilFrba.AbmEmpresa
{
    partial class ListadoEmpresas
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
            this.data_empresas = new System.Windows.Forms.DataGridView();
            this.grupo_filtros = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tx_verificador = new System.Windows.Forms.TextBox();
            this.tx_tipo = new System.Windows.Forms.TextBox();
            this.combo_rubros = new System.Windows.Forms.ComboBox();
            this.tx_numero_cuit = new System.Windows.Forms.TextBox();
            this.tx_nombre = new System.Windows.Forms.TextBox();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_atras = new System.Windows.Forms.Button();
            this.btn_limpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.data_empresas)).BeginInit();
            this.grupo_filtros.SuspendLayout();
            this.SuspendLayout();
            // 
            // data_empresas
            // 
            this.data_empresas.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.data_empresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_empresas.Location = new System.Drawing.Point(13, 249);
            this.data_empresas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.data_empresas.Name = "data_empresas";
            this.data_empresas.ReadOnly = true;
            this.data_empresas.RowTemplate.Height = 24;
            this.data_empresas.Size = new System.Drawing.Size(834, 279);
            this.data_empresas.TabIndex = 0;
            this.data_empresas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_empresas_CellClick);
            // 
            // grupo_filtros
            // 
            this.grupo_filtros.BackColor = System.Drawing.Color.White;
            this.grupo_filtros.Controls.Add(this.label4);
            this.grupo_filtros.Controls.Add(this.label6);
            this.grupo_filtros.Controls.Add(this.tx_verificador);
            this.grupo_filtros.Controls.Add(this.tx_tipo);
            this.grupo_filtros.Controls.Add(this.combo_rubros);
            this.grupo_filtros.Controls.Add(this.tx_numero_cuit);
            this.grupo_filtros.Controls.Add(this.tx_nombre);
            this.grupo_filtros.Controls.Add(this.btn_buscar);
            this.grupo_filtros.Controls.Add(this.label3);
            this.grupo_filtros.Controls.Add(this.label2);
            this.grupo_filtros.Controls.Add(this.label1);
            this.grupo_filtros.Location = new System.Drawing.Point(13, 107);
            this.grupo_filtros.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grupo_filtros.Name = "grupo_filtros";
            this.grupo_filtros.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grupo_filtros.Size = new System.Drawing.Size(834, 122);
            this.grupo_filtros.TabIndex = 1;
            this.grupo_filtros.TabStop = false;
            this.grupo_filtros.Text = "Filtros de Busqueda";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(748, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(615, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 17);
            this.label6.TabIndex = 20;
            this.label6.Text = "-";
            // 
            // tx_verificador
            // 
            this.tx_verificador.Location = new System.Drawing.Point(767, 45);
            this.tx_verificador.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tx_verificador.Name = "tx_verificador";
            this.tx_verificador.Size = new System.Drawing.Size(23, 22);
            this.tx_verificador.TabIndex = 19;
            // 
            // tx_tipo
            // 
            this.tx_tipo.Location = new System.Drawing.Point(572, 45);
            this.tx_tipo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tx_tipo.Name = "tx_tipo";
            this.tx_tipo.Size = new System.Drawing.Size(39, 22);
            this.tx_tipo.TabIndex = 18;
            
            // 
            // combo_rubros
            // 
            this.combo_rubros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_rubros.FormattingEnabled = true;
            this.combo_rubros.Location = new System.Drawing.Point(307, 42);
            this.combo_rubros.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.combo_rubros.Name = "combo_rubros";
            this.combo_rubros.Size = new System.Drawing.Size(193, 24);
            this.combo_rubros.TabIndex = 17;
            // 
            // tx_numero_cuit
            // 
            this.tx_numero_cuit.Location = new System.Drawing.Point(634, 44);
            this.tx_numero_cuit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tx_numero_cuit.Name = "tx_numero_cuit";
            this.tx_numero_cuit.Size = new System.Drawing.Size(108, 22);
            this.tx_numero_cuit.TabIndex = 16;
            // 
            // tx_nombre
            // 
            this.tx_nombre.Location = new System.Drawing.Point(75, 42);
            this.tx_nombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tx_nombre.Name = "tx_nombre";
            this.tx_nombre.Size = new System.Drawing.Size(156, 22);
            this.tx_nombre.TabIndex = 15;
            // 
            // btn_buscar
            // 
            this.btn_buscar.Location = new System.Drawing.Point(333, 84);
            this.btn_buscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(99, 34);
            this.btn_buscar.TabIndex = 14;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(249, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rubro:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(530, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cuit:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // btn_atras
            // 
            this.btn_atras.Location = new System.Drawing.Point(13, 534);
            this.btn_atras.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_atras.Name = "btn_atras";
            this.btn_atras.Size = new System.Drawing.Size(99, 34);
            this.btn_atras.TabIndex = 12;
            this.btn_atras.Text = "Atras";
            this.btn_atras.UseVisualStyleBackColor = true;
            this.btn_atras.Click += new System.EventHandler(this.btn_atras_Click);
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Location = new System.Drawing.Point(748, 534);
            this.btn_limpiar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(99, 34);
            this.btn_limpiar.TabIndex = 11;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.UseVisualStyleBackColor = true;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // ListadoEmpresas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 612);
            this.Controls.Add(this.btn_atras);
            this.Controls.Add(this.btn_limpiar);
            this.Controls.Add(this.grupo_filtros);
            this.Controls.Add(this.data_empresas);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ListadoEmpresas";
            this.Text = "Listado de Empresas";
            ((System.ComponentModel.ISupportInitialize)(this.data_empresas)).EndInit();
            this.grupo_filtros.ResumeLayout(false);
            this.grupo_filtros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView data_empresas;
        private System.Windows.Forms.GroupBox grupo_filtros;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_atras;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.ComboBox combo_rubros;
        private System.Windows.Forms.TextBox tx_numero_cuit;
        private System.Windows.Forms.TextBox tx_nombre;
        private System.Windows.Forms.TextBox tx_verificador;
        private System.Windows.Forms.TextBox tx_tipo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
    }
}