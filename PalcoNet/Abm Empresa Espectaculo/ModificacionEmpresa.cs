using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Repositorios;
using PalcoNet.Modelo;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Text.RegularExpressions;

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class ModificacionEmpresa : MaterialForm
    {
        Empresa empresa = new Empresa();
       
        public ModificacionEmpresa(String cuit)
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

           empresa = EmpresasRepositorio.getEmpresa(cuit);
           cargarRubros();

           tx_cuit_numero.Text = empresa.cuit;
           tx_nombre.Text = empresa.nombre.ToString();
           tx_direccion.Text = empresa.direccion;
           combo_rubros.Text = empresa.rubro.ToString();

           if (empresa.Habilitado)
           {
               check_box_habilitacion.Checked = true;
               check_box_habilitacion.Enabled = false;
           }
           else
           {
               check_box_habilitacion.Checked = false;
               check_box_habilitacion.Enabled = true;
           }
        }

        private void cargarRubros()
        {
            List<Rubro> rubros = RubrosRepositorio.getRubros();
            foreach (Rubro rubro in rubros)
            {
                combo_rubros.Items.Add(rubro);
            }
            combo_rubros.DisplayMember = "id";
        }

        private void btn_modificar_empresa_Click(object sender, EventArgs e)
        {
            if (!verificaValidaciones()) return;
            
            empresa.habilitado = check_box_habilitacion.Checked;
            empresa.cuit = tx_cuit.Text;
            empresa.nombre = tx_nombre.Text;
            empresa.Direccion = tx_direccion.Text;
            empresa.rubro = Convert.ToInt32(combo_rubros.Text);

            EmpresasRepositorio.modificar(empresa);
            limpiarVentana();
            MessageBox.Show("La empresa ha sido modificada exitosamente", "Modificacion de empresa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool verificaValidaciones()
        {
            errorProvider1.Clear();
            if (!formularioCompleto()) return false;
           

            return true;
        }

       
        private void btn_atras_Click(object sender, EventArgs e)
        {
            this.Hide();
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
         private bool formularioCompleto()
         {
             bool error = true;

             var controles = grupo_empresa.Controls;
             foreach (Control control in controles)
             {
                 if (string.IsNullOrWhiteSpace(control.Text))
                 {
                     errorProvider1.SetError(control, "Por favor complete el campo");
                     error = false;
                 }
             }
             return error;
         }   
    }
}
