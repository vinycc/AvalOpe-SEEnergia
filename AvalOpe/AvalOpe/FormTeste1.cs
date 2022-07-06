using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mommosoft.ExpertSystem;

namespace AvalOpe
{
    public partial class FormTeste1 : Form
    {
        //-----------------------------------------------------------------
        private Mommosoft.ExpertSystem.Environment clips;
        private class Acoes
        {
            public string acao { get; set; }
        }

        public FormTeste1()
        {
            InitializeComponent();
            clips = new Mommosoft.ExpertSystem.Environment();
            clips.Load("arquivoCLIPS2.clp");
        }

        //------------------------------------------------------------------
       
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void btEnviar_Click(object sender, EventArgs e)
        {
            if (this.ValidarCampos())
            {
                clips.Reset();
                this.SetFacts();
                clips.Run();
                this.GetRules();
            }
            else
            {
                MessageBox.Show("O preenchimentos dos campos são obrigatórios");
            }
        }

        private bool ValidarCampos()
        {
            if (this.cbConsumidorPrioritario.SelectedIndex < 0)
            {
                return false;
            }
            if (this.cbFioPartido.SelectedIndex < 0)
            {
                return false;
            }
            if (this.cbTensao.SelectedIndex < 0)
            {
                return false;
            }
            if (String.IsNullOrEmpty(this.txtHorasManutencao.Text))
            {
                return false;
            }
            return true;
        }

        private void SetFacts()
        {
            string strFioPartido = cbFioPartido.SelectedIndex == 0 ? "S" : "N";
            string strConsumidorPrioritario = cbConsumidorPrioritario.SelectedIndex == 0 ? "S" : "N";
            string strTensao = cbTensao.SelectedIndex == 0 ? "S" : "N";
            string strHorasManutencao = txtHorasManutencao.Text;
            clips.AssertString("(seguranca (fio_partido " + strFioPartido + "))");
            clips.AssertString("(servico (consumidor_prioritario " + strConsumidorPrioritario + "))");
            clips.AssertString("(custo (tempo_execucao_manut " + strHorasManutencao + "))");
            clips.AssertString("(produto (tensao " + strTensao + "))");
        }

        private void GetRules()
        {
            //Strings para acessar funções do CLIPS
            string strEvalSeguranca = "(MAIN::get-resposta-seguranca)";
            string strEvalCusto = "(MAIN::get-resposta-custo)";
            string strEvalServico = "(MAIN::get-resposta-servico)";
            string strEvalProduto = "(MAIN::get-resposta-produto)";

            String r_seguranca = "";
            String r_custo = "";
            String r_servico = "";
            String r_produto = "";

            MultifieldValue mv = (MultifieldValue)clips.Eval(strEvalSeguranca);
            for (int i = 0; i < mv.Count; i++)
            {
                FactAddressValue fv = (FactAddressValue)mv[i];
                r_seguranca = ((SymbolValue)fv.GetFactSlot("r"));
            }

            mv = (MultifieldValue)clips.Eval(strEvalCusto);
            for (int i = 0; i < mv.Count; i++)
            {
                FactAddressValue fv = (FactAddressValue)mv[i];
                r_custo = ((SymbolValue)fv.GetFactSlot("r"));
            }

            mv = (MultifieldValue)clips.Eval(strEvalServico);
            for (int i = 0; i < mv.Count; i++)
            {
                FactAddressValue fv = (FactAddressValue)mv[i];
                r_servico = ((SymbolValue)fv.GetFactSlot("r"));
            }

            mv = (MultifieldValue)clips.Eval(strEvalProduto);
            for (int i = 0; i < mv.Count; i++)
            {
                FactAddressValue fv = (FactAddressValue)mv[i];
                r_produto = ((SymbolValue)fv.GetFactSlot("r"));
            }
            List<Acoes> wineRecList = new List<Acoes>();
            if (!string.IsNullOrEmpty(r_seguranca))
                wineRecList.Add(new Acoes() { acao = r_seguranca });
            if (!string.IsNullOrEmpty(r_custo))
                wineRecList.Add(new Acoes() { acao = r_custo });
            if (!string.IsNullOrEmpty(r_servico))
                wineRecList.Add(new Acoes() { acao = r_servico });
            if (!string.IsNullOrEmpty(r_produto))
                wineRecList.Add(new Acoes() { acao = r_produto });

            dataGridView1.DataSource = wineRecList;

            DataGridViewColumn c = dataGridView1.Columns[0];
            //c.Width = 600;
            c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[0].HeaderText = "Ações a serem executadas";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clips = new Mommosoft.ExpertSystem.Environment();
            clips.Load("CPFL_1.clp");

            clips.Reset();
            clips.Run();
            
        }
    }
}
