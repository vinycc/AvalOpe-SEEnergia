using OpenFile;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AvalOpe
{
    public partial class FormFluxoPotencia : Form
    {
        List<Aresta> redeFluxoPotencia;

        public FormFluxoPotencia()
        {
            InitializeComponent();

            comboRede.SelectedIndex = 0;
            splitContainer1.Panel2Collapsed = true;
            txtFluxo.Text = "";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void comboRede_SelectedIndexChanged(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = true;
            txtFluxo.Text = "";

            if (comboRede.SelectedIndex == 0)
            {
                btExecutarFluxo.Enabled = false;
                ucDiagrama.Visible = false;
            }
            else
            {
                btExecutarFluxo.Enabled = true;
                ucDiagrama.Visible = true;
                ucDiagrama.SetDiagramaRede(comboRede.SelectedIndex);
            }
        }

        private void btExecutarFluxo_Click(object sender, EventArgs e)
        {
            txtFluxo.Text = "";

            //int idAlimentador = 15;
            //Vertice v = rede.vertices.First(o => o.Id == idAlimentador);
            foreach (Vertice verticeALimentador in ucDiagrama.getRede().vertices.Where(o => o.Alimentador == 1).ToList())
            {
                FluxoPotencia(verticeALimentador);
            }

            splitContainer1.Panel2Collapsed = false;
        }

        /// <summary>
        /// Executa Fluxo de Potencias
        /// </summary>
        /// <param name="verticeAlimentador">Vértice Alimentador</param>
        private void FluxoPotencia(Vertice verticeAlimentador)
        {
            //Instacia Rede
            redeFluxoPotencia = new List<Aresta>();

            //Executa o Fluxo de Potencia
            BuscaSubRede(verticeAlimentador);

            //Ordena os item da lista pelo id de destino
            redeFluxoPotencia = redeFluxoPotencia.OrderBy(o => o.Destino.Id).ToList();

            //foreach(Aresta a in redeFluxoPotencia)
            //{
            //    Console.WriteLine(a.Origem.Id);
            //}

            int n = redeFluxoPotencia.Count;

            int[] INI = redeFluxoPotencia.Select(x => x.Origem.Id).ToArray();
            int[] FIM = redeFluxoPotencia.Select(x => x.Destino.Id).ToArray();
            double[] R = redeFluxoPotencia.Select(x => x.Resistencia).ToArray();
            double[] X = redeFluxoPotencia.Select(x => x.Reatancia).ToArray();

            double[] L = redeFluxoPotencia.Select(x => x.L).ToArray();
            double[] P = redeFluxoPotencia.Select(x => x.P * 1000).ToArray();
            double[] Q = redeFluxoPotencia.Select(x => x.Q * 1000).ToArray();

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
            while (Prec > Erro)
            {

                //Incremento na iteração
                IT = IT + 1;

                //Cálculo das potências acumuladas
                for (int i = n - 1; i >= 0; i--)
                {
                    if (MRC[i] == 0)
                    {
                        Pac[i] = P[i];
                        Qac[i] = Q[i];
                        LPac[i] = (R[i] * (Math.Pow(Pac[i], 2) + Math.Pow(Qac[i], 2))) / Math.Pow(V[i], 2);
                        LQac[i] = (X[i] * (Math.Pow(Pac[i], 2) + Math.Pow(Qac[i], 2))) / Math.Pow(V[i], 2);
                    }
                    else {
                        Pac[i] = 0.0;
                        Qac[i] = 0.0;
                        for (int j = 0; j < n; j++)
                        {
                            if (INI[j] == FIM[i])
                            {
                                Pac[i] = Pac[i] + Pac[FIM[j] - 1 - verticeAlimentador.Id] + LPac[FIM[j] - 1 - verticeAlimentador.Id];           //ALTERACAO (Subtrai - o id do alimentador....)
                                Qac[i] = Qac[i] + Qac[FIM[j] - 1 - verticeAlimentador.Id] + LQac[FIM[j] - 1 - verticeAlimentador.Id];           //ALTERACAO
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
                        Vaux = V[INI[i] - 1 - verticeAlimentador.Id];                 //ALTERADO
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

            // Impressão de Resultados
            txtFluxo.Text += "\nVertice Alimentador: " + verticeAlimentador.Id + "\n";
            //Console.WriteLine("VPU:");
            //for(int i = 0; i < Vpu.Length; i++)
            //{
            //    Console.WriteLine(Vpu[i]);
            //}
            
            //peso.ToString("N2");
            txtFluxo.Text += "\nNúmero de Barras: " + n;
            txtFluxo.Text += "\nPotência Ativa (kW): " + (Pdem / 1000).ToString("N3").Replace(".","");
            txtFluxo.Text += "\nPotência Reativa (kvar): " + (Qdem / 1000).ToString("N3").Replace(".", "");
            txtFluxo.Text += "\nPerda Ativa (kW): " + (LPsist / 1000).ToString("N3").Replace(".", "");
            txtFluxo.Text += "\nPerda Reativa (kvar): " + (LQsist / 1000).ToString("N3").Replace(".", "");
            txtFluxo.Text += "\nPerda Ativa (%): " + (100 * LPsist / Pdem).ToString("N2");
            txtFluxo.Text += "\nNúmero de Iterações: " + IT;
            //txtFluxo.Text += "Tempo de Simulação (seg): " + toc);
            txtFluxo.Text += "\n\n----------------------------------------------------------------------\n";
            
            ////Exibe no console
            //Console.WriteLine("ID\t\tOrigem\tDestino\tR\t\tX");
            //int ii = 1;
            //foreach (Aresta a in redeFluxoPotencia)
            //{
            //    Console.WriteLine(ii + "\t\t" + a.Origem.Id + "\t\t" + a.Destino.Id + "\t\t" + a.Resistencia + "\t\t" + a.Reatancia);
            //    ii++;
            //}
        }

        /// <summary>
        /// Busca uma subRede a partir de determinado Alimentador. 
        /// </summary>
        /// <param name="alimentador">Id do Alimentador</param>
        /// <returns></returns>
        private bool BuscaSubRede(Vertice alimentador)
        {
            bool solved = false;

            List<Aresta> edges = ucDiagrama.getRede().edges.Where(p => p.Origem.Id == alimentador.Id && p.Tipo != 3 /*&& p.EdgeOposto == false*/).ToList();

            int n = 0;
            while (!solved && n < edges.Count)
            {
                redeFluxoPotencia.Add(edges[n]);
                solved = BuscaSubRede(edges[n].Destino);
                n++;
            }

            return solved;
        }
    }
}
