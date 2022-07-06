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
    public partial class FormEstatistica : Form
    {
        private class ItemsCriterio
        {
            public string Criterio { get; set; }
            public double Porcentagem { get; set; }

            public ItemsCriterio(string criterio, double porcentagem)
            {
                this.Criterio = criterio;
                this.Porcentagem = porcentagem;
            }
        }

        string[] operadores = { "Selecione", "João da Silva", "José dos Santos", "Antônio Vieira", "Todos os Operadores" };
        string[] regionais = { "Selecione", "Regional 01", "Regional 02", "Regional 03", "Todas as Regionais" };
        string[] criterios = { "Selecione",
            enumCriterios.criterioMagnitudeTensao.EnumToString(),
            enumCriterios.criterioVariacaoLinha.EnumToString(),
            enumCriterios.criterioCompetencia.EnumToString(),
            enumCriterios.criterioEUSD.EnumToString(),
            enumCriterios.criterioDMIC.EnumToString(),
            enumCriterios.criterioDEC.EnumToString(),
            enumCriterios.criterioFEC.EnumToString(),
            enumCriterios.criterioConsumidoes.EnumToString(),
            enumCriterios.criterioTempoFila.EnumToString(),
            enumCriterios.criterioConsumidoresPrioritario.EnumToString(),
            enumCriterios.criterioChaveamento.EnumToString(),
            enumCriterios.criterioSeguranca.EnumToString(),
            "Todos os Critérios"
        };


        public FormEstatistica()
        {
            InitializeComponent();

            //dataInicial.Format = DateTimePickerFormat.Custom;
            //dataInicial.CustomFormat = "MMMM yyyy";
            //dataInicial.ShowUpDown = true;

            dataGridView.AutoGenerateColumns = false;

            operador.DataSource = operadores;
            regional.DataSource = regionais;
            criterio.DataSource = criterios;

            Habilitar();

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void GerarGrafico()
        {
            string item = (string)operador.SelectedValue;

            UpdateRelatorio();
        }

        private void UpdateRelatorio()
        {
            List<ItemsCriterio> itensCriterio = new List<ItemsCriterio>();
            if (criterio.SelectedIndex == 1)
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioMagnitudeTensao.EnumToString(), 2.40));
            if (criterio.SelectedIndex == 2)
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioVariacaoLinha.EnumToString(), 3.00));
            if (criterio.SelectedIndex == 3)
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioCompetencia.EnumToString(), 7.00));
            if (criterio.SelectedIndex == 4)
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioEUSD.EnumToString(), 0.82));
            if (criterio.SelectedIndex == 5)
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioDMIC.EnumToString(), 7.50));
            if (criterio.SelectedIndex == 6)
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioDEC.EnumToString(), 6.15));
            if (criterio.SelectedIndex == 7)
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioFEC.EnumToString(), 0.33));
            if (criterio.SelectedIndex == 8)
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioConsumidoes.EnumToString(), 12.37));
            if (criterio.SelectedIndex == 9)
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioTempoFila.EnumToString(), 35.00));
            if (criterio.SelectedIndex == 10)
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioConsumidoresPrioritario.EnumToString(), 38.46));
            if (criterio.SelectedIndex == 11)
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioChaveamento.EnumToString(), 8.32));
            if (criterio.SelectedIndex == 12)
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioSeguranca.EnumToString(), 21.00));
            if (criterio.SelectedIndex == 13)
            {
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioMagnitudeTensao.EnumToString(), 2.40));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioVariacaoLinha.EnumToString(), 3.00));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioCompetencia.EnumToString(), 7.00));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioEUSD.EnumToString(), 0.82));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioDMIC.EnumToString(), 7.50));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioDEC.EnumToString(), 6.15));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioFEC.EnumToString(), 0.33));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioConsumidoes.EnumToString(), 12.37));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioTempoFila.EnumToString(), 35.00));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioConsumidoresPrioritario.EnumToString(), 38.46));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioChaveamento.EnumToString(), 8.32));
                itensCriterio.Add(new ItemsCriterio(enumCriterios.criterioSeguranca.EnumToString(), 21.00));
            }
                
            //if (criterio.SelectedIndex == 0 && (operador.SelectedIndex > 0 || regional.SelectedIndex > 0))
            //{
            //}
            //else
            //{
            //    if (criterio.SelectedIndex > 0)
            //    {
            //        itensCriterio.Add(new ItemsCriterio("Regional 01", 12.00));
            //        itensCriterio.Add(new ItemsCriterio("Regional 02", 34.00));
            //        itensCriterio.Add(new ItemsCriterio("Regional 03", 1.82));
            //    }
            //}
            dataGridView.DataSource = itensCriterio;
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView.ClearSelection();
        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            string s = Enumeracoes.EnumToString(enumCriterios.criterioMagnitudeTensao);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView.ClearSelection();
            Habilitar();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dataGridView.ClearSelection();
        }

        private void btEnviar_Click(object sender, EventArgs e)
        {
            GerarGrafico();
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            dataGridView.ClearSelection();
        }

        private void regional_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView.ClearSelection();
            Habilitar();
        }

        private void criterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView.ClearSelection();
            Habilitar();
        }

        public void Habilitar()
        {
            //Deixar todos os campos habilitados
            regional.Enabled = true;
            operador.Enabled = true;
            criterio.Enabled = true;
        }
    }
}
