using System;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using PalcoNet.AbmCliente;
using PalcoNet.Modelo;
using PalcoNet.Repositorios;

namespace PalcoNet.AbmPublicaciones
{
    public partial class ListaPublicacion : MaterialForm
    {
        DataTable tabla_publicaciones = new DataTable();
        List<PublicacionPuntual> publicaciones = new List<PublicacionPuntual>();
        public ListaPublicacion()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
           
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (data_publicaciones.SelectedRows.Count > 1)
            {
                MessageBox.Show("Debe seleccionar de a 1 registro", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                new EditarPublicacion(publicaciones[data_publicaciones.SelectedRows[0].Index]).Show();
                this.Hide();
            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
           // actualizarListado(PublicacionRepositorio.getPublicaciones(txt_titulo_pub.Text,dtpFechaPub.Value));
        }

        private void actualizarListado(List<Publicacion> publicaciones)
        {
            tabla_publicaciones.Rows.Clear();
            foreach (Publicacion publicacion in publicaciones)
            {
                String[] publicacionRow =
                {
                    publicacion.Descripcion
                };
                tabla_publicaciones.Rows.Add(publicacionRow);
            }
            data_publicaciones.DataSource = tabla_publicaciones;
        }
    }
}
