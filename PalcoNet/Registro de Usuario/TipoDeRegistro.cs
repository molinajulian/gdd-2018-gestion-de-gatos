using MaterialSkin;
using MaterialSkin.Controls;
using PalcoNet.Modelo;
using PalcoNet.Registro_de_usuario;
using PalcoNet.Registro_de_Usuario;
using PalcoNet.Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.AbmCliente;
using PalcoNet.AbmEmpresa;
using System.Windows.Forms;

namespace PalcoNet.Registro_de_usuario
{
    public partial class TipoDeRegistro : MaterialForm
    {
        public TipoDeRegistro()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            getRoles();
        }
        private void getRoles()
        {
            List<Rol> roles = new List<Rol>();
            combo_roles.Items.Clear();
            roles = RolRepositorio.getRoles();
            foreach (Rol rol in roles)
            {
                combo_roles.Items.Add(rol);
            }
            combo_roles.DisplayMember = "Nombre";
        }

        private void btn_rol_aceptado_Click(object sender, EventArgs e)
        {
            Rol seleccionado = (Rol)combo_roles.SelectedItem;
            if (seleccionado != null)
            {
                if (seleccionado.nombre == "CLIENTE")
                {
                    new AltaCliente(true).ShowDialog();
                }
                else
                {
                    new AltaEmpresa(true).ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Por favor complete todos los campos", "Advertencia.", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            

        }
    }
}
