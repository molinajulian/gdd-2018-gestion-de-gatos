namespace PalcoNet.AbmEmpresa
{
    partial class ListadoEmpresas
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
            this.data_empresas = new System.Windows.Forms.DataGridView();
            this.grupo_filtros = new System.Windows.Forms.GroupBox();
            this.txt_mail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_cuit = new System.Windows.Forms.TextBox();
            this.txt_razon_social = new System.Windows.Forms.TextBox();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_atras = new System.Windows.Forms.Button();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.btn_editar = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.data_empresas)).BeginInit();
            this.grupo_filtros.SuspendLayout();
            this.SuspendLayout();
            // 
            // data_empresas
            // 
            this.data_empresas.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.data_empresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_empresas.Location = new System.Drawing.Point(11, 171);
            this.data_empresas.Margin = new System.Windows.Forms.Padding(2);
            this.data_empresas.Name = "data_empresas";
            this.data_empresas.ReadOnly = true;
            this.data_empresas.RowTemplate.Height = 24;
            this.data_empresas.Size = new System.Drawing.Size(626, 250);
            this.data_empresas.TabIndex = 0;
            // 
            // grupo_filtros
            // 
            this.grupo_filtros.BackColor = System.Drawing.Color.White;
            this.grupo_filtros.Controls.Add(this.txt_mail);
            this.grupo_filtros.Controls.Add(this.label3);
            this.grupo_filtros.Controls.Add(this.txt_cuit);
            this.grupo_filtros.Controls.Add(this.txt_razon_social);
            this.grupo_filtros.Controls.Add(this.btn_buscar);
            this.grupo_filtros.Controls.Add(this.label2);
            this.grupo_filtros.Controls.Add(this.label1);
            this.grupo_filtros.Location = new System.Drawing.Point(10, 87);
            this.grupo_filtros.Margin = new System.Windows.Forms.Padding(2);
            this.grupo_filtros.Name = "grupo_filtros";
            this.grupo_filtros.Padding = new System.Windows.Forms.Padding(2);
            this.grupo_filtros.Size = new System.Drawing.Size(623, 71);
            this.grupo_filtros.TabIndex = 1;
            this.grupo_filtros.TabStop = false;
            this.grupo_filtros.Text = "Filtros de Busqueda";
            // 
            // txt_mail
            // 
            this.txt_mail.Location = new System.Drawing.Point(242, 31);
            this.txt_mail.Margin = new System.Windows.Forms.Padding(2);
            this.txt_mail.Name = "txt_mail";
            this.txt_mail.Size = new System.Drawing.Size(114, 20);
            this.txt_mail.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Mail";
            // 
            // txt_cuit
            // 
            this.txt_cuit.Location = new System.Drawing.Point(401, 31);
            this.txt_cuit.Margin = new System.Windows.Forms.Padding(2);
            this.txt_cuit.Name = "txt_cuit";
            this.txt_cuit.Size = new System.Drawing.Size(117, 20);
            this.txt_cuit.TabIndex = 16;
            // 
            // txt_razon_social
            // 
            this.txt_razon_social.Location = new System.Drawing.Point(79, 31);
            this.txt_razon_social.Margin = new System.Windows.Forms.Padding(2);
            this.txt_razon_social.Name = "txt_razon_social";
            this.txt_razon_social.Size = new System.Drawing.Size(118, 20);
            this.txt_razon_social.TabIndex = 15;
            // 
            // btn_buscar
            // 
            this.btn_buscar.Location = new System.Drawing.Point(534, 26);
            this.btn_buscar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(74, 28);
            this.btn_buscar.TabIndex = 14;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(372, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cuit";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Razon Social";
            // 
            // btn_atras
            // 
            this.btn_atras.Location = new System.Drawing.Point(10, 434);
            this.btn_atras.Margin = new System.Windows.Forms.Padding(2);
            this.btn_atras.Name = "btn_atras";
            this.btn_atras.Size = new System.Drawing.Size(74, 28);
            this.btn_atras.TabIndex = 12;
            this.btn_atras.Text = "Atras";
            this.btn_atras.UseVisualStyleBackColor = true;
            this.btn_atras.Click += new System.EventHandler(this.btn_atras_Click_1);
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Location = new System.Drawing.Point(561, 434);
            this.btn_limpiar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(74, 28);
            this.btn_limpiar.TabIndex = 11;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.UseVisualStyleBackColor = true;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click_1);
            // 
            // btn_editar
            // 
            this.btn_editar.Enabled = false;
            this.btn_editar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editar.Location = new System.Drawing.Point(210, 434);
            this.btn_editar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(74, 28);
            this.btn_editar.TabIndex = 13;
            this.btn_editar.Text = "Editar";
            this.btn_editar.UseVisualStyleBackColor = true;
            this.btn_editar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.Enabled = false;
            this.btn_eliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_eliminar.Location = new System.Drawing.Point(333, 434);
            this.btn_eliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(74, 28);
            this.btn_eliminar.TabIndex = 14;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = true;
            // 
            // ListadoEmpresas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 479);
            this.Controls.Add(this.btn_eliminar);
            this.Controls.Add(this.btn_editar);
            this.Controls.Add(this.btn_atras);
            this.Controls.Add(this.btn_limpiar);
            this.Controls.Add(this.grupo_filtros);
            this.Controls.Add(this.data_empresas);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ListadoEmpresas";
            this.Text = "Listado de Empresas";
            ((System.ComponentModel.ISupportInitialize)(this.data_empresas)).EndInit();
            this.grupo_filtros.ResumeLayout(false);
            this.grupo_filtros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView data_empresas;
        private System.Windows.Forms.GroupBox grupo_filtros;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_atras;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.TextBox txt_cuit;
        private System.Windows.Forms.TextBox txt_razon_social;
        private System.Windows.Forms.TextBox txt_mail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_editar;
        private System.Windows.Forms.Button btn_eliminar;
    }
}