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
        public MenuABMs(Usuario user,MenuPpal menuPpal)
        {
            this.user = user;
            this.menuPpal = menuPpal;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
         
        }
        
    }
}
