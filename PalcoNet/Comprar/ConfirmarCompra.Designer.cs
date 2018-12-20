namespace PalcoNet.Comprar
{
    partial class ConfirmarCompra
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
            this.epProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.group_alta_rol = new System.Windows.Forms.GroupBox();
            this.btn_agregar_tarjeta = new System.Windows.Forms.Button();
            this.data_ubicaciones = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_confirmar_compra = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.epProvider)).BeginInit();
            this.group_alta_rol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_ubicaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // epProvider
            // 
            this.epProvider.ContainerControl = this;
            // 
            // group_alta_rol
            // 
            this.group_alta_rol.BackColor = System.Drawing.Color.White;
            this.group_alta_rol.Controls.Add(this.btn_confirmar_compra);
            this.group_alta_rol.Controls.Add(this.btn_agregar_tarjeta);
            this.group_alta_rol.Controls.Add(this.data_ubicaciones);
            this.group_alta_rol.Controls.Add(this.comboBox1);
            this.group_alta_rol.Controls.Add(this.label1);
            this.group_alta_rol.Location = new System.Drawing.Point(23, 73);
            this.group_alta_rol.Name = "group_alta_rol";
            this.group_alta_rol.Size = new System.Drawing.Size(582, 359);
            this.group_alta_rol.TabIndex = 9;
            this.group_alta_rol.TabStop = false;
            this.group_alta_rol.Text = "Ubicaciones Elegidas";
            // 
            // btn_agregar_tarjeta
            // 
            this.btn_agregar_tarjeta.Location = new System.Drawing.Point(16, 298);
            this.btn_agregar_tarjeta.Name = "btn_agregar_tarjeta";
            this.btn_agregar_tarjeta.Size = new System.Drawing.Size(185, 41);
            this.btn_agregar_tarjeta.TabIndex = 14;
            this.btn_agregar_tarjeta.Text = "Agregar Nueva Tarjeta";
            this.btn_agregar_tarjeta.UseVisualStyleBackColor = true;
            this.btn_agregar_tarjeta.Click += new System.EventHandler(this.btn_agregar_tarjeta_Click);
            // 
            // data_ubicaciones
            // 
            this.data_ubicaciones.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.data_ubicaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_ubicaciones.Location = new System.Drawing.Point(6, 19);
            this.data_ubicaciones.Name = "data_ubicaciones";
            this.data_ubicaciones.ReadOnly = true;
            this.data_ubicaciones.Size = new System.Drawing.Size(570, 229);
            this.data_ubicaciones.TabIndex = 32;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(207, 263);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(369, 21);
            this.comboBox1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Seleccionar Tarjeta con la que abonar";
            // 
            // btn_confirmar_compra
            // 
            this.btn_confirmar_compra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_confirmar_compra.Location = new System.Drawing.Point(337, 293);
            this.btn_confirmar_compra.Name = "btn_confirmar_compra";
            this.btn_confirmar_compra.Size = new System.Drawing.Size(163, 46);
            this.btn_confirmar_compra.TabIndex = 11;
            this.btn_confirmar_compra.Text = "Confirmar Compra";
            this.btn_confirmar_compra.UseVisualStyleBackColor = true;
            this.btn_confirmar_compra.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // ConfirmarCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 444);
            this.Controls.Add(this.group_alta_rol);
            this.Name = "ConfirmarCompra";
            this.Text = "Comprar [Parte 3/3] - Confirmacion de Compra";
            ((System.ComponentModel.ISupportInitialize)(this.epProvider)).EndInit();
            this.group_alta_rol.ResumeLayout(false);
            this.group_alta_rol.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_ubicaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider epProvider;
        private System.Windows.Forms.GroupBox group_alta_rol;
        private System.Windows.Forms.Button btn_confirmar_compra;
        private System.Windows.Forms.DataGridView data_ubicaciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btn_agregar_tarjeta;
    }
}