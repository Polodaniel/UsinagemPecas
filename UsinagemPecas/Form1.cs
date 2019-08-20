using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UsinagemPecas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnPecaUm_Click(object sender, EventArgs e)
        {
            var CodigoUm = "XYq24";
        }

        private void BtnPecaDois_Click(object sender, EventArgs e)
        {
            var CodigoDois = "QSs12";

        }

        private void BtnPecaTres_Click(object sender, EventArgs e)
        {
            var CodigoTres = "WWz43";

        }

        private void BtnPecaQuatro_Click(object sender, EventArgs e)
        {
            var CodigoQuatro = "ACb33";

        }

        private void BtnPecaCinco_Click(object sender, EventArgs e)
        {
            var CodigoCinco = "KIm02";

        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
