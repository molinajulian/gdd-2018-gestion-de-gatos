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

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class AltaEmpresa : MaterialForm
    {
        Empresa empresa = new Empresa();
        public AltaEmpresa()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            cargarRubros();
        }

        private void btn_alta_empresa_Click(object sender, EventArgs e)
        {
            grupo_empresa.Enabled = false;
            if (!verificaValidaciones())
            {
                grupo_empresa.Enabled = true;
                return;
            }

            empresa.habilitado = true;
            empresa.cuit = tx_tipo.Text + "-" + tx_cuit_numero.Text + "-" + tx_verificador.Text;
            empresa.nombre = tx_nombre.Text;
            empresa.direccion = tx_direccion.Text;
            empresa.rubro = ((Rubro)combo_rubros.SelectedItem).id;

            EmpresasRepositorio.agregar(empresa);
            limpiarVentana();
            MessageBox.Show("La empresa ha sido de alta exitosamente", "Alta de empresa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            grupo_empresa.Enabled = true;
        }

        private bool verificaValidaciones()
        {
            epProvider.Clear();
            if (!formularioCompleto())  return false ; 
            if (!verificaTiposDeDatos()) return false;

            if (EmpresasRepositorio.esEmpresaExistente(tx_tipo.Text + "-" + tx_cuit_numero.Text + "-" + tx_verificador.Text))
            {
                MessageBox.Show("Ya existe una empresa con el cuit ingresado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        private bool verificaTiposDeDatos()
        {
           
           if (!Regex.IsMatch(tx_tipo.Text, @"\d{2}$"))
           {
               MessageBox.Show("Ingrese un tipo para el cuit valido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return false;
           }

           if (!Regex.IsMatch(tx_cuit_numero.Text, @"\d{8}$"))
           {
               MessageBox.Show("Ingrese un numero para el cuit valido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return false;
           }

           if (!Regex.IsMatch(tx_verificador.Text, @"\d{1}$"))
           {
               MessageBox.Show("Ingrese un verificador para el cuit valido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return false;
           }
            
            if(!EmpresasRepositorio.verificaConformacionCuit(tx_tipo.Text + tx_cuit_numero.Text + tx_verificador.Text))
           {
               MessageBox.Show("Ingrese un cuit valido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
           }

            return true;
        }

       
        

        private bool formularioCompleto()
        {
            bool verifica = true;

             var controles =grupo_empresa.Controls;
             foreach (Control control in controles)
             {
                 if (string.IsNullOrWhiteSpace(control.Text))
                 {
                     epProvider.SetError(control, "Por favor complete el campo");
                     verifica = false;
                 }
             }
             return verifica;
        }

        private void limpiarVentana()
        {
            var textboxes = grupo_empresa.Controls.OfType<TextBox>();
            foreach (TextBox textbox in textboxes)
            {
                textbox.Clear();
            }
            var comboboxes = grupo_empresa.Controls.OfType<ComboBox>();
            foreach (ComboBox combo_box in comboboxes)
            {
                combo_box.ResetText();
            }
            

        }

        private void cargarRubros()
        {
            List<Rubro> rubros = RubrosRepositorio.getRubros();
            foreach (Rubro rubro in rubros)
            {
                combo_rubros.Items.Add(rubro);
            }
            
            combo_rubros.DisplayMember = "detalle";
        }

    }
}
