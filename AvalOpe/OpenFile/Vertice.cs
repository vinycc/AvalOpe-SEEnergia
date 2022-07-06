using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenFile
{
    public class Vertice
    {
        /// <summary>
        /// Identificador numérico
        /// </summary>
        public int Id;
        /// <summary>
        /// Label descritivo
        /// </summary>
        public string Nome;
        /// <summary>
        /// Tipo de Nó (0 - Não alimentador; 1 - Alimentador)
        /// </summary>
        public int Alimentador;
        /// <summary>
        /// Carga do Nó
        /// </summary>
        public double Carga;
        /// <summary>
        /// Número de Consumidores
        /// </summary>
        public int NumeroDeConsumidores;
        /// <summary>
        /// Tempo de reparo
        /// </summary>
        public double TempoDeReparo;
        /// <summary>
        /// Taxa de Falha (lambda)
        /// </summary>
        public double TaxaDeFalha;

        /// <summary>
        /// Id temporario utilizado apenas pasra o fluxo de potência.
        /// </summary>
        public int idTemp;

        /// <summary>
        /// Construtor
        /// </summary>
        public Vertice() { }
    }

    enum enumNo
    {
        id = 0,
        nome = 1,
        alimentador = 2,
        carga = 3,
        numeroDeConsumidores = 4,
        tempoDeReparo = 5,
        taxaDeFalha = 6,
        idTemp = 7
    }
}