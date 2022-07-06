using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenFile
{
    public class Grafo
    {
        /// <summary>
        /// Lista de Nós
        /// </summary>
        public List<Vertice> vertices = new List<Vertice>();
        /// <summary>
        /// Lista de Linhas
        /// </summary>
        public List<Aresta> edges = new List<Aresta>();

        /// <summary>
        /// Construtor
        /// </summary>
        public Grafo() { }
    }
}
