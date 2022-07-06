using AvalOpe.UserControlsWPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AvalOpe.FormAvaliacaoCriterioSub
{
    public partial class FormAvaliarCriterioDM : Form
    {
        public double avaliacao { get; set; }
        public object fo { get; set; }

        public FormAvaliarCriterioDM(double pesoRoc, object f)
        {
            InitializeComponent();

            this.fo = f;

            txtAdequado.Text = "1";
            txtRazoavel.Text = "0,8";
            txtInadequado.Text = "0";
            txtPeso.Text = pesoRoc.ToString("N3");

            txtLimiteInferior.Text = "55";
            txtLimiteSuperior.Text = "110";

            txtCHI.Text = "1";
            txtCI.Text = "1";

            CalcularPontuacao();
            CalcularDM();
        }

        #region EVENTOS TEXTBOX
        private void txtCHI_TextChanged(object sender, EventArgs e)
        {
            CalcularDM();
        }
        private void txtCI_TextChanged(object sender, EventArgs e)
        {
            CalcularDM();
        }
        private void txtDM_TextChanged(object sender, EventArgs e)
        {
            CalcularPontuacao();
        }

        private void txtAdequado_TextChanged(object sender, EventArgs e)
        {
            CalcularPontuacao();
        }
        private void txtLimiteInferior_TextChanged(object sender, EventArgs e)
        {
            AtualizarLimites();
            CalcularPontuacao();
        }
        private void txtPeso_Leave(object sender, EventArgs e)
        {
            CalcularPontuacao();
        }
        #endregion

        #region EVENTOS SCROLL
        private void trackAdequado_Scroll(object sender, EventArgs e)
        {
        //    if (trackAdequado.Value == 1)
        //    {
        //        trackInadequado.Value = 0;
        //        trackRazoavel.Value = 0;
        //    }
        //    CalcularPontuacao();
        }
        private void trackRazoavel_Scroll(object sender, EventArgs e)
        {
        //    if (trackRazoavel.Value == 1)
        //    {
        //        trackInadequado.Value = 0;
        //        trackAdequado.Value = 0;
        //    }
        //    CalcularPontuacao();
        }
        private void trackInadequado_Scroll(object sender, EventArgs e)
        {
        //    if (trackInadequado.Value == 1)
        //    {
        //        trackAdequado.Value = 0;
        //        trackRazoavel.Value = 0;
        //    }
        //    CalcularPontuacao();
        }
        #endregion

        #region EVENTOS BOTÕES
        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                this.avaliacao = Convert.ToDouble(txtAvaliacao.Text)*100;
            }
            catch
            {
                this.avaliacao = 0;
            }

            ((ucArvoreSubtransmissao)this.fo).criterioDM.SetDesvio(this.avaliacao);
            ((ucArvoreSubtransmissao)this.fo).criterioDM.SetColor(this.avaliacao, true);
            this.Close();
        }
        #endregion

        #region CÁLCULOS
        void CalcularDM()
        {
            try
            {
                double chi = Convert.ToDouble(txtCHI.Text);
                double ci = Convert.ToDouble(txtCI.Text);
                double dm = (chi / ci) * 60;

                txtDM.Text = dm.ToString();
            }
            catch
            {
                txtDM.Text = "0";
            }
        }

        void CalcularPontuacao()
        {
            #region Atualiza Track
            double dm = 0;
            double limiteInferior = 0;
            double limiteSuperior = 0;

            try
            {
                dm = Convert.ToDouble(txtDM.Text);
                limiteInferior = Convert.ToDouble(txtLimiteInferior.Text);
                limiteSuperior = Convert.ToDouble(txtLimiteSuperior.Text);
            }
            catch { }

            if (dm <= limiteInferior)
            {
                trackAdequado.Value = 1;
                trackRazoavel.Value = 0;
                trackInadequado.Value = 0;
            }
            else if (dm > limiteInferior && dm <= limiteSuperior)
            {
                trackAdequado.Value = 0;
                trackRazoavel.Value = 1;
                trackInadequado.Value = 0;
            }
            else
            {
                trackAdequado.Value = 0;
                trackRazoavel.Value = 0;
                trackInadequado.Value = 1;
            }
            #endregion

            #region Atualiza Avaliação
            try
            {
                double peso = Convert.ToDouble(txtPeso.Text);
                double pontuacao = 0;
                if (trackAdequado.Value == 1)
                    pontuacao = Convert.ToDouble(txtAdequado.Text);
                else if (trackRazoavel.Value == 1)
                    pontuacao = Convert.ToDouble(txtRazoavel.Text);
                else if (trackInadequado.Value == 1)
                    pontuacao = Convert.ToDouble(txtInadequado.Text);

                double avaliacao = 1 - pontuacao;

                txtNota.Text = pontuacao.ToString();
                txtAvaliacao.Text = avaliacao.ToString("N3");
            }
            catch
            {
                txtNota.Text = "0";
            }
            #endregion
        }

        public void AtualizarLimites()
        {
            string inferior = "0";
            string superior = "0";

            try
            {
                inferior = txtLimiteInferior.Text;
                superior = txtLimiteSuperior.Text;
            }
            catch { }

            lblAdequado.Text = "Adequado? (DM até " + inferior + " min)";
            lblRazoavel.Text = "Razoável? (DM entre " + inferior + " e " + superior + " min)";
            lblInadequado.Text = "Inadequado? (DM maior que " + superior + " min)";
        }
        #endregion
    }
}
