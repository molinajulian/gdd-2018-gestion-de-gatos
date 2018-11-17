namespace PagoAgilFrba.AbmRol
{
    partial class ModificacionRol
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
            this.group_rol = new System.Windows.Forms.GroupBox();
            this.check_inhabilitado = new System.Windows.Forms.CheckBox();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.data_funcionalidades_rol = new System.Windows.Forms.DataGridView();
            this.btn_volver = new System.Windows.Forms.Button();
            this.epProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.group_rol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_funcionalidades_rol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_nombre_rol
            // 
            this.lbl_nombre_rol.AutoSize = true;
            this.lbl_nombre_rol.Location = new System.Drawing.Point(123, 25);
            this.lbl_nombre_rol.Name = "lbl_nombre_rol";
            this.lbl_nombre_rol.Size = new System.Drawing.Size(47, 13);
            this.lbl_nombre_rol.TabIndex = 0;
            this.lbl_nombre_rol.Text = "Nombre:";
            // 
            // tx_nombre_rol
            // 
            this.tx_nombre_rol.Location = new System.Drawing.Point(176, 22);
            this.tx_nombre_rol.Name = "tx_nombre_rol";
            this.tx_nombre_rol.Size = new System.Drawing.Size(100, 20);
            this.tx_nombre_rol.TabIndex = 1;
            // 
            // group_rol
            // 
            this.group_rol.BackColor = System.Drawing.Color.White;
            this.group_rol.Controls.Add(this.check_inhabilitado);
            this.group_rol.Controls.Add(this.btn_modificar);
            this.group_rol.Controls.Add(this.tx_nombre_rol);
            this.group_rol.Controls.Add(this.data_funcionalidades_rol);
            this.group_rol.Controls.Add(this.lbl_nombre_rol);
            this.group_rol.Location = new System.Drawing.Point(26, 79);
            this.group_rol.Name = "group_rol";
            this.group_rol.Size = new System.Drawing.Size(555, 272);
            this.group_rol.TabIndex = 2;
            this.group_rol.TabStop = false;
            this.group_rol.Text = "Datos del rol";
            // 
            // check_inhabilitado
            // 
            this.check_inhabilitado.AutoSize = true;
            this.check_inhabilitado.Location = new System.Drawing.Point(392, 25);
            this.check_inhabilitado.Name = "check_inhabilitado";
            this.check_inhabilitado.Size = new System.Drawing.Size(80, 17);
            this.check_inhabilitado.TabIndex = 2;
            this.check_inhabilitado.Text = "Inhabilitado";
            this.check_inhabilitado.UseVisualStyleBackColor = true;
            // 
            // btn_modificar
            // 
            this.btn_modificar.Location = new System.Drawing.Point(250, 233);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(75, 23);
            this.btn_modificar.TabIndex = 1;
            this.btn_modificar.Text = "Modificar";
            this.btn_modificar.UseVisualStyleBackColor = true;
            this.btn_modificar.Click += new System.EventHandler(this.btn_modificar_Click);
            // 
            // data_funcionalidades_rol
            // 
            this.data_funcionalidades_rol.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.data_funcionalidades_rol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_funcionalidades_rol.Location = new System.Drawing.Point(21, 60);
            this.data_funcionalidades_rol.Name = "data_funcionalidades_rol";
            this.data_funcionalidades_rol.Size = new System.Drawing.Size(512, 156);
            this.data_funcionalidades_rol.TabIndex = 0;
            // 
            // btn_volver
            // 
            this.btn_volver.Location = new System.Drawing.Point(47, 358);
            this.btn_volver.Name = "btn_volver";
            this.btn_volver.Size = new System.Drawing.Size(75, 23);
            this.btn_volver.TabIndex = 3;
            this.btn_volver.Text = "Volver";
            this.btn_volver.UseVisualStyleBackColor = true;
            this.btn_volver.Click += new System.EventHandler(this.btn_volver_Click);
            // 
            // epProvider
            // 
            this.epProvider.ContainerControl = this;
            // 
            // ModificacionRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 414);
            this.Controls.Add(this.btn_volver);
            this.Controls.Add(this.group_rol);
            this.Name = "ModificacionRol";
            this.Text = "ModificacionRol";
            this.group_rol.ResumeLayout(false);
            this.group_rol.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_funcionalidades_rol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_nombre_rol;
        private System.Windows.Forms.TextBox tx_nombre_rol;
        private System.Windows.Forms.GroupBox group_rol;
        private System.Windows.Forms.DataGridView data_funcionalidades_rol;
        private System.Windows.Forms.Button btn_modificar;
        private System.Windows.Forms.Button btn_volver;
        private System.Windows.Forms.CheckBox check_inhabilitado;
        private System.Windows.Forms.ErrorProvider epProvider;
    }
}