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
/*
using PagoAgilFrba.Modelo;
using PagoAgilFrba.AbmCliente;
using PagoAgilFrba.AbmEmpresa;
using PagoAgilFrba.AbmFactura;
using PagoAgilFrba.Devoluciones;
using PagoAgilFrba.Pagos;
using PagoAgilFrba.ListadoEstadistico;
using PagoAgilFrba.AbmSucursal;
using PagoAgilFrba.AbmRol;
using PagoAgilFrba.Repositorios;*/

namespace PalcoNet.Registro_de_Usuario
{
    public partial class MenuABMs : MaterialForm
    {
        Usuario user;
        MenuPpal menuPpal;
        Boolean pagos=false;
        Boolean devoluciones = false;
        Boolean rendiciones = false;
        Dictionary<int, Button> funcionalidadesPorBoton;
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

        private void initFuncionalidesPorBoton() {
                                        
           /* funcionalidadesPorBoton = new Dictionary<int,Button> {
                                        {1   : btn}, //CREAR CLIENTE
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
                                        {15  : btn}, //ELIMINAR GRADO PUBLICACION
                                    };*/

        }

        private void buttonModificacion_Click(object sender, EventArgs e)
        {

        }

        private void buttonRoles_Click(object sender, EventArgs e)
        {

        }

        private void MenuABMs_Load(object sender, EventArgs e)
        {

        }
        
    }
}
