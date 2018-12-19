using System;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using PalcoNet.Modelo;
using PalcoNet.Repositorios;

namespace PalcoNet.AbmPublicaciones
{
    public partial class ListaPublicacion : MaterialForm
    {
        DataTable tabla_publicaciones = new DataTable();
        List<PublicacionPuntual> Publicaciones = new List<PublicacionPuntual>();
        public ListaPublicacion()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            tabla_publicaciones.Columns.Add("Descripcion", typeof(string));
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (data_publicaciones.SelectedRows.Count > 1)
            {
                MessageBox.Show("Debe seleccionar 1 y solo 1 registro", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                new EditarPublicacion(Publicaciones[data_publicaciones.SelectedRows[0].Index]).Show();
                limpiarTabla();
            }
        }

        private void limpiarTabla()
        {
            tabla_publicaciones.Rows.Clear();
            data_publicaciones.DataSource = tabla_publicaciones;
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
           actualizarListado(PublicacionRepositorio.getPublicacionesEditables(txt_titulo_pub.Text));
        }

        private void actualizarListado(List<PublicacionPuntual> publicaciones)
        {
            Publicaciones = publicaciones;
            tabla_publicaciones.Rows.Clear();
            foreach (PublicacionPuntual publicacion in publicaciones)
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
