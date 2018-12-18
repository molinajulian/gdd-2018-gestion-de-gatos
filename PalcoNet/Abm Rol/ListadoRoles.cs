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

namespace PalcoNet.AbmRol
{
    public partial class ListadoRoles : MaterialForm
    {
        DataTable tabla_roles = new DataTable();
        Char modo;
        Rol rol_actual;
        public ListadoRoles(char modo)
        {
            this.rol_actual = rol_actual;
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

            foreach(Rol rol in roles)
            {
                string[] row = { rol.nombre, rol.Habilitado ? "Si" : "No" };
                tabla_roles.Rows.Add(row);
            }

            refreshValues();
        }

        private void getRoles()
        {
            List <Rol> roles = RolRepositorio.getRoles(1);
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
        
        private void data_listado_roles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tabla_roles.Rows.Count == 0) return;

            var senderGrid = (DataGridView)sender;
            
            if(senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                int indice = e.RowIndex;
                DataGridViewRow row = data_listado_roles.Rows[indice];
                Rol rol = new Rol(Convert.ToInt32(row.Cells["Id"].Value), row.Cells["Nombre"].Value.ToString());
                rol.Habilitado = Convert.ToBoolean(row.Cells["Inhabilitado"].Value);
                if (modo.Equals('M')) modificarRol(rol);
                else bajarRol(rol.nombre, indice);
            }
        }

        private void modificarRol(Rol rol)
        {
            this.Hide();
            // new ModificacionRol(rol,this.menu).ShowDialog();
            tabla_roles.Rows.Clear();
            refreshValues();
            this.Show();
        }

        private void bajarRol(String nombre_rol, int indice)
        {
            RolRepositorio.deshabilitar(nombre_rol);
            tabla_roles.Rows[indice].Delete();
            refreshValues();
            if (nombre_rol == rol_actual.nombre) 
            {
                this.Hide();
                this.Close();
            }
        }
    }
}
