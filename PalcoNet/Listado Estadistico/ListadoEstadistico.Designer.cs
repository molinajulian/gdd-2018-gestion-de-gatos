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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tipoListado = new System.Windows.Forms.ComboBox();
            this.data_Listado = new System.Windows.Forms.DataGridView();
            this.trimestre = new System.Windows.Forms.TextBox();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.data_Listado)).BeginInit();
            this.SuspendLayout();
            // 
            // tipoListado
            // 
            this.tipoListado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoListado.FormattingEnabled = true;
            this.tipoListado.Location = new System.Drawing.Point(12, 81);
            this.tipoListado.Name = "tipoListado";
            this.tipoListado.Size = new System.Drawing.Size(137, 21);
            this.tipoListado.TabIndex = 6;
            this.tipoListado.SelectedIndexChanged += new System.EventHandler(this.tipoListado_SelectedIndexChanged);
            // 
            // data_Listado
            // 
            this.data_Listado.AllowUserToAddRows = false;
            this.data_Listado.AllowUserToDeleteRows = false;
            this.data_Listado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.data_Listado.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.data_Listado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.NullValue = "-";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.data_Listado.DefaultCellStyle = dataGridViewCellStyle3;
            this.data_Listado.Location = new System.Drawing.Point(12, 131);
            this.data_Listado.Name = "data_Listado";
            this.data_Listado.ReadOnly = true;
            this.data_Listado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.data_Listado.Size = new System.Drawing.Size(627, 237);
            this.data_Listado.TabIndex = 24;
            this.data_Listado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_Listado_CellContentClick);
            // 
            // trimestre
            // 
            this.trimestre.AccessibleDescription = "";
            this.trimestre.Location = new System.Drawing.Point(202, 82);
            this.trimestre.Margin = new System.Windows.Forms.Padding(2);
            this.trimestre.Name = "trimestre";
            this.trimestre.Size = new System.Drawing.Size(53, 20);
            this.trimestre.TabIndex = 25;
            this.trimestre.TextChanged += new System.EventHandler(this.trimestre_TextChanged);
            // 
            // btn_buscar
            // 
            this.btn_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buscar.Location = new System.Drawing.Point(429, 68);
            this.btn_buscar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(91, 47);
            this.btn_buscar.TabIndex = 26;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(286, 82);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(53, 20);
            this.textBox1.TabIndex = 27;
            // 
            // ListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 403);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.trimestre);
            this.Controls.Add(this.data_Listado);
            this.Controls.Add(this.tipoListado);
            this.Name = "ListadoEstadistico";
            this.Text = "Listado estadistico";
            this.Load += new System.EventHandler(this.ListadoEstadistico_Load);
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
            
            
            
        }
        #endregion

        private System.Windows.Forms.ComboBox tipoListado;
        private System.Windows.Forms.TextBox trimestre;
        private System.Windows.Forms.DataGridView data_Listado;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.TextBox textBox1;
    }
}