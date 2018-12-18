using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Listado_Estadistico
{
    public partial class ListadoEstadistico : MaterialForm

    {
        
        public ListadoEstadistico()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

        }
        private void initColumnsParaEmpresasConLocalidades()
        {
            tabla_clientes.Columns.Add("Tipo doc", typeof(string));
            tabla_clientes.Columns.Add("Documento", typeof(string));
            tabla_clientes.Columns.Add("Cuil", typeof(string));
            tabla_clientes.Columns.Add("Nombre", typeof(string));
            tabla_clientes.Columns.Add("Apellido", typeof(string));
            tabla_clientes.Columns.Add("Email", typeof(string));
            tabla_clientes.Columns.Add("Calle", typeof(string));
            tabla_clientes.Columns.Add("Numero", typeof(string));
            tabla_clientes.Columns.Add("Localidad", typeof(string));
            tabla_clientes.Columns.Add("Codigo postal", typeof(string));
            tabla_clientes.Columns.Add("Habilitado", typeof(string));
            actualizarTabla();
        }
        private void initColumnsParaClientesConMasPuntosVencidos()
        {
            tabla_clientes.Columns.Add("Tipo doc", typeof(string));
            tabla_clientes.Columns.Add("Documento", typeof(string));
            tabla_clientes.Columns.Add("Cuil", typeof(string));
            tabla_clientes.Columns.Add("Nombre", typeof(string));
            tabla_clientes.Columns.Add("Apellido", typeof(string));
            tabla_clientes.Columns.Add("Email", typeof(string));
            tabla_clientes.Columns.Add("Calle", typeof(string));
            tabla_clientes.Columns.Add("Numero", typeof(string));
            tabla_clientes.Columns.Add("Localidad", typeof(string));
            tabla_clientes.Columns.Add("Codigo postal", typeof(string));
            tabla_clientes.Columns.Add("Habilitado", typeof(string));
            actualizarTabla();
        }
        private void initColumnsParaClientesConMayorCantidadDeCompras()
        {
            tabla_clientes.Columns.Add("Tipo doc", typeof(string));
            tabla_clientes.Columns.Add("Documento", typeof(string));
            tabla_clientes.Columns.Add("Cuil", typeof(string));
            tabla_clientes.Columns.Add("Nombre", typeof(string));
            tabla_clientes.Columns.Add("Apellido", typeof(string));
            tabla_clientes.Columns.Add("Email", typeof(string));
            tabla_clientes.Columns.Add("Calle", typeof(string));
            tabla_clientes.Columns.Add("Numero", typeof(string));
            tabla_clientes.Columns.Add("Localidad", typeof(string));
            tabla_clientes.Columns.Add("Codigo postal", typeof(string));
            tabla_clientes.Columns.Add("Habilitado", typeof(string));
            actualizarTabla();
        }
    }
}
