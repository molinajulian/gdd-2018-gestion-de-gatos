using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PalcoNet.Modelo;
using MaterialSkin.Controls;
using MaterialSkin;
using PalcoNet.AbmDomicilio;
using PalcoNet.Repositorios;

namespace PalcoNet.AbmPublicaciones
{
    public partial class GenerarPublicacion : MaterialForm
    {
        List<Sector> sectoresRegistrados = new List<Sector>();
        private Domicilio domicilioElegido = null;
        private List<DateTime> fechasElegidas = new List<DateTime>();
        public GenerarPublicacion()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            inicializarGrados();
            inicializarRubros();
            inicializarEstados();
        }

        private void inicializarEstados()
        {
            foreach (EstadoPublicacion estadoPublicacion in EstadoPublicacionRepositorio.getEstados())
            {
                if (estadoPublicacion.Editable)
                {
                    cmbEstado.Items.Add(estadoPublicacion);
                }
            }
            cmbEstado.DisplayMember = "Descripcion";
            cmbEstado.ValueMember = "Id";
        }
        private void inicializarRubros()
        {
            foreach (Rubro rubro in RubroRepositorio.getRubros())
            {
                cmbRubro.Items.Add(rubro);
            }
            cmbRubro.DisplayMember = "Descripcion";
            cmbRubro.ValueMember = "Codigo";
        }

        private void inicializarGrados()
        {
            foreach (Grado grado in GradoRepositorio.getGrados())
            {
                cmbGrado.Items.Add(grado);
            }
            cmbGrado.DisplayMember = "Descripcion";
            cmbGrado.ValueMember = "Id";
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        

        private void group_alta_rol_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AltaSector altaSector = new AltaSector(sectoresRegistrados);
            altaSector.ShowDialog();
        }

        public Publicacion getPublicacionDeUi()
        {
            return new Publicacion(-1, txtDescripcion.Text,
                                    (Grado) cmbGrado.SelectedItem,
                                    (EstadoPublicacion) cmbEstado.SelectedItem,
                                    getEspectaculosPorFechaElegida(),
                                    sectoresRegistrados,
                                    UsuarioRepositorio.buscarUsuario(txtUsername.Text));
        }

        private List<Espectaculo> getEspectaculosPorFechaElegida()
        {
            List<Espectaculo> espectaculos = new List<Espectaculo>();
            foreach (DateTime fechaElegida in fechasElegidas)
            {
                espectaculos.Add(new Espectaculo(
                    -1,
                    txtEspectTitulo.Text,
                    fechaElegida,
                    dtpFechaVencimiento.Value,
                    (Rubro)cmbRubro.SelectedItem,
                    EmpresasRepositorio.GetEmpresaByUserId(Usuario.Actual.id),
                    domicilioElegido,
                    true));
            }
            return espectaculos;
        }

        private void btn_alta_publicacion_Click(object sender, EventArgs e)
        {
            if (!validarIngresos())
            {
                return;
            }
            PublicacionRepositorio.darAltaPublicacion(getPublicacionDeUi());
        }

        private bool validarIngresos()
        {
            if(camposIngresadosInsuficientes()){
                return false;
            }
            List<DateTime> fechasAComparar = new List<DateTime>(fechasElegidas);
            fechasAComparar.Add(dtpFechaVencimiento.Value);

            if (!dtpFechaVencimiento.Value.Equals(fechaMaxima(fechasAComparar)))
            {
                MessageBox.Show(
                    "La fecha de vencimiento de la publicacion es anterior a alguna de las funciones planificadas.");
                return false;
            }
            return true;
        }

        private DateTime fechaMaxima(List<DateTime> fechasAComparar)
        {
            DateTime max = DateTime.MinValue; // Start with the lowest value possible...
            foreach (DateTime fecha in fechasAComparar)
            {
                if (DateTime.Compare(fecha, max) == 1)
                    max = fecha;
            }
            return max;
        }

        private bool camposIngresadosInsuficientes()
        {
            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListadoDomicilios listadoDomicilios = new ListadoDomicilios(domicilioElegido);
            listadoDomicilios.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AltaFechas altaFechas = new AltaFechas(fechasElegidas);
            altaFechas.ShowDialog();
        }
    }
}
