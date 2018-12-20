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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.data_historial = new System.Windows.Forms.DataGridView();
            this.buttonNext = new MaterialSkin.Controls.MaterialFlatButton();
            this.buttonBack = new MaterialSkin.Controls.MaterialFlatButton();
            this.txtLimit = new System.Windows.Forms.TextBox();
            this.labelAclaracion = new System.Windows.Forms.Label();
            this.comboTiposDoc = new System.Windows.Forms.ComboBox();
            this.labelTipoDoc = new System.Windows.Forms.Label();
            this.labelDoc = new System.Windows.Forms.Label();
            this.txtDoc = new System.Windows.Forms.TextBox();
            this.buttonBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.data_historial)).BeginInit();
            this.SuspendLayout();
            // 
            // data_historial
            // 
            this.data_historial.AllowUserToAddRows = false;
            this.data_historial.AllowUserToDeleteRows = false;
            this.data_historial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.data_historial.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.data_historial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.NullValue = "-";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.data_historial.DefaultCellStyle = dataGridViewCellStyle3;
            this.data_historial.Location = new System.Drawing.Point(49, 133);
            this.data_historial.Name = "data_historial";
            this.data_historial.ReadOnly = true;
            this.data_historial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.data_historial.Size = new System.Drawing.Size(605, 300);
            this.data_historial.TabIndex = 37;
            // 
            // buttonNext
            // 
            this.buttonNext.AutoSize = true;
            this.buttonNext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonNext.Depth = 0;
            this.buttonNext.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.buttonNext.Location = new System.Drawing.Point(333, 456);
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
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.buttonBack.Location = new System.Drawing.Point(272, 453);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonBack.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Primary = false;
            this.buttonBack.Size = new System.Drawing.Size(19, 36);
            this.buttonBack.TabIndex = 52;
            this.buttonBack.Text = "<";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // txtLimit
            // 
            this.txtLimit.Enabled = false;
            this.txtLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtLimit.Location = new System.Drawing.Point(298, 456);
            this.txtLimit.Multiline = true;
            this.txtLimit.Name = "txtLimit";
            this.txtLimit.Size = new System.Drawing.Size(28, 33);
            this.txtLimit.TabIndex = 53;
            this.txtLimit.Text = "4";
            this.txtLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelAclaracion
            // 
            this.labelAclaracion.AutoSize = true;
            this.labelAclaracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.labelAclaracion.Location = new System.Drawing.Point(397, 469);
            this.labelAclaracion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAclaracion.Name = "labelAclaracion";
            this.labelAclaracion.Size = new System.Drawing.Size(93, 16);
            this.labelAclaracion.TabIndex = 59;
            this.labelAclaracion.Text = "Página 1 de N";
            // 
            // comboTiposDoc
            // 
            this.comboTiposDoc.FormattingEnabled = true;
            this.comboTiposDoc.Location = new System.Drawing.Point(153, 93);
            this.comboTiposDoc.Name = "comboTiposDoc";
            this.comboTiposDoc.Size = new System.Drawing.Size(81, 21);
            this.comboTiposDoc.TabIndex = 63;
            // 
            // labelTipoDoc
            // 
            this.labelTipoDoc.AutoSize = true;
            this.labelTipoDoc.Location = new System.Drawing.Point(46, 96);
            this.labelTipoDoc.Name = "labelTipoDoc";
            this.labelTipoDoc.Size = new System.Drawing.Size(101, 13);
            this.labelTipoDoc.TabIndex = 62;
            this.labelTipoDoc.Text = "Tipo de Documento";
            // 
            // labelDoc
            // 
            this.labelDoc.AutoSize = true;
            this.labelDoc.Location = new System.Drawing.Point(257, 96);
            this.labelDoc.Name = "labelDoc";
            this.labelDoc.Size = new System.Drawing.Size(117, 13);
            this.labelDoc.TabIndex = 61;
            this.labelDoc.Text = "Numero de Documento";
            // 
            // txtDoc
            // 
            this.txtDoc.Location = new System.Drawing.Point(380, 96);
            this.txtDoc.Name = "txtDoc";
            this.txtDoc.Size = new System.Drawing.Size(110, 20);
            this.txtDoc.TabIndex = 60;
            this.txtDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoc_KeyPress);
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(558, 91);
            this.buttonBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(74, 28);
            this.buttonBuscar.TabIndex = 64;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // HistorialCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 501);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.comboTiposDoc);
            this.Controls.Add(this.labelTipoDoc);
            this.Controls.Add(this.labelDoc);
            this.Controls.Add(this.txtDoc);
            this.Controls.Add(this.labelAclaracion);
            this.Controls.Add(this.txtLimit);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.data_historial);
            this.Name = "HistorialCliente";
            this.Text = "Historial Cliente";
            ((System.ComponentModel.ISupportInitialize)(this.data_historial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView data_historial;
        private MaterialSkin.Controls.MaterialFlatButton buttonNext;
        private MaterialSkin.Controls.MaterialFlatButton buttonBack;
        private System.Windows.Forms.TextBox txtLimit;
        private System.Windows.Forms.Label labelAclaracion;
        private System.Windows.Forms.ComboBox comboTiposDoc;
        private System.Windows.Forms.Label labelTipoDoc;
        private System.Windows.Forms.Label labelDoc;
        private System.Windows.Forms.TextBox txtDoc;
        private System.Windows.Forms.Button buttonBuscar;
    }
}