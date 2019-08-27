using System;
using System.ComponentModel;

namespace UsinagemPecas
{
    public class Peca
    {
        public Peca(PecaEnum codigo, TimeSpan tempoFabricacao)
        {
            Id = Guid.NewGuid();
            Codigo = codigo;
            Nome = codigo.GetDescription();
            TempoFabricacao = tempoFabricacao;
        }

        public Guid Id { get; private set; }

        public PecaEnum Codigo { get; set; }

        [DisplayName("Cód. Peças")]
        public string Nome { get; set; }

        public TimeSpan TempoFabricacao { get; set; }

        [DisplayName("Data Ínicio")]
        public DateTime? DataInicio { get; private set; }

        [DisplayName("Data Termino")]
        public DateTime? DataTermino { get; private set; }

        public int PorcentagemProducao
        {
            get
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
        }

        public void SetTempoFabricacao()
        {
            DataInicio = DateTime.Now;
            DataTermino = DataInicio.Value.Add(TempoFabricacao);
        }

    }
}
