using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsinagemPecas
{
    class Pecas
    {
        public Pecas(int codigo, string peca, DateTime dataInicio, DateTime dataTermino)
        {
            Codigo = codigo;
            Peca = peca;
            DataInicio = dataInicio;
            DataTermino = dataTermino;
        }

        public int Codigo { get; set; }

        [DisplayName("Cód. Peças")]
        public string Peca { get; set; }

        [DisplayName("Data Ínicio")]
        public DateTime DataInicio { get; set; }

        [DisplayName("Data Termino")]
        public DateTime DataTermino { get; set; }

    }
}
