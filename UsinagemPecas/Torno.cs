using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace UsinagemPecas
{
    public static class Torno
    {
        public static CancellationTokenSource ThreadSourceToken { get; private set; }
        public static CancellationToken ThreadToken
        {
            get { return ThreadSourceToken.Token; }
        }

        private static EstadoTornoEnum _estado = EstadoTornoEnum.Ligado;
        public static EstadoTornoEnum Estado
        {
            get { return _estado; }
            private set { _estado = value; }
        }

        private static List<Peca> _filaFabricacao = new List<Peca>();
        public static List<Peca> FilaFabricacao
        {
            get { return _filaFabricacao; }
            set { _filaFabricacao = value; }
        }

        public static Peca PecaEmFabricacao { get; private set; }

        private static List<Peca> _pecasFabricadas = new List<Peca>();
        public static List<Peca> PecasFabricadas
        {
            get { return _pecasFabricadas; }
            private set { _pecasFabricadas = value; }
        }

        public static List<Peca> TodasPecas
        {
            get
            {
                var lista = new List<Peca>();
                lista.AddRange(PecasFabricadas);
                if (PecaEmFabricacao != null && lista.All(peca => peca.Id != PecaEmFabricacao.Id))
                    lista.Add(PecaEmFabricacao);
                lista.AddRange(FilaFabricacao);
                return lista;
            }
        }

        public static void LigarTorno()
        {
            ThreadSourceToken = new CancellationTokenSource();

            Task.Run(() =>
            {
                while (!ThreadToken.IsCancellationRequested)
                {
                    if (FilaFabricacao.Any() || PecaEmFabricacao != null)
                    {
                        Estado = EstadoTornoEnum.Ligado;

                        if (PecaEmFabricacao != null && PecaEmFabricacao.DataTermino < DateTime.Now)
                        {
                            if (PecasFabricadas.All(peca => peca.Id != PecaEmFabricacao.Id))
                            {
                                PecasFabricadas.Add(PecaEmFabricacao);
                            }
                            
                            PecaEmFabricacao = null;
                        }

                        if (PecaEmFabricacao == null && FilaFabricacao.Any())
                        {
                            PecaEmFabricacao = FilaFabricacao.First();
                            FilaFabricacao.Remove(PecaEmFabricacao);
                            PecaEmFabricacao.SetTempoFabricacao();
                        }
                    }
                    else
                    {
                        Estado = EstadoTornoEnum.StandBy;
                    }

                    try
                    {
                        if (!ThreadToken.IsCancellationRequested)
                            Task.Delay(TimeSpan.FromSeconds(1)).Wait(ThreadToken);
                    }
                    catch (Exception )
                    {
                    }
                    
                }
            }, ThreadToken);
        }

        public static void DesligarTorno()
        {
            Estado = EstadoTornoEnum.Desligado;
            ThreadSourceToken.Cancel();
        }
    }
}