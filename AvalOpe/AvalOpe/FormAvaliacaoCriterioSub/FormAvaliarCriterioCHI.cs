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
    public partial class FormAvaliarCriterioCHI : Form
    {
        public double avaliacao { get; set; }
        public object fo { get; set; }


        public FormAvaliarCriterioCHI(double pesoRoc , object f)
        {
            InitializeComponent();

            this.fo = f;

            txtAdequado.Text = "1";
            txtRazoavel.Text = "0,8";
            txtInadequado.Text = "0";
            txtPeso.Text = pesoRoc.ToString("N3");

            txtCHI.Text = "10";
            txtLimiteInferior.Text = "10000";
            txtLimiteSuperior.Text = "15000";

            CalcularPontuacao();
        }

        #region EVENTOS TEXTBOX
        private void txtAdequado_TextChanged(object sender, EventArgs e)
        {
            CalcularPontuacao();
        }

        private void txtCHI_TextChanged(object sender, EventArgs e)
        {
            AtualizarLimites();
            CalcularPontuacao();
        }

        private void txtPeso_TextChanged(object sender, EventArgs e)
        {
            CalcularPontuacao();
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
                this.avaliacao = Convert.ToDouble(txtDesvio.Text) * 100;
            }
            catch
            {
                this.avaliacao = 0;
            }

            ((ucArvoreSubtransmissao)this.fo).criterioCHI.SetDesvio(this.avaliacao);
            ((ucArvoreSubtransmissao)this.fo).criterioCHI.SetColor(this.avaliacao, true);

            this.Close();

        }
        #endregion

        #region CÁLCULOS
        void CalcularPontuacao()
        {
            #region Atualiza Track
            double chi = 0;
            double limiteInferior = 0;
            double limiteSuperior = 0;

            try
            {
               chi = Convert.ToDouble(txtCHI.Text);
                limiteInferior = Convert.ToDouble(txtLimiteInferior.Text);
                limiteSuperior = Convert.ToDouble(txtLimiteSuperior.Text);
            }
            catch { }

            if (chi <= limiteInferior)
            {
                trackAdequado.Value = 1;
                trackRazoavel.Value = 0;
                trackInadequado.Value = 0;
            }
            else if (chi > limiteInferior && chi <= limiteSuperior)
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

                txtAvaliacao.Text = pontuacao.ToString();
                txtDesvio.Text = avaliacao.ToString("N3");
            }
            catch
            {
                txtAvaliacao.Text = "0";
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

            lblAdequado.Text = "Adequado? ( CHI até " + inferior + " )";
            lblRazoavel.Text = "Razoável? ( CHI entre " + inferior + " e " + superior + " )";
            lblInadequado.Text = "Inadequado? ( CHI maior que " + superior + " )";
        }
        #endregion
    }
}
