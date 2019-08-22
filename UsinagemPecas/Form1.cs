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

        int CodigoRegistro = 0;
        List<Pecas> listaPecas = new List<Pecas>();

        public Form1()
        {
            InitializeComponent();

            AtualizaGrid(listaPecas);
        }

        private void BtnPecaUm_Click(object sender, EventArgs e)
        {
            string CodigoUm = "XYq24";

            CodigoRegistro++;
            listaPecas.Add(new Pecas(CodigoRegistro, CodigoUm, DateTime.Now, DateTime.Now));

            AtualizaGrid(listaPecas);

        }

        private void BtnPecaDois_Click(object sender, EventArgs e)
        {
            var CodigoDois = "QSs12";

            CodigoRegistro++;
            listaPecas.Add(new Pecas(CodigoRegistro, CodigoDois, DateTime.Now, DateTime.Now));

            AtualizaGrid(listaPecas);

        }

        private void BtnPecaTres_Click(object sender, EventArgs e)
        {
            var CodigoTres = "WWz43";

            CodigoRegistro++;
            listaPecas.Add(new Pecas(CodigoRegistro, CodigoTres, DateTime.Now, DateTime.Now));

            AtualizaGrid(listaPecas);

        }

        private void BtnPecaQuatro_Click(object sender, EventArgs e)
        {
            var CodigoQuatro = "ACb33";

            CodigoRegistro++;
            listaPecas.Add(new Pecas(CodigoRegistro, CodigoQuatro, DateTime.Now, DateTime.Now));

            AtualizaGrid(listaPecas);

        }

        private void BtnPecaCinco_Click(object sender, EventArgs e)
        {
            var CodigoCinco = "KIm02";

            CodigoRegistro++;
            listaPecas.Add(new Pecas(CodigoRegistro, CodigoCinco, DateTime.Now, DateTime.Now));

            AtualizaGrid(listaPecas);

        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AtualizaGrid(List<Pecas> listaPecas)
        {
            dgvPecas.DataSource = null;
            dgvPecas.Rows.Clear();
            dgvPecas.Columns.Clear();
            dgvPecas.Refresh();

            if (listaPecas.Count > 0 || Equals(listaPecas, null))
            {
                dgvPecas.DataSource = listaPecas;

                dgvPecas.Columns[00].Width = 50;
                dgvPecas.Columns[00].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvPecas.Columns[00].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dgvPecas.Columns[01].Width = 153;
                dgvPecas.Columns[02].Width = 215;
                dgvPecas.Columns[03].Width = 215;
            }
            else
            {
                dgvPecas.Columns.Add("Peças", "Peças");
                dgvPecas.Rows.Add("Sem Nenhum Peça Usinada !");
                dgvPecas.Columns[00].Width = 633;
            }
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            listaPecas.Clear();
            AtualizaGrid(listaPecas);
        }
    }
}
