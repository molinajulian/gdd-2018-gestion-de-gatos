using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MaterialSkin.Controls;
using MaterialSkin;
using PalcoNet.AbmPublicaciones;
using PalcoNet.Modelo;
using PalcoNet.Registro_de_usuario;
using PalcoNet.Repositorios;

namespace PalcoNet.Registro_de_Usuario
{
    public partial class MenuPpal : MaterialForm
    {
        Usuario user;
        private List<Funcionalidad> funcionalidadesPorRol;

        public MenuPpal(Usuario user)
        {
            InitializeComponent();
            this.user = user;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            configurarFuncionesParaElRol(user.rol);
        }

        private void inicializarFuncionalidadesPorRol(Rol rol)
        {
            funcionalidadesPorRol = RolRepositorio.buscarFuncionalidadesPorRol(rol);
        }

        public void configurarFuncionesParaElRol(Rol rol)
        {
            inicializarFuncionalidadesPorRol(rol);
            Dictionary<int, Button> funcionalidadPorBoton = getFuncionalidadPorBoton();
            foreach (Funcionalidad funcionalidad in funcionalidadesPorRol)
            {
                if (funcionalidadPorBoton.ContainsKey(funcionalidad.id))
                {
                    funcionalidadPorBoton[funcionalidad.id].Visible = true;
                }
            }

            if (tieneAlgunaFuncionalidadAbm(funcionalidadesPorRol))
            {
                btnABMs.Visible = true;
            }
        }

        private Boolean tieneAlgunaFuncionalidadAbm(List<Funcionalidad> funcionalidades)
        {
            foreach (Funcionalidad funcionalidad in funcionalidades)
            {
                if (funcionalidad.id >= 1 || funcionalidad.id <= 15)
                {
                    return true;
                }
            }
            return false;
        }

        private Dictionary<int, Button> getFuncionalidadPorBoton()
        {
           return new Dictionary<int, Button>()
            {
                {16  , btnGenerarPublicacion}, //GENERAR PUBLICACION
                {17  , btnEditarPublicacion}, //EDITAR PUBLICACION
                {18  , btnComprar}, //COMPRAR UBICACION
                {19  , btnHistorialCliente}, //HISTORIAL CLIENTE
                {20  , btnCanjeYAdminPuntos}, //CANJEAR Y ADMINISTRAR PUNTOS
                {21  , btnRegistroUsuario}, //REGISTRAR USUARIO
                {22  , btnPagoComisiones}, //PAGAR COMISIONES
                {23  , btnListadoEstadistico} //LISTADO ESTADISTICO
            };

        }

        private void MenuPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            //login.Close();
        }

        private void buttonABMs_Click(object sender, EventArgs e)
        {
            MenuABMs abms = new MenuABMs(funcionalidadesPorRol, this);
            abms.ShowDialog();
        }

        private void materialDivider1_Click(object sender, EventArgs e)
        {

        }

        private void MenuPpal_Load(object sender, EventArgs e)
        {
        }

        private void logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        
        private void buttonListadoEstadistico_Click(object sender, EventArgs e)
        {

        }

        private void buttonRegistroUsuario_Click(object sender, EventArgs e)
        {

        }

        private void buttonGenerarPublicacion_Click(object sender, EventArgs e)
        {
            GenerarPublicacion generarPublicacion = new GenerarPublicacion();
            generarPublicacion.ShowDialog();
        }

        private void buttonEditarPublicacion_Click(object sender, EventArgs e)
        {
            ListaPublicacion listaPublicacion = new ListaPublicacion();
            listaPublicacion.ShowDialog();
        }

        private void buttonComprar_Click(object sender, EventArgs e)
        {
            new Comprar.ElegirPublicacion().ShowDialog();

        }

        private void buttonHistorialCliente_Click(object sender, EventArgs e)
        {

        }

        private void buttonCanjeYAdminPuntos_Click(object sender, EventArgs e)
        {

        }

        private void buttonPagoComisiones_Click(object sender, EventArgs e)
        {

        }
    }
}
