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
    public partial class EditarPublicacion : MaterialForm
    {
        private Domicilio domicilioElegido = null;
        private DateTime fechaElegidas;
        private PublicacionPuntual PublicacionPuntual;
        public EditarPublicacion(PublicacionPuntual publicacionPuntual)
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            PublicacionPuntual = publicacionPuntual;
            inicializarUi();
        }

        private void inicializarUi()
        {
            txtDescripcion.Text = PublicacionPuntual.Descripcion;
            txtEspectTitulo.Text = PublicacionPuntual.Espectaculo.Descripcion;
            txtUsername.Text = PublicacionPuntual.Editor.username;
            dtpRealizacion.Value = PublicacionPuntual.Espectaculo.FechaOcurrencia;
            dtpVencimiento.Value = PublicacionPuntual.Espectaculo.FechaVencimiento;
            chkEspecDeshabilitado.Checked = !PublicacionPuntual.Espectaculo.Habilitado;
            inicializarGrados(PublicacionPuntual.Grado);
            inicializarRubros(PublicacionPuntual.Espectaculo.Rubro);
            inicializarEstados(PublicacionPuntual.Estado);
        }

        private void inicializarEstados(EstadoPublicacion estadoPublicacion)
        {
            List<EstadoPublicacion> estados = EstadoPublicacionRepositorio.getEstados();
            EstadoPublicacion estadoInicial = estados.Find(estado => estado.Id == estadoPublicacion.Id);
            foreach (EstadoPublicacion estado in estados)
            {
                if (estadoPublicacion.Editable)
                {
                    cmbEstado.Items.Add(estado);
                }
            }
            cmbEstado.DisplayMember = "Descripcion";
            cmbEstado.ValueMember = "Id";
            cmbEstado.SelectedItem = estadoInicial;
        }
        private void inicializarRubros(Rubro rubroPublicacion)
        {
            List<Rubro> rubros = RubroRepositorio.getRubros();
            Rubro rubroInicial = rubros.Find(rubro => rubro.Codigo == rubroPublicacion.Codigo);
            foreach (Rubro rubro in rubros)
            {
                cmbRubro.Items.Add(rubro);
            }
            cmbRubro.DisplayMember = "Descripcion";
            cmbRubro.ValueMember = "Codigo";
            cmbRubro.SelectedItem = rubroInicial;
        }

        private void inicializarGrados(Grado gradoPublicacion)
        {
            List<Grado> grados = GradoRepositorio.getGrados();
            Grado gradoInicial = grados.Find(grado => grado.Id == gradoPublicacion.Id);
            foreach (Grado grado in grados)
            {
                cmbGrado.Items.Add(grado);
            }
            cmbGrado.DisplayMember = "Descripcion";
            cmbGrado.ValueMember = "Id";
            cmbGrado.SelectedItem = gradoInicial;
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
            ListaSector listaSector = new ListaSector(PublicacionPuntual.getSectores());
            listaSector.ShowDialog();
        }

        public PublicacionPuntual getPublicacionDeUi()
        {
            return new PublicacionPuntual(
                                    PublicacionPuntual.Codigo,
                                    txtDescripcion.Text,
                                    (Grado) cmbGrado.SelectedItem,
                                    (EstadoPublicacion) cmbEstado.SelectedItem,
                                    getEspectaculoDeUi(PublicacionPuntual.Espectaculo),
                                    UsuarioRepositorio.buscarUsuario(txtUsername.Text),
                                    PublicacionPuntual.getSectores());
        }

        private Espectaculo getEspectaculoDeUi(Espectaculo espectaculoOriginal)
        {
            return new Espectaculo(
                        espectaculoOriginal.Id,
                        txtEspectTitulo.Text,
                        dtpRealizacion.Value,
                        dtpVencimiento.Value,
                        (Rubro)cmbRubro.SelectedItem,
                        espectaculoOriginal.Empresa,
                        domicilioElegido,
                        !chkEspecDeshabilitado.Checked);
        }

        private void btn_alta_publicacion_Click(object sender, EventArgs e)
        {
            if (!validarIngresos())
            {
                return;
            }
            PublicacionRepositorio.actualizarPublicacionPuntual(getPublicacionDeUi());
        }

        private bool validarIngresos()
        {
            if(camposIngresadosInsuficientes()){
                return false;
            }
            if (dtpVencimiento.Value.CompareTo(dtpRealizacion.Value) != 1)
            {
                MessageBox.Show(
                    "La fecha de vencimiento de la publicacion es anterior a alguna de las funciones planificadas.");
                return false;
            }
            return true;
        }

        private bool camposIngresadosInsuficientes()
        {
            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ModificarDomicilio modificarDomicilio = new ModificarDomicilio(PublicacionPuntual.Espectaculo.Domicilio);
            modificarDomicilio.ShowDialog();
        }
    }
}
