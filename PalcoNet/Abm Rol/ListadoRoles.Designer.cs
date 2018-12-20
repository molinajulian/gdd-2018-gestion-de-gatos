namespace PalcoNet.AbmRol
{
    partial class ListadoRoles
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
            this.tx_nombre_rol = new System.Windows.Forms.TextBox();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.group_filtros_rol = new System.Windows.Forms.GroupBox();
            this.data_listado_roles = new System.Windows.Forms.DataGridView();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.buttonHabilitar = new System.Windows.Forms.Button();
            this.buttonModificar = new System.Windows.Forms.Button();
            this.group_filtros_rol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_listado_roles)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_nombre_rol
            // 
            this.lbl_nombre_rol.AutoSize = true;
            this.lbl_nombre_rol.Location = new System.Drawing.Point(6, 39);
            this.lbl_nombre_rol.Name = "lbl_nombre_rol";
            this.lbl_nombre_rol.Size = new System.Drawing.Size(47, 13);
            this.lbl_nombre_rol.TabIndex = 0;
            this.lbl_nombre_rol.Text = "Nombre:";
            // 
            // tx_nombre_rol
            // 
            this.tx_nombre_rol.Location = new System.Drawing.Point(59, 36);
            this.tx_nombre_rol.Name = "tx_nombre_rol";
            this.tx_nombre_rol.Size = new System.Drawing.Size(66, 20);
            this.tx_nombre_rol.TabIndex = 1;
            // 
            // btn_buscar
            // 
            this.btn_buscar.Location = new System.Drawing.Point(149, 31);
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
            this.group_filtros_rol.Controls.Add(this.tx_nombre_rol);
            this.group_filtros_rol.Controls.Add(this.btn_buscar);
            this.group_filtros_rol.Location = new System.Drawing.Point(28, 82);
            this.group_filtros_rol.Name = "group_filtros_rol";
            this.group_filtros_rol.Size = new System.Drawing.Size(230, 75);
            this.group_filtros_rol.TabIndex = 3;
            this.group_filtros_rol.TabStop = false;
            this.group_filtros_rol.Text = "Filtros de búsqueda";
            // 
            // data_listado_roles
            // 
            this.data_listado_roles.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.data_listado_roles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_listado_roles.Location = new System.Drawing.Point(28, 163);
            this.data_listado_roles.Name = "data_listado_roles";
            this.data_listado_roles.ReadOnly = true;
            this.data_listado_roles.Size = new System.Drawing.Size(230, 150);
            this.data_listado_roles.TabIndex = 4;
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Location = new System.Drawing.Point(177, 318);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(81, 28);
            this.btn_limpiar.TabIndex = 6;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.UseVisualStyleBackColor = true;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // buttonHabilitar
            // 
            this.buttonHabilitar.Location = new System.Drawing.Point(28, 319);
            this.buttonHabilitar.Name = "buttonHabilitar";
            this.buttonHabilitar.Size = new System.Drawing.Size(125, 29);
            this.buttonHabilitar.TabIndex = 7;
            this.buttonHabilitar.Text = "Habilitar/Deshabilitar";
            this.buttonHabilitar.UseVisualStyleBackColor = true;
            this.buttonHabilitar.Click += new System.EventHandler(this.buttonHabilitar_Click);
            // 
            // buttonModificar
            // 
            this.buttonModificar.Location = new System.Drawing.Point(28, 318);
            this.buttonModificar.Name = "buttonModificar";
            this.buttonModificar.Size = new System.Drawing.Size(80, 29);
            this.buttonModificar.TabIndex = 8;
            this.buttonModificar.Text = "Modificar";
            this.buttonModificar.UseVisualStyleBackColor = true;
            this.buttonModificar.Click += new System.EventHandler(this.buttonModificar_Click);
            // 
            // ListadoRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 375);
            this.Controls.Add(this.buttonModificar);
            this.Controls.Add(this.buttonHabilitar);
            this.Controls.Add(this.btn_limpiar);
            this.Controls.Add(this.data_listado_roles);
            this.Controls.Add(this.group_filtros_rol);
            this.Name = "ListadoRoles";
            this.Text = "ListadoRoles";
            this.group_filtros_rol.ResumeLayout(false);
            this.group_filtros_rol.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_listado_roles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_nombre_rol;
        private System.Windows.Forms.TextBox tx_nombre_rol;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.GroupBox group_filtros_rol;
        private System.Windows.Forms.DataGridView data_listado_roles;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.Button buttonHabilitar;
        private System.Windows.Forms.Button buttonModificar;
    }
}