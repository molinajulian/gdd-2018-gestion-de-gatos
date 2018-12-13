namespace PalcoNet.GenerarPublicacion
{
    partial class AltaSector
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.data_listado_funcionalidades = new System.Windows.Forms.DataGridView();
            this.btn_alta_rol = new System.Windows.Forms.Button();
            this.tx_nombre_rol = new System.Windows.Forms.TextBox();
            this.lbl_nombre_rol = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.group_alta_rol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_listado_funcionalidades)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_volver
            // 
            this.btn_volver.Location = new System.Drawing.Point(458, 428);
            this.btn_volver.Name = "btn_volver";
            this.btn_volver.Size = new System.Drawing.Size(83, 44);
            this.btn_volver.TabIndex = 6;
            this.btn_volver.Text = "Volver";
            this.btn_volver.UseVisualStyleBackColor = true;
            // 
            // group_alta_rol
            // 
            this.group_alta_rol.BackColor = System.Drawing.Color.White;
            this.group_alta_rol.Controls.Add(this.textBox3);
            this.group_alta_rol.Controls.Add(this.label3);
            this.group_alta_rol.Controls.Add(this.textBox2);
            this.group_alta_rol.Controls.Add(this.label2);
            this.group_alta_rol.Controls.Add(this.textBox1);
            this.group_alta_rol.Controls.Add(this.label1);
            this.group_alta_rol.Controls.Add(this.data_listado_funcionalidades);
            this.group_alta_rol.Controls.Add(this.btn_alta_rol);
            this.group_alta_rol.Controls.Add(this.tx_nombre_rol);
            this.group_alta_rol.Controls.Add(this.lbl_nombre_rol);
            this.group_alta_rol.Location = new System.Drawing.Point(25, 88);
            this.group_alta_rol.Name = "group_alta_rol";
            this.group_alta_rol.Size = new System.Drawing.Size(538, 334);
            this.group_alta_rol.TabIndex = 5;
            this.group_alta_rol.TabStop = false;
            this.group_alta_rol.Text = "Datos del sector";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(379, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(60, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(269, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Precio por asiento";
            // 
            // data_listado_funcionalidades
            // 
            this.data_listado_funcionalidades.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.data_listado_funcionalidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_listado_funcionalidades.Location = new System.Drawing.Point(21, 106);
            this.data_listado_funcionalidades.Name = "data_listado_funcionalidades";
            this.data_listado_funcionalidades.Size = new System.Drawing.Size(495, 150);
            this.data_listado_funcionalidades.TabIndex = 2;
            // 
            // btn_alta_rol
            // 
            this.btn_alta_rol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_alta_rol.Location = new System.Drawing.Point(221, 262);
            this.btn_alta_rol.Name = "btn_alta_rol";
            this.btn_alta_rol.Size = new System.Drawing.Size(97, 50);
            this.btn_alta_rol.TabIndex = 0;
            this.btn_alta_rol.Text = "Dar de alta sector";
            this.btn_alta_rol.UseVisualStyleBackColor = true;
            this.btn_alta_rol.Click += new System.EventHandler(this.btn_alta_rol_Click);
            // 
            // tx_nombre_rol
            // 
            this.tx_nombre_rol.Location = new System.Drawing.Point(115, 23);
            this.tx_nombre_rol.Name = "tx_nombre_rol";
            this.tx_nombre_rol.Size = new System.Drawing.Size(135, 20);
            this.tx_nombre_rol.TabIndex = 1;
            // 
            // lbl_nombre_rol
            // 
            this.lbl_nombre_rol.AutoSize = true;
            this.lbl_nombre_rol.Location = new System.Drawing.Point(62, 26);
            this.lbl_nombre_rol.Name = "lbl_nombre_rol";
            this.lbl_nombre_rol.Size = new System.Drawing.Size(40, 13);
            this.lbl_nombre_rol.TabIndex = 0;
            this.lbl_nombre_rol.Text = "Detalle";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(156, 58);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(48, 20);
            this.textBox2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cantidad de Filas";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(379, 61);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(48, 20);
            this.textBox3.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(269, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Cantidad de Asientos";
            // 
            // AltaSector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 484);
            this.Controls.Add(this.btn_volver);
            this.Controls.Add(this.group_alta_rol);
            this.Name = "AltaSector";
            this.Text = "Alta Sector";
            this.group_alta_rol.ResumeLayout(false);
            this.group_alta_rol.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_listado_funcionalidades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_volver;
        private System.Windows.Forms.GroupBox group_alta_rol;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView data_listado_funcionalidades;
        private System.Windows.Forms.Button btn_alta_rol;
        private System.Windows.Forms.TextBox tx_nombre_rol;
        private System.Windows.Forms.Label lbl_nombre_rol;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
    }
}