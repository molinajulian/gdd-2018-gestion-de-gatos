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
using System.Data.SqlClient;

namespace PalcoNet.AbmRol
{
    public partial class AltaRol : MaterialForm
    {
        Rol rol = new Rol();
        DataTable tabla_funcionalidades = new DataTable();
        List<Funcionalidad> funcionalidades;
        public AltaRol()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            this.funcionalidades = FuncionalidadesRepositorio.getFuncionalidades();
            llenarChecks();
        }
        private void llenarChecks()
        {
            var labels = group_alta_rol.Controls.OfType<Label>();
            foreach (Label label in labels)
            {
                if (label.Name != "labelNombre")
                {
                    int indexC = label.Name.IndexOf('c');
                    int id = Convert.ToInt32(label.Name.Substring(indexC + 1, label.Name.Length - (indexC+1)));
                    label.Text = funcionalidades[id - 1].detalle;
                }
            }
        }
        private List<Funcionalidad> obtenerFuncionalidadesElegidas()
        {
            var checkboxs = group_alta_rol.Controls.OfType<CheckBox>();
            List<Funcionalidad> elegidas= new List<Funcionalidad>();
            foreach (CheckBox ch in checkboxs)
            {
                int indexK = ch.Name.IndexOf('k');
                int id = Convert.ToInt32(ch.Name.Substring(indexK + 1, ch.Name.Length - (indexK + 1)));
                if (ch.Checked == true) elegidas.Add(funcionalidades[id - 1]);
            }
            return elegidas;
        }
        private void btn_alta_rol_Click(object sender, EventArgs e)
        {
            List<Funcionalidad> elegidas = obtenerFuncionalidadesElegidas();
            if (string.IsNullOrEmpty(tx_nombre_rol.Text) || elegidas.Count == 0)
            {
                MessageBox.Show("Complete el nombre y alguna funcionalidad.", "Error al crear el rol", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    rol.nombre = tx_nombre_rol.Text.ToUpper();
                    RolRepositorio.agregar(rol, elegidas);
                    limpiarVentana();
                    elegidas.Clear();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Error al crear el rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void limpiarVentana()
        {
            var textBoxes = group_alta_rol.Controls.OfType<TextBox>();
            foreach(TextBox textbox in textBoxes)
            {
                textbox.Clear();
            }
            var checkboxs = group_alta_rol.Controls.OfType<CheckBox>();
            foreach (CheckBox ch in checkboxs)
            {
                ch.Checked = false;
            }

        }

        private void AltaRol_Load(object sender, EventArgs e)
        {

        }

        private void group_alta_rol_Enter(object sender, EventArgs e)
        {

        }

        private void check8_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
