using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PalcoNet.Modelo;
using MaterialSkin.Controls;
using MaterialSkin;

namespace PalcoNet.GenerarPublicacion
{
    public partial class AltaFechas : MaterialForm
    {
        private List<DateTime> FechasElegidas;
        public AltaFechas(List<DateTime> fechasElegidas)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            inicializarFlowPanel();
            FechasElegidas = fechasElegidas;
        }

        private void inicializarFlowPanel()
        {
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Add(
                new EslabonFecha(dateTimeDelUltimoEslabonCargado())
                {
                    Parent = flowLayoutPanel1
                });
        }

        private DateTime dateTimeDelUltimoEslabonCargado()
        {
            if (flowLayoutPanel1.Controls.Count == 0)
            {
                return DateTime.Now;
            }
            return ((EslabonFecha) flowLayoutPanel1.Controls[flowLayoutPanel1.Controls.Count - 1]).getDateTimeElegido();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (EslabonFecha eslabon in flowLayoutPanel1.Controls)
            {
                FechasElegidas.Add(eslabon.getDateTimeElegido());
            }

            MessageBox.Show("Fechas Elegidas Correctamente.", "Alta Fechas", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            this.Close();
        }
    }
}
