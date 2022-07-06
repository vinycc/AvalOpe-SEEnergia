using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenFile;
using Microsoft.Glee.Drawing;

namespace AvalOpe
{
    public partial class ucMatriz : UserControl
    {
        public static Grafo redePrincipal = new Grafo();
        public static Grafo redeImagem = new Grafo();
        public static List<Aresta> redeIntermediaria = new List<Aresta>();
        public static List<Aresta> redeMontante = new List<Aresta>();
        public static List<Aresta> redeJusante = new List<Aresta>();

        public static bool grafoDirigido;

        //Matriz Logico Estrutural
        string[,] matrizMLE = new string[0, 0];
        int[,] matrizMLEcontrole = new int[0, 0];
        double[,] matrizMLEValores = new double[0, 0];

        //Quantidade de Nós
        int N;

        public ucMatriz()
        {
            InitializeComponent();

            gViewer1.SelectionChanged += new EventHandler(gViewer_SelectionChanged);
            gViewer1.MouseDoubleClick += new MouseEventHandler(gViewer_MouseDoubleClick);
            //gViewer1.RemoveToolbar();

        }


        #region EVENTOS DE CRIAÇÃO DO GRAFO

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
                    Aresta ed = redePrincipal.edges.First(
                                                    o => o.Origem.Id.ToString() == ((selectedObject as Edge).Source) && 
                                                    o.Destino.Id.ToString() == ((selectedObject as Edge).Target)
                                                );
                    if (ed.Tipo == 1)   //NF
                    //if ((selectedObject as Edge).Attr.Label == "NF")
                    {
                        
                        ed.Tipo = 3;
                        //GeraEdgeNA((selectedObject as Edge));
                        //selectedObjectAttr = (selectedObject as Edge).Attr.Clone();
                        CreateGraph(grafoDirigido,false);
                    }
                    else if (ed.Tipo == 3)  //NA
                    //((selectedObject as Edge).Attr.Label == "NA")
                    {
                        ed.Tipo = 1;
                        CreateGraph(grafoDirigido,false);
                        
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
        #endregion

        #region CRIAÇÃO DO GRAFICO
        private void CreateGraph(bool dirigido, bool ehFluxoPotencia)
        {
            grafoDirigido = dirigido;

            Graph graph = new Graph("graph");
            graph.GraphAttr.NodeAttr.Padding = 3;
            

            Edge edge;

            foreach (Aresta ed in redePrincipal.edges)
            {
                edge = (Edge)graph.AddEdge(ed.Origem.Id.ToString(), ed.Destino.Id.ToString());
                
                if (ed.Origem.Alimentador == 1)
                {
                    GeraNoAlimentador(graph.FindNode(ed.Origem.Id.ToString()) as Node);
                }
                
                //Gera Aresta de acordo com o tipo
                this.GeraEdge(edge, ed, dirigido, ehFluxoPotencia);
            }
            
            //CreateSourceNode(graph.FindNode("0") as Node);
            //CreateSourceNode(graph.FindNode("15") as Node);
            //CreateSourceNode(graph.FindNode("48") as Node);
           
            graph.GraphAttr.LayerDirection = LayerDirection.LR;
            graph.GraphAttr.OptimizeLabelPositions = true;

            graph.GraphAttr.EdgeAttr.ArrowHeadLength = 20;

            //layout the graph and draw it
            gViewer1.Graph = graph;
        }

        /// <summary>
        /// Gera Aresta de acordo com o tipo
        /// </summary>
        /// <param name="edge">Aresta</param>
        /// <param name="tipoAresta">Tipo da Aresta</param>
        /// <param name="ehDirigido">Indica se o grafo é dirigido</param>
        /// <param name="ehFluxoPotencia">Indica se deve exibir valores de fluxo de potência</param>
        private void GeraEdge(Edge edge, Aresta aresta, bool ehDirigido, bool ehFluxoPotencia)
        {
            //Atributos Comuns
            edge.Attr.ClearStyles();
            edge.EdgeAttr.Fontsize = 12;
            
            if (aresta.Tipo == (int)enumtipoAresta.NF)
            {
                edge.EdgeAttr.Label = "NF";
                edge.Attr.LineWidth = 3;
                edge.Attr.AddStyle(Microsoft.Glee.Drawing.Style.Solid);
                edge.Attr.Color = Microsoft.Glee.Drawing.Color.Blue;
                edge.Attr.Fontcolor = Microsoft.Glee.Drawing.Color.Blue;
                //edge.UserData = "Teste NF";
                if (ehDirigido)
                {
                    edge.Attr.ArrowHeadAtTarget = ArrowStyle.Normal;
                }
                else
                {
                    edge.Attr.ArrowHeadAtTarget = ArrowStyle.None;
                }
            }
            else if (aresta.Tipo == (int)enumtipoAresta.FU)
            {
                edge.EdgeAttr.Label = "FU";
                edge.Attr.LineWidth = 1;
                edge.Attr.AddStyle(Microsoft.Glee.Drawing.Style.Solid);
                edge.Attr.Color = Microsoft.Glee.Drawing.Color.Black;
                edge.Attr.Fontcolor = Microsoft.Glee.Drawing.Color.Black;
                if (ehDirigido)
                {
                    edge.Attr.ArrowHeadAtTarget = ArrowStyle.Normal;
                }
                else
                {
                    edge.Attr.ArrowHeadAtTarget = ArrowStyle.None;
                }
            }
            else if (aresta.Tipo == (int)enumtipoAresta.NA)
            {
                edge.EdgeAttr.Label = "NA";
                edge.Attr.LineWidth = 3;
                edge.Attr.AddStyle(Microsoft.Glee.Drawing.Style.Dotted);
                edge.Attr.Color = Microsoft.Glee.Drawing.Color.Red;
                edge.Attr.Fontcolor = Microsoft.Glee.Drawing.Color.Red;
                edge.Attr.ArrowHeadAtTarget = ArrowStyle.None;              //NA nunca será dirigido
            }
            else
            {
                //Aresta Comum
                edge.EdgeAttr.Label = "";
                edge.Attr.LineWidth = 1;
                edge.Attr.AddStyle(Microsoft.Glee.Drawing.Style.Solid);
                edge.Attr.Color = Microsoft.Glee.Drawing.Color.Black;
                edge.Attr.Fontcolor = Microsoft.Glee.Drawing.Color.Black;
                if (ehDirigido)
                {
                    edge.Attr.ArrowHeadAtTarget = ArrowStyle.Normal;
                }
                else
                {
                    edge.Attr.ArrowHeadAtTarget = ArrowStyle.None;
                }
            }

            //Alterações realizadas em caso de Fluxo de Potencia
            if (ehFluxoPotencia)
            {
                edge.EdgeAttr.Fontsize = 10;

                if (redeFluxoPotenciaTotal.Exists(o => o.Origem.Id == aresta.Origem.Id && o.Destino.Id == aresta.Destino.Id))
                {
                    edge.EdgeAttr.Label = redeFluxoPotenciaTotal.First(o => o.Origem.Id == aresta.Origem.Id && o.Destino.Id == aresta.Destino.Id).fluxoPotencia.ToString("N2");
                }
            }

        }



        private void CreateTargetNode(Node a)
        {
            a.Attr.Shape = Microsoft.Glee.Drawing.Shape.DoubleCircle;
            a.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.LightGray;

            a.Attr.LabelMargin = -4;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCaso">Identificador da Rede</param>
        /// <param name="inicio">Indica se é a primeira vez</param>
        public void SetDiagramaRede(int idCaso, bool inicio)
        {
            this.idCaso = idCaso;

            elementHost1.Child = null;

            //checkBox1.Checked = false;

            if (idCaso == 0)
            {
                //Nenhuma rede selecionada
                gViewer1.Hide();
                txtMLE.Clear();
                txtIndicadores.Clear();
                txtIndicadoresAuxiliar.Clear();
                txtFluxoDePotencia.Clear();
            }
            else
            {
                gViewer1.Show();

                if (inicio)
                {
                    txtMLE.Clear();
                    txtIndicadores.Clear();
                    txtIndicadoresAuxiliar.Clear();
                    txtFluxoDePotencia.Clear();

                    txtMLE.Text = "\n\tPara visualizar a matriz lógico estrutural é necessário 'Calcular Indicadores de Continuidade'.";
                    txtIndicadores.Text = "\n\tPara visualizar os indicadores de continuidade é necessário 'Calcular Indicadores de Continuidade'.";
                    txtIndicadoresAuxiliar.Text = "\nPara visualizar os indicadores de continuidade é necessário 'Calcular Indicadores de Continuidade'.";
                    txtFluxoDePotencia.Text = "\n\tPara visualizar as informações do fluxo de potência é necessário 'Executar Fluxo de Potência'.";
                    
                }

                if (idCaso == 1)
                {
                    //elementHost1.Child = new ucDiagrama01();
                    //elementHost1.Dock = System.Windows.Forms.DockStyle.None;

                    //Abre arquivos e gera a estrutura da rede
                    if (redePrincipal.vertices.Count() == 0 || inicio)
                    {
                        File teste = new File();
                        redePrincipal = teste.Open(idCaso);
                    }
                    grafoDirigido = true;
                    CreateGraph(grafoDirigido, false);

                }
                else if (idCaso == 2 || idCaso == 3)
                {
                    //elementHost1.Child = new ucDiagrama02();
                    //elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;

                    //Abre arquivos e gera a estrutura da rede
                    File teste = new File();
                    redePrincipal = teste.Open(idCaso);

                    grafoDirigido = true;
                    CreateGraph(grafoDirigido, false);
                }
            }
        }

        public void SetMatriz(int idCaso)
        {
            if (idCaso > 0)
            {
                txtMLE.Text = "";
                txtIndicadores.Text = "";
                txtIndicadoresAuxiliar.Text = "";
                txtFluxoDePotencia.Text = "";
                txtTempo.Text = "";

                //Abre arquivos e gera a estrutura da rede
                if (redePrincipal.vertices.Count() == 0)
                {
                    File teste = new File();
                    redePrincipal = teste.Open(idCaso);
                }
                MetodoPrincipal();

                txtIndicadoresAuxiliar.Text = txtIndicadores.Text;
            }
            else
            {
                txtMLE.Text = "";
                txtIndicadores.Text = "";
                txtIndicadoresAuxiliar.Text = "";
                txtFluxoDePotencia.Text = "";
                txtTempo.Text = "";
            }
        }

        public void SetTab(int aba)
        {
            if (aba == 1)
            {
                tabControl1.SelectedTab = tabDiagramaUnifilar;
            }
            else if (aba == 2)
            {
                tabControl1.SelectedTab = tabDiagramaGeo;
            }
            else if (aba == 3)
            {
                tabControl1.SelectedTab = tabMatriz;
            }
            else if (aba == 4)
            {
                //Indicadores de continuidade
                if (tabControl1.SelectedTab == tabDiagramaUnifilar)
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    tabControl1.SelectedTab = tabIndicadores;
                    tabIndicadores.Focus();
                    checkBox1.Checked = true;
                }
            }
            else if (aba == 5)
            {
                tabControl1.SelectedTab = tabFluxoPotencia;
            }
        }

        #region METODOS AUXILIARES
        public bool ExisteNF(List<Aresta> lista)
        {
            return lista.Exists(e => e.Tipo == 1);
        }
        public bool ExisteNA(List<Aresta> lista)
        {
            return lista.Exists(e => e.Tipo == 3);
        }
        public bool ExisteFusivel(List<Aresta> lista)
        {
            return lista.Exists(e => e.Tipo == 2);
        }
        public bool ExisteAlimentador(List<Aresta> lista)
        {
            if (lista.Count == 0)
            {
                return true;
            }
            return lista.Exists(e => e.Origem.Alimentador == 1);
        }

        public bool ExisteNada(List<Aresta> lista)
        {
            if (!lista.Exists(e => e.Tipo == 1 || e.Tipo == 2 || e.Tipo == 3))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool PrimeiroNF(List<Aresta> lista)
        {
            try
            {
                Aresta edge = lista.First(e => e.Tipo == 1 || e.Tipo == 2 || e.Tipo == 3);
                if (edge.Tipo == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool PrimeiroNA(List<Aresta> lista)
        {
            try
            {
                Aresta edge = lista.First(e => e.Tipo == 1 || e.Tipo == 2 || e.Tipo == 3);
                if (edge.Tipo == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool PrimeiroFusivel(List<Aresta> lista)
        {
            try
            {
                Aresta edge = lista.First(e => e.Tipo == 1 || e.Tipo == 2 || e.Tipo == 3);
                if (edge.Tipo == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool PrimeiroAlimentador(List<Aresta> lista)
        {
            if (lista.Count == 0)
            {
                return true;
            }
            try
            {
                Aresta edge = lista.First(e => e.Tipo == 1 || e.Tipo == 2 || e.Tipo == 3 || e.Origem.Alimentador == 1);
                if (edge.Origem.Alimentador == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool EhFinal(List<Aresta> lista)
        {
            if (!ExisteNF(lista) && !ExisteNA(lista) && !ExisteFusivel(lista))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region BUSCAR REDE A JUSANTE E A MONTANTE

        #region Busca rede montante a um vertice qualquer
        public static bool buscaRedeMontante(Vertice vOrigem)
        {
            bool solved = false;

            if (redeMontante.Exists(e => e.Destino.Id == vOrigem.Id))
            {
                return true;
            }
            //try
            //{
            //    redeMontante.First(e => e.Destino.Id == vOrigem.Id);
            //    return true;
            //}
            //catch { }

            //Busca linhas a montante
            List<Aresta> edges = redePrincipal.edges.Where(p => p.Destino.Id == vOrigem.Id && p.EdgeOposto == false).ToList();
            int n = 0;
            while (!solved && n < edges.Count)
            {
                if (!ExisteOppositeVertice(edges[n].Destino, edges[n].Origem, redeMontante) && !ExisteVertice(edges[n].Destino, edges[n].Origem, redeMontante))
                {
                    //Adiciona linhas na lista 
                    redeMontante.Add(edges[n]);
                    //chama funcao recursivamente
                    solved = buscaRedeMontante(edges[n].Origem);
                }
                n++;
            }
            return solved;
        }
        #endregion

        #region Busca rede Jusante de um vertice qualquer
        public static bool buscaRedeJusante(Vertice vOrigem)
        {
            bool solved = false;

            if (redeJusante.Exists(e => e.Origem.Id == vOrigem.Id))
            {
                return true;
            }
            //try
            //{
            //    redeJusante.First(e => e.Origem.Id == vOrigem.Id);
            //    return true;
            //}
            //catch { }

            //Busca linhas a jusante
            List<Aresta> edges = redePrincipal.edges.Where(p => p.Origem.Id == vOrigem.Id && p.EdgeOposto == false).ToList();
            int n = 0;
            while (!solved && n < edges.Count)
            {
                if (!ExisteOppositeVertice(edges[n].Destino, edges[n].Origem, redeJusante) && !ExisteVertice(edges[n].Destino, edges[n].Origem, redeJusante))
                {
                    //Adiciona linhas na lista 
                    redeJusante.Add(edges[n]);
                    //chama funcao recursivamente
                    solved = buscaRedeJusante(edges[n].Destino);
                }
                n++;
            }
            return solved;
        }
        #endregion

        #region Busca menor rede entre dois vertices (DJKISTRA)
        /// <summary>
        /// Busca Menor caminho entre dois vértices (DIJKSTRA)
        /// REF: https://www.youtube.com/watch?v=5y8dch2uHR4&index=9&list=WL
        /// REF: http://www.cse.unt.edu/~tarau/teaching/AnAlgo/Dijkstra's%20algorithm.pdf
        /// </summary>
        /// <param name="ini">Vertice inicial</param>
        /// <param name="ant">Ordem dos vertices para chegar do vertice inicial até destino </param>
        /// <param name="dist">Distancia do vertice inicial ate destino</param>
        public static void buscaMenorRede(Vertice ini, Vertice fim, int[] ant, int[] dist)
        {
            bool finalizar = false;                 //interrompe a execução quando chegar ao destino, Se retirar esse controle, busca de todos para todos.
            int cont = redePrincipal.vertices.Count;         //pra garantir que visitou todos os vertices
            int nv = redePrincipal.vertices.Count;           //Quantidade de vértices na rede
            int ind;
            int u = -1;
            bool[] visitado = new bool[nv];           //Vetor auxiliar que informa os vertices que ja foram visitados

            //Cria vetor auxiliar. Inicializa distancias e anteriores

            for (int i = 0; i < nv; i++)
            {
                ant[i] = -1;
                dist[i] = -1;
                visitado[i] = false;
            }
            //verice inicial recebe a distancia 0 (dele para ele mesmo)
            dist[ini.Id] = 0;

            //Procura vertice com menor distancia e marca como visitado
            while (cont > 0 && !finalizar)
            {
                //Busca ID do vertice adjacente com menor distancia que ainda nao foi visitado
                u = procuraMenorDistancia(dist, visitado, nv);
                //caso nao achou um caminho (vertice desconexo)
                if (u == -1)
                {
                    break;
                }

                visitado[u] = true;
                cont--;

                //Para cada vertice vizinho do vertice U
                List<Aresta> vizinhos = redePrincipal.edges.Where(e => e.Origem.Id == u /*&& e.EdgeOposto == false*/).ToList();
                foreach (Aresta edge in vizinhos)
                {
                    if (edge.Destino.Id == fim.Id)
                    {
                        finalizar = true;
                    }
                    ind = edge.Destino.Id;
                    if (dist[ind] < 0)
                    {
                        dist[ind] = dist[u] + 1;
                        ant[ind] = u;
                    }
                    else
                    {
                        if (dist[ind] > dist[u] + 1)
                        {
                            dist[ind] = dist[u] + 1;
                            ant[ind] = u;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Funcao Auxiliar - Procura vertice adjacente com menor distancia e que nao tenha sido visitado
        /// </summary>
        /// <param name="dist">vetor de distancias</param>
        /// <param name="visitado">vetor de vertices visitados</param>
        /// <param name="n">numero de vertices</param>
        /// <returns>Id do vertice mais proximo nao visitado</returns>
        public static int procuraMenorDistancia(int[] dist, bool[] visitado, int n)
        {
            int i, menor = -1, primeiro = 1;
            for (i = 0; i < n; i++)
            {
                if (dist[i] >= 0 && !visitado[i])       //se vertive nao foi visitado a distancia é -1
                {
                    if (primeiro == 1)
                    {
                        menor = i;
                        primeiro = 0;
                    }
                    else
                    {
                        if (dist[menor] > dist[i])
                        {
                            menor = i;
                        }
                    }
                }
            }
            return menor;
        }
        #endregion

        #region Busca rede entre dois vertices (busca em profundidade, busca o primeiro caminho que encontrar)
        public static bool buscaRede(Vertice vOrigem, Vertice vDestino)
        {
            bool solved = false;

            if (redeIntermediaria.Exists(e => e.Destino.Id == vDestino.Id))
            {
                return true;
            }

            //Busca linhas
            List<Aresta> edges = redePrincipal.edges.Where(p => p.Origem.Id == vOrigem.Id).ToList();
            int n = 0;
            while (!solved && n < edges.Count)
            {
                if (!ExisteOppositeVertice(edges[n].Destino, edges[n].Origem) && !ExisteVertice(edges[n].Destino, edges[n].Origem))
                {
                    //Adiciona linhas na lista 
                    redeIntermediaria.Add(edges[n]);
                    //chama funcao recursivamente
                    solved = buscaRede(edges[n].Destino, vDestino);
                    if (!solved)
                    {
                        redeIntermediaria.Remove(edges[n]);
                    }
                }
                n++;
            }
            return solved;
        }
        #endregion

        public static bool ExisteOppositeVertice(Vertice o, Vertice d)
        {
            return ExisteOppositeVertice(o, d, redeIntermediaria);
        }
        public static bool ExisteOppositeVertice(Vertice o, Vertice d, List<Aresta> lista)
        {
            //PEGA O ARESTA INVERTIDA ONDE ORIGEM = DESTINO E DESTINO = ORIGEM
            try
            {
                List<Aresta> edges = lista
                        .Where(e => e.Destino == d)
                        .Where(e => e.Origem == o)
                        .ToList();

                if (edges.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool ExisteVertice(Vertice d, Vertice o)
        {
            return ExisteVertice(d, o, redeIntermediaria);
        }
        public static bool ExisteVertice(Vertice d, Vertice o, List<Aresta> lista)
        {
            try
            {
                List<Aresta> edges = lista
                        .Where(e => e.Destino == d)
                        .Where(e => e.Origem == o)
                        .ToList();

                if (edges.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// Retorna lista de vértices em sentido oposto
        /// </summary>
        /// <returns></returns>
        private List<Aresta> CreateOppositeVertices()
        {
            List<Aresta> lista = new List<Aresta>();
            foreach (Aresta edge in redePrincipal.edges)
            {
                Aresta newEdge = new Aresta();
                newEdge.Origem = edge.Destino;
                newEdge.Destino = edge.Origem;
                newEdge.EdgeOposto = true;
                newEdge.Reatancia = edge.Reatancia;
                newEdge.Resistencia = edge.Reatancia;
                newEdge.Tipo = edge.Tipo;
                newEdge.idAresta = edge.idAresta;
                newEdge.fluxoPotencia = edge.fluxoPotencia;
                newEdge.L = edge.L;
                newEdge.P = edge.P;
                newEdge.Q = edge.Q;
                lista.Add(newEdge);
            }

            return lista;
        }
        #endregion

        #region METODO PRINCIPAL
        public void MetodoPrincipal()
        {


            //Inicializa listas e variaveis globais
            redeIntermediaria = new List<Aresta>();
            redeMontante = new List<Aresta>();
            redeJusante = new List<Aresta>();
            N = redePrincipal.vertices.Count();                  //Quantidade de nós para determinar o tamanho da matriz. Por exemplo, 8 nós gera uma matriz 8x8
            matrizMLE = new string[N, N];
            matrizMLEcontrole = new int[N, N];
            matrizMLEValores = new double[N, N];

            //Gera matrizes de Adjacencia e de alcance
            GeraMatrizAdjacenciaAlcance();

            //Duplica as linhas da rede, adicionando-as em sentidos opostos
            List<Aresta> lista = this.CreateOppositeVertices();
            redePrincipal.edges.AddRange(lista);

            //INICIALIZA MATRIZ MLE    
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    matrizMLE[i, j] = "-";
                    matrizMLEcontrole[i, j] = 0;
                    matrizMLEValores[i, j] = 0;
                }
            }

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            //=====================================================================================
            #region CRIA MATRIZ MLE - aqui que acontece a mágica toda
            for (int origem = 0; origem < N; origem++)
            {
                //for (int destino = 60; destino <= 65; destino++)
                for (int destino = 0; destino < N; destino++)
                {
                    //SE AINDA NÃO FOI PREENCHIDA
                    if (matrizMLEcontrole[destino, origem] == 0)
                    {
                        //REGRA 1:
                        //Diagonal Principal - TR 
                        if (origem == destino)
                        {
                            PreencheMLE(destino, origem, "TR" + (origem).ToString());
                            continue;
                        }

                        //LISTA DE EDGES ENTRE OS DOIS NÓS
                        redeIntermediaria.Clear();

                        int[] ant = new int[N];         //vetor com o caminho de vertices percorridos para chegar ao destino
                        int[] dist = new int[N];        //vetor com a quantidade de edges percorrido do vertice de origem para todos os nós que alcancou 
                        buscaMenorRede(redePrincipal.vertices.First(e => e.Id == origem), redePrincipal.vertices.First(e => e.Id == destino), ant, dist);

                        //Gera lista de edges percorridos pelo menor caminho
                        int s = destino;
                        while (s >= 0)
                        {
                            if (ant[s] >= 0)
                            {
                                Aresta aresta = redePrincipal.edges.First(e => e.Origem.Id == ant[s] && e.Destino.Id == s);
                                redeIntermediaria.Add(aresta);
                            }
                            s = ant[s];
                        }
                        //Inverte a lista de arestas
                        redeIntermediaria.Reverse();

                        //METODO UTILIZADO ANTERIORMENTE (BUSCA EM PROFUNDIDADE, PEGANDO O PRIMEIRO CAMINHO Q ENCONTRAR)
                        //redeIntermediaria.Clear();
                        //buscaRede(rede.vertices.First(e => e.Id == origem), rede.vertices.First(e => e.Id == destino));

                        //REGRA 2
                        //Não há enhuma chave entre dois vértices - TR
                        if (ExisteNada(redeIntermediaria))
                        {
                            PreencheMLE(destino, origem, "TR" + (origem).ToString());
                            PreencheMLE(origem, destino, "TR" + (destino).ToString());
                            continue;
                        }

                        //LISTA DE EDGES DO ULTIMO NÓ DO TRECHO ATE OS FINAIS DA REDE
                        redeJusante.Clear();
                        buscaRedeJusante(redePrincipal.vertices.First(e => e.Id == destino));
                        foreach (Aresta ed in redeJusante)
                        {
                            Console.Write(ed.Origem.Id + " - ");
                        }

                        //LISTA DE EDGES DO PRIMEIRO NÓ DO TRECHO ATÉ O ALIMENTDOR
                        redeMontante.Clear();
                        buscaRedeMontante(redePrincipal.vertices.First(e => e.Id == origem));

                        //if (ExisteAlimentador(listaInicio) && origem != destino)
                        //{
                        //    if (ExisteNada(listaG))
                        //    {
                        //        if (PrimeiroNF(listaFim))
                        //        {
                        //            PreencheMLE(destino - 1, origem - 1, "TR" + origem);
                        //            continue;
                        //        }
                        //    }
                        //}

                        //if (ExisteAlimentador(redeMontante))
                        //{
                        //    if(ExisteNF(redeIntermediaria) && !ExisteNA(redeIntermediaria) && !ExisteFusivel(redeIntermediaria))
                        //    {
                        //        if (ExisteNA(redeJusante))
                        //        {
                        //            PreencheMLE(destino, origem, "TT");
                        //            continue;
                        //        }
                        //    }
                        //}

                        //if (ExisteAlimentador(redeMontante))
                        //{
                        //    if (ExisteNA(redeIntermediaria) && PrimeiroNF(redeIntermediaria))
                        //    {
                        //        //if (!ExisteNF(redeJusante) && !ExisteNA(redeJusante))
                        //        //{
                        //        PreencheMLE(destino, origem, "TT");
                        //        continue;
                        //        //}
                        //    }
                        //}

                        //if (ExisteAlimentador(redeMontante))
                        //{
                        //    if (ExisteNA(redeIntermediaria) && ! PrimeiroNF(redeIntermediaria))
                        //    {
                        //        //if (!ExisteNF(redeJusante) && !ExisteNA(redeJusante))
                        //        //{
                        //        PreencheMLE(destino, origem, "0");
                        //        continue;
                        //        //}
                        //    }
                        //}

                        if (PrimeiroAlimentador(redeMontante))
                        {
                            if (ExisteNA(redeIntermediaria))
                            {
                                if (ExisteNA(redeJusante))
                                {
                                    PreencheMLE(destino, origem, "0");
                                    continue;
                                }
                            }
                        }
                        //REGRA 3:
                        //Primeiro Alimentador a esquerda; 
                        //NF intermediária;  
                        //Primeiro NA a direita
                        //if (ExisteAlimentador(redeMontante) && !PrimeiroFusivel(redeMontante) && !PrimeiroNF(redeMontante) && !PrimeiroNA(redeMontante))
                        if (PrimeiroAlimentador(redeMontante))
                        {
                            if (ExisteNF(redeIntermediaria))
                            {
                                if (ExisteNA(redeJusante))
                                {
                                    PreencheMLE(destino, origem, "TT");
                                    continue;
                                }
                            }
                        }

                        //REGRA 4:
                        //Primeiro NF a esquerda
                        //NF intermediária
                        //Final da linha
                        if (PrimeiroNF(redeMontante))
                        {
                            if (ExisteNF(redeIntermediaria))
                            {
                                //if (!ExisteNF(redeJusante) && !ExisteNA(redeJusante))
                                if (EhFinal(redeJusante))
                                {
                                    PreencheMLE(destino, origem, "TS");
                                    continue;
                                }
                            }
                        }

                        //REGRA 5:
                        //Primeiro NF a esquerda
                        //NF Intermediária
                        //Primeiro NF a direita
                        if (PrimeiroNF(redeMontante))
                        {
                            if (ExisteNF(redeIntermediaria))
                            {
                                if (PrimeiroNF(redeJusante))
                                {
                                    PreencheMLE(destino, origem, "TS");
                                    continue;
                                }
                            }
                        }

                        //REGRA 6:
                        //Primeiro Fusivel a esquerda
                        //Existe Fusivel
                        //...
                        if (PrimeiroFusivel(redeMontante))
                        {
                            if (ExisteFusivel(redeIntermediaria))
                            {
                                //if (!ExisteNF(listaFim) && !ExisteNA(listaFim))
                                {
                                    PreencheMLE(destino, origem, "0");
                                    continue;
                                }
                            }
                        }

                        //if (PrimeiroFusivel(listaInicio))
                        //{
                        //    if (ExisteNada(listaG))
                        //    {
                        //        //if (!ExisteNF(listaFim) && !ExisteNA(listaFim))       //fim
                        //        {
                        //            PreencheMLE(destino - 1, origem - 1, "TR" + origem);
                        //            continue;
                        //        }
                        //    }
                        //}

                        //REGRA 7:
                        //Existe Alimentador
                        //NF intermediaria e Não NA
                        //Fim de rede
                        if (ExisteAlimentador(redeMontante))
                        {
                            if (ExisteNF(redeIntermediaria) && !ExisteNA(redeIntermediaria))
                            {
                                //if (!ExisteNF(redeJusante) && !ExisteNA(redeJusante))
                                if (EhFinal(redeJusante))
                                {
                                    PreencheMLE(destino, origem, "TT");
                                    continue;
                                }
                            }
                        }

                        //REGRA 8:
                        //Existe Alimentador
                        //Fusivel intermediario e Não NF e Não NA
                        //Fim de rede
                        if (ExisteAlimentador(redeMontante))
                        {
                            if (ExisteFusivel(redeIntermediaria) && (!ExisteNF(redeIntermediaria)) && (!ExisteNA(redeIntermediaria)))
                            {
                                //if (!ExisteNF(redeJusante) && !ExisteNA(redeJusante))
                                if (EhFinal(redeJusante))
                                {
                                    PreencheMLE(destino, origem, "TR" + (origem).ToString());
                                    continue;
                                }
                            }
                        }

                        //REGRA 9:
                        //Existe Alimentador
                        //NA intermediária
                        //fim de rede
                        if (ExisteAlimentador(redeMontante))
                        {
                            if (ExisteNA(redeIntermediaria))
                            {
                                //if (!ExisteNF(redeJusante) && !ExisteNA(redeJusante))
                                if (EhFinal(redeJusante))
                                {
                                    PreencheMLE(destino, origem, "0");
                                    continue;
                                }
                            }
                        }

                        //if (PrimeiroNF(listaInicio))
                        //{
                        //    if (ExisteNada(listaG))
                        //    {
                        //        if (PrimeiroNA(listaFim))
                        //        {
                        //            PreencheMLE(destino - 1, origem - 1, "TR" + origem);
                        //            continue;
                        //        }
                        //    }
                        //}

                        //REGRA 10:
                        //Primeiro NF a esquerda
                        //NF intermediaria
                        //fim de rede
                        if (PrimeiroNF(redeMontante))
                        {
                            if (ExisteNF(redeIntermediaria))
                            {
                                //if (!ExisteNF(redeJusante) && !ExisteNA(redeJusante))       //fim
                                if (EhFinal(redeJusante))
                                {
                                    PreencheMLE(destino, origem, "TS");
                                    continue;
                                }
                            }
                        }

                        //REGRA 11:
                        //Primeiro NF a esquerda
                        //NF intermediaria
                        //Primeiro NF a direita
                        if (PrimeiroNF(redeMontante))
                        {
                            if (ExisteNF(redeIntermediaria))
                            {
                                if (PrimeiroNF(redeJusante))
                                {
                                    PreencheMLE(destino, origem, "TS");
                                    continue;
                                }
                            }
                        }

                        //if (PrimeiroNA(listaInicio))
                        //{
                        //    if (ExisteNada(listaG))
                        //    {
                        //        if (!ExisteNF(listaFim) && !ExisteNA(listaFim))
                        //        {
                        //            PreencheMLE(destino - 1, origem - 1, "TR" + origem);
                        //            continue;
                        //        }

                        //    }
                        //}

                        //REGRA 12:
                        //Primeiro NA a esquerda
                        //Existe NA
                        //...
                        if (PrimeiroNA(redeMontante))
                        {
                            if (ExisteNA(redeIntermediaria))
                            {
                                //if (!ExisteNF(listaFim) && !ExisteNA(listaFim))  
                                {
                                    PreencheMLE(destino, origem, "0");
                                    continue;
                                }
                            }
                        }

                        //REGRA 13:
                        //Primeiro NA a esquerda
                        //Fusivel intermediario e Não NA e não NF
                        //fim de rede
                        if (PrimeiroNA(redeMontante))
                        {
                            if (ExisteFusivel(redeIntermediaria) && !ExisteNA(redeIntermediaria) && !ExisteNF(redeIntermediaria))
                            {
                                //if (!ExisteNF(redeJusante) && !ExisteNA(redeJusante))  
                                if (EhFinal(redeJusante))
                                {
                                    PreencheMLE(destino, origem, "TR" + (origem).ToString());
                                    continue;
                                }
                            }
                        }

                        //REGRA 14:
                        //Existe Alimentador
                        //NA intermediaria
                        //...
                        if (ExisteAlimentador(redeMontante))
                        {
                            if (ExisteNA(redeIntermediaria))
                            {
                                //if (!ExisteNF(redeJusante) && !ExisteNA(redeJusante))
                                //{
                                PreencheMLE(destino, origem, "0");
                                continue;
                                //}
                            }
                        }

                        //REGRA 15:
                        //Existe Alimentador
                        //NF intermediaria e Não NA
                        //Existe NF
                        if (ExisteAlimentador(redeMontante))
                        {
                            if (ExisteNF(redeIntermediaria) && !ExisteNA(redeIntermediaria))
                            {
                                if (ExisteNF(redeJusante))
                                {
                                    PreencheMLE(destino, origem, "TR" + (origem).ToString());
                                    continue;
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            //=====================================================================================

            sw.Stop();
            TimeSpan ts = sw.Elapsed;

            #region Imprime Matriz Logico Estrutural
            string matrizString = "";
            matrizString += "MATRIZ LÓGICO ESTRUTURAL:\n\n";

            matrizString += "\t";
            for (int i = 0; i < N; i++)
            {
                matrizString += i + "\t";
            }
            matrizString += "\n\n";

            for (int i = 0; i < N; i++)
            {
                matrizString += i + "\t";
                for (int j = 0; j < N; j++)
                {
                    matrizString += matrizMLE[i, j] + "\t";
                }
                matrizString += "\n";
            }



            matrizString += "\nMATRIZ LÓGICO ESTRUTURAL (valores):\n\n";

            matrizString += "\t";
            for (int i = 0; i < N; i++)
            {
                matrizString += i + "\t";
            }
            matrizString += "\n\n";

            for (int i = 0; i < N; i++)
            {
                matrizString += i + "\t";
                for (int j = 0; j < N; j++)
                {
                    matrizString += matrizMLEValores[i, j] + "\t";
                }
                matrizString += "\n";
            }

            txtMLE.Text = matrizString;

            //CALCULAR FEC, DEC
            CalcularFEC();
            txtIndicadores.Text += "\n\n";
            CalcularDEC();
            txtIndicadores.Text += "\n\n";
            CalcularENS();
            txtIndicadores.Text += "\n";
            CalcularDIC();

            #endregion

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);

            txtTempo.Text += "TEMPO DECORRIDO: " + elapsedTime;

        }
        #endregion

        #region MÉTODOS PARA MATRIZES 

        /// <summary>
        /// Gera matriz de adjacencia e matriz de alcance
        /// </summary>
        public void GeraMatrizAdjacenciaAlcance()
        {
            //int n = rede.vertices.Count();

            //MATRIZ ADJACENCIA (MATRIZ A)
            Matrix matrizA = Matrix.ZeroMatrix(N, N);
            foreach (Aresta linha in redePrincipal.edges)
                //matrizA[linha.Origem.Id - 1, linha.Destino.Id - 1] = 1;
                matrizA[linha.Origem.Id, linha.Destino.Id] = 1;

            //MATRIZ DE ALCANCE (MATRIZ R)
            Matrix matrizR = CriarMatrizAlcance(matrizA);

            //txtAdjacencia.Text += "\nMATRIZ DE ADJACENCIA:\n\n";
            //txtAdjacencia.Text += matrizA.ToString();
            //txtAlcance.Text += "\nMATRIZ DE ALCANCE:\n\n";
            //txtAlcance.Text += matrizR.ToString();
        }

        /// <summary>
        /// Cria uma matriz de alcance (matriz R) a partir de uma matriz de Adjacência (matriz a) 
        /// </summary>
        /// <param name="mA">Matriz de Adjacência</param>
        /// <returns></returns>
        public Matrix CriarMatrizAlcance(Matrix mA)
        {
            /* 
            Fórmula
            R =〖(mI+mA)〗^(n-1)
            */

            //Cria a matriz identidade de mesmo tamanho
            Matrix mI = Matrix.IdentityMatrix(mA.rows, mA.cols);
            Matrix mR = Matrix.Power((mA + mI), mA.rows - 1);

            for (int i = 0; i < mR.rows; i++)
            {
                for (int j = 0; j < mR.cols; j++)
                {
                    if (mR[i, j] != 0)
                    {
                        mR[i, j] = 1;
                    }
                }
            }

            return mR;
        }

        /// <summary>
        /// Copia uma matriz C# para uma Matrix
        /// </summary>
        /// <param name="m">matriz C#</param>
        /// <returns></returns>
        public Matrix CopiaMatriz(int[,] m)
        {
            int x = m.GetLength(0);
            int y = m.GetLength(1);
            Matrix matrix = new Matrix(x, y);

            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    matrix[i, j] = m[i, j];

            return matrix;
        }

        public void PreencheMLE(int linha, int coluna, string texto)
        {
            matrizMLE[linha, coluna] = texto;
            matrizMLEcontrole[linha, coluna] = 1;


            double tempoReparo = redePrincipal.vertices.First(e => e.Id == coluna).TempoDeReparo;
            double taxaFalha = redePrincipal.vertices.First(e => e.Id == coluna).TaxaDeFalha;
            double tempoSeccionamento = 0.5;
            double tempoTransferencia = 1;

            if (texto.Contains("TR"))
            {
                matrizMLEValores[linha, coluna] = tempoReparo * taxaFalha;
            }
            else
            {
                if (texto.Contains("TT"))
                {
                    matrizMLEValores[linha, coluna] = tempoTransferencia * taxaFalha;
                }
                else
                {
                    if (texto.Contains("TS"))
                    {
                        matrizMLEValores[linha, coluna] = tempoSeccionamento * taxaFalha;
                    }
                    else
                    {
                        matrizMLEValores[linha, coluna] = 0;
                    }
                }

            }
        }

        #endregion

        #region CÁLCULOS DEC, DIC, ENS, FEC

        #region DIC
        public void CalcularDIC()
        {
            //txtIndicadores.Text += "\n\nDIC:";

            //percorre cada uma das linhas
            for (int i = 0; i < N; i++)
            {
                double dicLinha = 0;
                //Percorre cada coluna da linha
                for (int j = 0; j < N; j++)
                {
                    //Multiplica o tempo (TR,TT,TS) pela taxa de falha do no
                    double valor = matrizMLEValores[i, j] * redePrincipal.vertices.First(e => e.Id == i).TaxaDeFalha;
                    dicLinha += valor;
                }
                txtIndicadores.Text += "\nDIC Nó " + i + ": " + dicLinha.ToString("N2");
            }
        }
        #endregion

        #region ENS
        public double CalcularENS()
        {
            txtIndicadores.Text += "ENS: ";
            double ensTotal = 0;
            //percorre colunas
            for (int j = 0; j < N; j++)
            {
                //calcular ens da linha
                double ensColuna = 0;
                //percorre linhas de cada coluna
                for (int i = 0; i < N; i++)
                {
                    double n = matrizMLEValores[i, j];
                    ensColuna += n;
                }
                //txtIndicadores.Text += "\n" + ensColuna.ToString() + " * " + rede.vertices.First(e => e.Id == j).Carga;

                //multiplica ens da coluna pela carga do no 
                ensColuna = ensColuna * redePrincipal.vertices.First(e => e.Id == j).Carga;

                //somatorio do ens de cada linha
                ensTotal += ensColuna;
            }

            //txtIndicadores.Text += "\nENS Total: " + ensTotal.ToString("N2");
            txtIndicadores.Text += ensTotal.ToString("N2");

            return ensTotal;
        }
        #endregion

        #region DEC
        public double CalcularDEC()
        {
            txtIndicadores.Text += "DEC: ";
            double decTotal = 0;
            //percorre colunas
            for (int j = 0; j < N; j++)
            {
                //calcular dec da linha
                double decColuna = 0;
                //percorre linhas de cada coluna
                for (int i = 0; i < N; i++)
                {
                    double n = matrizMLEValores[i, j];
                    decColuna += n;
                }
                //txtIndicadores.Text += "\n" + decColuna.ToString() + " * " + rede.vertices.First(e => e.Id == j).NumeroDeConsumidores;

                //multiplica dec da coluna pelo numero de consumidores do no 
                decColuna = decColuna * redePrincipal.vertices.First(e => e.Id == j).NumeroDeConsumidores;

                //somatorio dos decs de cada linha
                decTotal += decColuna;
            }

            //divide pelo numero total de consumidores da rede
            decTotal /= redePrincipal.vertices.Sum(e => e.NumeroDeConsumidores);

            //txtIndicadores.Text += "\nTotal Consumidores: " + rede.vertices.Sum(e => e.NumeroDeConsumidores);

            //txtIndicadores.Text += "\nDEC Total: " + decTotal.ToString("N2");
            txtIndicadores.Text += decTotal.ToString("N2");

            return decTotal;
        }
        #endregion

        #region FEC
        public double CalcularFEC()
        {
            txtIndicadores.Text += "FEC: ";
            double fecTotal = 0;
            //percorre colunas
            for (int j = 0; j < N; j++)
            {
                //calcular fec da linha
                double fecColuna = 0;
                //percorre linhas de cada coluna
                for (int i = 0; i < N; i++)
                {
                    double n = matrizMLEValores[i, j] > 0 ? 1 : 0;
                    n = n * GetTaxaFalha(j);
                    fecColuna += n;
                }
                //txtIndicadores.Text += "\n" + fecColuna.ToString() + " * " + rede.vertices.First(e => e.Id == j).NumeroDeConsumidores;

                //multiplica fec da coluna pelo numero de consumidores do no 
                fecColuna = fecColuna * redePrincipal.vertices.First(e => e.Id == j).NumeroDeConsumidores;

                //somatorio dos fecs de cada linha
                fecTotal += fecColuna;
            }

            //divide pelo numero total de consumidores da rede
            fecTotal /= redePrincipal.vertices.Sum(e => e.NumeroDeConsumidores);

            //txtIndicadores.Text += "\nTotal Consumidores: " + rede.vertices.Sum(e => e.NumeroDeConsumidores);

            //txtIndicadores.Text += "\nFEC Total: " + fecTotal.ToString("N2");
            txtIndicadores.Text += fecTotal.ToString("N2");

            return fecTotal;
        }
        #endregion

        #endregion

        public double GetTaxaFalha(int no)
        {
            double taxaFalha = -1;
            try
            {
                taxaFalha = redePrincipal.vertices.First(e => e.Id == no).TaxaDeFalha;
            }
            catch { }

            return taxaFalha;
        }
       
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = ! checkBox1.Checked;
        }

        public static bool isSwitchable(List<int> sw)
        {
            for (int i = 0; i < sw.Count(); i++)
            {
                if (sw[i] == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static Grafo multiplePrimSwitchable(List<Vertice> feeders)
        {
            Grafo redeNova = new Grafo();
            Grafo s;
            List<Grafo> graphs = new List<Grafo>();
            List<int> sw = new List<int>();

            for (int i = 0; i < feeders.Count(); i++)
            {
                s = new Grafo();
                s.vertices.Add(feeders[i]);
                Console.WriteLine(feeders[i].Id);
                graphs.Insert(i, s);
                sw.Add(0);
            }

            List<Aresta> edges;
            bool loop = true;
            
            int nextFeeder = 0;
            while (loop)
            {
                if (isSwitchable(sw))
                {
                    bool v = false;
                    for (int j = 0; j < feeders.Count(); j++)
                    {
                        //PEGA TODAS AS ARESTAS ADJACENTES AOS VERTICES DA SOLUCAO
                        edges = redePrincipal.edges
                            .Where(e => graphs[j].vertices.Contains(e.Origem))
                            .Where(e => e.Tipo == 0)
                            .OrderBy(e => e.Resistencia)
                            .ToList();

                        v = false;

                        if (edges.Count() != 0)
                        {
                            v = true;
                        }
                        //PARA CADA ARESTA NA SOLUCAO
                        for (int i = 0; i < edges.Count(); i++)
                        {

                            bool b = true;
                            for (int z = 0; z < feeders.Count(); z++)
                            {
                                //SE NAO EXISTE A ARESTA EM NENHUMA DAS SOLUCOES E SE NÃO EXISTE O VERTICE DE DESTINO EM NENHUMA DAS SOLUCOES
                                if (!graphs[z].edges.Exists(x => x.Equals(edges[i])) && !graphs[z].vertices.Exists(x => x.Equals(edges[i].Destino)))
                                {
                                    b = true;
                                }
                                else
                                {
                                    b = false;
                                    break;
                                }
                            }
                            if (b)
                            {
                                graphs[j].edges.Add(edges[i]);
                                graphs[j].edges.Add(oppositeVertice(edges[i].Destino, edges[i].Origem));
                                graphs[j].vertices.Add(edges[i].Destino);
                                v = false;
                            }

                        }
                        if (v)
                        {
                            sw[j] = 1;
                        }
                    }
                }
                else
                {
                    //   System.Threading.Thread.Sleep(5000);
                    for (int i = 0; i < feeders.Count(); i++)
                    {
                        sw[i] = 0;
                    }

                    int j = nextFeeder;
                    //PEGA TODAS AS ARESTAS ADJACENTES AOS VERTICES DA SOLUCAO
                    edges = redePrincipal.edges
                        .Where(e => graphs[j].vertices.Contains(e.Origem))
                        .OrderBy(e => e.Resistencia)
                        .ToList();

                    //PARA CADA ARESTA NA SOLUCAO
                    for (int i = 0; i < edges.Count(); i++)
                    {
                        bool b = true;
                        for (int z = 0; z < feeders.Count(); z++)
                        {
                            //SE NAO EXISTE A ARESTA EM NENHUMA DAS SOLUCOES E SE NÃO EXISTE O VERTICE DE DESTINO EM NENHUMA DAS SOLUCOES
                            if (!graphs[z].edges.Exists(x => x.Equals(edges[i])) && !graphs[z].vertices.Exists(x => x.Equals(edges[i].Destino)))
                            {
                                b = true;
                            }
                            else
                            {
                                b = false;
                                break;
                            }
                        }
                        if (b)
                        {
                            graphs[j].edges.Add(edges[i]);
                            graphs[j].edges.Add(oppositeVertice(edges[i].Destino, edges[i].Origem));
                            graphs[j].vertices.Add(edges[i].Destino);
                            break;
                        }
                    }
                    if (nextFeeder == feeders.Count() - 1)
                    {
                        nextFeeder = 0;
                    }
                    else
                    {
                        nextFeeder++;
                    }
                }
                int allVertices = 0;
                for (int x = 0; x < feeders.Count(); x++)
                {
                    allVertices = graphs[x].vertices.Count() + allVertices;
                }
                //SE TODOS O VERTICES FORAM ATIGINDOS FINALIZA LOOP SAO INATINGIVEIS
                if (redePrincipal.vertices.Count() <= allVertices)
                {
                    loop = false;
                }

            }


            //redeNova.vertices.AddRange(rede.vertices);


            //EXIBE A SOLUCAO
            Console.WriteLine("IMPRIME");
            for (int j = 0; j < feeders.Count(); j++)
            {
                Console.WriteLine("GRAFO" + j);
                for (int i = 0; i < graphs[j].edges.Count(); i = i + 2)
                {
                    //IMPRIME
                    Console.WriteLine("o:" + graphs[j].edges[i].Origem.Id + " d:" + graphs[j].edges[i].Destino.Id + " v:" + graphs[j].edges[i].Resistencia + " =" + graphs[j].edges[i].Tipo.ToString());

                    if (graphs[j].edges[i].Tipo == 3)
                    {
                        graphs[j].edges[i].Tipo = 1;
                    }

                    redeNova.edges.Add(graphs[j].edges[i]);
                }
            }
            Console.WriteLine("FIM");

            GeraChavesNA(redeNova);
            
            return redeNova;
        }

        /// <summary>
        /// Compara a nova rede coma rede original e adiciona chaves NA
        /// </summary>
        /// <param name="redeNova"></param>
        public static void GeraChavesNA(Grafo redeNova)
        {
            foreach (Aresta aresta in redePrincipal.edges)
            {
                //se a aresta nao existe
                if (!redeNova.edges.Exists(x => x.Origem.Id == aresta.Origem.Id && x.Destino.Id == aresta.Destino.Id))
                {
                    //e se nao existe no sentido contrario
                    if (!redeNova.edges.Exists(x => x.Origem.Id == aresta.Destino.Id && x.Destino.Id == aresta.Origem.Id))
                    {
                        //gera aresta NA e adiciona
                        aresta.Tipo = 3;
                        Vertice aux = aresta.Origem;
                        aresta.Origem = aresta.Destino;
                        aresta.Destino = aux;
                        redeNova.edges.Add(aresta);

                    }
                }

                //se o vertice destino nao existe, adiciona
                if (!redeNova.vertices.Exists(x => x.Id == aresta.Destino.Id))
                {
                    redeNova.vertices.Add(aresta.Destino);
                }
                //se o vertice origem nao existe, adiciona
                if (!redeNova.vertices.Exists(x => x.Id == aresta.Origem.Id))
                {
                    redeNova.vertices.Add(aresta.Origem);
                }
            }
        }

        public static Aresta oppositeVertice(Vertice o, Vertice d)
        {
            //PEGA O ARESTA INVERTIDA ONDE ORIGEM = DESTINO E DESTINO = ORIGEM
            List<Aresta> edges = redePrincipal.edges
                        .Where(e => e.Destino == d)
                        .Where(e => e.Origem == o)
                        .ToList();
            //RETORNA A ARESTA INVERTIDA
            return edges.First();
        }

        #region FLUXO DE POTENCIA

        List<Aresta> redeFluxoPotenciaParcial;
        List<Aresta> redeFluxoPotenciaTotal;
        private int idCaso;

        private void button2_Click(object sender, EventArgs e)
        {
            ExecutarFluxoPotencia();
        }

        public void ExecutarFluxoPotencia()
        {
            txtFluxoDePotencia.Text = "";
            redeFluxoPotenciaTotal = new List<Aresta>();

            //Solucao temporaria para evitar erro apos calculo de indicadores
            File teste = new File();
            redePrincipal = teste.Open(this.idCaso);

            foreach (Vertice verticeALimentador in redePrincipal.vertices.Where(o => o.Alimentador == 1).ToList())
            {
                FluxoPotencia(verticeALimentador);
            }
            //Gera o grafico com as informações do fluxo de potência
            CreateGraph(grafoDirigido, true);
        }

        /// <summary>
        /// Executa Fluxo de Potencias
        /// </summary>
        /// <param name="verticeAlimentador">Vértice Alimentador</param>
        private void FluxoPotencia(Vertice verticeAlimentador)
        {
            //Instacia Rede
            redeFluxoPotenciaParcial = new List<Aresta>();

            //Executa o Fluxo de Potencia
            try
            {
                BuscaSubRede(verticeAlimentador);
            }
            catch {
                MessageBox.Show("Fluxo de Potência não converge");
            }

            //Ordena os item da lista pelo id de destino
            //redeFluxoPotenciaParcial = redeFluxoPotenciaParcial.OrderBy(o => o.Destino.Id).ToList();
            redeFluxoPotenciaParcial = redeFluxoPotenciaParcial.OrderBy(o => o.idAresta).ToList();


            foreach (Aresta a in redeFluxoPotenciaParcial)
            {
                Console.WriteLine(a.Origem.Id.ToString() + " - " + a.Destino.Id.ToString());
            }
            Console.WriteLine();

            foreach (Aresta a in redeFluxoPotenciaParcial)
            {
                Console.WriteLine(a.Origem.idTemp.ToString() + " - " + a.Destino.idTemp.ToString());
            }
            Console.WriteLine();

            List<int> ids = redeFluxoPotenciaParcial.Select(o => o.Origem.Id).ToList();
            List<int> idsDestino = redeFluxoPotenciaParcial.Select(o => o.Destino.Id).ToList();
            ids.AddRange(idsDestino);
            ids = ids.Distinct().ToList();
            ids.Sort();

            int idTemp = 0;
            foreach (int idOriginal in ids)
            {
                List<Aresta> listTemp = redeFluxoPotenciaParcial.Where(o => o.Origem.Id == idOriginal).ToList();
                foreach (Aresta ar in listTemp)
                {
                    ar.Origem.idTemp = idTemp;
                }

                List<Aresta> listTemp2 = redeFluxoPotenciaParcial.Where(o => o.Destino.Id == idOriginal).ToList();
                foreach (Aresta ar in listTemp2)
                {
                    ar.Destino.idTemp = idTemp;
                }

                idTemp++;
            }
            

            int n = redeFluxoPotenciaParcial.Count;

            int[] INI = redeFluxoPotenciaParcial.Select(x => x.Origem.idTemp).ToArray();
            int[] FIM = redeFluxoPotenciaParcial.Select(x => x.Destino.idTemp).ToArray();
            double[] R = redeFluxoPotenciaParcial.Select(x => x.Resistencia).ToArray();
            double[] X = redeFluxoPotenciaParcial.Select(x => x.Reatancia).ToArray();

            double[] L = redeFluxoPotenciaParcial.Select(x => x.L).ToArray();
            double[] P = redeFluxoPotenciaParcial.Select(x => x.P * 1000).ToArray();
            double[] Q = redeFluxoPotenciaParcial.Select(x => x.Q * 1000).ToArray();

            double Vbase = 13800;
            double Erro = 0.000001; // 1e-6;

            // Cálculos iniciais
            double[] Vbar = Enumerable.Repeat(Vbase, n).ToArray();
            double[] V = new double[n];
            Array.Copy(Vbar, V, Vbar.Length);

            int[] MRC = Enumerable.Repeat(0, n).ToArray();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (FIM[i] == INI[j])
                    {
                        MRC[i] = 1;
                    }
                }
            }
            for (int i = 0; i < R.Length; i++)
            {
                R[i] = R[i] * L[i];
            }
            for (int i = 0; i < X.Length; i++)
            {
                X[i] = X[i] * L[i];
            }

            double[] Pac = Enumerable.Repeat(0.0, n).ToArray();
            double[] Qac = Enumerable.Repeat(0.0, n).ToArray();
            double[] LPac = Enumerable.Repeat(0.0, n).ToArray();
            double[] LQac = Enumerable.Repeat(0.0, n).ToArray();
            double[] A = Enumerable.Repeat(0.0, n).ToArray();
            double[] B = Enumerable.Repeat(0.0, n).ToArray();

            // Contador de iterações
            int IT = 0;
            double Prec = 99.99;

            //Início da iteração
            while (Prec > Erro) {

                //Incremento na iteração
                IT = IT + 1;

                //Cálculo das potências acumuladas
                for (int i = n - 1; i >= 0; i--) {
                    if (MRC[i] == 0) {
                        Pac[i] = P[i];
                        Qac[i] = Q[i];
                        LPac[i] = (R[i] * (Math.Pow(Pac[i], 2) + Math.Pow(Qac[i], 2))) / Math.Pow(V[i], 2);
                        LQac[i] = (X[i] * (Math.Pow(Pac[i], 2) + Math.Pow(Qac[i], 2))) / Math.Pow(V[i], 2);
                    }
                    else {
                        Pac[i] = 0.0;
                        Qac[i] = 0.0;
                        for (int j = 0; j < n; j++) {
                            if (INI[j] == FIM[i]) {
                                Pac[i] = Pac[i] + Pac[FIM[j] - 1 /*- verticeAlimentador.idTemp*/] + LPac[FIM[j] - 1 /*- verticeAlimentador.idTemp*/];           //ALTERACAO (Subtrai - o id do alimentador....)
                                Qac[i] = Qac[i] + Qac[FIM[j] - 1 /*- verticeAlimentador.idTemp*/] + LQac[FIM[j] - 1 /*- verticeAlimentador.idTemp*/];           //ALTERACAO
                            }
                        } 
                        Pac[i] = P[i] + Pac[i];
                        Qac[i] = Q[i] + Qac[i];
                        LPac[i] = (R[i] * (Math.Pow(Pac[i], 2) + Math.Pow(Qac[i], 2))) / Math.Pow(V[i], 2);
                        LQac[i] = (X[i] * (Math.Pow(Pac[i], 2) + Math.Pow(Qac[i], 2))) / Math.Pow(V[i], 2);
                    }
                }

                // Cálculo das tensões nas barras
                for (int i = 0; i < n; i++)
                {
                    double Vaux;
                    if (i == 0)
                    {
                        Vaux = Vbase;
                    }
                    else {
                        Vaux = V[INI[i] - 1 /*- verticeAlimentador.idTemp*/];                 //ALTERADO
                    }

                    A[i] = Pac[i] * R[i] + Qac[i] * X[i] - 0.5 * Math.Pow(Vaux, 2);
                    B[i] = Math.Sqrt(Math.Pow(A[i], 2) - (Math.Pow(Pac[i], 2) + Math.Pow(Qac[i], 2)) * (Math.Pow(R[i], 2) + Math.Pow(X[i], 2)));
                    V[i] = Math.Sqrt(B[i] - A[i]);
                }
                
                double[] vetAux = new double[Vbar.Length];
                for (int i = 0; i < Vbar.Length; i++)
                {
                    vetAux[i] = Math.Abs(V[i] - Vbar[i]);
                }
                Prec = vetAux.Max();
                
                Array.Copy(V, Vbar, V.Length);
            }

            // Cálculo do ângulo das tensões
            double[] dthetaR = Enumerable.Repeat(0.0, n).ToArray();
            double[] dthetaG = Enumerable.Repeat(0.0, n).ToArray();
            for (int i = 0; i < n; i++)
            {
                dthetaR[i] = Math.Atan((Pac[i] * X[i] - Qac[i] * R[i]) / (Pac[i] * R[i] + Qac[i] * X[i] + Math.Pow(V[i], 2)));
                dthetaG[i] = (dthetaR[i] * 180 / 3.14156);
            }

            // Cálculo das Correntes
            double[] I = Enumerable.Repeat(0.0, n).ToArray();
            for (int i = 0; i < n; i++)
            {
                I[i] = Math.Sqrt(Math.Pow(Pac[i], 2) + Math.Pow(Qac[i], 2)) / V[i];
            }

            //Armazenar tensões das barras(em pu)
            double[] Vpu = Enumerable.Repeat(0.0, n).ToArray();
            for (int i = 0; i < n; i++)
            {
                Vpu[i] = V[i] / Vbase;
            }

            // Cálculo das potências e perdas do sistema
            double LPsist = LPac.Sum();
            double LQsist = LQac.Sum();

            double Psist = (Pac[0] + LPac[0]);
            double Qsist = (Qac[0] + LQac[0]);

            // Cálculo da demanda
            double Pdem = P.Sum();
            double Qdem = Q.Sum();

            //for (int ip = 0; ip < Pac.Length; ip++)
            //{
            //    Edge ed = gViewer1.Graph.Edges.First(o => o.Source == INI[ip].ToString() && o.Target == FIM[ip].ToString());
            //    ed.Attr.Fontcolor = Microsoft.Glee.Drawing.Color.Black;
            //    ed.Attr.Label = P[ip].ToString();
            //}
            //gViewer1.Refresh();

            for (int ip = 0; ip < Pac.Length; ip++)
            {
                redeFluxoPotenciaParcial[ip].fluxoPotencia = I[ip];
            }

            // Impressão de Resultados
            txtFluxoDePotencia.Text += "Vertice Alimentador: " + verticeAlimentador.Id + "\n";
            txtFluxoDePotencia.Text += "\nNúmero de Barras: " + n;
            txtFluxoDePotencia.Text += "\nPotência Ativa (kW): " + (Pdem / 1000).ToString("N3").Replace(".", "");
            txtFluxoDePotencia.Text += "\nPotência Reativa (kvar): " + (Qdem / 1000).ToString("N3").Replace(".", "");
            txtFluxoDePotencia.Text += "\nPerda Ativa (kW): " + (LPsist / 1000).ToString("N3").Replace(".", "");
            txtFluxoDePotencia.Text += "\nPerda Reativa (kvar): " + (LQsist / 1000).ToString("N3").Replace(".", "");
            txtFluxoDePotencia.Text += "\nPerda Ativa (%): " + (100 * LPsist / Pdem).ToString("N2");
            txtFluxoDePotencia.Text += "\nNúmero de Iterações: " + IT;
            txtFluxoDePotencia.Text += "\n\n----------------------------------------------------------------------\n";

            redeFluxoPotenciaTotal.AddRange(redeFluxoPotenciaParcial);
            
        }



        /// <summary>
        /// Busca uma subRede a partir de determinado Alimentador. 
        /// </summary>
        /// <param name="alimentador">Id do Alimentador</param>
        /// <returns></returns>
        private bool BuscaSubRede(Vertice alimentador)
        {

            bool solved = false;

            List<Aresta> edges = redePrincipal.edges.Where(p => p.Origem.Id == alimentador.Id && p.Tipo != 3 /*&& p.EdgeOposto == false*/).ToList();

            int n = 0;
            while (!solved && n < edges.Count)
            {
                redeFluxoPotenciaParcial.Add(edges[n]);
                solved = BuscaSubRede(edges[n].Destino);
                n++;
            }

            return solved;
        }
        #endregion

        /// <summary>
        /// Reconfiguração da Rede
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            ReconfigurarRede();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ExibirRedeOriginal();
        }

        /// <summary>
        /// Exibir Rede Original
        /// </summary>
        public void ExibirRedeOriginal()
        {
            SetDiagramaRede(this.idCaso, true);
            //btReconfigurarRede.Enabled = true;

            Control myControl = this;
            while (myControl.Parent != null)
            {

                if (myControl.Parent != null)
                {
                    myControl = myControl.Parent;
                    if (myControl.Name == "FormMLE")
                    {
                        ((FormMLE)myControl).HabilitarBotaoReconfigurarRede(true);
                    }
                }

            }
        }

        /// <summary>
        /// Reconfigurar Rede
        /// </summary>
        public void ReconfigurarRede()
        {
            //Duplica as linhas da rede, adicionando-as em sentidos opostos
            List<Aresta> lista = this.CreateOppositeVertices();
            redePrincipal.edges.AddRange(lista);

            List<Vertice> vertices = new List<Vertice>();

            foreach (Vertice v in redePrincipal.vertices)
            {
                if (v.Alimentador == 1)
                {
                    vertices.Add(v);
                }
            }
            redePrincipal = multiplePrimSwitchable(vertices);


            foreach (Aresta v in redePrincipal.edges)
            {
                Console.WriteLine(v.Origem.Id + " - " + v.Destino.Id);
            }

            //Abre arquivos e gera a estrutura da rede
            //File teste = new File();
            //rede = teste.Open(1);

            grafoDirigido = false;
            CreateGraph(grafoDirigido, false);

            //btReconfigurarRede.Enabled = false;

            Control myControl = this;
            while (myControl.Parent != null)
            {

                if (myControl.Parent != null)
                {
                    myControl = myControl.Parent;
                    if (myControl.Name == "FormMLE")
                    {
                        ((FormMLE)myControl).HabilitarBotaoReconfigurarRede(false);
                    }
                }

            }

        }
    }

    enum enumtipoAresta
    {
        Comum,
        NF,
        FU,
        NA
    }
}
