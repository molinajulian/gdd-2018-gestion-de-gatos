using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace PalcoNet.Listado_Estadistico
{
    partial class ListadoEstadistico
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
            this.comboListado = new System.Windows.Forms.ComboBox();
            this.data_Listado = new System.Windows.Forms.DataGridView();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboTrimestre = new System.Windows.Forms.ComboBox();
            this.comboGrados = new System.Windows.Forms.ComboBox();
            this.labelGrado = new System.Windows.Forms.Label();
            this.labelMes = new System.Windows.Forms.Label();
            this.txtAño = new System.Windows.Forms.TextBox();
            this.txtMes = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.data_Listado)).BeginInit();
            this.SuspendLayout();
            // 
            // comboListado
            // 
            this.comboListado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboListado.FormattingEnabled = true;
            this.comboListado.Location = new System.Drawing.Point(286, 94);
            this.comboListado.Name = "comboListado";
            this.comboListado.Size = new System.Drawing.Size(228, 21);
            this.comboListado.TabIndex = 6;
            this.comboListado.SelectedIndexChanged += new System.EventHandler(this.tipoListado_SelectedIndexChanged);
            // 
            // data_Listado
            // 
            this.data_Listado.AllowUserToAddRows = false;
            this.data_Listado.AllowUserToDeleteRows = false;
            this.data_Listado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.data_Listado.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.data_Listado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.NullValue = "-";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.data_Listado.DefaultCellStyle = dataGridViewCellStyle1;
            this.data_Listado.Location = new System.Drawing.Point(12, 230);
            this.data_Listado.Name = "data_Listado";
            this.data_Listado.ReadOnly = true;
            this.data_Listado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.data_Listado.Size = new System.Drawing.Size(627, 237);
            this.data_Listado.TabIndex = 24;
            this.data_Listado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_Listado_CellContentClick);
            // 
            // btn_buscar
            // 
            this.btn_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buscar.Location = new System.Drawing.Point(548, 68);
            this.btn_buscar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(91, 47);
            this.btn_buscar.TabIndex = 26;
            this.btn_buscar.Text = "Consultar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(283, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Seleccione Consulta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(171, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Trimestre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 68);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Año";
            // 
            // comboTrimestre
            // 
            this.comboTrimestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTrimestre.FormattingEnabled = true;
            this.comboTrimestre.Location = new System.Drawing.Point(145, 93);
            this.comboTrimestre.Name = "comboTrimestre";
            this.comboTrimestre.Size = new System.Drawing.Size(107, 21);
            this.comboTrimestre.TabIndex = 33;
            // 
            // comboGrados
            // 
            this.comboGrados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGrados.FormattingEnabled = true;
            this.comboGrados.Location = new System.Drawing.Point(145, 159);
            this.comboGrados.Name = "comboGrados";
            this.comboGrados.Size = new System.Drawing.Size(107, 21);
            this.comboGrados.TabIndex = 34;
            // 
            // labelGrado
            // 
            this.labelGrado.AutoSize = true;
            this.labelGrado.Location = new System.Drawing.Point(185, 132);
            this.labelGrado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelGrado.Name = "labelGrado";
            this.labelGrado.Size = new System.Drawing.Size(36, 13);
            this.labelGrado.TabIndex = 36;
            this.labelGrado.Text = "Grado";
            // 
            // labelMes
            // 
            this.labelMes.AutoSize = true;
            this.labelMes.Location = new System.Drawing.Point(351, 132);
            this.labelMes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMes.Name = "labelMes";
            this.labelMes.Size = new System.Drawing.Size(27, 13);
            this.labelMes.TabIndex = 37;
            this.labelMes.Text = "Mes";
            // 
            // txtAño
            // 
            this.txtAño.Location = new System.Drawing.Point(28, 94);
            this.txtAño.MaxLength = 4;
            this.txtAño.Name = "txtAño";
            this.txtAño.Size = new System.Drawing.Size(56, 20);
            this.txtAño.TabIndex = 38;
            this.txtAño.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAño_KeyPress);
            // 
            // txtMes
            // 
            this.txtMes.Location = new System.Drawing.Point(340, 160);
            this.txtMes.MaxLength = 2;
            this.txtMes.Name = "txtMes";
            this.txtMes.Size = new System.Drawing.Size(56, 20);
            this.txtMes.TabIndex = 39;
            this.txtMes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAño_KeyPress);
            // 
            // ListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 488);
            this.Controls.Add(this.txtMes);
            this.Controls.Add(this.txtAño);
            this.Controls.Add(this.labelMes);
            this.Controls.Add(this.labelGrado);
            this.Controls.Add(this.comboGrados);
            this.Controls.Add(this.comboTrimestre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.data_Listado);
            this.Controls.Add(this.comboListado);
            this.Name = "ListadoEstadistico";
            this.Text = "Listado estadistico";
            ((System.ComponentModel.ISupportInitialize)(this.data_Listado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void trimestre_TextChanged(object sender, System.EventArgs e)
        {
        }

        

        private void data_Listado_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void tipoListado_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            tipoListadoseleccionado = (string)comboListado.SelectedItem;
            
            
        }
        #endregion

        private System.Windows.Forms.ComboBox comboListado;
        private System.Windows.Forms.DataGridView data_Listado;
        private System.Windows.Forms.Button btn_buscar;
        private Label label2;
        private Label label1;
        private Label label3;
        private ComboBox comboTrimestre;
        private ComboBox comboGrados;
        private Label labelGrado;
        private Label labelMes;
        private TextBox txtAño;
        private TextBox txtMes;
    }
}