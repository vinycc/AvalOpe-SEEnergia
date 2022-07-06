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
    public partial class FormMLE : Form
    {
        public FormMLE()
        {
            InitializeComponent();
            comboRede.SelectedIndex = 0;

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void comboRede_SelectedIndexChanged(object sender, EventArgs e)
        {
            btIndicadores.Enabled = btReconfigurarRede.Enabled = btExecutarFluxoPotencia.Enabled = (comboRede.SelectedIndex > 0);
            btExibirRedeOriginal.Enabled = !btReconfigurarRede.Enabled;
            ucMatriz.SetDiagramaRede(comboRede.SelectedIndex, true);

            //ucMatriz.Enabled = (comboRede.SelectedIndex > 0);

            //Desabilitar botoes para rede MAZ-10
            if (comboRede.SelectedIndex == 3)
            {
                btReconfigurarRede.Enabled = false;
                btExecutarFluxoPotencia.Enabled = true;
                btIndicadores.Enabled = true;
                btExibirRedeOriginal.Enabled = false;
            }


            ucMatriz.SetTab(1);
        }

        private void btIndicadores_Click(object sender, EventArgs e)
        {
            comboRede.Enabled = btIndicadores.Enabled = ucMatriz.Enabled = false;

            

            //ucMatriz.SetDiagramaRede(comboRede.SelectedIndex, false);
            ucMatriz.SetMatriz(comboRede.SelectedIndex);

            comboRede.Enabled = btIndicadores.Enabled = ucMatriz.Enabled = true;

            ucMatriz.SetTab(4);
        }

        protected override void OnActivated(EventArgs e)
        {
            comboRede.SelectedIndex = 0;
            base.OnActivated(e);    
        }

        private void ucMatriz_Load(object sender, EventArgs e)
        {

        }

        private void btReconfigurarRede_Click(object sender, EventArgs e)
        {
            ucMatriz.ReconfigurarRede();
            ucMatriz.SetTab(1);
            btExibirRedeOriginal.Enabled = true;
        }

        private void btExecutarFluxoPotencia_Click(object sender, EventArgs e)
        {
            ucMatriz.ExecutarFluxoPotencia();
            ucMatriz.SetTab(1);
        }

        private void btExibirRedeOriginal_Click(object sender, EventArgs e)
        {
            ucMatriz.ExibirRedeOriginal();
            ucMatriz.SetTab(1);
            btExibirRedeOriginal.Enabled = false;
        }

        public void HabilitarBotaoReconfigurarRede(bool habilitado)
        {
            this.btReconfigurarRede.Enabled = habilitado;

        }

        
    }
}
