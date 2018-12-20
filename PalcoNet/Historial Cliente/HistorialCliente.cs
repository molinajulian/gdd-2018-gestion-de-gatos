using MaterialSkin;
using MaterialSkin.Controls;
using PalcoNet.Modelo;
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
using System.Windows.Forms;
using PalcoNet.Repositorios;

namespace PalcoNet.Historial_Cliente
{
    public partial class HistorialCliente : MaterialForm
    {
        public HistorialCliente(Usuario usuario)
        {
            
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            Cliente cli = ClienteRepositorio.getCliente(usuario);
            int cantidad = CompraRepositorio.GetCantidadHistorial(Convert.ToInt32(cli.TipoDeDocumento.Id), cli.NumeroDocumento);
            List<CompraListado> historial = CompraRepositorio.GetHistorialCompra(Convert.ToInt32(cli.TipoDeDocumento.Id),cli.NumeroDocumento);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {

        }
    }
}
