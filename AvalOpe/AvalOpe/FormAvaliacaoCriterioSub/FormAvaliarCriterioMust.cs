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
    public partial class FormAvaliarCriterioMust : Form
    {
        public double avaliacao { get; set; }
        public object fo { get; set; }

        public FormAvaliarCriterioMust(double pesoRoc, object f)
        {
            InitializeComponent();

            this.fo = f;

            txtPeso.Text = pesoRoc.ToString("N3");

            CalcularPontuacao();

        }

        void CalcularPontuacao()
        {
            try
            {
                double peso = Convert.ToDouble(txtPeso.Text);
                double pontuacao = 1;
                if (trackAlerta.Value == 1)
                    pontuacao = 0;
                
                double avaliacao = 1 - pontuacao;

                txtNota.Text = pontuacao.ToString("N1");
                txtAvaliacao.Text = avaliacao.ToString("N2");
            }
            catch
            {
                txtNota.Text = "0,00";
            }
        }

        private void trackAlerta_Scroll(object sender, EventArgs e)
        {
            CalcularPontuacao();
        }

        private void txtPeso_TextChanged(object sender, EventArgs e)
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
                this.avaliacao = Convert.ToDouble(txtAvaliacao.Text) * 100;
            }
            catch
            {
                this.avaliacao = 0;
            }

            ((ucArvoreSubtransmissao)this.fo).criterioMUST.SetDesvio(this.avaliacao);
            ((ucArvoreSubtransmissao)this.fo).criterioMUST.SetColor(this.avaliacao, true);
            this.Close();
        }
    }
}
