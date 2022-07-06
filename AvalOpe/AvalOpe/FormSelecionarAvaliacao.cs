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
    public partial class FormSelecionarAvaliacao : Form
    {
        public int avaliacao { get; set; }

        public FormSelecionarAvaliacao()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione uma Avaliação.");
                //this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                this.avaliacao = comboBox1.SelectedIndex;
                FormAvaliacao f = new FormAvaliacao();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
