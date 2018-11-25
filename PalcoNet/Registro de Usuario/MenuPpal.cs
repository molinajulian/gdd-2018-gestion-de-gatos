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
using PalcoNet.Registro_de_usuario;

namespace PalcoNet.Registro_de_Usuario
{
    public partial class MenuPpal : MaterialForm
    {
        Usuario user;
        Log login;

        public MenuPpal(Usuario user,Log login)
        {
            InitializeComponent();
            this.user = user;
            this.login = login;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void MenuPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            //login.Close();
        }

        private void buttonABMs_Click(object sender, EventArgs e)
        {
            MenuABMs abms = new MenuABMs(user, this);
            abms.ShowDialog();
        }

        private void materialDivider1_Click(object sender, EventArgs e)
        {

        }

        private void MenuPpal_Load(object sender, EventArgs e)
        {
           /* if (!user.isAdmin())
            {
                buttonABMs.Hide();
            }*/
        }

        private void logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            login.ShowDialog();
            this.Close();
        }

        private void buttonSidebarRegistroUsuario_Click(object sender, EventArgs e)
        {

        }
    }
}
