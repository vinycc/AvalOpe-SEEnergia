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
    public partial class FormAvaliarCriterioFecEvitado : Form
    {
        public double avaliacao { get; set; }
        public object fo { get; set; }


        public FormAvaliarCriterioFecEvitado(double pesoRoc, object f)
        {
            InitializeComponent();

            this.fo = f;

            txtAdequado.Text = "1";
            txtRazoavel.Text = "0,8";
            txtInadequado.Text = "0";
            txtPeso.Text = pesoRoc.ToString("N3");

            txtLimiteInferior.Text = "1";
            txtLimiteSuperior.Text = "3";
            txtValorFEC.Text = "5";

            trackAdequado.Enabled = false;
            trackRazoavel.Enabled = false;
            trackInadequado.Enabled = false;

            CalcularPontuacao();
        }

        void CalcularPontuacao()
        {
            try
            {
                double peso = Convert.ToDouble(txtPeso.Text);
                double pontuacao = 0;

                double fec = Convert.ToDouble(txtValorFEC.Text);
                double limiteInferior = Convert.ToDouble(txtLimiteInferior.Text);
                double limiteSuperior = Convert.ToDouble(txtLimiteSuperior.Text);

                if (fec <= limiteInferior)
                {
                    trackAdequado.Value = 0;
                    trackRazoavel.Value = 0;
                    trackInadequado.Value = 1;
                }
                else if (fec >= limiteSuperior)
                {
                    trackAdequado.Value = 1;
                    trackRazoavel.Value = 0;
                    trackInadequado.Value = 0;
                }
                else if (fec > limiteInferior && fec < limiteSuperior)
                {
                    trackAdequado.Value = 0;
                    trackRazoavel.Value = 1;
                    trackInadequado.Value = 0;
                }

                if (trackAdequado.Value == 1)
                    pontuacao = Convert.ToDouble(txtAdequado.Text);
                else if (trackRazoavel.Value == 1)
                    pontuacao = Convert.ToDouble(txtRazoavel.Text);
                else if (trackInadequado.Value == 1)
                    pontuacao = Convert.ToDouble(txtInadequado.Text);

                double avaliacao = 1 - pontuacao;

                txtPontuacao.Text = pontuacao.ToString("N1");
                txtAvaliacao.Text = avaliacao.ToString("N2");
            }
            catch
            {
                txtPontuacao.Text = "0,00";
            }
        }

        private void txtPeso_TextChanged(object sender, EventArgs e)
        {
            CalcularPontuacao();
        }

        private void txtValorFEC_TextChanged(object sender, EventArgs e)
        {
            CalcularPontuacao();
        }

        private void txtLimiteInferior_TextChanged(object sender, EventArgs e)
        {
            CalcularPontuacao();
        }

        private void txtLimiteSuperior_TextChanged(object sender, EventArgs e)
        {
            CalcularPontuacao();
        }

        private void txtAvaliacao_TextChanged(object sender, EventArgs e)
        {
            
        }

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

            ((ucArvoreSubtransmissao)this.fo).criterioFEC.SetDesvio(this.avaliacao);
            ((ucArvoreSubtransmissao)this.fo).criterioFEC.SetColor(this.avaliacao, true);
            this.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
