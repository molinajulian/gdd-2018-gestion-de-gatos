namespace PalcoNet.Generar_Rendicion_Comisiones
{
    partial class RendicionDeComisiones
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
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_login = new MaterialSkin.Controls.MaterialFlatButton();
            this.dgvFacturas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Location = new System.Drawing.Point(93, 84);
            this.txtEmpresa.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new System.Drawing.Size(238, 20);
            this.txtEmpresa.TabIndex = 46;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(442, 84);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(2);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(77, 20);
            this.txtCantidad.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 87);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Cuit Empresa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(346, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Cantidad a Rendir";
            // 
            // btn_login
            // 
            this.btn_login.AutoSize = true;
            this.btn_login.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_login.Depth = 0;
            this.btn_login.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_login.Location = new System.Drawing.Point(543, 75);
            this.btn_login.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_login.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_login.Name = "btn_login";
            this.btn_login.Primary = false;
            this.btn_login.Size = new System.Drawing.Size(59, 36);
            this.btn_login.TabIndex = 50;
            this.btn_login.Text = "Rendir";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // dgvFacturas
            // 
            this.dgvFacturas.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturas.Location = new System.Drawing.Point(44, 133);
            this.dgvFacturas.Name = "dgvFacturas";
            this.dgvFacturas.ReadOnly = true;
            this.dgvFacturas.Size = new System.Drawing.Size(570, 229);
            this.dgvFacturas.TabIndex = 51;
            // 
            // RendicionDeComisiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 398);
            this.Controls.Add(this.dgvFacturas);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.txtEmpresa);
            this.Name = "RendicionDeComisiones";
            this.Text = "RendicionDeComisiones";
            this.Load += new System.EventHandler(this.RendicionDeComisiones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmpresa;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MaterialSkin.Controls.MaterialFlatButton btn_login;
        private System.Windows.Forms.DataGridView dgvFacturas;
    }
}