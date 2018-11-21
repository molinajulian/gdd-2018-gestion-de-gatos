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
    public partial class AltaRol : MaterialForm
    {
        Rol rol = new Rol();
        DataTable tabla_funcionalidades = new DataTable();
        List<String> funcionalidades = new List<String>();
        public AltaRol()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            fillFuncionalidadesDgv();
        }

        private void fillFuncionalidadesDgv()
        {
            DataGridViewCheckBoxColumn check_funcionalidad = new DataGridViewCheckBoxColumn();
            tabla_funcionalidades.Columns.Add("Nombre");
            tabla_funcionalidades.Columns.Add("Descripcion");
            data_listado_funcionalidades.Columns.Add(check_funcionalidad);
            List<Funcionalidad> funcionalidades = FuncionalidadesRepositorio.getFuncionalidades();

            foreach (Funcionalidad funcionalidad in funcionalidades)
            {
                String[] row = new String[] { funcionalidad.Codigo.ToString(), funcionalidad.Detalle };
                tabla_funcionalidades.Rows.Add(row);
            }
            data_listado_funcionalidades.DataSource = tabla_funcionalidades;
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_alta_rol_Click(object sender, EventArgs e)
        {
            epProvider.Clear();
            if (validarCamposRol()) { return; }

            if (RolesRepositorio.esRolExistente(tx_nombre_rol.Text))
            {
                MessageBox.Show("Ya existe un rol con el nombre ingresado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            rol.Nombre = tx_nombre_rol.Text;
            rol.Habilitado = true;
            listarFuncionalidades();
            RolesRepositorio.agregar(rol,funcionalidades);
            funcionalidades.Clear();
            limpiarVentana();
        }

        private void limpiarVentana()
        {
            var textBoxes = group_alta_rol.Controls.OfType<TextBox>();
            foreach(TextBox textbox in textBoxes)
            {
                textbox.Clear();
            }

            foreach (DataGridViewRow row in data_listado_funcionalidades.Rows)
            {
                row.Cells[0].Value = false;
            }

        }

        private bool validarCamposRol()
        {
            bool error = false;
            bool tildoAlgunCheckBox = false;
            if (String.IsNullOrWhiteSpace(tx_nombre_rol.Text))
            {
                epProvider.SetError(tx_nombre_rol, "Por favor complete el campo");
                error = true;
            }
            foreach(DataGridViewRow row in data_listado_funcionalidades.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value)) { tildoAlgunCheckBox = true; } 
            }

            if (!tildoAlgunCheckBox)
            {
                epProvider.SetError(data_listado_funcionalidades, "Por favor seleccione alguna funcionalidad");
                error = true;
            }
            return error;
        }

        private void listarFuncionalidades()
        {
            foreach(DataGridViewRow row in data_listado_funcionalidades.Rows)
            {
                //if (Convert.ToBoolean(row.Cells[0].Value))
                //TODO: Probar si funciona igual
                if (row.Selected)
                {
                    funcionalidades.Add(Convert.ToString(row.Cells[1].Value));
                }
            }
        }
    }
}
