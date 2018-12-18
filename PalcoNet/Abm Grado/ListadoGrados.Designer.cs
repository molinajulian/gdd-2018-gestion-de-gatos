namespace PalcoNet.AbmGrado
{
    partial class ListadoGrados
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
            this.lbl_nombre_rol = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.group_filtros_rol = new System.Windows.Forms.GroupBox();
            this.data_listado_grados = new System.Windows.Forms.DataGridView();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.buttonHabilitar = new System.Windows.Forms.Button();
            this.group_filtros_rol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_listado_grados)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_nombre_rol
            // 
            this.lbl_nombre_rol.AutoSize = true;
            this.lbl_nombre_rol.Location = new System.Drawing.Point(6, 31);
            this.lbl_nombre_rol.Name = "lbl_nombre_rol";
            this.lbl_nombre_rol.Size = new System.Drawing.Size(63, 13);
            this.lbl_nombre_rol.TabIndex = 0;
            this.lbl_nombre_rol.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(80, 28);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(100, 20);
            this.txtDescripcion.TabIndex = 1;
            // 
            // btn_buscar
            // 
            this.btn_buscar.Location = new System.Drawing.Point(210, 23);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(81, 29);
            this.btn_buscar.TabIndex = 2;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // group_filtros_rol
            // 
            this.group_filtros_rol.BackColor = System.Drawing.Color.White;
            this.group_filtros_rol.Controls.Add(this.lbl_nombre_rol);
            this.group_filtros_rol.Controls.Add(this.txtDescripcion);
            this.group_filtros_rol.Controls.Add(this.btn_buscar);
            this.group_filtros_rol.Location = new System.Drawing.Point(28, 82);
            this.group_filtros_rol.Name = "group_filtros_rol";
            this.group_filtros_rol.Size = new System.Drawing.Size(324, 75);
            this.group_filtros_rol.TabIndex = 3;
            this.group_filtros_rol.TabStop = false;
            this.group_filtros_rol.Text = "Filtros de búsqueda";
            // 
            // data_listado_grados
            // 
            this.data_listado_grados.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.data_listado_grados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_listado_grados.Location = new System.Drawing.Point(28, 163);
            this.data_listado_grados.Name = "data_listado_grados";
            this.data_listado_grados.ReadOnly = true;
            this.data_listado_grados.Size = new System.Drawing.Size(324, 150);
            this.data_listado_grados.TabIndex = 4;
            this.data_listado_grados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_listado_grados_CellContentClick);
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Location = new System.Drawing.Point(238, 319);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(81, 28);
            this.btn_limpiar.TabIndex = 6;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.UseVisualStyleBackColor = true;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // btn_modificar
            // 
            this.btn_modificar.Location = new System.Drawing.Point(75, 319);
            this.btn_modificar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(74, 28);
            this.btn_modificar.TabIndex = 28;
            this.btn_modificar.Text = "Modificar";
            this.btn_modificar.UseVisualStyleBackColor = true;
            this.btn_modificar.Click += new System.EventHandler(this.btn_modificar_Click);
            // 
            // buttonHabilitar
            // 
            this.buttonHabilitar.Location = new System.Drawing.Point(50, 319);
            this.buttonHabilitar.Margin = new System.Windows.Forms.Padding(2);
            this.buttonHabilitar.Name = "buttonHabilitar";
            this.buttonHabilitar.Size = new System.Drawing.Size(127, 28);
            this.buttonHabilitar.TabIndex = 29;
            this.buttonHabilitar.Text = "Habilitar/Inhabilitar";
            this.buttonHabilitar.UseVisualStyleBackColor = true;
            this.buttonHabilitar.Click += new System.EventHandler(this.buttonHabilitar_Click);
            // 
            // ListadoGrados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 375);
            this.Controls.Add(this.buttonHabilitar);
            this.Controls.Add(this.btn_modificar);
            this.Controls.Add(this.btn_limpiar);
            this.Controls.Add(this.data_listado_grados);
            this.Controls.Add(this.group_filtros_rol);
            this.Name = "ListadoGrados";
            this.Text = "ListadoGrados";
            this.group_filtros_rol.ResumeLayout(false);
            this.group_filtros_rol.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_listado_grados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_nombre_rol;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.GroupBox group_filtros_rol;
        private System.Windows.Forms.DataGridView data_listado_grados;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.Button btn_modificar;
        private System.Windows.Forms.Button buttonHabilitar;
    }
}