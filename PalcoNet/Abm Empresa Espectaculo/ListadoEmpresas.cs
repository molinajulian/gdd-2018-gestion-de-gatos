using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Modelo; 
using PalcoNet.Repositorios;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Text.RegularExpressions;
using PalcoNet.AbmEmpresa;
using PalcoNet.Abm_Empresa_Espectaculo;

namespace PalcoNet.AbmEmpresa
{
    public partial class ListadoEmpresas : MaterialForm
    {
        DataTable tabla_empresas = new DataTable();
        String modo;
        public ListadoEmpresas(String modo)
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);


            this.modo = modo;

            tabla_empresas.Columns.Add("Cuit", typeof(string));
            tabla_empresas.Columns.Add("Nombre", typeof(string));
            tabla_empresas.Columns.Add("Direccion", typeof(string));
            tabla_empresas.Columns.Add("Rubro", typeof(string));
            tabla_empresas.Columns.Add("Habilitacion", typeof(string));
            actualizarTablaEmpresas();
            this.cargarBotonLogico();

        }


        private void cargarBotonLogico()
        {

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();

            if (modo.Equals("baja"))
            {
                btn.HeaderText = "Baja";
                btn.Text = "Inhabilitar";
                btn.Name = "btn_baja";
                btn.UseColumnTextForButtonValue = true;
            }
            else
            {
                btn.HeaderText = "Modificacion";
                btn.Text = "Modificar";
                btn.Name = "btn_modificacion";
                btn.UseColumnTextForButtonValue = true;
            }
            
            // data_empresas.Columns.Add(btn);
        }

        /* private void cargarRubros()
        {
            List<Rubro> rubros = RubrosRepositorio.getRubros();
            foreach(Rubro rubro in rubros)
            {
                combo_rubros.Items.Add(rubro);
            }
            combo_rubros.DisplayMember = "detalle";
        } */


        private void btn_buscar_Click(object sender, EventArgs e)
        {
            if (!verificarAlgunIngreso()) return;
            if (!verificaTiposDatos()) return;

            tabla_empresas.Rows.Clear();
            List<Empresa> empresas = EmpresasRepositorio.getEmpresas(txt_razon_social.Text, txt_mail.Text, txt_cuit.Text);

            foreach (Empresa empresa in empresas)
            {
               
                String[] row = new String[] { empresa.RazonSocial, empresa.Email, empresa.Telefono,
                    Convert.ToString(empresa.Habilitada) };
                tabla_empresas.Rows.Add(row);
            }
            actualizarTablaEmpresas();

            if (empresas.Count == 0) MessageBox.Show("No se han encontrado resultados", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private bool verificarAlgunIngreso()
        {
            return txt_razon_social.Text != null || txt_mail != null || txt_cuit != null;
        }

        public bool verificaTiposDatos()
        {
            if (!Regex.IsMatch(txt_mail.Text, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$"))
            {
                MessageBox.Show("Ingrese un mail válido.");
                return false;
            }

            if (!Regex.IsMatch(txt_cuit.Text, @"[0-9]{2}-[0-9]{5,9}-[0-9]{1,2}$"))
            {
                MessageBox.Show("Ingrese un CUIT válido.");
                return false;
            }

            return true;
        }

        private void btn_atras_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            this.limpiarEmpresas();
        }

        private void limpiarEmpresas()
        {
            tabla_empresas.Rows.Clear();
            actualizarTablaEmpresas();
        }

     

        private void actualizarTablaEmpresas()
        {
            data_empresas.DataSource = tabla_empresas;

        }

        private void data_empresas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (tabla_empresas.Rows.Count == 0) return;
            
            if (tabla_empresas.Rows.Count < e.RowIndex + 1) return;
            if (e.ColumnIndex == 5 || e.ColumnIndex == 0)
            {
                int indice = e.RowIndex;
                DataGridViewRow row = data_empresas.Rows[indice];
                String empresa_cuit = row.Cells["Cuit"].Value.ToString();
                if (modo.Equals("modificacion")) modificarEmpresa(empresa_cuit);
                else bajarEmpresa(empresa_cuit, indice);
             
            }
        }

        private void modificarEmpresa(String empresa_cuit)
        {
            this.Hide();
            new PalcoNet.AbmEmpresa.ModificacionEmpresa(empresa_cuit).ShowDialog();
            tabla_empresas.Rows.Clear();
            actualizarTablaEmpresas();
            this.Show();
        }

        private void bajarEmpresa(String empresa_cuit,int indice)
        {
            if (!EmpresasRepositorio.esEmpresaHabilitada(empresa_cuit))
            {
                MessageBox.Show("La empresa ya se encuentra inhabilitada", "Inhabilitacion de empresa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                EmpresasRepositorio.deshabilitar(empresa_cuit);
            }
            catch (EmpresaNoRendidaError e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK,MessageBoxIcon.Error);
              
                return;
            }
            
           

            tabla_empresas.Rows[indice].Delete();
            actualizarTablaEmpresas();
            MessageBox.Show("La empresa ha sido inhabilitada exitosamente", "Inhabilitacion de empresa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tx_numero_cuit_TextChanged(object sender, EventArgs e)
        {

        }

        private void ListadoEmpresas_Load(object sender, EventArgs e)
        {

        }
    }
}
