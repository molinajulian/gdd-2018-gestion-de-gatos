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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.data_clientes = new System.Windows.Forms.DataGridView();
            this.buttonNext = new MaterialSkin.Controls.MaterialFlatButton();
            this.buttonBack = new MaterialSkin.Controls.MaterialFlatButton();
            this.txtLimit = new System.Windows.Forms.TextBox();
            this.labelAclaracion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.data_clientes)).BeginInit();
            this.SuspendLayout();
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
            this.data_clientes.Location = new System.Drawing.Point(44, 91);
            this.data_clientes.Name = "data_clientes";
            this.data_clientes.ReadOnly = true;
            this.data_clientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.data_clientes.Size = new System.Drawing.Size(458, 242);
            this.data_clientes.TabIndex = 37;
            // 
            // buttonNext
            // 
            this.buttonNext.AutoSize = true;
            this.buttonNext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonNext.Depth = 0;
            this.buttonNext.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonNext.Location = new System.Drawing.Point(274, 355);
            this.buttonNext.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonNext.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Primary = false;
            this.buttonNext.Size = new System.Drawing.Size(19, 36);
            this.buttonNext.TabIndex = 51;
            this.buttonNext.Text = ">";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.AutoSize = true;
            this.buttonBack.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonBack.Depth = 0;
            this.buttonBack.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonBack.Location = new System.Drawing.Point(208, 355);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonBack.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Primary = false;
            this.buttonBack.Size = new System.Drawing.Size(19, 36);
            this.buttonBack.TabIndex = 52;
            this.buttonBack.Text = "<";
            this.buttonBack.UseVisualStyleBackColor = true;
            // 
            // txtLimit
            // 
            this.txtLimit.Location = new System.Drawing.Point(234, 355);
            this.txtLimit.Multiline = true;
            this.txtLimit.Name = "txtLimit";
            this.txtLimit.Size = new System.Drawing.Size(33, 36);
            this.txtLimit.TabIndex = 53;
            // 
            // labelAclaracion
            // 
            this.labelAclaracion.AutoSize = true;
            this.labelAclaracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.labelAclaracion.Location = new System.Drawing.Point(347, 375);
            this.labelAclaracion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAclaracion.Name = "labelAclaracion";
            this.labelAclaracion.Size = new System.Drawing.Size(102, 16);
            this.labelAclaracion.TabIndex = 59;
            this.labelAclaracion.Text = "N de N páginas";
            // 
            // HistorialCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 418);
            this.Controls.Add(this.labelAclaracion);
            this.Controls.Add(this.txtLimit);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.data_clientes);
            this.Name = "HistorialCliente";
            this.Text = "Historial Cliente";
            ((System.ComponentModel.ISupportInitialize)(this.data_clientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView data_clientes;
        private MaterialSkin.Controls.MaterialFlatButton buttonNext;
        private MaterialSkin.Controls.MaterialFlatButton buttonBack;
        private System.Windows.Forms.TextBox txtLimit;
        private System.Windows.Forms.Label labelAclaracion;
    }
}