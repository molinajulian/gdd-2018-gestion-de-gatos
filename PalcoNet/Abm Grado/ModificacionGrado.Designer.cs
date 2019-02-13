namespace PalcoNet.AbmGrado
{
    partial class ModificacionGrado
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
            this.lbl_nombre_rol = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnAltaGrado = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGrado = new System.Windows.Forms.TextBox();
            this.group_alta_grado = new System.Windows.Forms.GroupBox();
            this.checkHabilitado = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.epProvider)).BeginInit();
            this.group_alta_grado.SuspendLayout();
            this.SuspendLayout();
            // 
            // epProvider
            // 
            this.epProvider.ContainerControl = this;
            // 
            // lbl_nombre_rol
            // 
            this.lbl_nombre_rol.AutoSize = true;
            this.lbl_nombre_rol.Location = new System.Drawing.Point(33, 30);
            this.lbl_nombre_rol.Name = "lbl_nombre_rol";
            this.lbl_nombre_rol.Size = new System.Drawing.Size(63, 13);
            this.lbl_nombre_rol.TabIndex = 0;
            this.lbl_nombre_rol.Text = "Descripción";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(115, 23);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // btnAltaGrado
            // 
            this.btnAltaGrado.Location = new System.Drawing.Point(287, 39);
            this.btnAltaGrado.Name = "btnAltaGrado";
            this.btnAltaGrado.Size = new System.Drawing.Size(97, 39);
            this.btnAltaGrado.TabIndex = 0;
            this.btnAltaGrado.Text = "Modificar";
            this.btnAltaGrado.UseVisualStyleBackColor = true;
            this.btnAltaGrado.Click += new System.EventHandler(this.btn_alta_grado_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Grado Comisión (*)";
            // 
            // txtGrado
            // 
            this.txtGrado.Location = new System.Drawing.Point(115, 78);
            this.txtGrado.Name = "txtGrado";
            this.txtGrado.Size = new System.Drawing.Size(100, 20);
            this.txtGrado.TabIndex = 4;
            this.txtGrado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGrado_KeyPress);
            // 
            // group_alta_grado
            // 
            this.group_alta_grado.BackColor = System.Drawing.Color.White;
            this.group_alta_grado.Controls.Add(this.checkHabilitado);
            this.group_alta_grado.Controls.Add(this.label2);
            this.group_alta_grado.Controls.Add(this.txtGrado);
            this.group_alta_grado.Controls.Add(this.label1);
            this.group_alta_grado.Controls.Add(this.btnAltaGrado);
            this.group_alta_grado.Controls.Add(this.txtNombre);
            this.group_alta_grado.Controls.Add(this.lbl_nombre_rol);
            this.group_alta_grado.Location = new System.Drawing.Point(12, 79);
            this.group_alta_grado.Name = "group_alta_grado";
            this.group_alta_grado.Size = new System.Drawing.Size(412, 157);
            this.group_alta_grado.TabIndex = 3;
            this.group_alta_grado.TabStop = false;
            this.group_alta_grado.Text = "Datos del grado";
            // 
            // checkHabilitado
            // 
            this.checkHabilitado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkHabilitado.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.checkHabilitado.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.checkHabilitado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.checkHabilitado.Location = new System.Drawing.Point(255, 108);
            this.checkHabilitado.Name = "checkHabilitado";
            this.checkHabilitado.Size = new System.Drawing.Size(86, 22);
            this.checkHabilitado.TabIndex = 21;
            this.checkHabilitado.Text = "Habilitado";
            this.checkHabilitado.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "* Número en porcentaje";
            // 
            // ModificacionGrado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 262);
            this.Controls.Add(this.group_alta_grado);
            this.Name = "ModificacionGrado";
            this.Text = "Alta grado de publicación";
            ((System.ComponentModel.ISupportInitialize)(this.epProvider)).EndInit();
            this.group_alta_grado.ResumeLayout(false);
            this.group_alta_grado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider epProvider;
        private System.Windows.Forms.GroupBox group_alta_grado;
        private System.Windows.Forms.TextBox txtGrado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAltaGrado;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lbl_nombre_rol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkHabilitado;
    }
}