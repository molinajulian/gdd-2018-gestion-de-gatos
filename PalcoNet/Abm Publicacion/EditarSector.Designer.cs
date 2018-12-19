namespace PalcoNet.AbmPublicaciones
{
    partial class EditarSector
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
            this.btn_volver = new System.Windows.Forms.Button();
            this.group_alta_rol = new System.Windows.Forms.GroupBox();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAsientos = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFilas = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.group_alta_rol.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_volver
            // 
            this.btn_volver.Location = new System.Drawing.Point(34, 215);
            this.btn_volver.Name = "btn_volver";
            this.btn_volver.Size = new System.Drawing.Size(83, 44);
            this.btn_volver.TabIndex = 10;
            this.btn_volver.Text = "Volver";
            this.btn_volver.UseVisualStyleBackColor = true;
            this.btn_volver.Click += new System.EventHandler(this.btn_volver_Click);
            // 
            // group_alta_rol
            // 
            this.group_alta_rol.BackColor = System.Drawing.Color.White;
            this.group_alta_rol.Controls.Add(this.cmbTipo);
            this.group_alta_rol.Controls.Add(this.label4);
            this.group_alta_rol.Controls.Add(this.label1);
            this.group_alta_rol.Controls.Add(this.txtAsientos);
            this.group_alta_rol.Controls.Add(this.txtPrecio);
            this.group_alta_rol.Controls.Add(this.label3);
            this.group_alta_rol.Controls.Add(this.txtFilas);
            this.group_alta_rol.Controls.Add(this.label2);
            this.group_alta_rol.Location = new System.Drawing.Point(23, 73);
            this.group_alta_rol.Name = "group_alta_rol";
            this.group_alta_rol.Size = new System.Drawing.Size(538, 104);
            this.group_alta_rol.TabIndex = 9;
            this.group_alta_rol.TabStop = false;
            this.group_alta_rol.Text = "Datos del sector";
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(347, 20);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(139, 21);
            this.cmbTipo.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(251, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tipo Ubicaciones";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(251, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Precio por asiento";
            // 
            // txtAsientos
            // 
            this.txtAsientos.Location = new System.Drawing.Point(133, 62);
            this.txtAsientos.Name = "txtAsientos";
            this.txtAsientos.Size = new System.Drawing.Size(48, 20);
            this.txtAsientos.TabIndex = 8;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(349, 59);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(65, 20);
            this.txtPrecio.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Cantidad de Asientos";
            // 
            // txtFilas
            // 
            this.txtFilas.Location = new System.Drawing.Point(133, 24);
            this.txtFilas.Name = "txtFilas";
            this.txtFilas.Size = new System.Drawing.Size(48, 20);
            this.txtFilas.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cantidad de Filas";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(216, 183);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 44);
            this.button1.TabIndex = 11;
            this.button1.Text = "Confirmar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EditarSector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 271);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_volver);
            this.Controls.Add(this.group_alta_rol);
            this.Name = "EditarSector";
            this.Text = "Editar Sector";
            this.group_alta_rol.ResumeLayout(false);
            this.group_alta_rol.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_volver;
        private System.Windows.Forms.GroupBox group_alta_rol;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAsientos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFilas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}