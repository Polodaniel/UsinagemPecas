using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UsinagemPecas.Annotations;

namespace UsinagemPecas
{
    public class Peca : INotifyPropertyChanged
    {
        public Peca(PecaEnum codigo, TimeSpan tempoFabricacao)
        {
            Id = Guid.NewGuid();
            Codigo = codigo;
            Nome = codigo.GetDescription();
            TempoFabricacao = tempoFabricacao;
        }

        private delegate void ThreadCallback();

        public Guid Id { get; private set; }

        [DisplayName("Cód. Peças")]
        public PecaEnum Codigo { get; set; }

        public string Nome { get; set; }

        [DisplayName("Tempo Fabricação")]
        public TimeSpan TempoFabricacao { get; set; }

        private DateTime? _dataInicio;
        [DisplayName("Data Ínicio")]
        public DateTime? DataInicio
        {
            get { return _dataInicio;}
            private set
            {
                _dataInicio = value;
                OnPropertyChanged(nameof(DataInicio));
            }
        }

        private DateTime? _dataTermino;
        [DisplayName("Data Termino")]
        public DateTime? DataTermino
        {
            get { return _dataTermino;}
            private set
            {
                _dataTermino = value;
                OnPropertyChanged(nameof(DataTermino));
            }
        }

        private int _porcentagemProducao;
        [DisplayName("Produção")]
        public string PorcentagemProducao
        {
            get { return $"{CalcPorcentagemProducao()}%"; }
        }

        public void SetTempoFabricacao()
        {
            DataInicio = DateTime.Now;
            DataTermino = DataInicio.Value.Add(TempoFabricacao);

            Task.Run(() =>
            {
                while (DataInicio.HasValue && DataTermino.HasValue && CalcPorcentagemProducao() < 100)
                {
                    OnPropertyChanged(nameof(PorcentagemProducao));

                    Task.Delay(TimeSpan.FromSeconds(1)).Wait();
                }
            });
        }

        private int CalcPorcentagemProducao()
        {
            if (DataInicio.HasValue && DataTermino.HasValue)
            {
                if (DataTermino < DateTime.Now)
                {
                    return 100;
                }

                var periodo = DataTermino.Value.Ticks - DataInicio.Value.Ticks;
                var intervalo = DateTime.Now.Ticks - DataInicio.Value.Ticks;
                return (int)((intervalo * 100) / periodo);
            }

            return 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
