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
    public partial class FormCadastroTreinamento : Form
    {
        private class Treinamentos
        {
            public string numero { get; set; }
            public string titulo { get; set; }
            public string responsavel { get; set; }
            public string local { get; set; }
            public string data { get; set; }
            
        }

        public FormCadastroTreinamento()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();

            List<Treinamentos> acoes = new List<Treinamentos>();
            acoes.Add(new Treinamentos() { numero = "001", titulo = "Treinamento 01", responsavel = "João da Silva", local = "", data = "20/10/2015" });
            acoes.Add(new Treinamentos() { numero = "002", titulo = "Treinamento 02", responsavel = "Jose dos Santos", local = "", data = "02/12/2015" });
            acoes.Add(new Treinamentos() { numero = "003", titulo = "Treinamento 03", responsavel = "Fernando Freitas", local = "", data = "13/11/2015" });
            acoes.Add(new Treinamentos() { numero = "004", titulo = "Treinamento 04", responsavel = "Maria Santo", local = "", data = "10/01/2016" });


            dataGridView1.DataSource = acoes;

            dataGridView1.Columns[0].HeaderText = "Número";
            dataGridView1.Columns[1].HeaderText = "Título";
            dataGridView1.Columns[2].HeaderText = "Responsável";
            dataGridView1.Columns[3].HeaderText = "Local";
            dataGridView1.Columns[4].HeaderText = "Data";
        }
    }
}
