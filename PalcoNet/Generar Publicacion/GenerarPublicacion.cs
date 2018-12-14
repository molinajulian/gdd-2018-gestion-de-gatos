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
    public partial class GenerarPublicacion : MaterialForm
    {
        List<Sector> sectoresRegistrados = new List<Sector>();
        public GenerarPublicacion()
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

        private void button1_Click(object sender, EventArgs e)
        {
            AltaSector altaSector = new AltaSector(sectoresRegistrados);
            altaSector.ShowDialog();
            this.Hide();
        }

        public Publicacion getPublicacionDeUi()
        {
            return null; //Publicacion publicacion = new Publicacion(txtDescripcion.Text, fechaYHoraEstablecidaPicker.Value.ToString(), Convert.ToInt32(cmbGrado.SelectedValue), Convert.ToInt32(cmbEstado.SelectedValue),);
        }

        private void btn_alta_publicacion_Click(object sender, EventArgs e)
        {
            Publicacion pulicacion = getPublicacionDeUi();
        }
    }
}
