using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AvalOpe
{
    public partial class FormAdicionarManobraParametro : Form
    {
        public string Nome { get; set; }
        public string Operador { get; set; }
        public string Localizacao { get; set; }
        public string Data { get; set; }

        public FormAdicionarManobraParametro()
        {
            InitializeComponent();

            panelBotoes.Visible = false;
        }

        private void btAdicionarLista_Click(object sender, EventArgs e)
        {
            panelBotoes.Visible = true;
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("Insira o nome da avaliação.");
            }
            else if (comboOperador.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione o operador.");
            }
            else if (String.IsNullOrEmpty(txtLocalizacao.Text))
            {
                MessageBox.Show("Insira a localização.");
            }
            else
            {
                this.Nome = txtNome.Text;
                this.Operador = comboOperador.SelectedItem.ToString();
                this.Localizacao = txtLocalizacao.Text;
                this.Data = comboData.Text;

                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }

        private void btDistribuição_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidade não Implementada.", "Erro");
        }
    }
}
