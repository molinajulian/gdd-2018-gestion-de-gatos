namespace PalcoNet.Historial_Cliente
{
    partial class HistorialCliente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.comboTiposDoc = new System.Windows.Forms.ComboBox();
            this.txDni = new System.Windows.Forms.TextBox();
            this.data_clientes = new System.Windows.Forms.DataGridView();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.data_clientes)).BeginInit();
            this.SuspendLayout();
            // 
            // comboTiposDoc
            // 
            this.comboTiposDoc.FormattingEnabled = true;
            this.comboTiposDoc.Location = new System.Drawing.Point(12, 90);
            this.comboTiposDoc.Name = "comboTiposDoc";
            this.comboTiposDoc.Size = new System.Drawing.Size(121, 21);
            this.comboTiposDoc.TabIndex = 35;
            // 
            // txDni
            // 
            this.txDni.Location = new System.Drawing.Point(152, 90);
            this.txDni.Name = "txDni";
            this.txDni.Size = new System.Drawing.Size(136, 20);
            this.txDni.TabIndex = 36;
            // 
            // data_clientes
            // 
            this.data_clientes.AllowUserToAddRows = false;
            this.data_clientes.AllowUserToDeleteRows = false;
            this.data_clientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.data_clientes.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.data_clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.NullValue = "-";
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.data_clientes.DefaultCellStyle = dataGridViewCellStyle4;
            this.data_clientes.Location = new System.Drawing.Point(12, 117);
            this.data_clientes.Name = "data_clientes";
            this.data_clientes.ReadOnly = true;
            this.data_clientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.data_clientes.Size = new System.Drawing.Size(458, 179);
            this.data_clientes.TabIndex = 37;
            // 
            // btn_buscar
            // 
            this.btn_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buscar.Location = new System.Drawing.Point(379, 63);
            this.btn_buscar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(91, 47);
            this.btn_buscar.TabIndex = 38;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(32, 74);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 13);
            this.label13.TabIndex = 39;
            this.label13.Text = "Tipo de Documento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(171, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Numero de Documento";
            // 
            // HistorialCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 300);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.data_clientes);
            this.Controls.Add(this.txDni);
            this.Controls.Add(this.comboTiposDoc);
            this.Name = "HistorialCliente";
            this.Text = "Historial Cliente";
            ((System.ComponentModel.ISupportInitialize)(this.data_clientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboTiposDoc;
        private System.Windows.Forms.TextBox txDni;
        private System.Windows.Forms.DataGridView data_clientes;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label4;
    }
}