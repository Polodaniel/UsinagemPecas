using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UsinagemPecas
{
    public partial class Form1 : Form
    {
        public CancellationTokenSource ThreadSourceToken { get; private set; }
        public CancellationToken ThreadToken
        {
            get { return ThreadSourceToken.Token; }
        }
        delegate void ThreadCallback();

        public bool GridAtualizadaSemDados { get; private set; }

        public ObservableCollection<Peca> ListaPecas { get; private set; }

        public Form1()
        {
            ThreadSourceToken = new CancellationTokenSource();
            ListaPecas = new ObservableCollection<Peca>();
            GridAtualizadaSemDados = false;
            InitializeComponent();
            Torno.LigarTorno();
            RunAtualizaGrid();
        }

        #region Botoes Ações

        private void BtnPecaUm_Click(object sender, EventArgs e)
        {
            var peca = new Peca(PecaEnum.XYq24, TimeSpan.FromSeconds(24));
            Torno.FilaFabricacao.Add(peca);
        }

        private void BtnPecaDois_Click(object sender, EventArgs e)
        {
            var peca = new Peca(PecaEnum.QSs12, TimeSpan.FromSeconds(12));
            Torno.FilaFabricacao.Add(peca);
        }

        private void BtnPecaTres_Click(object sender, EventArgs e)
        {
            var peca = new Peca(PecaEnum.WWz43, TimeSpan.FromSeconds(43));
            Torno.FilaFabricacao.Add(peca);
        }

        private void BtnPecaQuatro_Click(object sender, EventArgs e)
        {
            var peca = new Peca(PecaEnum.ACb33, TimeSpan.FromSeconds(43));
            Torno.FilaFabricacao.Add(peca);
        }

        private void BtnPecaCinco_Click(object sender, EventArgs e)
        {
            var peca = new Peca(PecaEnum.KIm02, TimeSpan.FromSeconds(43));
            Torno.FilaFabricacao.Add(peca);
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            Torno.DesligarTorno();
            this.Close();
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
        }

        private void Button1_Click(object sender, EventArgs e)
        {
        }

        #endregion

        private void RunAtualizaGrid()
        {
            Task.Run(() =>
            {
                while (!ThreadToken.IsCancellationRequested)
                {
                    if (!ThreadToken.IsCancellationRequested)
                        Task.Delay(TimeSpan.FromSeconds(1)).Wait(ThreadToken);

                    if (!ThreadToken.IsCancellationRequested)
                    {
                        ThreadCallback callback = new ThreadCallback(AtualizaGrid);
                        this.Invoke(callback);
                    }
                }
            }, ThreadToken);
        }

        public void AtualizaGrid()
        {
            if (AtualizaListaPecas())
            {
                dgvPecas.DataSource = null;
                dgvPecas.Rows.Clear();
                dgvPecas.Columns.Clear();
                dgvPecas?.Refresh();

                dgvPecas.DataSource = ListaPecas;

                dgvPecas.Columns[00].Width = 50;
                dgvPecas.Columns[00].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvPecas.Columns[00].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dgvPecas.Columns[01].Width = 153;
                dgvPecas.Columns[02].Width = 215;
                dgvPecas.Columns[03].Width = 215;

                
            }
            else if(!GridAtualizadaSemDados)
            {
                GridAtualizadaSemDados = true;

                dgvPecas.DataSource = null;
                dgvPecas.Rows.Clear();
                dgvPecas.Columns.Clear();
                dgvPecas?.Refresh();

                dgvPecas.Columns.Add("Peças", "Peças");
                dgvPecas.Rows.Add("Sem Nenhum Peça Usinada !");
                dgvPecas.Columns[00].Width = 633;

                
            }
        }

        public bool AtualizaListaPecas()
        {
            if (Torno.TodasPecas.Any())
            {
                if (!ListaPecas.Any())
                {
                    ListaPecas = new ObservableCollection<Peca>(Torno.TodasPecas);
                    return true;
                }
                else
                {
                    var listaTorno = Torno.TodasPecas.Select(l => new { l.Id }).ToList();
                    var listaForm = ListaPecas.Select(r => new { r.Id }).ToList();
                    if (listaTorno.Except(listaForm).Any())
                    {
                        ListaPecas = new ObservableCollection<Peca>(Torno.TodasPecas);
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
