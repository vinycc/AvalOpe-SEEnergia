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
    public partial class FormAvaliarCriterioLimiteTensao : Form
    {
        public double avaliacao { get; set; }
        public object fo { get; set; }

        public FormAvaliarCriterioLimiteTensao(double pesoRoc, object f)
        {
            InitializeComponent();

            this.fo = f;

            txtAdequado.Text = "1";
            txtRazoavel.Text = "0,8";
            txtInadequado.Text = "0";
            txtPeso.Text = pesoRoc.ToString("N3");

            CalcularPontuacao();
        }

        #region EVENTOS TEXTBOX
        private void txtAdequado_TextChanged(object sender, EventArgs e)
        {
            CalcularPontuacao();
        }
        #endregion

        #region EVENTOS SCROLL
        private void trackAdequado_Scroll(object sender, EventArgs e)
        {
            if (trackAdequado.Value == 1)
            {
                trackInadequado.Value = 0;
                trackRazoavel.Value = 0;
            }
            CalcularPontuacao();
        }

        private void trackRazoavel_Scroll(object sender, EventArgs e)
        {
            if (trackRazoavel.Value == 1)
            {
                trackInadequado.Value = 0;
                trackAdequado.Value = 0;
            }
            CalcularPontuacao();
        }

        private void trackInadequado_Scroll(object sender, EventArgs e)
        {
            if (trackInadequado.Value == 1)
            {
                trackAdequado.Value = 0;
                trackRazoavel.Value = 0;
            }
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
                this.avaliacao = Convert.ToDouble(txtAvaliacao.Text)*100;
            }
            catch
            {
                this.avaliacao = 0;
            }


            ((ucArvoreSubtransmissao)this.fo).criterioLIMITETENSAO.SetDesvio(this.avaliacao);
            ((ucArvoreSubtransmissao)this.fo).criterioLIMITETENSAO.SetColor(this.avaliacao, true);
            this.Close();
        }
        #endregion

        #region CÁLCULO
        void CalcularPontuacao()
        {
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

                txtNota.Text = pontuacao.ToString("N1");
                txtAvaliacao.Text = avaliacao.ToString("N2");
            }
            catch
            {
                txtNota.Text = "0,00";
            }
        }
        #endregion
    }
}
