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
        public Pecas(int codigo, string peca, string dataInicio, string dataTermino)
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
        public string DataInicio { get; set; }

        [DisplayName("Data Termino")]
        public string DataTermino { get; set; }

    }
}
