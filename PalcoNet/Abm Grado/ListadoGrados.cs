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
using PalcoNet.AbmRol;
using System.Data.SqlClient;

namespace PalcoNet.AbmGrado
{
    public partial class ListadoGrados : MaterialForm
    {
        DataTable tabla_grados = new DataTable();
        List<Grado> grados = new List<Grado>();
        Char modo;
        public ListadoGrados(char modo)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            this.modo = modo;
            if (modo =='B')
            {
                btn_modificar.Hide();
            }
            else
            {
                buttonHabilitar.Hide();
            }
            initColumns();
            getGrados();
            refreshValues();
        }
        private void initColumns()
        {
            tabla_grados.Columns.Add("Descripcion");
            tabla_grados.Columns.Add("Porcentaje");
            tabla_grados.Columns.Add("Habilitado");
        }
        private void getGrados()
        {
           grados = GradoRepositorio.getGrados();
           foreach (Grado g in grados)
           {
               string[] row = { g.Descripcion,(g.Comision*100).ToString(), g.Habilitado ? "Si" : "No" };
               tabla_grados.Rows.Add(row);
           }
        }
        public ListadoGrados()
        {
            // TODO: Complete member initialization
        }

        public void refreshValues()
        {
            data_listado_grados.DataSource = tabla_grados;
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            tabla_grados.Rows.Clear();
            List<Grado> grados = GradoRepositorio.getGrados(txtDescripcion.Text);

            foreach (Grado g in grados)
            {
                string[] row = { g.Descripcion, (g.Comision * 100).ToString(), g.Habilitado ? "Si" : "No" };
                tabla_grados.Rows.Add(row);
            }
            refreshValues();
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void limpiarGrados()
        {
            tabla_grados.Rows.Clear();
            refreshValues();
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            this.limpiarGrados();
        }
        

        private void tx_nombre_rol_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (this.data_listado_grados.RowCount > 0)
            {
                if (data_listado_grados.SelectedRows.Count > 1)
                {
                    MessageBox.Show("Debe seleccionar de a 1 registro", "Advertencia", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        if (this.data_listado_grados.SelectedRows.Count == 0)
                        {
                            MessageBox.Show("Por favor seleccione un grado.");
                        }
                        else
                        {
                            int indiceSeleccionada = data_listado_grados.SelectedRows[0].Index;
                            Grado seleccionada = grados[data_listado_grados.SelectedRows[0].Index];
                            new ModificacionGrado(seleccionada).ShowDialog();
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Error al intentar modificar el grado", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Busque y seleccione un cliente antes.");
            }
        }
        private void actualizarEstado(int indice,Grado g)
        {
            string[] row = { g.Descripcion, (g.Comision * 100).ToString(), g.Habilitado ? "Si" : "No" };
            data_listado_grados.Rows[indice].SetValues(row);
        }
        private void buttonHabilitar_Click(object sender, EventArgs e)
        {
            if (this.data_listado_grados.RowCount > 0)
            {
                if (data_listado_grados.SelectedRows.Count > 1)
                {
                    MessageBox.Show("Debe seleccionar de a 1 registro", "Advertencia", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        if (this.data_listado_grados.SelectedRows.Count == 0)
                        {
                            MessageBox.Show("Por favor seleccione un grado.");
                        }
                        else
                        {
                            int indiceSeleccionada = data_listado_grados.SelectedRows[0].Index;
                            Grado seleccionada = grados[data_listado_grados.SelectedRows[0].Index];
                            seleccionada.Habilitado =GradoRepositorio.cambiarEstado(seleccionada);
                            actualizarEstado(indiceSeleccionada,seleccionada);
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Error al intentar modificar el estado del grado", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
            }            
        }

        private void data_listado_grados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
