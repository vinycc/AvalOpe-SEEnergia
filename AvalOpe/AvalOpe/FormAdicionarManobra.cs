using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static AvalOpe.Enumeracoes;

namespace AvalOpe
{
    public partial class FormAdicionarManobra : Form
    {
        public string tempo { get; set; }
        public string objeto { get; set; }
        public string idObjeto { get; set; }
        public enumAcoes acao { get; set; }

        public List<FormAvaliacao.AcoesRecomendadas> listaAcoes { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        public FormAdicionarManobra(bool novaAvaliacao, bool primeiraAvaliacao)
        {
            InitializeComponent();
            comboAcao.DataSource = Enum.GetValues(typeof(enumAcoes));
            comboObjeto.DataSource = Enum.GetValues(typeof(enumObjetosManobra));
            btAdicionar.Text = "Adicionar";

            if (novaAvaliacao)
            {
                btAdicionar.Visible = false;
                btAdicionarLista.Visible = true;

                this.AcceptButton = btAdicionarLista;

            }
            else
            {
                btAdicionar.Visible = true;
                btAdicionarLista.Visible = false;

                this.AcceptButton = btAdicionar;
            }
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="te">Tempo</param>
        /// <param name="ob">Objeto</param>
        /// <param name="ac">Ação</param>
        public FormAdicionarManobra(string te, string ob, string ac)
        {
            InitializeComponent();

            txtTempo.Text = te;

            string[] strObj = ob.Split('_');

            comboObjeto.DataSource = Enum.GetValues(typeof(enumObjetosManobra));
            comboObjeto.SelectedItem = strObj[0];

            txtIdObjeto.Text = strObj[1];

            comboAcao.DataSource = Enum.GetValues(typeof(enumAcoes));
            comboAcao.SelectedItem = (enumAcoes)System.Enum.Parse(typeof(enumAcoes), ac);

            btAdicionar.Text = "Enviar";

            btAdicionar.Visible = true;
            btAdicionarLista.Visible = false;

            this.AcceptButton = btAdicionar;
        }

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            if (txtTempo.Text == "")
            {
                MessageBox.Show("Insira o tempo de ocorrência.");
            }
            else if (comboObjeto.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione o objeto da manobra.");
            }
            else if (comboAcao.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione uma Ação.");
                //this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                enumAcoes ac;
                Enum.TryParse<enumAcoes>(comboAcao.SelectedValue.ToString(), out ac);
                this.acao = ac;
                this.tempo = txtTempo.Text.Trim();
                this.objeto = comboObjeto.SelectedItem.ToString();
                this.idObjeto = txtIdObjeto.Text.ToUpper().Trim();

                //FormAvaliacao f = new FormAvaliacao();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btAdicionarLista_Click(object sender, EventArgs e)
        {
            if (txtTempo.Text == "")
            {
                MessageBox.Show("Insira o tempo de ocorrência.");
            }
            else if (comboObjeto.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione o objeto da manobra.");
            }
            else if (comboAcao.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione uma Ação.");
                //this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                listaAcoes = new List<FormAvaliacao.AcoesRecomendadas>();

                enumAcoes ac;
                Enum.TryParse<enumAcoes>(comboAcao.SelectedValue.ToString(), out ac);

                double minut = 0;
                try
                {
                    minut = TimeSpan.Parse(txtTempo.Text.Trim()).TotalMinutes;
                    listaAcoes.Add(new FormAvaliacao.AcoesRecomendadas(1, Convert.ToInt32(minut), comboObjeto.SelectedItem.ToString() +"_"+ txtIdObjeto.Text.ToUpper().Trim(), ac));
                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Favor informar um horário válido (00:00 - 23:59)");
                }
            }
        }
    }
}
