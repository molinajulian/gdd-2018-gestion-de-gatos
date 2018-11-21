using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MaterialSkin;
using PalcoNet.Modelo;

using PalcoNet.Repositorios;
using MaterialSkin.Controls;
using Palconet.AbmCliente;
using Palconet.AbmRol;

namespace PalcoNet.Login_e_Inicio
{
    public partial class Menu : MaterialForm
    {
      /*  Usuario user;
        Log login;
        Boolean pagos=false;
        Boolean devoluciones = false;
        Boolean rendiciones = false;
        public Menu(Usuario user, Log login)
        {
            InitializeComponent();
            this.user = user;
            this.login = login;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            materialDivider2.BackColor = Color.FromArgb(255, 255, 255);
            materialDivider3.BackColor = Color.FromArgb(255, 255, 255);
            materialDivider1.BackColor = Color.FromArgb(51,71,79);
            ocultarBotonesSide();
            ocultarTodo();
            configurarBotones();
        }

        private void ocultarBotonesSide()
        {
            buttonSidebarListados.Hide();
            buttonSidebarOperaciones.Hide();
            buttonSidebarRoles.Hide();
            buttonSidebarSucursales.Hide();
            buttonSidebarFacturas.Hide();
            buttonSidebarEmpresas.Hide();
            buttonSidebarClientes.Hide();
        }

        public void configurarBotones()
        {
            ocultarBotonesSide();
            ocultarTodo();
            List<String> funcionalidades = new List<string>();
            //funcionalidades = RolesRepositorio.getFuncionalidades(this.user.RolUsuario);
            if (funcionalidades == null)
            {
                MessageBox.Show("Su Rol ha sido inhabilitado. Por favor inicie sesión nuevamente.");
                object sender= new object();
                EventArgs e = new EventArgs();
                logout_Click(sender, e);
            }
            else
            {
                foreach (String funcion in funcionalidades)
                {
                    switch (funcion)
                    {
                        case "ABMROL":
                            buttonSidebarRoles.Show();
                            break;
                        case "ABMCLI":
                            buttonSidebarClientes.Show();
                            break;
                        case "ABMEMP":
                            buttonSidebarEmpresas.Show();
                            break;
                        case "ABMSUC":
                            buttonSidebarSucursales.Show();
                            break;
                        case "ABMFAC":
                            buttonSidebarFacturas.Show();
                            break;
                        case "DEV":
                            buttonSidebarOperaciones.Show();
                            this.devoluciones = true;
                            break;
                        case "REGPAGFAC":
                            buttonSidebarOperaciones.Show();
                            this.pagos = true;
                            break;
                        case "RENFACCOB":
                            buttonSidebarOperaciones.Show();
                            this.rendiciones = true;
                            break;
                        case "LISTEST":
                            buttonSidebarListados.Show();
                            break;
                    }
                }
            }
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            ocultarTodo();
            iconClientes.Show();
            textoClientes.Show();
            iconAltaClientes.Show();
            iconBaja.Show();
            iconModificacion.Show();
            buttonAltaClientes.Show();
            buttonBajaClientes.Show();
            buttonModificacionClientes.Show();

        }

        private void ocultarTodo()
        {
            //Clientes
            textoClientes.Hide();
            iconClientes.Hide();
            iconAltaClientes.Hide();
            buttonAltaClientes.Hide();
            buttonBajaClientes.Hide();
            buttonModificacionClientes.Hide();
            //Iconos ABMs
            iconAlta.Hide();
            iconBaja.Hide();
            iconModificacion.Hide();
            //Empresas
            textoEmpresas.Hide();
            iconEmpresas.Hide();
            buttonAltaEmpresa.Hide();
            buttonBajaEmpresa.Hide();
            buttonModificacionEmpresa.Hide();
            //Facturas
            textoFacturas.Hide();
            iconFacturas.Hide();
            buttonBajaFactura.Hide();
            buttonAltaFactura.Hide();
            buttonModificacionFactura.Hide();
            //Listados
            textoListados.Hide();
            iconListados.Hide();
            iconPagosTotales.Hide();
            iconMontoRendido.Hide();
            iconFacturasPagadas.Hide();
            iconFacturasCobradas.Hide();
            buttonPagosTotales.Hide();
            buttonMontoRendido.Hide();
            buttonFacturasPagadas.Hide();
            buttonFacturasCobradas.Hide();
            //Sucursales
            textoSucursales.Hide();
            iconSucursales.Hide();
            buttonBajaSucursal.Hide();
            buttonAltaSucursal.Hide();
            buttonModificacionSucursal.Hide();
            //Operaciones
            textoOperaciones.Hide();
            iconOperaciones.Hide();
            iconRegistroPago.Hide();
            iconRendicionFacturas.Hide();
            iconDevolucionFactura.Hide();
            buttonRegistroPagos.Hide();
            buttonRendicionFacturas.Hide();
            buttonDevolucionFacturas.Hide();
            // Roles
            iconRoles.Hide();
            textoRoles.Hide();
            buttonAltaRoles.Hide();
            buttonBajaRoles.Hide();
            buttonModificacionRoles.Hide();
        }

        private void buttonSidebarOperaciones_Click(object sender, EventArgs e)
        {
            ocultarTodo();
            iconOperaciones.Show();
            textoOperaciones.Show();
            if (this.pagos)
            {
                iconRegistroPago.Show();
                buttonRegistroPagos.Show();
            }
            if (this.rendiciones)
            {
                iconRendicionFacturas.Show();
                buttonRendicionFacturas.Show();
            }
            if (this.devoluciones)
            {
                iconDevolucionFactura.Show();
                buttonDevolucionFacturas.Show();
            }
        }

        private void buttonSidebarEmpresas_Click(object sender, EventArgs e)
        {
            ocultarTodo();
            iconEmpresas.Show();
            textoEmpresas.Show();
            iconAlta.Show();
            buttonAltaEmpresa.Show();
            iconBaja.Show();
            buttonBajaEmpresa.Show();
            iconModificacion.Show();
            buttonModificacionEmpresa.Show();
        }

        private void buttonSidebarFacturas_Click(object sender, EventArgs e)
        {
            ocultarTodo();
            iconFacturas.Show();
            textoFacturas.Show();
            iconAlta.Show();
            buttonAltaFactura.Show();
            iconBaja.Show();
            buttonBajaFactura.Show();
            iconModificacion.Show();
            buttonModificacionFactura.Show();
        }

        private void buttonSidebarSucursales_Click(object sender, EventArgs e)
        {
            ocultarTodo();
            iconSucursales.Show();
            textoSucursales.Show();
            iconAlta.Show();
            buttonAltaSucursal.Show();
            iconBaja.Show();
            buttonBajaSucursal.Show();
            iconModificacion.Show();
            buttonModificacionSucursal.Show();
        }

        private void buttonSidebarListados_Click(object sender, EventArgs e)
        {
            ocultarTodo();
            iconListados.Show();
            textoListados.Show();
            iconFacturasCobradas.Show();
            iconFacturasPagadas.Show();
            iconMontoRendido.Show();
            iconPagosTotales.Show();
            buttonFacturasCobradas.Show();
            buttonFacturasPagadas.Show();
            buttonMontoRendido.Show();
            buttonPagosTotales.Show();
        }

        private void buttonAltaClientes_Click(object sender, EventArgs e)
        {
            (new AltaCliente()).Show();
            colorearDividers();
        }

        

        private void buttonAltaEmpresa_Click(object sender, EventArgs e)
        {
            (new AltaEmpresa()).Show();
            colorearDividers();
        }

        private void buttonBajaEmpresa_Click(object sender, EventArgs e)
        {
            (new ListadoEmpresas("baja")).Show();
            colorearDividers();
        }

        private void buttonModificacionEmpresa_Click(object sender, EventArgs e)
        {
            (new ListadoEmpresas("modificacion")).Show();
            colorearDividers();
        }

        private void buttonAltaFactura_Click(object sender, EventArgs e)
        {
            (new AltaFactura()).Show();
            colorearDividers();
        }

        private void buttonBajaFactura_Click(object sender, EventArgs e)
        {
            (new ListadoFacturas("baja")).Show();
            colorearDividers();
        }

        private void buttonModificacionFactura_Click(object sender, EventArgs e)
        {
            (new ListadoFacturas("modificacion")).Show();
            colorearDividers();
        }

        private void buttonAltaSucursal_Click(object sender, EventArgs e)
        {
            (new AltaSucursal()).Show();
            colorearDividers();
        }

        private void buttonBajaSucursal_Click(object sender, EventArgs e)
        {
            (new ListadoSucursales('B')).Show();
            colorearDividers();
        }

        private void buttonModificacionSucursal_Click(object sender, EventArgs e)
        {
            (new ListadoSucursales('M')).Show();
            colorearDividers();
        }

        private void buttonDevolucionFacturas_Click(object sender, EventArgs e)
        {
            new RegistroDevolucion().Show();
            colorearDividers();
        }

        private void buttonRegistroPagos_Click(object sender, EventArgs e)
        {
            new RegistroPago(this.user).Show();
            colorearDividers();

        }

        private void colorearDividers()
        {
            materialDivider2.BackColor = Color.FromArgb(255, 255, 255);
            materialDivider3.BackColor = Color.FromArgb(255, 255, 255);
            materialDivider1.BackColor = Color.FromArgb(51, 71, 79);
        }

        private void buttonRendicionFacturas_Click(object sender, EventArgs e)
        {
            new Rendicion.Rendicion().Show();
            colorearDividers();
        }

        private void buttonFacturasCobradas_Click(object sender, EventArgs e)
        {
            (new Listados(4)).Show();
            colorearDividers();
        }

        private void buttonMontoRendido_Click(object sender, EventArgs e)
        {
            (new Listados(3)).Show();
            colorearDividers();
        }

        private void buttonPagosTotales_Click(object sender, EventArgs e)
        {
            (new Listados(1)).Show();
            colorearDividers();
        }

        private void buttonFacturasPagadas_Click(object sender, EventArgs e)
        {
            (new Listados(2)).Show();
            colorearDividers();
        }

        private void buttonSidebarRoles_Click(object sender, EventArgs e)
        {
            ocultarTodo();
            iconRoles.Show();
            textoRoles.Show();
            iconAlta.Show();
            iconBaja.Show();
            iconModificacion.Show();
            buttonAltaRoles.Show();
            buttonBajaRoles.Show();
            buttonModificacionRoles.Show();
        }

        private void buttonAltaRoles_Click(object sender, EventArgs e)
        {
            (new AltaRol()).Show();
            colorearDividers();
        }

        private void buttonBajaRoles_Click(object sender, EventArgs e)
        {
            (new ListadoRoles('B',this,this.user.RolUsuario)).Show();
            colorearDividers();
        }

        private void buttonModificacionRoles_Click(object sender, EventArgs e)
        {
            (new ListadoRoles('M',this,this.user.RolUsuario)).Show();
            ocultarTodo();
            colorearDividers();
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            login.Close();
        }

        private void buttonBajaClientes_Click(object sender, EventArgs e)
        {
            (new ListadoCliente('B')).Show();
            colorearDividers();
        }

        private void buttonModificacionClientes_Click(object sender, EventArgs e)
        {
            (new ListadoCliente('M')).Show();
            colorearDividers();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            login.Show();
            this.Hide();
        }

        private void Menu_MouseMove(object sender, MouseEventArgs e)
        {
            colorearDividers();
        }

        private void Menu_SystemColorsChanged(object sender, EventArgs e)
        {
            colorearDividers();
        }

        private void Menu_Shown(object sender, EventArgs e)
        {
            configurarBotones();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void materialDivider2_Click(object sender, EventArgs e)
        {

        }
     */   
    }
}
