using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QuickGraph;
using OpenFile;

namespace AvalOpe
{
    /// <summary>
    /// Interaction logic for ucTesteGrafo.xaml
    /// </summary>
    public partial class ucTesteGrafo : UserControl
    {
        private IBidirectionalGraph<object, IEdge<object>> _graphToVisualize;

        BidirectionalGraph<object, IEdge<object>> g;
        string[] vertices;
        public IBidirectionalGraph<object, IEdge<object>> GraphToVisualize
        {
            get { return _graphToVisualize; }
        }

        public ucTesteGrafo()
        {
            CreateGraphToVisualize();
            InitializeComponent();

            //"Circular", "Tree", "FR", "BoundedFR", "KK", "ISOM", "LinLog", "EfficientSugiyama", "CompoundFDP" }; }

        }

        private void CreateGraphToVisualize()
        {
            g = new BidirectionalGraph<object, IEdge<object>>();


            //Abre arquivos e gera a estrutura da rede
            File teste = new File();
            Grafo rede = teste.Open(2);

            //adiciona os vertices
            int n = rede.vertices.Count;
            vertices = new string[n];

            int i = 0;
            foreach (Vertice v in rede.vertices)
            {
                vertices[i] = v.Id.ToString();
                g.AddVertex(vertices[i]);

                i++;
            }
            
            //for (int i = 0; i < 5; i++)
            //{
            //    vertices[i] = i.ToString();
            //    g.AddVertex(vertices[i]);
            //}

            //adiciona arestas

            foreach(Aresta e in rede.edges)
            {
                g.AddEdge(new Edge<object>(vertices[e.Origem.Id], vertices[e.Destino.Id]));
                
            }

            //g.AddEdge(new Edge<object>(vertices[0], vertices[1]));
            //g.AddEdge(new Edge<object>(vertices[1], vertices[2]));
            //g.AddEdge(new Edge<object>(vertices[2], vertices[3]));
            //g.AddEdge(new Edge<object>(vertices[3], vertices[0]));
            //g.AddEdge(new Edge<object>(vertices[0], vertices[4]));

            _graphToVisualize = g;

            
        }
    }
}
