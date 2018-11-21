using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;
using PalcoNet.Modelo;
using Palconet.Repositorios;

namespace Palconet.AbmRol
{
    public partial class ListadoRoles : MaterialForm
    {
        DataTable tabla_roles = new DataTable();
        Char modo;
        Rol rol_actual;
        Menu menu;
        public ListadoRoles(char modo, Menu menu, Rol rol_actual)
        {
            this.rol_actual = rol_actual;
            this.menu = menu;
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);


            this.modo = modo;

            tabla_roles.Columns.Add("Id");
            tabla_roles.Columns.Add("Nombre");
            tabla_roles.Columns.Add("Inhabilitado");

            DataGridViewButtonColumn btn_accion = new DataGridViewButtonColumn();

            if (modo.Equals('B'))
            {
                btn_accion.HeaderText = "Baja";
                btn_accion.Text = "Inhabilitar";
                btn_accion.Name = "btn_baja";
                btn_accion.UseColumnTextForButtonValue = true;
            }
            else
            {
                btn_accion.HeaderText = "Modificación";
                btn_accion.Text = "Modificar";
                btn_accion.Name = "btn_modificacion";
                btn_accion.UseColumnTextForButtonValue = true;
            }

            refreshValues();
            data_listado_roles.Columns.Add(btn_accion);
        }

        public void refreshValues()
        {
            data_listado_roles.DataSource = tabla_roles;
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            tabla_roles.Rows.Clear();
            List<Rol> roles = RolesRepositorio.getRoles(tx_nombre_rol.Text);

            foreach(Rol rol in roles)
            {
                String[] row = new String[] { Convert.ToString(rol.id), Convert.ToString(rol.nombre), Convert.ToString(rol.inhabilitado) };
                tabla_roles.Rows.Add(row);
            }

            refreshValues();
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void limpiarRoles()
        {
            tabla_roles.Rows.Clear();
            refreshValues();
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            this.limpiarRoles();
        }
        
        private void data_listado_roles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tabla_roles.Rows.Count == 0) return;

            var senderGrid = (DataGridView)sender;
            
            if(senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                int indice = e.RowIndex;
                DataGridViewRow row = data_listado_roles.Rows[indice];
                Rol rol = new Rol();
                rol.Nombre = row.Cells["Nombre"].Value.ToString();
                rol.Habilitado = Convert.ToBoolean(row.Cells["habilitado"].Value);

                if (modo.Equals('M')) modificarRol(rol);
                else bajarRol(rol.Nombre, indice);
            }
        }

        private void modificarRol(Rol rol)
        {
            this.Hide();
            new ModificacionRol(rol,this.menu).ShowDialog();
            tabla_roles.Rows.Clear();
            refreshValues();
            this.Show();
        }

        private void bajarRol(String nombre_rol, int indice)
        {
            RolesRepositorio.deshabilitar(nombre_rol);
            tabla_roles.Rows[indice].Delete();
            refreshValues();
            if (nombre_rol == rol_actual.Nombre) 
            {
                this.Hide();
                //this.menu.configurarBotones();
                this.Close();
            }
        }
    }
}
