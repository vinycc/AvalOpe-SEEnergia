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
    public partial class FormRelatorioAvaliacao : Form
    {
        private class ItemsCriterio
        {
            public string Criterio { get; set; }
            public double Porcentagem { get; set; }

            public ItemsCriterio(string criterio, double porcentagem)
            {
                this.Criterio = criterio;
                this.Porcentagem = porcentagem;
            }
        }

        string[] avaliacoes = { "Selecione", "Queda de Poste", "Avaliação Teste 2", "Avaliação Teste 3", "MAZ-10" };

        //private Mommosoft.ExpertSystem.Environment enviroment;
        private bool ready = false;

        public FormRelatorioAvaliacao()
        {
            InitializeComponent();


            //enviroment = new Mommosoft.ExpertSystem.Environment();
            
            dataGridView.AutoGenerateColumns = false;
            comboBox1.DataSource = avaliacoes;

            //enviroment = new Mommosoft.ExpertSystem.Environment();
            //enviroment.Load("winedemo.clp");
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            RunWine();

            ready = true;
        }

        private void RunWine()
        {
            string item = (string)comboBox1.SelectedValue;

            UpdateRelatorio();
        }

        private void UpdateRelatorio()
        {
            List<ItemsCriterio> itensCriterio = new List<ItemsCriterio>();

            if (comboBox1.SelectedIndex == 1)
            {
                this.lblInstalacao.Text = "";
                this.lblDataAvaliacao.Text = "15/12/2015";
                this.lblOperador.Text = "João da Silva";
                this.lblAvaliacao.Text = "86.65%";

                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioMagnitudeTensao.EnumToString(), 0.00));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioVariacaoLinha.EnumToString(), 0.00));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioCompetencia.EnumToString(), 0.00));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioEUSD.EnumToString(), -0.82));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioDMIC.EnumToString(), 0.00));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioDEC.EnumToString(), 6.15));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioFEC.EnumToString(), -40.33));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioConsumidoes.EnumToString(), -38.37));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioTempoFila.EnumToString(), 60.00));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioConsumidoresPrioritario.EnumToString(), 38.46));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioChaveamento.EnumToString(), 25.00));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioSeguranca.EnumToString(), 0.00));
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                this.lblInstalacao.Text = "";
                this.lblDataAvaliacao.Text = "23/01/2016";
                this.lblOperador.Text = "José dos Santos";
                lblAvaliacao.Text = "70.00%";

                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioMagnitudeTensao.EnumToString(), 59));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioVariacaoLinha.EnumToString(), 2));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioCompetencia.EnumToString(), 0));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioEUSD.EnumToString(), 11));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioDMIC.EnumToString(), 6));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioDEC.EnumToString(), 5));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioFEC.EnumToString(), 1));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioConsumidoes.EnumToString(), 0));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioTempoFila.EnumToString(), 0));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioConsumidoresPrioritario.EnumToString(), 0));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioChaveamento.EnumToString(), 2));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioSeguranca.EnumToString(), 2));

            }
            else if (comboBox1.SelectedIndex == 3){
                this.lblInstalacao.Text = "";
                this.lblDataAvaliacao.Text = "07/11/2015";
                this.lblOperador.Text = "Antônio Vieira";
                this.lblAvaliacao.Text = "75.50%";

                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioMagnitudeTensao.EnumToString(), 5));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioVariacaoLinha.EnumToString(), 10));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioCompetencia.EnumToString(), 8));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioEUSD.EnumToString(), 15));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioDMIC.EnumToString(), 25));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioDEC.EnumToString(), 30));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioFEC.EnumToString(), 35));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioConsumidoes.EnumToString(), 40));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioTempoFila.EnumToString(), 45));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioConsumidoresPrioritario.EnumToString(), 20));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioChaveamento.EnumToString(), 0));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioSeguranca.EnumToString(), 2));
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                this.lblInstalacao.Text = "";
                this.lblDataAvaliacao.Text = "";
                this.lblOperador.Text = "";
                this.lblAvaliacao.Text = "84,86%";

                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioMagnitudeTensao.EnumToString(), 0));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioVariacaoLinha.EnumToString(), 0));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioCompetencia.EnumToString(), 0));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioEUSD.EnumToString(), 70.200));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioDMIC.EnumToString(), 70.500));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioDEC.EnumToString(), 70.600));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioFEC.EnumToString(), 0));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioConsumidoes.EnumToString(), 0));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioTempoFila.EnumToString(), 0));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioConsumidoresPrioritario.EnumToString(), 28.800));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioChaveamento.EnumToString(),72.000));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioSeguranca.EnumToString(), 0));
            }
            else
            {
                this.lblInstalacao.Text = "";
                this.lblDataAvaliacao.Text = "";
                this.lblOperador.Text = "";
                this.lblAvaliacao.Text = "";
            }
            dataGridView.DataSource = itensCriterio;
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView.ClearSelection();
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            string s = Enumeracoes.EnumToString(enumCriterios.criterioMagnitudeTensao);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                RunWine();
            }
        }
    }

    public enum enumCriterios
    {
        [Description("Magnitude de Tensão Mínima")]
        criterioMagnitudeTensao = 1,
        [Description("Variação do Carregamento de Linhas")]
        criterioVariacaoLinha = 2,
        [Description("Aspectos Pessoais e Profissionais")]
        criterioCompetencia = 3,
        [Description("EUSD")]
        criterioEUSD = 4,
        [Description("DMIC")]
        criterioDMIC = 5,
        [Description("Duração da Interrupção (DEC)")]
        criterioDEC = 6,
        [Description("Frequência de Interrupção (FEC)")]
        criterioFEC = 7,
        [Description("Número de Consumidores sem Energia")]
        criterioConsumidoes = 8,
        [Description("Tempo Médio de Fila")]
        criterioTempoFila = 9,
        [Description("Interrupção em Consumidores Prioritários")]
        criterioConsumidoresPrioritario = 10,
        [Description("Sequência de Chaveamentos")]
        criterioChaveamento = 11,
        [Description("Segurança da Rede")]
        criterioSeguranca = 12,
        [Description("Habilidade")]
        criterioHabilidade = 13,
        [Description("Conhecimento")]
        criterioConhecimento = 14,
        [Description("Atitude")]
        criterioAtitude = 15,
        [Description("Stress")]
        criterioStress = 16,
   
        [Description("DM")]
        criterioDM = 17,
        [Description("DM Chave")]
        criterioDMChave = 18,
        [Description("DM Transformador")]
        criterioDMTransformador = 19,
        [Description("DM Religador")]
        criterioDMReligador = 20,
        [Description("DM Disjuntor")]
        criterioDMDisjuntor = 21,

        [Description("Extra 1")]
        criterioExtra1 = 22,
        [Description("Extra 2")]
        criterioExtra2 = 23,
        [Description("Extra 3")]
        criterioExtra3 = 24,
        [Description("Extra 4")]
        criterioExtra4 = 25
    }

    //public enum enumCriteriosEnglish
    //{
    //    [Description("Minimum Voltage")]
    //    criterio01,
    //    [Description("Lines Loading")]
    //    criterio02,
    //    [Description("Personal Competence")]
    //    criterio03,
    //    [Description("Revenue Reduction")]
    //    criterio04,
    //    [Description("Penalties")]
    //    criterio05,
    //    [Description("Duration Time")]
    //    criterio06,
    //    [Description("Interruption Frequency")]
    //    criterio07,
    //    [Description("Number of Consumers")]
    //    criterio08,
    //    [Description("Queue Mean Time")]
    //    criterio09,
    //    [Description("Duration Time of High Priority Consumers")]
    //    criterio10,
    //    [Description("Switchings Number")]
    //    criterio11,
    //    [Description("Switchings Sequence")]
    //    criterio12,
    //    [Description("Network Safety")]
    //    criterio13,
    //    [Description("Skills")]
    //    criterio14,
    //    [Description("Knowledge")]
    //    criterio15,
    //    [Description("Atitude")]
    //    criterio16,
    //    [Description("Stress")]
    //    criterio17
    //}

    public enum enumCriteriosSubtransmissao
    {
        [Description("Limites de Tensão")]
        criterioLimiteTensao = 1,
        [Description("Limites de Carregamento")]
        criterioLimiteCarregamento = 2,
        [Description("FEC Evitado")]
        criterioFEC = 3,
        [Description("DM")]
        criterioDM = 4,
        [Description("CHI")]
        criterioCHI = 5,
        [Description("Competência Profissional")]
        criterioCompetencia = 6,
        [Description("MUST")]
        criterioMust = 7,
        [Description("Segurança na Rede")]
        criterioSeguranca = 8,
        [Description("Sequência de Restabelecimento")]
        criterioSequenciaRestabelecimento = 9,
        [Description("Conhecimentos")]
        criterioConhecimento = 10,
        [Description("Habilidades")]
        criterioHabilidade = 11,
        [Description("Atitudes")]
        criterioAtitude = 12,
        [Description("Stress")]
        criterioStress = 13,

        [Description("Extra 1")]
        criterioExtra1 = 14,
        [Description("Extra 2")]
        criterioExtra2 = 15,
        [Description("Extra 3")]
        criterioExtra3 = 16,
        [Description("Extra 4")]
        criterioExtra4 = 17
    }


}
