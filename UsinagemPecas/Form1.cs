using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UsinagemPecas
{
    public partial class Form1 : Form
    {

        int CodigoRegistro = 0;
        int Tempo = 0;
        string CodigoPeca = string.Empty;
        DateTime Data;
        List<Pecas> listaPecas = new List<Pecas>();
        //Thread t;

        public Form1()
        {
            InitializeComponent();

            AtualizaGrid(listaPecas);
        }

        private void BtnPecaUm_Click(object sender, EventArgs e)
        {
            string CodigoUm = "XYq24";

            Tempo = ColetaTempo(CodigoUm);
            CodigoPeca = CodigoUm;
            Data = DateTime.Now;

            UsinarPeca();

            //AtualizaGrid(listaPecas);
        }

        private void BtnPecaDois_Click(object sender, EventArgs e)
        {
            var CodigoDois = "QSs12";

            Tempo = ColetaTempo(CodigoDois);
            CodigoPeca = CodigoDois;
            Data = DateTime.Now;

            UsinarPeca();

            //AtualizaGrid(listaPecas);

        }

        private void BtnPecaTres_Click(object sender, EventArgs e)
        {
            var CodigoTres = "WWz43";

            Tempo = ColetaTempo(CodigoTres);
            CodigoPeca = CodigoTres;
            Data = DateTime.Now;

            UsinarPeca();

            //AtualizaGrid(listaPecas);

        }

        private void BtnPecaQuatro_Click(object sender, EventArgs e)
        {
            var CodigoQuatro = "ACb33";

            Tempo = ColetaTempo(CodigoQuatro);
            CodigoPeca = CodigoQuatro;
            Data = DateTime.Now;

            UsinarPeca();

            //AtualizaGrid(listaPecas);

        }

        private void BtnPecaCinco_Click(object sender, EventArgs e)
        {
            var CodigoCinco = "KIm02";

            Tempo = ColetaTempo(CodigoCinco);
            CodigoPeca = CodigoCinco;
            Data = DateTime.Now;

            UsinarPeca();

            //AtualizaGrid(listaPecas);

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

        private void UsinarPeca()
        {
            var t = new Thread(NovaThread);
            t.Start();

            //AtualizaGrid(listaPecas);
        }

        private void NovaThread()
        {
            var CodPeca = CodigoPeca;
            var DataInicio = Data;
            var TempoUsinagem = Tempo;

            Thread.Sleep((TempoUsinagem * 1000));

            CodigoRegistro++;
            listaPecas.Add(new Pecas(CodigoRegistro, CodPeca, DataInicio.ToString("dd/MM/yyyy hh:mm:ss tt"), DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")));
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            AtualizaGrid(listaPecas);
        }

        private int ColetaTempo(string Codigo)
        {
            return Convert.ToInt32(Codigo.Substring(3,2));
        }

    }
}
