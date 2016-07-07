using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estacionamento.View
{
    public partial class ListarVagas : Form
    {
        public ListarVagas()
        {
            InitializeComponent();
        }

        private void ListarVagas_Load(object sender, EventArgs e)
        {

            


            vendasCompletoTableAdapter1.Fill(dsBanco.VendasCompleto, 1);
            this.reportViewer1.RefreshReport();


        }

    }
}
