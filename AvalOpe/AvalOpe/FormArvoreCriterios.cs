using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AvalOpe
{
    public partial class FormArvoreCriterios : Form
    {
        public bool Automatico { get; set; }
        public List<Criterio> listaCriterio;

        public FormArvoreCriterios()
        {
            InitializeComponent();
            comboOperador.SelectedIndex = 0;
            comboContingencia.SelectedIndex = 0;
            radioAutomatico.Checked = true;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void btGerarArvore_Click(object sender, EventArgs e)
        {
            if (radioAutomatico.Checked)
            {
                btReordenarCriterios.Text = "Reordenar Critérios";
            }
            else if (radioManual.Checked)
            {
                btReordenarCriterios.Text = "Visualizar Critérios";
            }
            lblAvaliacaoTitulo.Text = "";
            lblAvaliacao.Text = "";
            ucArvoreDeCriterios arvoreWPF = new ucArvoreDeCriterios(radioAutomatico.Checked, comboOperador.SelectedIndex, comboContingencia.SelectedIndex);
            ucArvore.Child = arvoreWPF;
            ucArvore.Update();
            arvoreWPF.SetCalculo(this, false);

            this.Automatico = radioAutomatico.Checked;
        }

        private void comboOperador_SelectedIndexChanged(object sender, EventArgs e)
        {
            habilitarBotaoGerarArvore();
        }

        private void radioAutomatico_CheckedChanged(object sender, EventArgs e)
        {
            habilitarBotaoGerarArvore();
        }
        private void radioManual_CheckedChanged(object sender, EventArgs e)
        {
            habilitarBotaoGerarArvore();
        }

        private void habilitarBotaoGerarArvore()
        {
            if ((comboOperador.SelectedIndex > 0 || comboContingencia.SelectedIndex > 0) && (radioAutomatico.Checked || radioManual.Checked))
            {
                btGerarArvore.Enabled = true;
            }
            else
            {
                btGerarArvore.Enabled = false;
            }
        }

        private void ucArvore_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {
            if (ucArvore.Child != null && ucArvore.Child.IsVisible)
            {
                btCalcularAvaliacao.Enabled = true;
                btReordenarCriterios.Visible = true; //radioAutomatico.Checked;
            }
        }

        public void CalcularAvaliacao()
        {
            //quando for preenchimento manual, verificar se a soma dos pesos é igual a 100 (100%). Se nao for exibir erro
            //if (! this.Automatico)
            //{
            //    double p = ((ucArvoreDeCriterios)ucArvore.Child).GetSomaPesos();
            //    if (p < 99.9 || p > 100.01)
            //    {
            //        if (Thread.CurrentThread.CurrentCulture.Name == "en-US")
            //        {
            //            MessageBox.Show("ERROR: The sum of the weights must be equal to 100.");
            //        }
            //        else
            //        {
            //            MessageBox.Show("ERRO: A soma dos pesos dos critérios deve ser igual a 100.");
            //        }
            //        return;
            //    }
            //}

            double valor = ((ucArvoreDeCriterios)ucArvore.Child).GetAvaliacao();

            if (Thread.CurrentThread.CurrentCulture.Name == "en-US")
            {
                lblAvaliacaoTitulo.Text = "Evaluation:";
            }
            else
            {
                lblAvaliacaoTitulo.Text = "Avaliação:";
            }

            lblAvaliacao.Text = valor.ToString("N2") + " %";

            lblAvaliacao.Visible = true;
            lblAvaliacaoTitulo.Visible = true;

            ((ucArvoreDeCriterios)ucArvore.Child).SetCalculo(this, true);
        }

        private void btCalcularAvaliacao_Click(object sender, EventArgs e)
        {
            CalcularAvaliacao();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ucArvore.Child != null)
            {
                List<Criterio> listaCriterios = ((ucArvoreDeCriterios)ucArvore.Child).GetListCriterios().Where(
                    //excluir Conhecimento, habilidade, atitude, stress e inativos
                    o=>o.Ativo == true &&
                    o.Id != (int)enumCriterios.criterioHabilidade &&
                    o.Id != (int)enumCriterios.criterioAtitude &&
                    o.Id != (int)enumCriterios.criterioConhecimento &&
                    o.Id != (int)enumCriterios.criterioStress &&
                    o.Id != (int)enumCriterios.criterioDMChave &&
                    o.Id != (int)enumCriterios.criterioDMDisjuntor &&
                    o.Id != (int)enumCriterios.criterioDMReligador &&
                    o.Id != (int)enumCriterios.criterioDMTransformador).ToList();

                listaCriterios = listaCriterios.OrderByDescending(o => o.Peso).ToList();

                DialogResult dr = new DialogResult();
                FormReordenarCriterios f = new FormReordenarCriterios(listaCriterios, false, false, ((ucArvoreDeCriterios)ucArvore.Child).automatico);
                dr = f.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    this.AtualizarArvoreCriterios(this.listaCriterio);
                }
            }
        }

        public void AtualizarArvoreCriterios(List<Criterio> lista)
        {
            ((ucArvoreDeCriterios)ucArvore.Child).AtualizarArvore(lista);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            habilitarBotaoGerarArvore();
        }
    }
}
