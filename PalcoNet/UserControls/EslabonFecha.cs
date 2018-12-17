using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet
{
    public partial class EslabonFecha : UserControl
    {
        public EslabonFecha(DateTime fechaMinima)
        {
            InitializeComponent();
            fechaPicker.MinDate = fechaMinima;
            fechaPicker.Value = fechaMinima;
            timePicker.MinDate = fechaMinima;
            timePicker.Value = fechaMinima.AddMinutes(1);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public DateTime getDateTimeElegido()
        {
            return fechaPicker.Value.Date + timePicker.Value.TimeOfDay;
        }
    }
}
