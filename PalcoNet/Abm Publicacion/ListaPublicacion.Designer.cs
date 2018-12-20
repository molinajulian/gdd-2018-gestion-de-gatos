namespace PalcoNet.AbmPublicaciones
{
    partial class ListaPublicacion
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
            this.btn_editar = new System.Windows.Forms.Button();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.grupo_filtros = new System.Windows.Forms.GroupBox();
            this.txt_titulo_pub = new System.Windows.Forms.TextBox();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.data_publicaciones = new System.Windows.Forms.DataGridView();
            this.grupo_filtros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_publicaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_editar
            // 
            this.btn_editar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editar.Location = new System.Drawing.Point(85, 421);
            this.btn_editar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(74, 28);
            this.btn_editar.TabIndex = 19;
            this.btn_editar.Text = "Editar";
            this.btn_editar.UseVisualStyleBackColor = true;
            this.btn_editar.Click += new System.EventHandler(this.btn_editar_Click);
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Location = new System.Drawing.Point(478, 421);
            this.btn_limpiar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(74, 28);
            this.btn_limpiar.TabIndex = 17;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.UseVisualStyleBackColor = true;
            // 
            // grupo_filtros
            // 
            this.grupo_filtros.BackColor = System.Drawing.Color.White;
            this.grupo_filtros.Controls.Add(this.txt_titulo_pub);
            this.grupo_filtros.Controls.Add(this.btn_buscar);
            this.grupo_filtros.Controls.Add(this.label1);
            this.grupo_filtros.Location = new System.Drawing.Point(11, 66);
            this.grupo_filtros.Margin = new System.Windows.Forms.Padding(2);
            this.grupo_filtros.Name = "grupo_filtros";
            this.grupo_filtros.Padding = new System.Windows.Forms.Padding(2);
            this.grupo_filtros.Size = new System.Drawing.Size(623, 79);
            this.grupo_filtros.TabIndex = 16;
            this.grupo_filtros.TabStop = false;
            this.grupo_filtros.Text = "Filtros de Busqueda";
            // 
            // txt_titulo_pub
            // 
            this.txt_titulo_pub.Location = new System.Drawing.Point(64, 31);
            this.txt_titulo_pub.Margin = new System.Windows.Forms.Padding(2);
            this.txt_titulo_pub.Name = "txt_titulo_pub";
            this.txt_titulo_pub.Size = new System.Drawing.Size(417, 20);
            this.txt_titulo_pub.TabIndex = 15;
            // 
            // btn_buscar
            // 
            this.btn_buscar.Location = new System.Drawing.Point(511, 23);
            this.btn_buscar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(74, 34);
            this.btn_buscar.TabIndex = 14;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Titulo";
            // 
            // data_publicaciones
            // 
            this.data_publicaciones.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.data_publicaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_publicaciones.Location = new System.Drawing.Point(12, 158);
            this.data_publicaciones.Margin = new System.Windows.Forms.Padding(2);
            this.data_publicaciones.Name = "data_publicaciones";
            this.data_publicaciones.ReadOnly = true;
            this.data_publicaciones.RowTemplate.Height = 24;
            this.data_publicaciones.Size = new System.Drawing.Size(626, 250);
            this.data_publicaciones.TabIndex = 15;
            // 
            // ListaPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 480);
            this.Controls.Add(this.btn_editar);
            this.Controls.Add(this.btn_limpiar);
            this.Controls.Add(this.grupo_filtros);
            this.Controls.Add(this.data_publicaciones);
            this.Name = "ListaPublicacion";
            this.Text = "Editar Publicacion";
            this.grupo_filtros.ResumeLayout(false);
            this.grupo_filtros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_publicaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_editar;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.GroupBox grupo_filtros;
        private System.Windows.Forms.TextBox txt_titulo_pub;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView data_publicaciones;
    }
}