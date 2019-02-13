namespace PalcoNet.Comprar
{
    partial class ElegirUbicaciones
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
            this.group_alta_rol = new System.Windows.Forms.GroupBox();
            this.data_listado_sectores = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvUbicacionesElegidas = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvUbicacionAElegir = new System.Windows.Forms.DataGridView();
            this.group_alta_rol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_listado_sectores)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUbicacionesElegidas)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUbicacionAElegir)).BeginInit();
            this.SuspendLayout();
            // 
            // group_alta_rol
            // 
            this.group_alta_rol.BackColor = System.Drawing.Color.White;
            this.group_alta_rol.Controls.Add(this.data_listado_sectores);
            this.group_alta_rol.Controls.Add(this.button1);
            this.group_alta_rol.Location = new System.Drawing.Point(23, 73);
            this.group_alta_rol.Name = "group_alta_rol";
            this.group_alta_rol.Size = new System.Drawing.Size(480, 342);
            this.group_alta_rol.TabIndex = 9;
            this.group_alta_rol.TabStop = false;
            this.group_alta_rol.Text = "Seleccion de sector y asientos";
            // 
            // data_listado_sectores
            // 
            this.data_listado_sectores.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.data_listado_sectores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_listado_sectores.Location = new System.Drawing.Point(17, 28);
            this.data_listado_sectores.Name = "data_listado_sectores";
            this.data_listado_sectores.Size = new System.Drawing.Size(448, 223);
            this.data_listado_sectores.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(102, 269);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(280, 43);
            this.button1.TabIndex = 11;
            this.button1.Text = "Seleccionar Sector";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.dgvUbicacionesElegidas);
            this.groupBox1.Location = new System.Drawing.Point(23, 421);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(861, 270);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ubicaciones Elegidas";
            // 
            // dgvUbicacionesElegidas
            // 
            this.dgvUbicacionesElegidas.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvUbicacionesElegidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUbicacionesElegidas.Location = new System.Drawing.Point(6, 19);
            this.dgvUbicacionesElegidas.Name = "dgvUbicacionesElegidas";
            this.dgvUbicacionesElegidas.Size = new System.Drawing.Size(844, 237);
            this.dgvUbicacionesElegidas.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(52, 269);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(280, 43);
            this.button2.TabIndex = 18;
            this.button2.Text = "Confirmar Asiento";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(525, 707);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(280, 43);
            this.button3.TabIndex = 19;
            this.button3.Text = "Elegir Medio de Pago";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.dgvUbicacionAElegir);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Location = new System.Drawing.Point(509, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(379, 342);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seleccion de asiento";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // dgvUbicacionAElegir
            // 
            this.dgvUbicacionAElegir.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvUbicacionAElegir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUbicacionAElegir.Location = new System.Drawing.Point(16, 28);
            this.dgvUbicacionAElegir.Name = "dgvUbicacionAElegir";
            this.dgvUbicacionAElegir.Size = new System.Drawing.Size(348, 223);
            this.dgvUbicacionAElegir.TabIndex = 12;
            // 
            // ElegirUbicaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 771);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.group_alta_rol);
            this.Name = "ElegirUbicaciones";
            this.Text = "Comprar [Parte 2/3] - Seleccion de Ubicaciones ";
            this.group_alta_rol.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.data_listado_sectores)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUbicacionesElegidas)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUbicacionAElegir)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox group_alta_rol;
        private System.Windows.Forms.DataGridView data_listado_sectores;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvUbicacionesElegidas;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvUbicacionAElegir;
    }
}