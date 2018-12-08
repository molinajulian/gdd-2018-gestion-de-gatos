namespace PalcoNet.AbmCliente
{
    partial class ListadoCliente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_atras = new System.Windows.Forms.Button();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.data_clientes = new System.Windows.Forms.DataGridView();
            this.grupo_filtros = new System.Windows.Forms.GroupBox();
            this.tx_apellido = new System.Windows.Forms.TextBox();
            this.tx_dni = new System.Windows.Forms.TextBox();
            this.tx_nombre = new System.Windows.Forms.TextBox();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.switch_habilitacion = new System.Windows.Forms.Button();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonRigth = new System.Windows.Forms.Button();
            this.txtLimit = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.data_clientes)).BeginInit();
            this.grupo_filtros.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_atras
            // 
            this.btn_atras.Location = new System.Drawing.Point(82, 500);
            this.btn_atras.Margin = new System.Windows.Forms.Padding(2);
            this.btn_atras.Name = "btn_atras";
            this.btn_atras.Size = new System.Drawing.Size(74, 28);
            this.btn_atras.TabIndex = 25;
            this.btn_atras.Text = "Atras";
            this.btn_atras.UseVisualStyleBackColor = true;
            this.btn_atras.Click += new System.EventHandler(this.btn_atras_Click);
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Location = new System.Drawing.Point(589, 500);
            this.btn_limpiar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(74, 28);
            this.btn_limpiar.TabIndex = 28;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.UseVisualStyleBackColor = true;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // data_clientes
            // 
            this.data_clientes.AllowUserToAddRows = false;
            this.data_clientes.AllowUserToDeleteRows = false;
            this.data_clientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.data_clientes.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.data_clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.NullValue = "-";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.data_clientes.DefaultCellStyle = dataGridViewCellStyle1;
            this.data_clientes.Location = new System.Drawing.Point(11, 198);
            this.data_clientes.Name = "data_clientes";
            this.data_clientes.ReadOnly = true;
            this.data_clientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.data_clientes.Size = new System.Drawing.Size(717, 237);
            this.data_clientes.TabIndex = 23;
            this.data_clientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_clientes_CellClick);
            this.data_clientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_clientes_CellContentClick);
            // 
            // grupo_filtros
            // 
            this.grupo_filtros.BackColor = System.Drawing.Color.White;
            this.grupo_filtros.Controls.Add(this.tx_apellido);
            this.grupo_filtros.Controls.Add(this.tx_dni);
            this.grupo_filtros.Controls.Add(this.tx_nombre);
            this.grupo_filtros.Controls.Add(this.btn_buscar);
            this.grupo_filtros.Controls.Add(this.label3);
            this.grupo_filtros.Controls.Add(this.label2);
            this.grupo_filtros.Controls.Add(this.label1);
            this.grupo_filtros.Location = new System.Drawing.Point(11, 86);
            this.grupo_filtros.Margin = new System.Windows.Forms.Padding(2);
            this.grupo_filtros.Name = "grupo_filtros";
            this.grupo_filtros.Padding = new System.Windows.Forms.Padding(2);
            this.grupo_filtros.Size = new System.Drawing.Size(717, 107);
            this.grupo_filtros.TabIndex = 22;
            this.grupo_filtros.TabStop = false;
            this.grupo_filtros.Text = "Filtros de Busqueda";
            this.grupo_filtros.Enter += new System.EventHandler(this.grupo_filtros_Enter);
            // 
            // tx_apellido
            // 
            this.tx_apellido.Location = new System.Drawing.Point(305, 31);
            this.tx_apellido.Margin = new System.Windows.Forms.Padding(2);
            this.tx_apellido.Name = "tx_apellido";
            this.tx_apellido.Size = new System.Drawing.Size(118, 20);
            this.tx_apellido.TabIndex = 2;
            // 
            // tx_dni
            // 
            this.tx_dni.Location = new System.Drawing.Point(495, 31);
            this.tx_dni.Margin = new System.Windows.Forms.Padding(2);
            this.tx_dni.Name = "tx_dni";
            this.tx_dni.Size = new System.Drawing.Size(118, 20);
            this.tx_dni.TabIndex = 3;
            // 
            // tx_nombre
            // 
            this.tx_nombre.Location = new System.Drawing.Point(90, 31);
            this.tx_nombre.Margin = new System.Windows.Forms.Padding(2);
            this.tx_nombre.Name = "tx_nombre";
            this.tx_nombre.Size = new System.Drawing.Size(118, 20);
            this.tx_nombre.TabIndex = 1;
            this.tx_nombre.TextChanged += new System.EventHandler(this.tx_nombre_TextChanged);
            // 
            // btn_buscar
            // 
            this.btn_buscar.Location = new System.Drawing.Point(244, 75);
            this.btn_buscar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(74, 28);
            this.btn_buscar.TabIndex = 4;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(241, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Apellido";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(453, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "DNI";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // switch_habilitacion
            // 
            this.switch_habilitacion.Location = new System.Drawing.Point(262, 500);
            this.switch_habilitacion.Margin = new System.Windows.Forms.Padding(2);
            this.switch_habilitacion.Name = "switch_habilitacion";
            this.switch_habilitacion.Size = new System.Drawing.Size(74, 28);
            this.switch_habilitacion.TabIndex = 26;
            this.switch_habilitacion.Text = "Inhabilitar";
            this.switch_habilitacion.UseVisualStyleBackColor = true;
            this.switch_habilitacion.Click += new System.EventHandler(this.switch_habilitacion_Click);
            // 
            // btn_modificar
            // 
            this.btn_modificar.Location = new System.Drawing.Point(434, 500);
            this.btn_modificar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(74, 28);
            this.btn_modificar.TabIndex = 27;
            this.btn_modificar.Text = "Modificar";
            this.btn_modificar.UseVisualStyleBackColor = true;
            this.btn_modificar.Click += new System.EventHandler(this.btn_modificar_Click);
            // 
            // buttonLeft
            // 
            this.buttonLeft.Location = new System.Drawing.Point(255, 440);
            this.buttonLeft.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(74, 28);
            this.buttonLeft.TabIndex = 29;
            this.buttonLeft.Text = "<<";
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.Click += new System.EventHandler(this.buttonLeft_Click);
            // 
            // buttonRigth
            // 
            this.buttonRigth.Location = new System.Drawing.Point(416, 440);
            this.buttonRigth.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRigth.Name = "buttonRigth";
            this.buttonRigth.Size = new System.Drawing.Size(74, 28);
            this.buttonRigth.TabIndex = 31;
            this.buttonRigth.Text = ">";
            this.buttonRigth.UseVisualStyleBackColor = true;
            this.buttonRigth.Click += new System.EventHandler(this.buttonRigth_Click);
            // 
            // txtLimit
            // 
            this.txtLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLimit.Location = new System.Drawing.Point(343, 443);
            this.txtLimit.Margin = new System.Windows.Forms.Padding(2);
            this.txtLimit.Name = "txtLimit";
            this.txtLimit.Size = new System.Drawing.Size(60, 26);
            this.txtLimit.TabIndex = 5;
            this.txtLimit.Text = "20";
            this.txtLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLimit.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLimit_KeyPress);
            // 
            // ListadoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 562);
            this.Controls.Add(this.txtLimit);
            this.Controls.Add(this.buttonLeft);
            this.Controls.Add(this.buttonRigth);
            this.Controls.Add(this.btn_modificar);
            this.Controls.Add(this.switch_habilitacion);
            this.Controls.Add(this.btn_atras);
            this.Controls.Add(this.btn_limpiar);
            this.Controls.Add(this.data_clientes);
            this.Controls.Add(this.grupo_filtros);
            this.Name = "ListadoCliente";
            this.Text = "Listado de clientes";
            this.Load += new System.EventHandler(this.ListadoCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data_clientes)).EndInit();
            this.grupo_filtros.ResumeLayout(false);
            this.grupo_filtros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_atras;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.DataGridView data_clientes;
        private System.Windows.Forms.GroupBox grupo_filtros;
        private System.Windows.Forms.TextBox tx_apellido;
        private System.Windows.Forms.TextBox tx_dni;
        private System.Windows.Forms.TextBox tx_nombre;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button switch_habilitacion;
        private System.Windows.Forms.Button btn_modificar;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonRigth;
        private System.Windows.Forms.TextBox txtLimit;
    }
}