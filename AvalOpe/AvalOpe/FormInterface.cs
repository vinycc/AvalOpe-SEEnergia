using System;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using AvalOpe.FormAvaliacaoCriterioSub;

namespace AvalOpe
{
    public partial class FormInterface : Form
    {
        public int tipoSistema;

        #region LOAD
        public FormInterface(int tipo)
        {
            InitializeComponent();

            this.tipoSistema = tipo;
        }

        protected override void OnLoad(EventArgs e)
        {
            this.ReloadForm();

            //foreach (Form f in this.MdiChildren)
            //{
            //    if (f.GetType() == typeof(FormInicio))
            //    {
            //        f.Activate();
            //        return;
            //    }
            //}
            FormInicio form = new FormInicio(true);
            form.MdiParent = this;
            form.Show();

            base.OnLoad(e);
        }
        #endregion

        #region BOTOES
        private void bbToolStripMenuItem_Click(object sender, EventArgs e) { }

        //AVALIAÇÃO
        private void ccToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.showAvaliacao();
        }
        
        //CADASTRO TREINAMENTO
        private void cadastrarTreinamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.showCadastroTreinamento();
        }

        //TESTE INTEGRACAO CLIPS
        private void integraçãoCLIPSToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.showIntegracaoCLIPS();
        }

        //FECHAR
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Fechar();
            this.Close();
        }

        public void Fechar()
        {
            while (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }
        }
        #endregion

        public void setTipoSistema(int tipo)
        {
            this.tipoSistema = tipo;
            this.ReloadForm();
        }

        public void showAvaliacao()
        {
            //foreach (Form f in this.MdiChildren)
            //{
            //    if (f.GetType() == typeof(FormAvaliacao))
            //    {
            //        f.Activate();
            //        return;
            //    }
            //}
            FormAvaliacao form = new FormAvaliacao();
            form.MdiParent = this;
            form.Show();
        }

        public void showFluxoPotencia()
        {
            //foreach (Form f in this.MdiChildren)
            //{
            //    if (f.GetType() == typeof(FormFluxoPotencia))
            //    {
            //        f.Activate();
            //        return;
            //    }
            //}
            FormFluxoPotencia form = new FormFluxoPotencia();
            form.MdiParent = this;
            form.Show();
        }

        public void showReconfiguracaoDeRedes()
        {
            //foreach (Form f in this.MdiChildren)
            //{
            //    if (f.GetType() == typeof(FormReconfiguracaoRede))
            //    {
            //        f.Activate();
            //        return;
            //    }
            //}
            FormReconfiguracaoRede form = new FormReconfiguracaoRede();
            form.MdiParent = this;
            form.Show();
        }

        public void showCadastroTreinamento()
        {
            //foreach (Form f in this.MdiChildren)
            //{
            //    if (f.GetType() == typeof(FormCadastroTreinamento))
            //    {
            //        f.Activate();
            //        return;
            //    }
            //}
            FormCadastroTreinamento form = new FormCadastroTreinamento();
            form.MdiParent = this;
            form.Show();
        }

        public void showMatrizLogicoEstrutural()
        {

            //foreach (Form f in this.MdiChildren)
            //{
            //    if (f.GetType() == typeof(FormMLE))
            //    {
                    
            //        f.Activate();
            //        return;
            //    }
            //}
            FormMLE form = new FormMLE();
            form.MdiParent = this;
            form.Show();
        }

        public void showIntegracaoCLIPS()
        {
            //foreach (Form f in this.MdiChildren)
            //{
            //    if (f.GetType() == typeof(FormTeste1))
            //    {
            //        f.Activate();
            //        return;
            //    }
            //}
            FormTeste1 form = new FormTeste1();
            form.MdiParent = this;
            form.Show();
        }

        public void showIntegracaoFuzzy()
        {
            //foreach (Form f in this.MdiChildren)
            //{
            //    if (f.GetType() == typeof(FormTesteFuzzy))
            //    {
            //        f.Activate();
            //        return;
            //    }
            //}
            FormTesteFuzzy form = new FormTesteFuzzy();
            form.MdiParent = this;
            form.Show();
        }

        private void aaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setTipoSistema(1);
            exibeInicio(false);
        }

        private void abrirAvaliaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                f.Close();
            }

            //foreach (Form f in this.MdiChildren)
            //{
            //    if (f.GetType() == typeof(FormAvaliacao))
            //    {
            //        ((FormAvaliacao)f).AbrirAvaliacao();
            //        return;
            //    }
            //}
            FormAvaliacao form = new FormAvaliacao();
            form.MdiParent = this;
            form.Show();
            form.AbrirAvaliacao();
        }

        private void gerarRelatórioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void visualizarRelatórioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRelatorioAvaliacao f = new FormRelatorioAvaliacao();
            f.Show();
        }

        private void executarAlgoritmoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void matrizLógicoEstruturalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showMatrizLogicoEstrutural();
        }

        private void novaAvaliaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                f.Close();
            }

            FormAvaliacao form = new FormAvaliacao();
            form.MdiParent = this;
            form.Show();
            form.NovaAvaliacaoParametros();

        }

        private void arvoreDeCriteriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        public void showArvoreCriterios()
        {
            foreach (Form f in this.MdiChildren)
            {
                f.Close();
            }
            //foreach (Form f in this.MdiChildren)
            //{
            //    if (f.GetType() == typeof(FormArvoreCriterios))
            //    {
            //        f.Activate();
            //        return;
            //    }
            //}
            FormArvoreCriterios form = new FormArvoreCriterios();
            form.MdiParent = this;
            form.Show();
        }

        public void showArvoreSubtransmissao(bool ehMUST)
        {
            foreach (Form f in this.MdiChildren)
            {
                f.Close();
            }
            //foreach (Form f in this.MdiChildren)
            //{
            //    if (f.GetType() == typeof(FormArvoreSubtransmissao))
            //    {
            //        f.Activate();
            //        return;
            //    }
            //}
            FormArvoreSubtransmissao form = new FormArvoreSubtransmissao(ehMUST);
            form.MdiParent = this;
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FormAvaliarCriterioLimiteTensao f = new FormAvaliarCriterioLimiteTensao();
            //f.Show();
            
        }

        private void estatísticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEstatistica f = new FormEstatistica();
            f.Show();
        }

        private void integraçãoFuzzyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.showIntegracaoFuzzy();
        }

        private void executarAlgoritmoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            

        }

        private void fluxoDePotênciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //foreach (Form f in this.MdiChildren)
            //{
            //    if (f.GetType() == typeof(FormFluxoPotencia))
            //    {
            //        f.Activate();
            //        return;
            //    }
            //}
            FormFluxoPotencia form = new FormFluxoPotencia();
            form.MdiParent = this;
            form.Show();
        }

        public void ReloadForm()
        {
            if (this.tipoSistema == 0)
            {
                this.Text = "AvalOpe";

                //desabilitar todos os menus
                menuDistribuicao.Visible = false;
                menuSubtransmissao.Visible = false;
            }
            else if (this.tipoSistema == 1)
            {
                if (Thread.CurrentThread.CurrentCulture.Name == "en-US")
                {
                    this.Text = "AvalOpe Distribution";
                }
                else
                {
                    this.Text = "AvalOpe Distribuição";
                }
                //Distribuição - Exibe botões específicos
                menuDistribuicao.Visible = true;
                menuSubtransmissao.Visible = false;
            }
            else
            {
                if (Thread.CurrentThread.CurrentCulture.Name == "en-US")
                {
                    this.Text = "AvalOpe Subtransmission";
                }
                else
                {
                    this.Text = "AvalOpe Subtransmissão";
                }

                //Subtransmissão - Exibe botões específicos
                menuDistribuicao.Visible = false;
                menuSubtransmissao.Visible = true;
            }
        }


        #region EVENTOS SUBTRANSMISSÃO
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Fechar();
            this.Close();
        }
        #endregion

        private void árvoreDeCritériosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showArvoreSubtransmissao(false);
        }

        private void distribiçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setTipoSistema(1);
            exibeInicio(false);
        }

        private void subtransmissãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setTipoSistema(2);
            exibeInicio(false);
        }

        private void distribuiçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setTipoSistema(1);
            exibeInicio(false);
        }

        private void subtransmissãoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            setTipoSistema(2);
            exibeInicio(false);

            
        }
        public void exibeInicio(bool exibeBotao)
        {
            //foreach (Form f in this.MdiChildren)
            //{
            //    if (f.GetType() == typeof(FormInicio))
            //    {
            //        f.Activate();
            //        return;
            //    }
            //}
            FormInicio form = new FormInicio(exibeBotao);
            form.MdiParent = this;
            form.Show();
        }
        
        private void contingênciaNormalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showArvoreSubtransmissao(false);
        }

        private void mUSTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showArvoreSubtransmissao(true);
        }

        private void inglêsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CultureInfo culture = new CultureInfo("en-US");

            Application.CurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture.Name);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(culture.Name);
        }

        private void portuguêsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CultureInfo culture = new CultureInfo("pt-BR");

            Application.CurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture.Name);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(culture.Name);
        }

        private void menuDistribuicao_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void reconfiguraçãoDeRedesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ajudaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                f.Close();
            }
            FormManual form = new FormManual();
            form.MdiParent = this;
            form.Show();
        }

        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                f.Close();
            }
            FormManual form = new FormManual();
            form.MdiParent = this;
            form.Show();
        }

        private void integraçãoCLIPSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Fechar();
            this.Close();
        }

        private void inspeçãoTrechoATrechoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clipsInterface form = new clipsInterface();
            form.MdiParent = this;
            form.Show();
        }

        private void árvoreDeNavegaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidade não Implementada.");
        }

        private void sairToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Fechar();
            this.Close();
        }

        private void inícioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setTipoSistema(2);
            exibeInicio(false);
        }

        private void árvoreDeCritériosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showArvoreCriterios();
        }
    }
}
