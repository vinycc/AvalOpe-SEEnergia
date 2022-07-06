using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using static AvalOpe.Enumeracoes;

using LINQtoCSV;

namespace AvalOpe
{

    public partial class FormAvaliacao : Form
    {
        public int nrRegistros = 0;
        public int nrRegistrosRecomendados = 0;
        public int nrTempoMedioManobra = 0;

        public int avaliacao { get; set; }

        public class AcoesRecomendadas
        {
            public int Numero { get; set; }
            public int Tempo { get; set; }
            public string Objeto { get; set; }
            public Enumeracoes.enumAcoes Acao { get; set; }
            public int AcaoCorreta { get; set; }
            public bool Visitado { get; set; }
            
            public AcoesRecomendadas(int numero, int tempo, string objeto, Enumeracoes.enumAcoes acao)
            {
                this.Numero = numero;
                this.Tempo = tempo;
                this.Objeto = objeto;
                this.Acao = acao;
            }

            public AcoesRecomendadas(int numero, int tempo, string objeto, Enumeracoes.enumAcoes acao, int acaoCorreta, bool visitado)
            {
                this.Numero = numero;
                this.Tempo = tempo;
                this.Objeto = objeto;
                this.Acao = acao;
                this.AcaoCorreta = acaoCorreta;
                this.Visitado = visitado;
            }
        }
        
        

        #region CORES DO GRID
        void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            switch (this.avaliacao)
            {
                case 0:
                    if (e.RowIndex == 8)
                        //Vermelho (erro)
                        gridOperador.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PeachPuff;
                    else if (e.RowIndex == nrRegistros - 1)
                        //Branco (total)
                        //dataGridView1.Rows[nrRegistros - 1].DefaultCellStyle.BackColor = Color.White;
                        gridOperador.Rows[nrRegistros - 1].DefaultCellStyle.BackColor = Color.PaleGreen;
                    else
                        //Verde (correto)
                        gridOperador.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PaleGreen;
                        break;
                case 1:
                    if (e.RowIndex == 3)
                        gridOperador.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PeachPuff;
                    else if (e.RowIndex == nrRegistros - 1)
                        //dataGridView1.Rows[nrRegistros - 1].DefaultCellStyle.BackColor = Color.White;
                        gridOperador.Rows[nrRegistros - 1].DefaultCellStyle.BackColor = Color.PaleGreen;
                    else
                        gridOperador.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PaleGreen;
                    break;
                case 2:
                    if (e.RowIndex == 1)
                        gridOperador.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PeachPuff;
                    else if (e.RowIndex == nrRegistros - 1)
                        //dataGridView1.Rows[nrRegistros - 1].DefaultCellStyle.BackColor = Color.White;
                        gridOperador.Rows[nrRegistros - 1].DefaultCellStyle.BackColor = Color.PaleGreen;
                    else
                        gridOperador.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PaleGreen;
                    break;
            }
            // dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.BackColor = Color.White;

        }

        void dataGridView2_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            //deixa tudo verde
            gridReferencia.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PaleGreen;
            
            /*
            switch (this.avaliacao)
            {
                case 0:
                    if (e.RowIndex == nrRegistrosRecomendados - 1)
                        //Branco (total)
                        //dataGridView2.Rows[nrRegistrosRecomendados - 1].DefaultCellStyle.BackColor = Color.White;
                        dataGridView1.Rows[nrRegistros - 1].DefaultCellStyle.BackColor = Color.PaleGreen;
                    else
                        //Verde (correto)
                        dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PaleGreen;
                    break;
                case 1:
                    if (e.RowIndex == nrRegistrosRecomendados - 1)
                        //dataGridView2.Rows[nrRegistrosRecomendados - 1].DefaultCellStyle.BackColor = Color.White;
                        dataGridView1.Rows[nrRegistros - 1].DefaultCellStyle.BackColor = Color.PaleGreen;
                    else
                        dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PaleGreen;
                    break;
                case 2:
                    if (e.RowIndex == nrRegistrosRecomendados - 1)
                        //dataGridView2.Rows[nrRegistrosRecomendados - 1].DefaultCellStyle.BackColor = Color.White;
                        dataGridView1.Rows[nrRegistros - 1].DefaultCellStyle.BackColor = Color.PaleGreen;
                    else
                        dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PaleGreen;
                    break;
            } 
            */   
        }
        #endregion

        public FormAvaliacao()
        {
            InitializeComponent();
            //this.gridOperador.RowPrePaint += dataGridView1_RowPrePaint;
            //this.gridReferencia.RowPrePaint += dataGridView2_RowPrePaint;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
            splitContainer1.SplitterDistance = splitContainer1.Width / 2;
        }

        public void NovaAvaliacaoParametros()
        {
            DialogResult dr = new DialogResult();
            FormAdicionarManobraParametro frm = new FormAdicionarManobraParametro();
            dr = frm.ShowDialog();
            if (dr == DialogResult.Yes)
            {
                this.lblTituloAvaliacao.Text = frm.Nome;
                this.lblLocalizacao.Text = frm.Localizacao;
                this.lblData.Text = frm.Data;
                this.lblOperador.Text = frm.Operador;

                splitContainer1.SplitterDistance = splitContainer1.Width / 2;
                panelConteudo.Visible = true;

                NovaAvaliacao(true);
            }
        }

        public void NovaAvaliacao(bool primeiraAvaliacao)
        {
            DialogResult dr = new DialogResult();
            FormAdicionarManobra frm = new FormAdicionarManobra(true, primeiraAvaliacao);
            dr = frm.ShowDialog();
            if (dr == DialogResult.Yes)
            {
                List<AcoesRecomendadas> acoes = new List<AcoesRecomendadas>();
                List<AcoesRecomendadas> acoesRecomendadas = new List<AcoesRecomendadas>();
                                
                int nr = 1;
                foreach (AcoesRecomendadas acao in frm.listaAcoes)
                {
                    acoes.Add(new AcoesRecomendadas((nr++), acao.Tempo, acao.Objeto, acao.Acao));
                    gridOperador.Rows.Add(
                        nr,
                        TimeSpan.FromMinutes(acao.Tempo).ToString(@"hh\:mm"),
                        acao.Objeto,
                        acao.Acao
                    );

                    acoesRecomendadas.Add(new AcoesRecomendadas((nr++), acao.Tempo, acao.Objeto, acao.Acao));
                    gridReferencia.Rows.Add(
                        nr,
                        TimeSpan.FromMinutes(acao.Tempo).ToString(@"hh\:mm"),
                        acao.Objeto,
                        acao.Acao
                    );
                }

                TimeSpan time = TimeSpan.FromMinutes(acoes.Last().Tempo);
                lblTempoOperador.Text = time.ToString(@"hh\:mm");

                time = TimeSpan.FromMinutes(acoesRecomendadas.Last().Tempo);
                lblTempoReferencia.Text = time.ToString(@"hh\:mm");

                nrRegistros = acoes.Count;
                nrRegistrosRecomendados = acoesRecomendadas.Count;

                splitContainer1.SplitterDistance = splitContainer1.Width / 2;
                panelConteudo.Visible = true;

                AtualizaNumeroSequencia();

                NovaAvaliacao(false);
            }
        }

        #region  ABRIR AVALIAÇÃO
        public void AbrirAvaliacao()
        {
            DialogResult dr = new DialogResult();
            FormSelecionarAvaliacao frmSelecionar = new FormSelecionarAvaliacao();
            dr = frmSelecionar.ShowDialog();
            if (dr == DialogResult.OK)
            {

                List<AcoesRecomendadas> acoesOperador = new List<AcoesRecomendadas>();
                List<AcoesRecomendadas> acoesRecomendadas = new List<AcoesRecomendadas>();

                this.avaliacao = frmSelecionar.avaliacao;

                #region AVALIACAO 1
                if (frmSelecionar.avaliacao == 0)
                {
                    this.lblTituloAvaliacao.Text = "Queda de Poste";
                    this.lblLocalizacao.Text = "";
                    this.lblData.Text = "15/12/2015";
                    this.lblOperador.Text = "João da Silva";

                    int nr = 1;
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 10, "CS_204", Enumeracoes.enumAcoes.Abrir));
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 11, "DJ_2", Enumeracoes.enumAcoes.Reconectar));
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 21, "CS_228", Enumeracoes.enumAcoes.Abrir));
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 22, "DJ_3", Enumeracoes.enumAcoes.Desligar));
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 23, "CS_32", Enumeracoes.enumAcoes.Fechar));
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 24, "DJ_3", Enumeracoes.enumAcoes.Reconectar));
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 39, "CS_212", Enumeracoes.enumAcoes.Abrir));
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 40, "DJ_1", Enumeracoes.enumAcoes.Desligar));
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 41, "CS_13", Enumeracoes.enumAcoes.Fechar));
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 42, "DJ_1", Enumeracoes.enumAcoes.Reconectar));
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 44, "DJ_1", Enumeracoes.enumAcoes.Desligar));// "Turn Off (protection)" ));
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 60, "CS_13", Enumeracoes.enumAcoes.Abrir));
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 61, "CS_12", Enumeracoes.enumAcoes.Fechar));
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 62, "DJ_1", Enumeracoes.enumAcoes.Reconectar));
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 63, "FU_1", Enumeracoes.enumAcoes.Desligar));// "Turn Off (Priority consumer disconnected)" ));
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 64, "CS_12", Enumeracoes.enumAcoes.Fechar));
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 65, "FU_1", Enumeracoes.enumAcoes.Abrir));
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 66, "FU_3", Enumeracoes.enumAcoes.Desligar));
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 67, "CS_32", Enumeracoes.enumAcoes.Abrir));
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 68, "FU_3", Enumeracoes.enumAcoes.Restaurar));
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 69, "FU_2", Enumeracoes.enumAcoes.Desligar));
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 79, "CS_212", Enumeracoes.enumAcoes.Fechar));
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 94, "CS_228", Enumeracoes.enumAcoes.Fechar));
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 104, "CS_204", Enumeracoes.enumAcoes.Fechar));
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 105, "FU_2", Enumeracoes.enumAcoes.Restaurar));// "Restore (Priority consumer restored)" ));

                    TimeSpan time = TimeSpan.FromMinutes(acoesOperador.Last().Tempo);
                    lblTempoOperador.Text = time.ToString(@"hh\:mm");

                    acoesRecomendadas.AddRange(acoesOperador);
                    time = TimeSpan.FromMinutes(acoesRecomendadas.Last().Tempo);
                    lblTempoReferencia.Text = time.ToString(@"hh\:mm");

                }
                #endregion

                #region AVALIAÇÃO 2
                if (frmSelecionar.avaliacao == 1)
                {
                    this.lblTituloAvaliacao.Text = "Teste Avaliação 1";
                    this.lblLocalizacao.Text = "";
                    this.lblData.Text = "15/12/2015";
                    this.lblOperador.Text = "José dos Santos";

                    int nr = 1;
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 15, "DJ_01", Enumeracoes.enumAcoes.Desligar));
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 20, "CS_03", Enumeracoes.enumAcoes.Abrir));
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 30, "FU_01", Enumeracoes.enumAcoes.Abrir));
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 45, "CS_04", Enumeracoes.enumAcoes.Abrir));
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 47, "DJ_01", Enumeracoes.enumAcoes.Ligar));
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 60, "FU_02", Enumeracoes.enumAcoes.Abrir));

                    TimeSpan time = TimeSpan.FromMinutes(acoesOperador.Last().Tempo);
                    lblTempoOperador.Text = time.ToString(@"hh\:mm");

                    acoesRecomendadas.AddRange(acoesOperador);
                    time = TimeSpan.FromMinutes(acoesRecomendadas.Last().Tempo);
                    lblTempoReferencia.Text = time.ToString(@"hh\:mm");

                }
                #endregion

                #region AVALIAÇÃO 3
                if (frmSelecionar.avaliacao == 2)
                {
                    this.lblTituloAvaliacao.Text = "Teste Avaliação 2";
                    this.lblLocalizacao.Text = "";
                    this.lblData.Text = "23/01/2016";
                    this.lblOperador.Text = "Antônio Vieira";

                    int nr = 1;
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 30, "DJ_01", Enumeracoes.enumAcoes.Abrir));     //Certo
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 45, "CS_01", Enumeracoes.enumAcoes.Ligar));     //Certo
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 60, "FU_02", Enumeracoes.enumAcoes.Fechar));    //ERRO
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 78, "RE_04", Enumeracoes.enumAcoes.Abrir));     //Certo
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 83, "DJ_01", Enumeracoes.enumAcoes.Fechar));    //Certo
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 83, "RE_03", Enumeracoes.enumAcoes.Desligar));  //ERRO

                    acoesOperador.Add(new AcoesRecomendadas((nr++), 83, "CF_01", Enumeracoes.enumAcoes.Desligar));  //Certo
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 83, "DJ_99", Enumeracoes.enumAcoes.Reconectar));     //ERRO
                    acoesOperador.Add(new AcoesRecomendadas((nr++), 83, "CF_01", Enumeracoes.enumAcoes.Ligar));     //Certo

                    TimeSpan time = TimeSpan.FromMinutes(acoesOperador.Last().Tempo);
                    lblTempoOperador.Text = time.ToString(@"hh\:mm");

                    //acoesRecomendadas.AddRange(acoes);
                    acoesRecomendadas.Add(new AcoesRecomendadas((nr++), 30, "DJ_01", Enumeracoes.enumAcoes.Abrir));
                    acoesRecomendadas.Add(new AcoesRecomendadas((nr++), 45, "CS_01", Enumeracoes.enumAcoes.Ligar));
                    acoesRecomendadas.Add(new AcoesRecomendadas((nr++), 60, "FU_02", Enumeracoes.enumAcoes.Abrir));
                    acoesRecomendadas.Add(new AcoesRecomendadas((nr++), 75, "RE_03", Enumeracoes.enumAcoes.Desligar));
                    acoesRecomendadas.Add(new AcoesRecomendadas((nr++), 78, "RE_04", Enumeracoes.enumAcoes.Abrir));
                    acoesRecomendadas.Add(new AcoesRecomendadas((nr++), 83, "DJ_01", Enumeracoes.enumAcoes.Fechar));

                    acoesRecomendadas.Add(new AcoesRecomendadas((nr++), 83, "CF_01", Enumeracoes.enumAcoes.Desligar));
                    acoesRecomendadas.Add(new AcoesRecomendadas((nr++), 83, "DJ_99", Enumeracoes.enumAcoes.Abrir));
                    acoesRecomendadas.Add(new AcoesRecomendadas((nr++), 83, "CF_01", Enumeracoes.enumAcoes.Ligar));

                    time = TimeSpan.FromMinutes(acoesRecomendadas.Last().Tempo);
                    lblTempoReferencia.Text = time.ToString(@"hh\:mm");

                }
                #endregion
                #region MAZ-10
                if (frmSelecionar.avaliacao == 3)
                {
                    this.lblTituloAvaliacao.Text = "MAZ-10";
                    this.lblLocalizacao.Text = "";
                    this.lblData.Text = "";
                    this.lblOperador.Text = "";


                    acoesOperador.Add(new AcoesRecomendadas(01, 0, "DJ_CB01", Enumeracoes.enumAcoes.Abrir));     //Certo
                    acoesOperador.Add(new AcoesRecomendadas(02, 30, "RE_03", Enumeracoes.enumAcoes.Abrir));     //Certo
                    acoesOperador.Add(new AcoesRecomendadas(03, 32, "RE_04", Enumeracoes.enumAcoes.Fechar));    //ERRO
                    acoesOperador.Add(new AcoesRecomendadas(04, 33, "KS_06", Enumeracoes.enumAcoes.Abrir));     //Certo
                    acoesOperador.Add(new AcoesRecomendadas(05, 35, "RE_03", Enumeracoes.enumAcoes.Fechar));    //Certo
                    acoesOperador.Add(new AcoesRecomendadas(06, 40, "KS_02", Enumeracoes.enumAcoes.Abrir));  //ERRO
                    acoesOperador.Add(new AcoesRecomendadas(07, 45, "RE_01", Enumeracoes.enumAcoes.Fechar));  //Certo
                    acoesOperador.Add(new AcoesRecomendadas(08, 46, " ", Enumeracoes.enumAcoes.Outro));     //ERRO
                    acoesOperador.Add(new AcoesRecomendadas(09, 61, " ", Enumeracoes.enumAcoes.Outro));     //Certo
                    acoesOperador.Add(new AcoesRecomendadas(10, 96, " ", Enumeracoes.enumAcoes.Outro));     //Certo
                    acoesOperador.Add(new AcoesRecomendadas(11, 97, "RE_01", Enumeracoes.enumAcoes.Ligar));     //Certo
                    acoesOperador.Add(new AcoesRecomendadas(12, 102, "KS_02", Enumeracoes.enumAcoes.Ligar));     //Certo
                    acoesOperador.Add(new AcoesRecomendadas(13, 103, "CB_01", Enumeracoes.enumAcoes.Ligar));     //Certo
                    acoesOperador.Add(new AcoesRecomendadas(14, 123, "RE_04", Enumeracoes.enumAcoes.Ligar));     //Certo
                    acoesOperador.Add(new AcoesRecomendadas(15, 128, "KS_06", Enumeracoes.enumAcoes.Ligar));     //Certo

                    TimeSpan time = TimeSpan.FromMinutes(acoesOperador.Last().Tempo);
                    lblTempoOperador.Text = time.ToString(@"hh\:mm");

                    //acoesRecomendadas.AddRange(acoes);
                    acoesRecomendadas.Add(new AcoesRecomendadas(01, 69, "DJ_CB01", Enumeracoes.enumAcoes.Abrir));     //Certo
                    acoesRecomendadas.Add(new AcoesRecomendadas(02, 99, "RE_03", Enumeracoes.enumAcoes.Abrir));     //Certo
                    acoesRecomendadas.Add(new AcoesRecomendadas(03, 101, "RE_04", Enumeracoes.enumAcoes.Fechar));    //ERRO
                    acoesRecomendadas.Add(new AcoesRecomendadas(04, 102, "KS_06", Enumeracoes.enumAcoes.Abrir));     //Certo
                    acoesRecomendadas.Add(new AcoesRecomendadas(05, 104, "RE_03", Enumeracoes.enumAcoes.Fechar));    //Certo
                    acoesRecomendadas.Add(new AcoesRecomendadas(06, 105, " ", Enumeracoes.enumAcoes.Abrir));  //ERRO
                    acoesRecomendadas.Add(new AcoesRecomendadas(07, 135, "KS_04", Enumeracoes.enumAcoes.Abrir));  //Certo
                    acoesRecomendadas.Add(new AcoesRecomendadas(08, 136, " ", Enumeracoes.enumAcoes.Outro));     //ERRO
                    acoesRecomendadas.Add(new AcoesRecomendadas(09, 146, "KS_04", Enumeracoes.enumAcoes.Fechar));     //Certo
                    acoesRecomendadas.Add(new AcoesRecomendadas(10, 147, " ", Enumeracoes.enumAcoes.Outro));     //Certo
                    acoesRecomendadas.Add(new AcoesRecomendadas(11, 160, "R", Enumeracoes.enumAcoes.Outro));     //Certo
                    acoesRecomendadas.Add(new AcoesRecomendadas(12, 195, " ", Enumeracoes.enumAcoes.Outro));     //Certo
                    acoesRecomendadas.Add(new AcoesRecomendadas(13, 196, "CB_01", Enumeracoes.enumAcoes.Ligar));     //Certo
                    acoesRecomendadas.Add(new AcoesRecomendadas(14, 206, "RE_04", Enumeracoes.enumAcoes.Abrir));     //Certo
                    acoesRecomendadas.Add(new AcoesRecomendadas(15, 208, "KS_06", Enumeracoes.enumAcoes.Fechar));     //Certo

                    time = TimeSpan.FromMinutes(acoesRecomendadas.Last().Tempo);
                    lblTempoReferencia.Text = time.ToString(@"hh\:mm");

                    //List<Manobra> listManobra = OpenCSV(true);
                    //foreach (Manobra m in listManobra)
                    //{
                    //    acoes.Add(new AcoesRecomendadas( Convert.ToInt32(m.Sequencia), 0, m.Objeto+"_"+m.DescricaoObjeto, enumAcoes.Abrir));     //Certo
                    //}
                }
                #endregion

                //GRID OPERADOR
                int idSequencia = 1;
                foreach (AcoesRecomendadas c in acoesOperador)
                {
                    gridOperador.Rows.Add(
                        idSequencia, 
                        TimeSpan.FromMinutes(c.Tempo).ToString(@"hh\:mm"), 
                        c.Objeto, 
                        c.Acao
                    );
                    idSequencia++;
                }
                nrRegistros = acoesOperador.Count;
                nrRegistrosRecomendados = acoesRecomendadas.Count;

                //gridOperador.Columns[0].HeaderText = Enumeracoes.enumColunas.Sequencia.EnumToString(); ;
                //gridOperador.Columns[1].HeaderText = Enumeracoes.enumColunas.Tempo.EnumToString(); ;
                //gridOperador.Columns[2].HeaderText = Enumeracoes.enumColunas.Objeto.EnumToString(); ;
                //gridOperador.Columns[3].HeaderText = Enumeracoes.enumColunas.Acao.EnumToString(); ;

                //GRID RECOMENDADO
                idSequencia = 1;
                foreach (AcoesRecomendadas c in acoesRecomendadas)
                {

                    gridReferencia.Rows.Add(
                        idSequencia,
                        TimeSpan.FromMinutes(c.Tempo).ToString(@"hh\:mm"),
                        c.Objeto,
                        c.Acao
                    );

                    idSequencia++;
                }
                nrRegistrosRecomendados = acoesRecomendadas.Count;

                //this.gridReferencia.DataBindingComplete += DataGridView2_DataBindingComplete;
                //gridReferencia.DataSource = acoesRecomendadas;

                //gridReferencia.Columns[0].HeaderText = Enumeracoes.enumColunas.Sequencia.EnumToString() ;
                //gridReferencia.Columns[1].HeaderText = Enumeracoes.enumColunas.Tempo.EnumToString() ;
                //gridReferencia.Columns[2].HeaderText = Enumeracoes.enumColunas.Objeto.EnumToString() ;
                //gridReferencia.Columns[3].HeaderText = Enumeracoes.enumColunas.Acao.EnumToString();

                splitContainer1.SplitterDistance = splitContainer1.Width / 2;

                panelConteudo.Visible = true;
            }
            else
            {
                if (dr == DialogResult.Cancel)
                {
                    //MessageBox.Show("User clicked Cancel button");
                }
            }



        }
        #endregion

        #region DEFINIR TEMPO MÉDIO DE MANOBRA
        private void PreecherGridReferencia(int tempoManobra)
        {
            DateTime tempo = new DateTime(2016, 1, 1, 0, 0, 0);
            foreach (DataGridViewRow row in gridReferencia.Rows)
            {
                tempo = tempo.AddMinutes(tempoManobra);
                row.Cells[1].Value = tempo.ToString("HH:mm");
            }
            lblTempoReferencia.Text = tempo.ToString("HH") + "h " + tempo.ToString("mm") + "min";
        }
        #endregion

        #region ADICIONA COMBOBOX NO GRID REFERENCIA
        private void DataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //for (int i = 0; i < gridReferencia.Rows.Count; i++)
            //{
            //    //Adiciona comboBox
            //    DataGridViewComboBoxCell comboBox = new DataGridViewComboBoxCell();
            //    comboBox.DataSource = Enum.GetValues(typeof(Enumeracoes.enumAcoes));
            //    comboBox.Value = ((AcoesRecomendadas)this.gridReferencia.Rows[0].DataBoundItem).Acao;
            //    this.gridReferencia.Rows[i].Cells[3] = comboBox;

                
            //    gridReferencia.Rows[i].Cells[3].Style.BackColor = Color.White;
            //}

           
        }

        #endregion

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxVisualizarAcoes.Checked)
            {
                //splitContainer1.SplitterDistance = splitContainer1.Width/2;
                splitContainer1.Panel2Collapsed = false;
                splitContainer1.Panel2.Show();
            }
            else {
                // splitContainer1.SplitterDistance = splitContainer1.Width;

                splitContainer1.Panel2Collapsed = true;
                splitContainer1.Panel2.Hide();
            }
            
        }

        private void btTempoPadrao_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            FormSelecionarTempo frmSelecionar = new FormSelecionarTempo();
            dr = frmSelecionar.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                this.PreecherGridReferencia(this.nrTempoMedioManobra);
            }
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (gridReferencia.SelectedRows.Count > 0)
            {
                //int sel = gridReferencia.SelectedRows[0].Index;
                gridReferencia.Rows.RemoveAt(gridReferencia.SelectedRows[0].Index);

                //Atualiza sequencia
                AtualizaNumeroSequencia();

            }else
            {
                MessageBox.Show("Não há item selecionado");
            }
        }

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            FormAdicionarManobra frmAdicionar = new FormAdicionarManobra(false, false);
            dr = frmAdicionar.ShowDialog();
            if (dr == DialogResult.OK)
            {

                gridReferencia.Rows.Add(
                    "0",
                    frmAdicionar.tempo,
                    frmAdicionar.objeto + "_" + frmAdicionar.idObjeto,
                    frmAdicionar.acao.EnumToString()
                );

                gridReferencia.ClearSelection();
                gridReferencia.Rows[gridReferencia.Rows.Count - 1].Selected = true;
                gridReferencia.FirstDisplayedScrollingRowIndex = gridReferencia.Rows.Count - 1;

                AtualizaNumeroSequencia();
                //gridReferencia.Rows.Insert(gridReferencia.SelectedRows[0].Index, r);

                //Atualiza Tempo Total
                lblTempoReferencia.Text = frmAdicionar.tempo;
            }
        }

        private void btSubir_Click(object sender, EventArgs e)
        {
            if (gridReferencia.SelectedRows.Count > 0)
            {
                if (gridReferencia.SelectedRows[0].Index > 0)
                {
                    DataGridViewSelectedRowCollection rOrigem = gridReferencia.SelectedRows;

                    int indiceOrigem = rOrigem[0].Index;
                    int indiceDestino = rOrigem[0].Index - 1;

                    //Armazenas as duas linhas que serão trocadas
                    DataGridViewRow Origem = gridReferencia.Rows[indiceOrigem];
                    DataGridViewRow Destino = gridReferencia.Rows[indiceDestino];

                    //Troca os tempos entre as duas ações
                    object tempo = Destino.Cells[1].Value;
                    Destino.Cells[1].Value = Origem.Cells[1].Value;
                    Origem.Cells[1].Value = tempo;

                    //Exclui as duas linhas
                    gridReferencia.Rows.RemoveAt(indiceOrigem);
                    gridReferencia.Rows.RemoveAt(indiceDestino);

                    //insere novamente em posições opostas
                    gridReferencia.Rows.Insert(indiceDestino, Origem);
                    gridReferencia.Rows.Insert(indiceOrigem, Destino);

                    gridReferencia.ClearSelection();
                    Origem.Selected = true;
                    gridReferencia.FirstDisplayedScrollingRowIndex = indiceDestino;

                    AtualizaNumeroSequencia();
                }
            }
            else
            {
                MessageBox.Show("Não há item selecionado");
            }
        }

        private void btDescer_Click(object sender, EventArgs e)
        {
            if (gridReferencia.SelectedRows.Count > 0)
            {
                if (gridReferencia.SelectedRows[0].Index <= gridReferencia.Rows.Count - 2)
                {
                    DataGridViewSelectedRowCollection rOrigem = gridReferencia.SelectedRows;

                    int indiceOrigem = rOrigem[0].Index;
                    int indiceDestino = rOrigem[0].Index + 1;

                    //Armazenas as duas linhas que serão trocadas
                    DataGridViewRow Origem = gridReferencia.Rows[indiceOrigem];
                    DataGridViewRow Destino = gridReferencia.Rows[indiceDestino];

                    //Troca os tempos entre as duas ações
                    object tempo = Destino.Cells[1].Value;
                    Destino.Cells[1].Value = Origem.Cells[1].Value;
                    Origem.Cells[1].Value = tempo;

                    //Exclui as duas linhas
                    gridReferencia.Rows.RemoveAt(indiceDestino);
                    gridReferencia.Rows.RemoveAt(indiceOrigem);

                    //insere novamente em posições opostas
                    gridReferencia.Rows.Insert(indiceOrigem, Destino);
                    gridReferencia.Rows.Insert(indiceDestino, Origem);

                    gridReferencia.ClearSelection();
                    Origem.Selected = true;
                    gridReferencia.FirstDisplayedScrollingRowIndex = indiceOrigem;

                    AtualizaNumeroSequencia();
                }
            }
            else
            {
                MessageBox.Show("Não há item selecionado");
            }
        }

        private void AtualizaNumeroSequencia()
        {
            int idSequencia = 1;
            foreach (DataGridViewRow row in gridReferencia.Rows)
            {
                row.Cells[0].Value = idSequencia;
                idSequencia++;
            }

            idSequencia = 1;
            foreach (DataGridViewRow row in gridOperador.Rows)
            {
                row.Cells[0].Value = idSequencia;
                idSequencia++;
            }

            if (gridOperador.Rows.Count > 0)
            {
                lblTempoOperador.Text = gridOperador.Rows[gridOperador.Rows.Count - 1].Cells[1].Value.ToString();
            }
            if (gridReferencia.Rows.Count > 0)
            {
                lblTempoReferencia.Text = gridReferencia.Rows[gridReferencia.Rows.Count - 1].Cells[1].Value.ToString();
            }
        }



        private void btEditar_Click(object sender, EventArgs e)
        {
            if (gridReferencia.SelectedRows.Count > 0)
            {
                DataGridViewRow Origem = gridReferencia.Rows[gridReferencia.SelectedRows[0].Index];

                DialogResult dr = new DialogResult();
                FormAdicionarManobra frmAdicionar = new FormAdicionarManobra(Origem.Cells[1].Value.ToString(), Origem.Cells[2].Value.ToString(), Origem.Cells[3].Value.ToString());
                dr = frmAdicionar.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Origem.Cells[1].Value = frmAdicionar.tempo;
                    Origem.Cells[2].Value = frmAdicionar.objeto + "_" + frmAdicionar.idObjeto;
                    Origem.Cells[3].Value = frmAdicionar.acao.EnumToString();

                    lblTempoReferencia.Text = frmAdicionar.tempo;
                }
            }
            else
            {
                MessageBox.Show("Não há item selecionado");
            }

        }


        private void btComparar_Click(object sender, EventArgs e)
        {
            //WriteCSV();
            List<AcoesRecomendadas> listaReferencia = new List<AcoesRecomendadas>();
            List<AcoesRecomendadas> listaOperador = new List<AcoesRecomendadas>();

            #region Lista de ações de referência
            foreach (DataGridViewRow row in gridReferencia.Rows)
            {
                enumAcoes ac;
                Enum.TryParse<enumAcoes>(row.Cells[3].Value.ToString(), out ac);
                double minut = TimeSpan.Parse(row.Cells[1].Value.ToString()).TotalMinutes;

                AcoesRecomendadas acao = new AcoesRecomendadas(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(minut), row.Cells[2].Value.ToString(), ac, -1, false);
                listaReferencia.Add(acao);
            }
            #endregion

            #region Lista de ações do operador
            foreach (DataGridViewRow row in gridOperador.Rows)
            {
                enumAcoes ac;
                Enum.TryParse<enumAcoes>(row.Cells[3].Value.ToString(), out ac);
                double minut = TimeSpan.Parse(row.Cells[1].Value.ToString()).TotalMinutes;

                AcoesRecomendadas acao = new AcoesRecomendadas(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(minut), row.Cells[2].Value.ToString(), ac, -1, false);
                listaOperador.Add(acao);
            }
            #endregion

            #region Busca Ações corretas
            List<AcoesRecomendadas> listaAcoesCorretas = new List<AcoesRecomendadas>();
            for (int p = 1; p <= listaOperador.Last().Numero; p++)
            {
                List<AcoesRecomendadas> listaRetorno = getListaAcoesCorretasPorComparacao(listaOperador, listaReferencia, p);
                if (listaRetorno != null && listaRetorno.Count > 0)
                {
                    foreach (AcoesRecomendadas ac in listaRetorno)
                    {
                        if (!listaAcoesCorretas.Exists(o => o.Numero > ac.Numero))
                        {
                            listaAcoesCorretas.Add(ac);
                        }
                    }

                    //listaAcoesCorretas.AddRange(listaRetorno);
                }
            }
            #endregion

            #region  Percorre lista de acoes do operador marcando como certo ou errado
            foreach (AcoesRecomendadas acao in listaOperador)
            {
                if (listaAcoesCorretas.Exists(o => o.Objeto == acao.Objeto && o.Acao == acao.Acao))
                {
                    //Se a acao existe na lista de acoes corretas, marca ACERTO...
                    acao.AcaoCorreta = 1;
                }
                else
                {
                    //...Senão marca ERRO
                    acao.AcaoCorreta = 0;
                }
            }
            #endregion

            #region  Pinta todas as linhas de Branco
            for (int i = 0; i < listaOperador.Count; i++)
            {
                DataGridViewCellStyle cor = new DataGridViewCellStyle();
                cor.BackColor = Color.White;
                gridOperador.Rows[i].Cells[0].Style = cor;
                gridOperador.Rows[i].Cells[1].Style = cor;
                gridOperador.Rows[i].Cells[2].Style = cor;
                gridOperador.Rows[i].Cells[3].Style = cor;
            }
            #endregion

            #region Percorre lista de acoes do operador e pinta as linhas de erro e acertos
            int j = 0;
            foreach (AcoesRecomendadas acOpe in listaOperador)
            {
                DataGridViewCellStyle corCerto = new DataGridViewCellStyle();

                if (acOpe.AcaoCorreta == 1)
                {
                    corCerto.BackColor = Color.LightGreen;
                }
                else if (acOpe.AcaoCorreta == 0)
                {
                    corCerto.BackColor = Color.Orange;
                }
                gridOperador.Rows[j].Cells[0].Style = corCerto;
                gridOperador.Rows[j].Cells[1].Style = corCerto;
                gridOperador.Rows[j].Cells[2].Style = corCerto;
                gridOperador.Rows[j].Cells[3].Style = corCerto;

                j++;
            }
            #endregion

            gridOperador.ClearSelection();
            gridReferencia.ClearSelection();
            
        }

        /// <summary>
        /// Retorna sublistas de acoes corretas de acordo com a comparação Referencia-Operador
        /// </summary>
        /// <param name="listaOperador">Lista de Ações do operador</param>
        /// <param name="listaReferencia">Lista de Ações de referência</param>
        /// <param name="numero">Numero da ação do operador a partir de onde será realizada a busca</param>
        /// <returns></returns>
        public List<AcoesRecomendadas> getListaAcoesCorretasPorComparacao(List<AcoesRecomendadas> listaOperador, List<AcoesRecomendadas> listaReferencia, int numero)
        {
            List<AcoesRecomendadas> listaRetorno = new List<AcoesRecomendadas>();
            for (int i = numero - 1; i < listaOperador.Count; i++)
            {
                if (listaReferencia.Where(x => x.Visitado == false).ToList().Exists(o => o.Objeto == listaOperador[i].Objeto && o.Acao == listaOperador[i].Acao && o.Numero >= i))
                {
                    listaRetorno.Add(listaOperador[i]);
                    listaReferencia.Where(x => x.Visitado == false).ToList().First(o => o.Objeto == listaOperador[i].Objeto && o.Acao == listaOperador[i].Acao).Visitado = true;
                }
            }
            return listaRetorno;
        }

        #region Botoes de controle do grid do operador
        private void button1_Click(object sender, EventArgs e)
        {
            if (gridOperador.SelectedRows.Count > 0)
            {
                if (gridOperador.SelectedRows[0].Index > 0)
                {
                    DataGridViewSelectedRowCollection rOrigem = gridOperador.SelectedRows;

                    int indiceOrigem = rOrigem[0].Index;
                    int indiceDestino = rOrigem[0].Index - 1;

                    //Armazenas as duas linhas que serão trocadas
                    DataGridViewRow Origem = gridOperador.Rows[indiceOrigem];
                    DataGridViewRow Destino = gridOperador.Rows[indiceDestino];

                    //Troca os tempos entre as duas ações
                    object tempo = Destino.Cells[1].Value;
                    Destino.Cells[1].Value = Origem.Cells[1].Value;
                    Origem.Cells[1].Value = tempo;

                    //Exclui as duas linhas
                    gridOperador.Rows.RemoveAt(indiceOrigem);
                    gridOperador.Rows.RemoveAt(indiceDestino);

                    //insere novamente em posições opostas
                    gridOperador.Rows.Insert(indiceDestino, Origem);
                    gridOperador.Rows.Insert(indiceOrigem, Destino);

                    gridOperador.ClearSelection();
                    Origem.Selected = true;
                    gridOperador.FirstDisplayedScrollingRowIndex = indiceDestino;

                    AtualizaNumeroSequencia();
                }
            }
            else
            {
                MessageBox.Show("Não há item selecionado");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (gridOperador.SelectedRows.Count > 0)
            {
                if (gridOperador.SelectedRows[0].Index <= gridOperador.Rows.Count - 2)
                {
                    DataGridViewSelectedRowCollection rOrigem = gridOperador.SelectedRows;

                    int indiceOrigem = rOrigem[0].Index;
                    int indiceDestino = rOrigem[0].Index + 1;

                    //Armazenas as duas linhas que serão trocadas
                    DataGridViewRow Origem = gridOperador.Rows[indiceOrigem];
                    DataGridViewRow Destino = gridOperador.Rows[indiceDestino];

                    //Troca os tempos entre as duas ações
                    object tempo = Destino.Cells[1].Value;
                    Destino.Cells[1].Value = Origem.Cells[1].Value;
                    Origem.Cells[1].Value = tempo;

                    //Exclui as duas linhas
                    gridOperador.Rows.RemoveAt(indiceDestino);
                    gridOperador.Rows.RemoveAt(indiceOrigem);

                    //insere novamente em posições opostas
                    gridOperador.Rows.Insert(indiceOrigem, Destino);
                    gridOperador.Rows.Insert(indiceDestino, Origem);

                    gridOperador.ClearSelection();
                    Origem.Selected = true;
                    gridOperador.FirstDisplayedScrollingRowIndex = indiceOrigem;

                    AtualizaNumeroSequencia();

                }
            }
            else
            {
                MessageBox.Show("Não há item selecionado");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            FormAdicionarManobra frmAdicionar = new FormAdicionarManobra(false, false);
            dr = frmAdicionar.ShowDialog();
            if (dr == DialogResult.OK)
            {

                gridOperador.Rows.Add(
                    "0",
                    frmAdicionar.tempo,
                    frmAdicionar.objeto + "_" + frmAdicionar.idObjeto,
                    frmAdicionar.acao.EnumToString()
                );

                gridOperador.ClearSelection();
                gridOperador.Rows[gridOperador.Rows.Count - 1].Selected = true;
                gridOperador.FirstDisplayedScrollingRowIndex = gridOperador.Rows.Count - 1;

                AtualizaNumeroSequencia();
                //gridReferencia.Rows.Insert(gridReferencia.SelectedRows[0].Index, r);

                
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (gridOperador.SelectedRows.Count > 0)
            {
                DataGridViewRow Origem = gridOperador.Rows[gridOperador.SelectedRows[0].Index];

                DialogResult dr = new DialogResult();
                FormAdicionarManobra frmAdicionar = new FormAdicionarManobra(Origem.Cells[1].Value.ToString(), Origem.Cells[2].Value.ToString(), Origem.Cells[3].Value.ToString());
                dr = frmAdicionar.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Origem.Cells[1].Value = frmAdicionar.tempo;
                    Origem.Cells[2].Value = frmAdicionar.objeto + "_" + frmAdicionar.idObjeto;
                    Origem.Cells[3].Value = frmAdicionar.acao.EnumToString();

                    AtualizaNumeroSequencia();
                }
            }
            else
            {
                MessageBox.Show("Não há item selecionado");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (gridOperador.SelectedRows.Count > 0)
            {
                //int sel = gridReferencia.SelectedRows[0].Index;
                gridOperador.Rows.RemoveAt(gridOperador.SelectedRows[0].Index);

                //Atualiza sequencia
                AtualizaNumeroSequencia();

            }
            else
            {
                MessageBox.Show("Não há item selecionado");
            }
        }

        #endregion

        //private void gridReferencia_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        //{
        //    if (e.ColumnIndex == 4 && e.RowIndex > -1)
        //    {
        //        Image img = Properties.Resources.delete;

        //        e.PaintContent(e.CellBounds);
        //        e.Graphics.DrawImage(img, e.CellBounds.Location);

        //        e.Handled = true;
        //    }
        //}


        CsvContext cc = new CsvContext();
        CsvFileDescription fileDescription = new CsvFileDescription
        {
            SeparatorChar = '\t', // tab delimited
            FirstLineHasColumnNames = false,
            EnforceCsvColumnAttribute = true
        };

        public void WriteCSV()
        {
            List<Manobra> manobras = new List<Manobra>();

            foreach (DataGridViewRow row in gridReferencia.Rows)
            {
                string s0 = row.Cells[0].Value.ToString();
                string s1 = row.Cells[1].Value.ToString();
                string s2 = row.Cells[2].Value.ToString().Split('_')[0];
                string s3 = row.Cells[2].Value.ToString().Split('_')[1];
                string s4 = row.Cells[3].Value.ToString();
            
                manobras.Add(new Manobra { Sequencia = s0, Tempo = s1, Objeto = s2, DescricaoObjeto = s3, Acao = s4 });
            }

            cc.Write(manobras, "Manobras2.csv", fileDescription);
        }

        List<Manobra> OpenCSV(bool referencia) {

            List<Manobra> listManobras = new List<Manobra>();
            IEnumerable<Manobra> manobras = cc.Read<Manobra>(@"manobras\maz-10\referencia.csv", fileDescription);

            var manobrasBySequencia =
                from m in manobras
                orderby m.Sequencia
                select new { m.Sequencia, m.Tempo, m.Objeto, m.DescricaoObjeto, m.Acao };

            foreach (var item in manobrasBySequencia) {
                Manobra man = new Manobra();
                man.Sequencia = item.Sequencia;
                man.Acao = item.Acao;
                man.DescricaoObjeto = item.DescricaoObjeto;
                man.Objeto = item.Objeto;
                man.Tempo = item.Objeto;
                listManobras.Add(man);
                //Console.WriteLine(item);
            }
            return listManobras;
        }

    }





}
