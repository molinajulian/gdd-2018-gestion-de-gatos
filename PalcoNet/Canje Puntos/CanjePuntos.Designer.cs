namespace PalcoNet.Canje_Puntos
{
    partial class CanjePuntos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.data_clientes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tx_nombre = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.data_clientes)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_buscar
            // 
            this.btn_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buscar.Location = new System.Drawing.Point(570, 307);
            this.btn_buscar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(91, 47);
            this.btn_buscar.TabIndex = 5;
            this.btn_buscar.Text = "Canjear";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // data_clientes
            // 
            this.data_clientes.AllowUserToAddRows = false;
            this.data_clientes.AllowUserToDeleteRows = false;
            this.data_clientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.data_clientes.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.data_clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.NullValue = "-";
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.data_clientes.DefaultCellStyle = dataGridViewCellStyle5;
            this.data_clientes.Location = new System.Drawing.Point(95, 131);
            this.data_clientes.Name = "data_clientes";
            this.data_clientes.ReadOnly = true;
            this.data_clientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.data_clientes.Size = new System.Drawing.Size(441, 188);
            this.data_clientes.TabIndex = 24;
            this.data_clientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_clientes_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 97);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 97);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Puntos acumulados";
            // 
            // tx_nombre
            // 
            this.tx_nombre.Location = new System.Drawing.Point(155, 94);
            this.tx_nombre.Margin = new System.Windows.Forms.Padding(2);
            this.tx_nombre.Name = "tx_nombre";
            this.tx_nombre.Size = new System.Drawing.Size(71, 20);
            this.tx_nombre.TabIndex = 27;
            // 
            // CanjePuntos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 365);
            this.Controls.Add(this.tx_nombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.data_clientes);
            this.Controls.Add(this.btn_buscar);
            this.Name = "CanjePuntos";
            this.Text = "CanjePuntos";
            ((System.ComponentModel.ISupportInitialize)(this.data_clientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.DataGridView data_clientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tx_nombre;
    }
}