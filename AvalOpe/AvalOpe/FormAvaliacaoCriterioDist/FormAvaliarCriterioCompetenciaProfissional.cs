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

    public partial class FormAvaliarCriterioCompetenciaProfissional : Form
    {

        public double avaliacao { get; set; }
        public object fo { get; set; }


        public FormAvaliarCriterioCompetenciaProfissional(double pesoRoc, double pesoConhecimento, double pesoHabilidade, double pesoAtitude, AspectosPessoais asp, object f)
        {
            InitializeComponent();


            this.fo = f;

            txtPeso.Text = pesoRoc.ToString("N3");
            txtNota.Text = "0,00";
            txtAvaliacao.Text = "0,00";

            txtPesoConhecimento.Text = pesoConhecimento.ToString("N3");
            txtPesoHabilidade.Text = pesoHabilidade.ToString("N3");
            txtPesoAtitude.Text = pesoAtitude.ToString("N3");

            comboHabilidade.SelectedIndex = 0;
            comboConhecimento.SelectedIndex = 0;
            comboAtitudes.SelectedIndex = 0;


            if (asp != null)
            {
                comboHabilidade.SelectedIndex = asp.HabilidadeAvaliacao;
                comboConhecimento.SelectedIndex = asp.ConhecimentoAvaliacao;
                comboAtitudes.SelectedIndex = asp.AtitudeAvaliacao;

                txtObservação.Text = asp.Observacao;



            }
        }

        private void combo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularAvaliacao();
        }
        
        private void combo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularAvaliacao();
        }

        private void combo3_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularAvaliacao();
        }

        public void CalcularAvaliacao()
        {
            try
            {
                double nota1 = Convert.ToDouble(comboHabilidade.SelectedItem) * 10;
                double nota2 = Convert.ToDouble(comboConhecimento.SelectedItem) * 10;
                double nota3 = Convert.ToDouble(comboAtitudes.SelectedItem) * 10;

                double desvio1 = 100 - nota1;
                double desvio2 = 100 - nota2;
                double desvio3 = 100 - nota3;

                double peso1;
                double peso2;
                double peso3;

                try {
                    peso1 = Convert.ToDouble(txtPesoHabilidade.Text);
                }
                catch
                {
                    peso1 = 0;
                }
                try
                {
                    peso2 = Convert.ToDouble(txtPesoConhecimento.Text);
                }
                catch
                {
                    peso2 = 0;
                }
                try
                {
                    peso3 = Convert.ToDouble(txtPesoAtitude.Text);
                }
                catch
                {
                    peso3 = 0;
                }

                double t = (desvio1 * peso1 + desvio2 * peso2 + desvio3 * peso3) / (peso1 + peso2 + peso3);
                if (Double.IsNaN(t))
                    t = 0;

                double peso = Convert.ToDouble(txtPeso.Text);
                double pontuacao = t;  //(n1 + n2 + n3) / 3;
                double avaliacao = t;  //1 - pontuacao;

                txtNota.Text = pontuacao.ToString("N3");
                txtAvaliacao.Text = avaliacao.ToString("N3");
            }
            catch
            {
                txtNota.Text = "0,00";
            }
        }

        private void txtPeso_Leave(object sender, EventArgs e)
        {
            CalcularAvaliacao();
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
            AspectosPessoais aspecto = new AspectosPessoais
            {
                HabilidadeAvaliacao = comboHabilidade.SelectedIndex,
                HabilidadePeso = Convert.ToDouble(txtPesoHabilidade.Text),
                ConhecimentoAvaliacao = comboConhecimento.SelectedIndex,
                ConhecimentoPeso = Convert.ToDouble(txtPesoConhecimento.Text),
                AtitudeAvaliacao = comboAtitudes.SelectedIndex,
                AtitudePeso = Convert.ToDouble(txtPesoAtitude.Text),
                Observacao = txtObservação.Text,
                Peso = Convert.ToDouble(txtPeso.Text),
                Desvio = Convert.ToDouble(txtAvaliacao.Text)
            };
            ((ucArvoreDeCriterios)this.fo).SetAspectosPessoais(aspecto);



            try
            {
                this.avaliacao = Convert.ToDouble(txtAvaliacao.Text);
            }
            catch
            {
                this.avaliacao = 0;
            }

            ((ucArvoreDeCriterios)this.fo).criterioCOMPETENCIA.SetDesvio(this.avaliacao);
            ((ucArvoreDeCriterios)this.fo).criterioCOMPETENCIA.SetColor(this.avaliacao, true);

            ((ucArvoreDeCriterios)this.fo).criterioCOMPETENCIA.SetDesvio(this.avaliacao);
            ((ucArvoreDeCriterios)this.fo).criterioCOMPETENCIA.SetColor(this.avaliacao, true);



            //Filhos

            double desvio1 = 100 - (Convert.ToDouble(comboHabilidade.SelectedItem) * 10);
            double desvio2 = 100 - (Convert.ToDouble(comboConhecimento.SelectedItem) * 10); ;
            double desvio3 = 100 - (Convert.ToDouble(comboAtitudes.SelectedItem) * 10);

            double peso1 = 0;
            double peso2 = 0;
            double peso3 = 0;
            try
            {
                peso1 = Convert.ToDouble(txtPesoHabilidade.Text);
            }
            catch { }
            try
            {
                peso2 = Convert.ToDouble(txtPesoConhecimento.Text);
            }
            catch { }
            try
            {
                peso3 = Convert.ToDouble(txtPesoAtitude.Text);
            }
            catch { }


            ((ucArvoreDeCriterios)this.fo).criterioHABILIDADE.SetPeso(peso1, desvio1);
            ((ucArvoreDeCriterios)this.fo).criterioHABILIDADE.SetColor(desvio1, true);

            ((ucArvoreDeCriterios)this.fo).criterioCONHECIMENTO.SetPeso(peso2, desvio2);
            ((ucArvoreDeCriterios)this.fo).criterioCONHECIMENTO.SetColor(desvio2, true);

            ((ucArvoreDeCriterios)this.fo).criterioATITUDE.SetPeso(peso3, desvio3);
            ((ucArvoreDeCriterios)this.fo).criterioATITUDE.SetColor(desvio3, true);
            this.Close();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void txtPesoHabilidade_Leave(object sender, EventArgs e)
        {
            txtPesoHabilidade.Text = txtPesoHabilidade.Text.Replace(".", ",");
            try {
                double t = Convert.ToDouble(txtPesoHabilidade.Text);
            }
            catch
            {
                txtPesoHabilidade.Text = "0,000";
            }
        }

        private void txtPesoConhecimento_Leave(object sender, EventArgs e)
        {
            txtPesoConhecimento.Text = txtPesoConhecimento.Text.Replace(".", ",");
            try
            {
                double t = Convert.ToDouble(txtPesoConhecimento.Text);
            }
            catch
            {
                txtPesoConhecimento.Text = "0,000";
            }
        }

        private void txtPesoAtitude_Leave(object sender, EventArgs e)
        {
            txtPesoAtitude.Text = txtPesoAtitude.Text.Replace(".", ",");
            try
            {
                double t = Convert.ToDouble(txtPesoAtitude.Text);
            }
            catch
            {
                txtPesoAtitude.Text = "0,000";
            }
        }

        private void txtPesoHabilidade_Leave_1(object sender, EventArgs e)
        {
            CalcularAvaliacao();
        }
    }
}
