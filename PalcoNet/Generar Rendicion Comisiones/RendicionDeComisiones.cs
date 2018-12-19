using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using PalcoNet.Repositorios;
namespace PalcoNet.Generar_Rendicion_Comisiones
{
    public partial class RendicionDeComisiones :  MaterialForm
    {
        public string cuitIngresado { get; set; }
        public int cantIngresada { get; set; }
        public List<SqlParameter> parametros { get; set; }
        public RendicionDeComisiones()
        {   
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            
        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtMail.Text, @"[0-9]{2}-[0-9]{5,9}-[0-9]{1,2}$"))
            {
                MessageBox.Show("Ingrese un CUIT válido.");

            }
            else { cuitIngresado = txtMail.Text; }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(int.Parse(textBox1.Text) > 0 )
                MessageBox.Show("Ingrese una cantidad válida.");
            else { cantIngresada = int.Parse(textBox1.Text); }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                parametros.Clear();
                parametros.Add(new SqlParameter("@empresaCuit", cuitIngresado));
                parametros.Add(new SqlParameter("@cantidad", cantIngresada));
                //agregar el Usuario 
                //agregarlafechadehoy
                DataBase.WriteInBase("GenerarRendicionComisiones", "SP", parametros);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
