using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Glee.Drawing;
using OpenFile;

namespace AvalOpe
{
    public partial class ucDiagramaUnifilar : UserControl
    {
        public static Grafo rede = new Grafo();
        public static bool grafoDirigido;

        public ucDiagramaUnifilar()
        {
            InitializeComponent();
            gViewer1.SelectionChanged += new EventHandler(gViewer_SelectionChanged);
            gViewer1.MouseDoubleClick += new MouseEventHandler(gViewer_MouseDoubleClick);
        }

        public Grafo getRede()
        {
            return rede;
        }
        public void SetDiagramaRede(int idRede)
        {
            //Abre arquivos e gera a estrutura da rede
            if (idRede == 1)
            {
                File teste = new File();
                rede = teste.Open(idRede);
                grafoDirigido = true;
                CreateGraph(grafoDirigido);
            }
            if (idRede == 2)
            {
                File teste = new File();
                rede = teste.Open(idRede);
                grafoDirigido = true;
                CreateGraph(grafoDirigido);
            }
        }

        object selectedObjectAttr;
        object selectedObject;
        void gViewer_SelectionChanged(object sender, EventArgs e)
        {
            if (selectedObject != null)
            {
                if (selectedObject is Edge)
                {
                    (selectedObject as Edge).Attr = selectedObjectAttr as EdgeAttr;
                }
                else if (selectedObject is Node)
                {
                    (selectedObject as Node).Attr = selectedObjectAttr as NodeAttr;
                }
                selectedObject = null;
            }

            if (gViewer1.SelectedObject == null)
            {
                //label1.Text = "No object under the mouse";
                //this.gViewer1.SetToolTip(toolTip1, "");
                lblLegenda.Text = "";
            }
            else
            {
                selectedObject = gViewer1.SelectedObject;

                if (selectedObject is Edge)
                {
                    selectedObjectAttr = (gViewer1.SelectedObject as Edge).Attr.Clone();
                    (gViewer1.SelectedObject as Edge).Attr.Color = Microsoft.Glee.Drawing.Color.Gray;
                    (gViewer1.SelectedObject as Edge).Attr.Fontcolor = Microsoft.Glee.Drawing.Color.Gray;
                    Edge edge = gViewer1.SelectedObject as Edge;

                    //string s = (selectedObject as Edge).UserData.ToString();
                    //here you can use e.Attr.Id or e.UserData to get back to you data
                    //this.gViewer1.SetToolTip(this.toolTip1, String.Format("edge from {0} {1}", edge.Source, edge.Target));

                    //Exibe detalhes da aresta
                    //Aresta a = rede.edges.First(
                    //                            o => o.Origem.Id.ToString() == (selectedObject as Edge).Source &&
                    //                            o.Destino.Id.ToString() == (selectedObject as Edge).Target
                    //                            );
                    //lblLegenda.Text = "Reatância: " + a.Reatancia + "   Resistência: " + a.Resistencia;
                }
                else if (selectedObject is Node)
                {

                    selectedObjectAttr = (gViewer1.SelectedObject as Node).Attr.Clone();
                    (selectedObject as Node).Attr.Color = Microsoft.Glee.Drawing.Color.Magenta;
                    (selectedObject as Node).Attr.Fontcolor = Microsoft.Glee.Drawing.Color.Magenta;


                    //here you can use e.Attr.Id to get back to your data
                    //this.gViewer1.SetToolTip(toolTip1, String.Format("node {0}", (selectedObject as Node).Attr.Label));

                    //Exibe detalhes do vértice
                    //Vertice v = rede.vertices.First(o => o.Id.ToString() == (selectedObject as Node).Attr.Label);
                    //lblLegenda.Text = "Carga: " + v.Carga + "   Taxa de Falha: " + v.TaxaDeFalha + "   Tempo de Reparo: " + v.TempoDeReparo + "   Número de Consumidores: " + v.NumeroDeConsumidores;
                }
                //label1.Text = selectedObject.ToString();
            }
            gViewer1.Invalidate();
        }

        void gViewer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (selectedObject is Node)
                {
                    //MessageBox.Show("Node Selected: " + (selectedObject as Node).Attr.Label);
                }
                else if (selectedObject is Edge)
                {
                    //Aresta ed = rede.edges.First(o => o.Origem.Id.ToString() == (selectedObject as Edge).Source && o.Destino.Id.ToString() == (selectedObject as Edge).Target);
                    Aresta ed = rede.edges.First(
                                                    o => o.Origem.Id.ToString() == ((selectedObject as Edge).Source) &&
                                                    o.Destino.Id.ToString() == ((selectedObject as Edge).Target)
                                                );
                    if (ed.Tipo == 1)   //NF
                    //if ((selectedObject as Edge).Attr.Label == "NF")
                    {

                        ed.Tipo = 3;
                        //GeraEdgeNA((selectedObject as Edge));
                        //selectedObjectAttr = (selectedObject as Edge).Attr.Clone();
                        CreateGraph(grafoDirigido);
                    }
                    else if (ed.Tipo == 3)  //NA
                    //((selectedObject as Edge).Attr.Label == "NA")
                    {
                        ed.Tipo = 1;
                        CreateGraph(grafoDirigido);

                        //GeraEdgeNF((selectedObject as Edge));
                        //selectedObjectAttr = (selectedObject as Edge).Attr.Clone();
                    }

                    //MessageBox.Show("Edge Selected: " + (selectedObject as Edge).Attr.Label);
                }
                //gViewer1.Invalidate();
                gViewer1.Refresh();
                //gViewer1.Update();
            }
        }

        #region CRIAÇÃO DO GRAFICO
        private void CreateGraph(bool dirigido)
        {
            grafoDirigido = dirigido;

            Graph graph = new Graph("graph");
            graph.GraphAttr.NodeAttr.Padding = 3;

            Edge edge;

            foreach (Aresta ed in rede.edges)
            {
                edge = (Edge)graph.AddEdge(ed.Origem.Id.ToString(), ed.Destino.Id.ToString());


                if (ed.Origem.Alimentador == 1)
                {
                    GeraNoAlimentador(graph.FindNode(ed.Origem.Id.ToString()) as Node);
                }

                //verificar se deve ser dirigido ou nao
                if (dirigido)
                {
                    edge.Attr.ArrowHeadAtTarget = ArrowStyle.Normal;
                }
                else
                {
                    edge.Attr.ArrowHeadAtTarget = ArrowStyle.Normal;
                }


                switch (ed.Tipo)
                {
                    case 1:
                        //NF
                        this.GeraEdgeNF(edge);
                        break;
                    case 2:
                        //Fusivel
                        this.GeraEdgeFU(edge);
                        break;
                    case 3:
                        //NA
                        this.GeraEdgeNA(edge);
                        break;
                }
            }

            //edge = (Edge)graph.AddEdge("19", "20");
            //edge.Attr.AddStyle(Microsoft.Glee.Drawing.Style.Dashed);

            //CreateSourceNode(graph.FindNode("0") as Node);
            //CreateSourceNode(graph.FindNode("15") as Node);
            //CreateSourceNode(graph.FindNode("48") as Node);

            graph.GraphAttr.LayerDirection = LayerDirection.LR;
            graph.GraphAttr.OptimizeLabelPositions = true;
            graph.GraphAttr.EdgeAttr.ArrowHeadLength = 20;

            //layout the graph and draw it
            gViewer1.Graph = graph;

            //Node a = graph.FindNode("0") as Node;
            //double x = a.Attr.GleeNode.Center.X;
            //double y = a.Attr.GleeNode.Center.Y;
        }

        private void GeraEdgeNA(Edge edge)
        {
            edge.Attr.ClearStyles();
            edge.Attr.AddStyle(Microsoft.Glee.Drawing.Style.Dotted);
            edge.Attr.Color = Microsoft.Glee.Drawing.Color.Red;
            edge.Attr.Fontcolor = Microsoft.Glee.Drawing.Color.Red;
            edge.Attr.LineWidth = 3;
            edge.EdgeAttr.Label = "NA";
            edge.Attr.ArrowHeadAtTarget = ArrowStyle.None;
        }

        private void GeraEdgeNF(Edge edge)
        {
            edge.Attr.ClearStyles();
            edge.Attr.AddStyle(Microsoft.Glee.Drawing.Style.Solid);
            edge.Attr.Color = Microsoft.Glee.Drawing.Color.Blue;
            edge.Attr.Fontcolor = Microsoft.Glee.Drawing.Color.Blue;
            edge.Attr.LineWidth = 3;
            edge.EdgeAttr.Label = "NF";
            edge.Attr.ArrowHeadAtTarget = ArrowStyle.Normal;
            edge.UserData = "Teste NF";

        }

        private void GeraEdgeFU(Edge edge)
        {
            edge.Attr.ClearStyles();
            edge.Attr.AddStyle(Microsoft.Glee.Drawing.Style.Solid);
            edge.Attr.Color = Microsoft.Glee.Drawing.Color.Black;
            edge.Attr.Fontcolor = Microsoft.Glee.Drawing.Color.Black;
            // edge.Attr.LineWidth = 2;
            edge.EdgeAttr.Label = "FU";
            edge.Attr.ArrowHeadAtTarget = ArrowStyle.Normal;
        }

        private void GeraNoAlimentador(Node a)
        {
            //a.Attr.Shape = Microsoft.Glee.Drawing.Shape.Box;
            //a.Attr.XRad = 3;
            //a.Attr.YRad = 3;
            a.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.LightGreen;
            a.Attr.Shape = Microsoft.Glee.Drawing.Shape.DoubleCircle;
            a.Attr.LineWidth = 4;
        }
        #endregion


    }
}
