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
using PalcoNet.AbmCliente;
using PalcoNet.AbmGrado;
using PalcoNet.AbmEmpresa;
using PalcoNet.AbmRol;
using PalcoNet.Repositorios;

namespace PalcoNet.Registro_de_Usuario
{
    public partial class MenuABMs : MaterialForm
    {
        MenuPpal menuPpal;
        String actual;
        private List<Funcionalidad> funcionalidades;

        public MenuABMs(List<Funcionalidad> funcionalidades,MenuPpal menuPpal)
        {
            InitializeComponent();
            this.funcionalidades = funcionalidades;
            this.menuPpal = menuPpal;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
         
            configurarBotones();
        }
        private void ocultarBotones(){
            iconAlta.Hide();
            iconBaja.Hide();
            iconModificacion.Hide();
            buttonAltaEmpresa.Hide();
            buttonAltaGrado.Hide();
            buttonAltaCliente.Hide();
            buttonAltaRol.Hide();
            buttonBajaCliente.Hide();
            buttonBajaEmpresa.Hide();
            buttonBajaGrado.Hide();
            buttonBajaRol.Hide();
            buttonModificacionCliente.Hide();
            buttonModificacionEmpresa.Hide();
            buttonModificacionGrado.Hide();
            buttonModificacionRol.Hide();
        }
        private void mostrarBotonesRol()
        {
            iconAlta.Show();
            iconBaja.Show();
            iconModificacion.Show();
            buttonAltaRol.Show();
            buttonModificacionRol.Show();
            buttonBajaRol.Show();
        }
        private void mostrarBotonesGrado()
        {
            iconAlta.Show();
            iconBaja.Show();
            iconModificacion.Show();
            buttonAltaGrado.Show();
            buttonModificacionGrado.Show();
            buttonBajaGrado.Show();
        }
        private void mostrarBotonesEmpresa()
        {
            iconAlta.Show();
            iconBaja.Show();
            iconModificacion.Show();
            buttonAltaEmpresa.Show();
            buttonModificacionEmpresa.Show();
            buttonBajaEmpresa.Show();
        }
        private void mostrarBotonesCliente()
        {
            iconAlta.Show();
            iconBaja.Show();
            iconModificacion.Show();
            buttonAltaCliente.Show();
            buttonModificacionCliente.Show();
            buttonBajaCliente.Show();
        }

        private void configurarBotones()
        {
            Dictionary<int, Button> funcionalidadesPorBoton = getFuncionalidadesPorBoton();
            foreach (Funcionalidad funcionalidad in funcionalidades)
            {
                if(funcionalidadesPorBoton.ContainsKey(funcionalidad.id))
                {
                    funcionalidadesPorBoton[funcionalidad.id].Visible = true;
                    activarCategoriaAdecuada(funcionalidad);
                }
            }
        }

        private void activarCategoriaAdecuada(Funcionalidad funcionalidad)
        {
            switch (funcionalidad.id)
            {
                case 1:
                case 2:
                case 3:
                    buttonSidebarClientes.Visible = true;
                    break;
                case 4:
                case 5:
                case 6:
                    buttonSidebarEmpresas.Visible = true;
                    break;
                case 7:
                case 8:
                case 9:
                    buttonRoles.Visible = true;
                    break;
                case 13:
                case 14:
                case 15:
                    buttonSidebarGradoPublicacion.Visible = true;
                    break;
            }
        }

        private Dictionary<int, Button> getFuncionalidadesPorBoton()
        {
            return new Dictionary<int, Button>()
            {
                {1, buttonAltaCliente}, //CREAR CLIENTE
                {2, buttonModificacionCliente}, //EDITAR CLIENTE
                {3, buttonBajaCliente}, //ELIMINAR CLIENTE
                {4, buttonAltaEmpresa}, //CREAR EMPRESA
                {5, buttonModificacionEmpresa}, //EDITAR EMPRESA
                {6, buttonBajaEmpresa}, //ELIMINAR EMPRESA
                {7, buttonAltaRol}, //CREAR ROL
                {8, buttonModificacionRol}, //EDITAR ROL
                {9, buttonBajaRol}, //ELIMINAR ROL
                {13, buttonAltaGrado}, //CREAR GRADO PUBLICACION
                {14, buttonModificacionGrado}, //EDITAR GRADO PUBLICACION
                {15, buttonBajaGrado} //ELIMINAR GRADO PUBLICACION
            };
        }

        private void buttonModificacionRol_Click(object sender, EventArgs e)
        {
            new ListadoRoles('M').ShowDialog();
        }

        private void buttonRoles_Click(object sender, EventArgs e)
        {
            ocultarBotones();
            mostrarBotonesRol();
        }

        private void MenuABMs_Load(object sender, EventArgs e)
        {

        }

        private void buttonSidebarClientes_Click(object sender, EventArgs e)
        {
            ocultarBotones();
            mostrarBotonesCliente();
        }

        private void buttonSidebarEmpresas_Click(object sender, EventArgs e)
        {
            ocultarBotones();
            mostrarBotonesEmpresa();
        }

        private void buttonAltaCliente_Click(object sender, EventArgs e)
        {
            AltaCliente ac = new AltaCliente();
            ac.ShowDialog();
        }

        private void buttonSidebarCategorias_Click(object sender, EventArgs e)
        {
            ocultarBotones();
            
        }

        private void buttonSidebarGradoPublicacion_Click(object sender, EventArgs e)
        {
            ocultarBotones();
            mostrarBotonesGrado();
            actual = "Grado";
        }

        private void buttonModificacionEmpresa_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonModificacionCliente_Click(object sender, EventArgs e)
        {
            ListadoCliente lc = new ListadoCliente('M');
            lc.ShowDialog();
        }

        private void buttonModificacionGrado_Click(object sender, EventArgs e)
        {
            ListadoGrados lg = new ListadoGrados('M');
            lg.ShowDialog();
        }

        private void buttonBajaCliente_Click(object sender, EventArgs e)
        {
            ListadoCliente lc = new ListadoCliente('B');
            lc.ShowDialog();
        }

        private void buttonBajaRol_Click(object sender, EventArgs e)
        {
            new ListadoRoles('B').ShowDialog();
        }

        private void buttonBajaGrado_Click(object sender, EventArgs e)
        {
            ListadoGrados lg = new ListadoGrados('B');
            lg.ShowDialog();
        }

        private void buttonBajaEmpresa_Click(object sender, EventArgs e)
        {
            ListadoEmpresas me = new ListadoEmpresas("modo?");
            me.ShowDialog();
        }

        private void buttonAltaRol_Click(object sender, EventArgs e)
        {
            AltaRol ar = new AltaRol();
            ar.ShowDialog();
        }

        private void buttonAltaEmpresa_Click(object sender, EventArgs e)
        {
            AltaEmpresa ae = new AltaEmpresa();
            ae.ShowDialog();
        }

        private void buttonAltaGrado_Click(object sender, EventArgs e)
        {
            AltaGrado ag = new AltaGrado();
            ag.ShowDialog();
        }
        
    }
}
