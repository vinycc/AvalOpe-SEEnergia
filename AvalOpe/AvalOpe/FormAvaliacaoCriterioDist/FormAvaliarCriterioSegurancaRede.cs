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

namespace AvalOpe.FormAvaliacaoCriterioDist
{
    public partial class FormAvaliarCriterioSegurancaRede : Form
    {
        public double avaliacao { get; set; }
        public object fo { get; set; }

        public FormAvaliarCriterioSegurancaRede(double pesoRoc, object f)
        {
            InitializeComponent();

            this.fo = f;

            txtPeso.Text = pesoRoc.ToString("N3");

            trackBar1.Enabled = false;
            trackBar2.Enabled = false;
            trackBar3.Enabled = false;
            trackBar4.Enabled = false;
            trackBar5.Enabled = false;

            CalcularPontuacao();
        }

        void CalcularPontuacao()
        {
            try
            {
                double peso = Convert.ToDouble(txtPeso.Text);
                double pontuacao = 1;
                if (trackRisco.Value == 1)
                {
                    pontuacao = 0;
                    //if(trackBar1.Value == 1
                    //|| trackBar2.Value == 1
                    //|| trackBar3.Value == 1
                    //|| trackBar4.Value == 1
                    //|| trackBar5.Value == 1)
                    //{
                    //    pontuacao = 1;
                    //}
                }

                double avaliacao = 1 - pontuacao;

                txtNota.Text = pontuacao.ToString("N2");
                txtAvaliacao.Text = avaliacao.ToString("N2");
            }
            catch
            {
               txtNota.Text = "0,00";
            }
        }

        private void trackRisco_Scroll(object sender, EventArgs e)
        {
            if (trackRisco.Value == 1)
            {
                trackBar1.Enabled = true;
                trackBar2.Enabled = true;
                trackBar3.Enabled = true;
                trackBar4.Enabled = true;
                trackBar5.Enabled = true;
            }
            else
            {
                trackBar1.Enabled = false;
                trackBar2.Enabled = false;
                trackBar3.Enabled = false;
                trackBar4.Enabled = false;
                trackBar5.Enabled = false;
            }
            CalcularPontuacao();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
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
                this.avaliacao = Convert.ToDouble(txtAvaliacao.Text)*100;
            }
            catch
            {
                this.avaliacao = 0;
            }

            ((ucArvoreDeCriterios)this.fo).criterioSEGURANCA.SetDesvio(this.avaliacao);
            ((ucArvoreDeCriterios)this.fo).criterioSEGURANCA.SetColor(this.avaliacao, true);
            this.Close();
        }
    }
}
