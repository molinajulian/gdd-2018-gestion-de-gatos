using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Modelo;
using MaterialSkin.Controls;
using MaterialSkin;
using PalcoNet.Repositorios;

namespace PalcoNet.GenerarPublicacion
{
    public partial class AltaSector : MaterialForm
    {

        public AltaSector()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
           
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void limpiarVentana()
        {
           

        }

        private void listarFuncionalidades()
        {
           
        }

        private void group_alta_rol_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_alta_rol_Click(object sender, EventArgs e)
        {

        }
    }
}
