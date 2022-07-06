using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenFile
{
    public class Aresta
    {
        /// <summary>
        /// Nó de origem
        /// </summary>
        public Vertice Origem;
        /// <summary>
        /// Nó de destino
        /// </summary>
        public Vertice Destino;
        /// <summary>
        /// Resistência (R)
        /// </summary>
        public double Resistencia;
        /// <summary>
        /// Reatância (X)
        /// </summary>
        public double Reatancia;
        /// <summary>
        /// Tipo da chave (1-NF; 2-FU; 3-NA)
        /// </summary>
        public int Tipo;

        public double L;
        public double P;
        public double Q;
        
        /// <summary>
        /// Indica se é um vertice no sentido do fluxo de energia (Padrão: False -> Sentido original conforme arquivo) (False - No fluxo; True - Contra Fluxo) 
        /// </summary>
        public bool EdgeOposto;
        /// <summary>
        /// Valor que será utilizado para exibir informações do fluxo de potência.
        /// </summary>
        public double fluxoPotencia;

        public int idAresta;

        public Aresta() { }

    }

    enum enumLinha
    {
        origem = 0,
        destino = 1,
        resistencia = 2,
        reatancia = 3,
        tipo = 4,
        L = 5,
        P = 6,
        Q = 7,
        edgeOposto = 8,
        fluxoPotencia = 9,
        idAresta = 10
    }
}

