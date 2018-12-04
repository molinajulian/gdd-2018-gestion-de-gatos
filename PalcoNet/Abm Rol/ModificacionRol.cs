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

namespace PalcoNet.AbmRol
{
    public partial class ModificacionRol : MaterialForm
    {
        Rol rol = new Rol();
        Menu menu;
        DataTable tabla_funcionalidades = new DataTable();
        List<String> funcionalidades_rol = new List<String>();
        public ModificacionRol(Rol rol_seleccionado, Menu menu)
        {
            this.menu = menu;
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            DataRow row;
            this.rol = rol_seleccionado;
            tx_nombre_rol.Text = rol.nombre;
            check_inhabilitado.Checked = rol.Habilitado;
            if (rol.Habilitado) check_inhabilitado.Enabled = true;
            else check_inhabilitado.Enabled = false;
            tabla_funcionalidades.Columns.Add(new DataColumn("Prueba", typeof(bool)));
            tabla_funcionalidades.Columns.Add("Detalle");
            tabla_funcionalidades.Columns.Add("Descripcion");
            List<Funcionalidad> funcionalidades = FuncionalidadesRepositorio.getFuncionalidades();

            foreach(Funcionalidad funcionalidad in funcionalidades)
            {
                row = tabla_funcionalidades.NewRow();
                row["Prueba"] = RolRepositorio.tieneFuncionalidad(rol.id,funcionalidad.detalle);
                row["Detalle"] = funcionalidad.detalle;
                row["Descripcion"] = funcionalidad.detalle;
                tabla_funcionalidades.Rows.Add(row);
            }

            data_funcionalidades_rol.DataSource = tabla_funcionalidades;        

        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            epProvider.Clear();
            if (validarCamposVacios()) return;

            rol.nombre = tx_nombre_rol.Text;
            rol.Habilitado = check_inhabilitado.Checked;
            listarFuncionalidades();

            RolRepositorio.modificarRol(rol, funcionalidades_rol);
            limpiarVentana();
            this.Hide();
            this.menu.configurarBotones();
        }

        private bool validarCamposVacios()
        {
            bool error = false;
            bool tildoAlgunCheckBox = false;
            if (String.IsNullOrWhiteSpace(tx_nombre_rol.Text))
            {
                epProvider.SetError(tx_nombre_rol, "Por favor complete el campo");
                error = true;
            }
            foreach (DataGridViewRow row in data_funcionalidades_rol.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value)) { tildoAlgunCheckBox = true; }
            }

            if (!tildoAlgunCheckBox)
            {
                epProvider.SetError(data_funcionalidades_rol, "Por favor seleccione alguna funcionalidad");
                error = true;
            }
            return error;
        }

        private void listarFuncionalidades()
        {
            foreach (DataGridViewRow row in data_funcionalidades_rol.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {
                    funcionalidades_rol.Add(Convert.ToString(row.Cells[1].Value));
                }
            }
        }

        private void limpiarVentana()
        {
            tx_nombre_rol.Clear();
        }

        private void group_rol_Enter(object sender, EventArgs e)
        {

        }
    }
}
