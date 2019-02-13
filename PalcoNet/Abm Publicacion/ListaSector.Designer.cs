namespace PalcoNet.AbmPublicaciones
{
    partial class ListaSector
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
            this.components = new System.ComponentModel.Container();
            this.epProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.group_alta_rol = new System.Windows.Forms.GroupBox();
            this.data_listado_sectores = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.epProvider)).BeginInit();
            this.group_alta_rol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_listado_sectores)).BeginInit();
            this.SuspendLayout();
            // 
            // epProvider
            // 
            this.epProvider.ContainerControl = this;
            // 
            // group_alta_rol
            // 
            this.group_alta_rol.BackColor = System.Drawing.Color.White;
            this.group_alta_rol.Controls.Add(this.data_listado_sectores);
            this.group_alta_rol.Location = new System.Drawing.Point(23, 73);
            this.group_alta_rol.Name = "group_alta_rol";
            this.group_alta_rol.Size = new System.Drawing.Size(480, 270);
            this.group_alta_rol.TabIndex = 9;
            this.group_alta_rol.TabStop = false;
            this.group_alta_rol.Text = "Datos del sector";
            // 
            // data_listado_sectores
            // 
            this.data_listado_sectores.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.data_listado_sectores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_listado_sectores.Location = new System.Drawing.Point(6, 33);
            this.data_listado_sectores.Name = "data_listado_sectores";
            this.data_listado_sectores.Size = new System.Drawing.Size(468, 223);
            this.data_listado_sectores.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(199, 349);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 44);
            this.button1.TabIndex = 11;
            this.button1.Text = "Editar Sector";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ListaSector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 408);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.group_alta_rol);
            this.Name = "ListaSector";
            this.Text = "Lista Sector";
            ((System.ComponentModel.ISupportInitialize)(this.epProvider)).EndInit();
            this.group_alta_rol.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.data_listado_sectores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider epProvider;
        private System.Windows.Forms.GroupBox group_alta_rol;
        private System.Windows.Forms.DataGridView data_listado_sectores;
        private System.Windows.Forms.Button button1;
    }
}