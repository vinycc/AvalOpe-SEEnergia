using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AvalOpe
{
    /// <summary>
    /// Interaction logic for ucFolhaExtra.xaml
    /// </summary>
    public partial class ucFolhaExtra : UserControl
    {
        public bool Automatico { get; set; }

        public ucFolhaExtra()
        {
            InitializeComponent();

            if (Thread.CurrentThread.CurrentCulture.Name == "en-US")
            {
                lblDesvio.Content = "Deviation";
                lblPeso.Content = "Weight";
            }
            else
            {
                lblDesvio.Content = "Desvio(%)";
                lblPeso.Content = "Peso(%)";
            }
        }

        
        public void CriarNo(string titulo)
        {
            Titulo.Text = "\n" + titulo;

            //Oculta campos de valores
            lblDesvio.Visibility = Visibility.Hidden;
            Desvio.Visibility = Visibility.Hidden;
            lblPeso.Visibility = Visibility.Hidden;
            Peso.Visibility = Visibility.Hidden;
        }

        /*public void CriarNo(string titulo, double peso)
        {
            Titulo.Text = "\n" + titulo;

            lblDesvio.Visibility = Visibility.Hidden;
            Desvio.Visibility = Visibility.Hidden;
            lblPeso.Visibility = Visibility.Visible;
            Peso.Visibility = Visibility.Visible;
            Peso.Text = peso.ToString("N4");
            Peso.IsEnabled = false;

            //Altera cor
            //SetColor(desvio);
        }*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ativo">Ativar Nó</param>
        /// <param name="titulo">Titulo do criterio</param>
        /// <param name="peso">Peso do criterio</param>
        /// <param name="desvio">Desvio do criterio</param>
        /// <param name="exibePeso">Exibir Peso</param>
        /// <param name="exibeDesvio">Exibir Desvio</param>
            /// <param name="habilitaPeso">Habilitar campo Peso para edição</param>
        /// <param name="habilitaDesvio">Habilitar campo Desvio para edição</param>
        public void CriarNo(bool ativo, string titulo, double peso, double desvio, bool exibePeso, bool exibeDesvio, bool habilitaPeso, bool habilitaDesvio, bool automatico)
        {
            this.Automatico = automatico;

            this.lblPeso.Content = this.Automatico ? "Peso(%)" : "Peso";

            Titulo.Text = titulo;

            if (ativo)
            {

                //O campo peso deve ser exibido somente nos subcriterios 
                if (exibePeso)
                {
                    lblPeso.Visibility = Peso.Visibility = Visibility.Visible;
                }
                else
                {
                    lblPeso.Visibility = Peso.Visibility = Visibility.Hidden;
                }

                //O campo desvio deve ser exibido nos criterios e nos subcriterios 
                if (exibeDesvio)
                {
                    lblDesvio.Visibility = Desvio.Visibility = Visibility.Visible;
                }
                else
                {
                    lblDesvio.Visibility = Desvio.Visibility = Visibility.Hidden;
                }

                //Preenche Peso
                peso = Double.IsNaN(peso) ? 0 : peso;
                Peso.Text = peso.ToString("N3");
                Peso.IsEnabled = habilitaPeso;

                //Preenche Desvio
                desvio = Double.IsNaN(desvio) ? 0 : desvio;
                Desvio.Text = desvio.ToString("N3");
                Desvio.IsEnabled = habilitaDesvio;

                //Altera a cor de acordo com o desvio (0 = verde; 100 = vermelho)
                SetColor(desvio, ativo);
            }
            else
            {
                Peso.IsEnabled = habilitaPeso;
                lblDesvio.Visibility = Visibility.Hidden;
                lblPeso.Visibility = Visibility.Hidden;
                Peso.Visibility = Visibility.Hidden;
                Desvio.Visibility = Visibility.Hidden;

                SetColor(desvio, ativo);
            }
            

        }

        public bool getAtivo()
        {
            return this.IsEnabled;
        }

        public double getPeso()
        {
            double p;
            if (String.IsNullOrEmpty(Peso.Text))
            {
                p = 0;
            }
            else {
                try
                {
                    p = Convert.ToDouble(Peso.Text);
                    p = Math.Round(p, 4);
                }
                catch
                {
                    p = 0;
                }
            }
            return p;
        }
        public double getDesvio()
        {
            double p;
            if (String.IsNullOrEmpty(Desvio.Text))
            {
                p = 0;
            }
            else {
                try
                {
                    p = Convert.ToDouble(Desvio.Text);
                    p = Math.Round(p, 4);
                }
                catch
                {
                    p = 0;
                }
            }
            return p;
        }

        /// <summary>
        /// Define a cor do nó
        /// </summary>
        /// <param name="desvio">Valor do desvio do nó</param>
        /// <param name="ativo">Nó ativo</param>
        public void SetColor(double desvio, bool ativo)
        {
            if (ativo)
            {
                //this.Opacity = 1;
                this.Opacity = 0.9;

                lblDesvio.Visibility = Visibility.Visible;
                lblPeso.Visibility = Visibility.Visible;
                Peso.Visibility = Visibility.Visible;
                Desvio.Visibility = Visibility.Visible;

                if (desvio > 90)
                {
                    fundo.Background = new SolidColorBrush(Color.FromArgb(255, 248, 68, 75));
                }
                else if (desvio > 80)
                {
                    fundo.Background = new SolidColorBrush(Color.FromArgb(255, 243, 100, 71));
                }
                else if (desvio > 70)
                {
                    fundo.Background = new SolidColorBrush(Color.FromArgb(255, 239, 137, 74));
                }
                else if (desvio > 60)
                {
                    fundo.Background = new SolidColorBrush(Color.FromArgb(255, 235, 171, 77));
                }
                else if (desvio > 50)
                {
                    fundo.Background = new SolidColorBrush(Color.FromArgb(255, 230, 201, 80));
                }
                else if (desvio > 40)
                {
                    fundo.Background = new SolidColorBrush(Color.FromArgb(255, 223, 226, 82));
                }
                else if (desvio > 30)
                {
                    fundo.Background = new SolidColorBrush(Color.FromArgb(255, 190, 221, 85));
                }
                else if (desvio > 20)
                {
                    fundo.Background = new SolidColorBrush(Color.FromArgb(255, 159, 217, 87));
                }
                else if (desvio > 10)
                {
                    fundo.Background = new SolidColorBrush(Color.FromArgb(255, 132, 213, 89));
                }
                else
                {
                    fundo.Background = new SolidColorBrush(Color.FromArgb(255, 106, 209, 91));
                }
                this.IsEnabled = true;
            }
            else
            {
                lblDesvio.Visibility = Visibility.Hidden;
                lblPeso.Visibility = Visibility.Hidden;
                Peso.Visibility = Visibility.Hidden;
                Desvio.Visibility = Visibility.Hidden;

                fundo.Background = new SolidColorBrush(Color.FromArgb(255, 206, 206, 206));
                this.Opacity = 0.4;
                this.IsEnabled = false;
            }
        }

        internal void Habilitar(bool ativo)
        {
            if (ativo)
            {
                lblDesvio.Visibility = Visibility.Visible;
                lblPeso.Visibility = Visibility.Visible;
                Peso.Visibility = Visibility.Visible;
                Desvio.Visibility = Visibility.Visible;

                SetColor(getDesvio(), ativo);
                this.IsEnabled = true;
            }
            else
            {
                lblDesvio.Visibility = Visibility.Hidden;
                lblPeso.Visibility = Visibility.Hidden;
                Peso.Visibility = Visibility.Hidden;
                Desvio.Visibility = Visibility.Hidden;
                SetPeso(0, 0);
                SetColor(getDesvio(), ativo);
                this.IsEnabled = false;
            }
        }

        /*public double GetValor()
        {
            double p;
            double d;


            //ponto para virgula

            Peso.Text = Peso.Text.Replace('.', ',');
            Desvio.Text = Desvio.Text.Replace('.', ',');

            if (String.IsNullOrEmpty(Peso.Text))
            {
                p = 0;
            }
            else
            {
                p = Convert.ToDouble(Peso.Text);
            }

            if (String.IsNullOrEmpty(Desvio.Text))
            {
                d = 0;
            }
            else
            {
                d = Convert.ToDouble(Desvio.Text);
            }

            double valor = p * d;
            return valor;
        }*/

        

        DependencyObject GetTopLevelControl(DependencyObject control)
        {
            DependencyObject tmp = control;
            DependencyObject parent = null;
            while ((tmp = VisualTreeHelper.GetParent(tmp)) != null)
            {
                
                parent = tmp;

                if (parent is AvalOpe.ucArvoreDeCriterios)
                {
                    return parent;
                }else if (parent is AvalOpe.UserControlsWPF.ucArvoreSubtransmissao)
                {
                    return parent;
                }
            }
            return null;
        }

        public void SetPeso(double peso, double desvio)
        {
            //Preenche Peso
            peso = Double.IsNaN(peso) ? 0 : peso;
            Peso.Text = peso.ToString("N3");

            //Preenche Desvio
            desvio = Double.IsNaN(desvio) ? 0 : desvio;
            Desvio.Text = desvio.ToString("N3");
        }

        private void Peso_LostFocus(object sender, RoutedEventArgs e)
        {
            double d = 0;
            try
            {
                if (Thread.CurrentThread.CurrentCulture.Name == "en-US")
                {
                    d = Convert.ToDouble(Peso.Text.Replace(",", ""));
                }
                else {
                    d = Convert.ToDouble(Peso.Text.Replace(".", ""));
                }
            }
            catch
            {
                d = 0;
            }

            double valorMinimo = this.Automatico ? -100 : 0;
            double valorMaximo = this.Automatico ? 100 : 10;

            if (d >= valorMinimo && d <= valorMaximo)
            {
                this.Peso.Text = d.ToString("N3");

                //Alterar Peso do nó pai
                var pai = GetTopLevelControl(this);
                if (pai.ToString().Contains("ucArvoreSubtransmissao"))
                {
                    ((AvalOpe.UserControlsWPF.ucArvoreSubtransmissao)pai).SetPesoNoPai();
                }
                else {
                    ((AvalOpe.ucArvoreDeCriterios)pai).SetPesoNoPai();
                }
            }
            else
            {
                if (d > valorMaximo)
                {
                    MessageBox.Show("Erro: O peso não pode ser superior a " + valorMaximo);
                }
                else if (d < valorMinimo)
                {
                    MessageBox.Show("Erro: O peso não pode ser inferior a "+ valorMinimo);
                }

                d = 0;
                this.Peso.Text = d.ToString("N3");
                Peso.Focus();
                this.Focus();
            }
        }
        private void Desvio_LostFocus(object sender, RoutedEventArgs e)
        {
            double d = 0;
            try
            {
                if (Thread.CurrentThread.CurrentCulture.Name == "en-US")
                {
                    d = Convert.ToDouble(Desvio.Text.Replace(",", ""));
                }
                else {
                    d = Convert.ToDouble(Desvio.Text.Replace(".", ""));
                }
            }
            catch
            {
                d = 0;
            }

            if (d >= -100 && d <= 100)
            {
                this.Desvio.Text = d.ToString("N3");
                SetColor(d, true);

                //Alterar Desvio do Pai
                var pai = GetTopLevelControl(this);

                if (pai.ToString().Contains("ucArvoreSubtransmissao"))
                {
                    ((AvalOpe.UserControlsWPF.ucArvoreSubtransmissao)pai).SetPesoNoPai();
                }
                else {
                    ((AvalOpe.ucArvoreDeCriterios)pai).SetPesoNoPai();
                }
            }
            else
            {
                if (d > 100)
                {
                    MessageBox.Show("Erro: O desvio não pode ser superior a 100 %");
                }
                else if (d < 100)
                {
                    MessageBox.Show("Erro: O desvio não pode ser inferior a -100 %");
                }

                d = 0;
                this.Desvio.Text = d.ToString("N3");
                SetColor(d, true);
                Desvio.Focus();
                this.Focus();

                //Selecionar a mesma folha
                //var pai = GetTopLevelControl(this);
                //if (pai.ToString().Contains("ucArvoreSubtransmissao"))
                //{
                //    ((AvalOpe.UserControlsWPF.ucArvoreSubtransmissao)pai).SetFolhaExtra(this);
                //}
                //else {
                //    ((AvalOpe.ucArvoreDeCriterios)pai).SetFolhaExtra(this);
                //}
            }
        }
        

        public void AtualizarNo(double peso, double desvio, bool ativo)
        {
            //Preenche Peso
            peso = Double.IsNaN(peso) ? 0 : peso;
            Peso.Text = peso.ToString("N3");

            //Preenche Desvio
            desvio = Double.IsNaN(desvio) ? 0 : desvio;
            Desvio.Text = desvio.ToString("N3");

            //Altera a cor de acordo com o desvio (0 = verde; 100 = vermelho)
            SetColor(desvio, ativo);
        }

        private void Peso_GotFocus(object sender, RoutedEventArgs e)
        {
            Peso.SelectAll();
        }

        private void Desvio_GotFocus(object sender, RoutedEventArgs e)
        {
            Desvio.SelectAll();
        }
    }
}
