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
using PalcoNet.Abm_Empresa_Espectaculo;
using PalcoNet.AbmRol;

namespace PalcoNet.Registro_de_Usuario
{
    public partial class MenuABMs : MaterialForm
    {
        Usuario user;
        MenuPpal menuPpal;
        // Dictionary<int, Button> funcionalidadesPorBoton;
        String actual;

        public MenuABMs(Usuario user,MenuPpal menuPpal)
        {
            InitializeComponent();
            this.user = user;
            this.menuPpal = menuPpal;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
         
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


        private void initFuncionalidesPorBoton() {
           /*funcionalidadesPorBoton[1]=buttonAlta;
                                        {1   : buttonAlta}, //CREAR CLIENTE
                                        {2   : btn}, //EDITAR CLIENTE
                                        {3   : btn}, //ELIMINAR CLIENTE
                                        {4   : btn}, //CREAR EMPRESA
                                        {5   : btn}, //EDITAR EMPRESA
                                        {6   : btn}, //ELIMINAR EMPRESA
                                        {7   : btn}, //CREAR ROL
                                        {8   : btn}, //EDITAR ROL
                                        {9   : btn}, //ELIMINAR ROL
                                        {10  : btn}, //CREAR CATEGORIA
                                        {11  : btn}, //EDITAR CATEGORIA
                                        {12  : btn}, //ELIMINAR CATEGORIA
                                        {13  : btn}, //CREAR GRADO PUBLICACION
                                        {14  : btn}, //EDITAR GRADO PUBLICACION
                                        {15  : btn}, //ELIMINAR GRADO PUBLICACION*/
                                    

        }

        private void buttonModificacionRol_Click(object sender, EventArgs e)
        {

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
            ListadoGrados lg = new ListadoGrados();
            lg.ShowDialog();
        }

        private void buttonBajaCliente_Click(object sender, EventArgs e)
        {
            ListadoCliente lc = new ListadoCliente('B');
            lc.ShowDialog();
        }

        private void buttonBajaRol_Click(object sender, EventArgs e)
        {
            //ListadoRoles lr = new ListadoRoles();
            // lr.ShowDialog();
        }

        private void buttonBajaGrado_Click(object sender, EventArgs e)
        {
            ListadoGrados lg = new ListadoGrados();
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
