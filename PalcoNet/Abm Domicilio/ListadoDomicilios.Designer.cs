namespace PalcoNet.AbmDomicilio
{
    partial class ListadoDomicilios
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
            this.btn_buscar = new System.Windows.Forms.Button();
            this.group_filtros_domicilio = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txNumero = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txCalle = new System.Windows.Forms.TextBox();
            this.data_listado_domicilios = new System.Windows.Forms.DataGridView();
            this.btn_volver = new System.Windows.Forms.Button();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.group_filtros_domicilio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_listado_domicilios)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_buscar
            // 
            this.btn_buscar.Location = new System.Drawing.Point(433, 23);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(81, 29);
            this.btn_buscar.TabIndex = 2;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // group_filtros_domicilio
            // 
            this.group_filtros_domicilio.BackColor = System.Drawing.Color.White;
            this.group_filtros_domicilio.Controls.Add(this.label11);
            this.group_filtros_domicilio.Controls.Add(this.txNumero);
            this.group_filtros_domicilio.Controls.Add(this.label3);
            this.group_filtros_domicilio.Controls.Add(this.txCalle);
            this.group_filtros_domicilio.Controls.Add(this.btn_buscar);
            this.group_filtros_domicilio.Location = new System.Drawing.Point(28, 82);
            this.group_filtros_domicilio.Name = "group_filtros_domicilio";
            this.group_filtros_domicilio.Size = new System.Drawing.Size(545, 75);
            this.group_filtros_domicilio.TabIndex = 3;
            this.group_filtros_domicilio.TabStop = false;
            this.group_filtros_domicilio.Text = "Filtros de búsqueda";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(270, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 56;
            this.label11.Text = "Número";
            // 
            // txNumero
            // 
            this.txNumero.Location = new System.Drawing.Point(320, 27);
            this.txNumero.Name = "txNumero";
            this.txNumero.Size = new System.Drawing.Size(72, 20);
            this.txNumero.TabIndex = 54;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "Calle";
            // 
            // txCalle
            // 
            this.txCalle.Location = new System.Drawing.Point(80, 27);
            this.txCalle.Name = "txCalle";
            this.txCalle.Size = new System.Drawing.Size(143, 20);
            this.txCalle.TabIndex = 53;
            // 
            // data_listado_domicilios
            // 
            this.data_listado_domicilios.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.data_listado_domicilios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_listado_domicilios.Location = new System.Drawing.Point(28, 163);
            this.data_listado_domicilios.Name = "data_listado_domicilios";
            this.data_listado_domicilios.ReadOnly = true;
            this.data_listado_domicilios.Size = new System.Drawing.Size(545, 150);
            this.data_listado_domicilios.TabIndex = 4;
            // 
            // btn_volver
            // 
            this.btn_volver.Location = new System.Drawing.Point(28, 319);
            this.btn_volver.Name = "btn_volver";
            this.btn_volver.Size = new System.Drawing.Size(80, 29);
            this.btn_volver.TabIndex = 5;
            this.btn_volver.Text = "Volver";
            this.btn_volver.UseVisualStyleBackColor = true;
            this.btn_volver.Click += new System.EventHandler(this.btn_volver_Click);
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Location = new System.Drawing.Point(492, 318);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(81, 28);
            this.btn_limpiar.TabIndex = 6;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.UseVisualStyleBackColor = true;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.Enabled = false;
            this.btn_eliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_eliminar.Location = new System.Drawing.Point(376, 318);
            this.btn_eliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(83, 28);
            this.btn_eliminar.TabIndex = 16;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = true;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btn_agregar
            // 
            this.btn_agregar.Enabled = false;
            this.btn_agregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_agregar.Location = new System.Drawing.Point(152, 318);
            this.btn_agregar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(74, 28);
            this.btn_agregar.TabIndex = 15;
            this.btn_agregar.Text = "Nuevo";
            this.btn_agregar.UseVisualStyleBackColor = true;
            this.btn_agregar.Click += new System.EventHandler(this.btn_editar_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(268, 318);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 28);
            this.button1.TabIndex = 17;
            this.button1.Text = "Editar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(592, 204);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 66);
            this.button2.TabIndex = 18;
            this.button2.Text = "Seleccionar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ListadoDomicilios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 377);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_eliminar);
            this.Controls.Add(this.btn_agregar);
            this.Controls.Add(this.btn_limpiar);
            this.Controls.Add(this.btn_volver);
            this.Controls.Add(this.data_listado_domicilios);
            this.Controls.Add(this.group_filtros_domicilio);
            this.Name = "ListadoDomicilios";
            this.Text = "ListadoDomicilios";
            this.group_filtros_domicilio.ResumeLayout(false);
            this.group_filtros_domicilio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_listado_domicilios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.GroupBox group_filtros_domicilio;
        private System.Windows.Forms.DataGridView data_listado_domicilios;
        private System.Windows.Forms.Button btn_volver;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txNumero;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txCalle;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.Button btn_agregar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}