using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AvalOpe
{
    public partial class FormSelecionarLinhaDefeito : Form
    {
        public FormSelecionarLinhaDefeito()
        {
            InitializeComponent();
            this.comboBox1.SelectedIndex = 0;
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btEnviar_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione uma Linha com Defeito.");
            }
            else
            {
                FormMLE f = new FormMLE();
                //this.avaliacao = this.comboBox1.SelectedIndex;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
