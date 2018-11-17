namespace PagoAgilFrba.AbmRol
{
    partial class AltaRol
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
            this.lbl_nombre_rol = new System.Windows.Forms.Label();
            this.tx_nombre_rol = new System.Windows.Forms.TextBox();
            this.group_alta_rol = new System.Windows.Forms.GroupBox();
            this.data_listado_funcionalidades = new System.Windows.Forms.DataGridView();
            this.btn_alta_rol = new System.Windows.Forms.Button();
            this.btn_volver = new System.Windows.Forms.Button();
            this.epProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.group_alta_rol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_listado_funcionalidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_nombre_rol
            // 
            this.lbl_nombre_rol.AutoSize = true;
            this.lbl_nombre_rol.Location = new System.Drawing.Point(134, 22);
            this.lbl_nombre_rol.Name = "lbl_nombre_rol";
            this.lbl_nombre_rol.Size = new System.Drawing.Size(47, 13);
            this.lbl_nombre_rol.TabIndex = 0;
            this.lbl_nombre_rol.Text = "Nombre:";
            // 
            // tx_nombre_rol
            // 
            this.tx_nombre_rol.Location = new System.Drawing.Point(187, 19);
            this.tx_nombre_rol.Name = "tx_nombre_rol";
            this.tx_nombre_rol.Size = new System.Drawing.Size(100, 20);
            this.tx_nombre_rol.TabIndex = 1;
            // 
            // group_alta_rol
            // 
            this.group_alta_rol.BackColor = System.Drawing.Color.White;
            this.group_alta_rol.Controls.Add(this.label1);
            this.group_alta_rol.Controls.Add(this.data_listado_funcionalidades);
            this.group_alta_rol.Controls.Add(this.btn_alta_rol);
            this.group_alta_rol.Controls.Add(this.tx_nombre_rol);
            this.group_alta_rol.Controls.Add(this.lbl_nombre_rol);
            this.group_alta_rol.Location = new System.Drawing.Point(36, 76);
            this.group_alta_rol.Name = "group_alta_rol";
            this.group_alta_rol.Size = new System.Drawing.Size(538, 273);
            this.group_alta_rol.TabIndex = 3;
            this.group_alta_rol.TabStop = false;
            this.group_alta_rol.Text = "Datos del rol";
            // 
            // data_listado_funcionalidades
            // 
            this.data_listado_funcionalidades.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.data_listado_funcionalidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_listado_funcionalidades.Location = new System.Drawing.Point(24, 72);
            this.data_listado_funcionalidades.Name = "data_listado_funcionalidades";
            this.data_listado_funcionalidades.Size = new System.Drawing.Size(495, 150);
            this.data_listado_funcionalidades.TabIndex = 2;
            // 
            // btn_alta_rol
            // 
            this.btn_alta_rol.Location = new System.Drawing.Point(225, 228);
            this.btn_alta_rol.Name = "btn_alta_rol";
            this.btn_alta_rol.Size = new System.Drawing.Size(94, 39);
            this.btn_alta_rol.TabIndex = 0;
            this.btn_alta_rol.Text = "Dar de alta rol";
            this.btn_alta_rol.UseVisualStyleBackColor = true;
            this.btn_alta_rol.Click += new System.EventHandler(this.btn_alta_rol_Click);
            // 
            // btn_volver
            // 
            this.btn_volver.Location = new System.Drawing.Point(36, 358);
            this.btn_volver.Name = "btn_volver";
            this.btn_volver.Size = new System.Drawing.Size(83, 28);
            this.btn_volver.TabIndex = 4;
            this.btn_volver.Text = "Volver";
            this.btn_volver.UseVisualStyleBackColor = true;
            this.btn_volver.Click += new System.EventHandler(this.btn_volver_Click);
            // 
            // epProvider
            // 
            this.epProvider.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Funcionalidades";
            // 
            // AltaRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 406);
            this.Controls.Add(this.btn_volver);
            this.Controls.Add(this.group_alta_rol);
            this.Name = "AltaRol";
            this.Text = "AltaRol";
            this.group_alta_rol.ResumeLayout(false);
            this.group_alta_rol.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_listado_funcionalidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_nombre_rol;
        private System.Windows.Forms.TextBox tx_nombre_rol;
        private System.Windows.Forms.GroupBox group_alta_rol;
        private System.Windows.Forms.Button btn_alta_rol;
        private System.Windows.Forms.Button btn_volver;
        private System.Windows.Forms.ErrorProvider epProvider;
        private System.Windows.Forms.DataGridView data_listado_funcionalidades;
        private System.Windows.Forms.Label label1;
    }
}