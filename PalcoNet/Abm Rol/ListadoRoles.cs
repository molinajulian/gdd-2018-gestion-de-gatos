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
using PalcoNet.Repositorios;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Data.SqlClient;

namespace PalcoNet.AbmRol
{
    public partial class ListadoRoles : MaterialForm
    {
        DataTable tabla_roles = new DataTable();
        Char modo;
        List<Rol> roles = new List<Rol>();
        public ListadoRoles(char modo)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            this.modo = modo;
            tabla_roles.Columns.Add("Nombre");
            tabla_roles.Columns.Add("Habilitado");
            if (modo.Equals('B'))
            {
                buttonModificar.Hide();
            }
            else
            {
                buttonHabilitar.Hide();
            }
            getRoles();
            refreshValues();
        }

        public void refreshValues()
        {
            data_listado_roles.DataSource = tabla_roles;
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            tabla_roles.Rows.Clear();
            List<Rol> roles = RolRepositorio.getRoles(tx_nombre_rol.Text);

            foreach (Rol rol in roles)
            {
                string[] row = { rol.nombre, rol.Habilitado ? "Si" : "No" };
                tabla_roles.Rows.Add(row);
            }

            refreshValues();
        }

        private void getRoles()
        {
            roles = RolRepositorio.getRoles(1);
            foreach (Rol r in roles)
            {
                string[] row = { r.nombre, r.Habilitado ? "Si" : "No" };
                tabla_roles.Rows.Add(row);
            }
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            tabla_roles.Rows.Clear();
            refreshValues();
        }
        private void actualizarEstado(int indice, Rol rol)
        {
            string[] row = { rol.nombre, rol.Habilitado ? "Si" : "No" };
            data_listado_roles.Rows[indice].SetValues(row);
        }
        private bool chequearSeleccion(string message)
        {
            if (this.data_listado_roles.RowCount > 0)
            {
                if (data_listado_roles.SelectedRows.Count > 1)
                {
                    MessageBox.Show("Debe seleccionar de a 1 registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    try
                    {
                        if (this.data_listado_roles.SelectedRows.Count == 0)
                        {
                            MessageBox.Show("Por favor seleccione un rol.");
                            return false;
                        }
                        return true;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }
        private void buttonHabilitar_Click(object sender, EventArgs e)
        {
            if (!chequearSeleccion("Error al intentar cambiar el estado del rol")) return;
            int indiceSeleccionada = data_listado_roles.SelectedRows[0].Index;
            Rol seleccionada = roles[data_listado_roles.SelectedRows[0].Index];
            seleccionada.Habilitado = RolRepositorio.cambiarEstado(seleccionada);
            actualizarEstado(indiceSeleccionada, seleccionada);
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            if (!chequearSeleccion("Error al intentar modificar el grado")) return;
            int indiceSeleccionada = data_listado_roles.SelectedRows[0].Index;
            Rol seleccionada = roles[data_listado_roles.SelectedRows[0].Index];
            new ModificacionRol(seleccionada).ShowDialog();
        }
    }
}
