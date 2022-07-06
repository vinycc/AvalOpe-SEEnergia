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

namespace AvalOpe
{
    public partial class FormReordenarCriterios : Form
    {
        public int idCriterioAdicionar;

        public List<Criterio> listaOriginal;

        public bool subtransmissao;
        public bool must;
        public bool automatico;

        public FormReordenarCriterios()
        {
            InitializeComponent();

            btSubir.Visible = this.automatico;
            btDescer.Visible = this.automatico;

        }

        public FormReordenarCriterios(List<Criterio> listaCriterios, bool ehSubtransmissao, bool ehMust, bool ehAutomatico)
        {
            InitializeComponent();

            this.subtransmissao = ehSubtransmissao;
            this.must = ehMust;
            this.automatico = ehAutomatico;

            idCriterioAdicionar = -1;

            int i = 1;
            foreach (Criterio c in listaCriterios)
            {
                double peso = c.Peso;
                this.dataGridView1.Rows.Add(i, c.Descricao, peso.ToString("N3"), c.Id, c.Desvio, 0);
                i++;
            }

            listaOriginal = new List<AvalOpe.Criterio>();
            listaOriginal = listaCriterios;

            dataGridView1.ClearSelection();
            HabilitarBotao();

            ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btSubir, "Aumentar Prioridade");
            ToolTip ToolTip2 = new System.Windows.Forms.ToolTip();
            ToolTip2.SetToolTip(this.btDescer, "Diminuir Prioridade");
            ToolTip ToolTip3 = new System.Windows.Forms.ToolTip();
            ToolTip3.SetToolTip(this.btExcluir, "Excluir Critério");
            ToolTip ToolTip4 = new System.Windows.Forms.ToolTip();
            ToolTip4.SetToolTip(this.btSalvar, "Salvar Alterações");
            ToolTip ToolTip5 = new System.Windows.Forms.ToolTip();
            ToolTip5.SetToolTip(this.btAdicionar, "Adicionar Critério");

            btSubir.Visible = this.automatico;
            btDescer.Visible = this.automatico;

        }

        private void btSubir_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows[0].Index > 0)
            {
                DataGridViewSelectedRowCollection rOrigem = dataGridView1.SelectedRows;
                int indiceOrigem = rOrigem[0].Index;
                int indiceDestion = rOrigem[0].Index - 1;

                DataGridViewRow Origem = dataGridView1.Rows[indiceOrigem];
                DataGridViewRow Destino = dataGridView1.Rows[indiceDestion];

                object d = Destino.Cells[0].Value;
                Destino.Cells[0].Value = Origem.Cells[0].Value;
                Origem.Cells[0].Value = d;

                dataGridView1.Rows.Remove(Origem);
                dataGridView1.Rows.Insert(indiceDestion, Origem);

                dataGridView1.ClearSelection();
                Origem.Selected = true;

                RecalcularPesos();
            }
        }

        private void btDescer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows[0].Index <= dataGridView1.Rows.Count - 2)
            {
                DataGridViewSelectedRowCollection rOrigem = dataGridView1.SelectedRows;
                int indiceOrigem = rOrigem[0].Index;
                int indiceDestion = rOrigem[0].Index + 1;

                DataGridViewRow Origem = dataGridView1.Rows[indiceOrigem];
                DataGridViewRow Destino = dataGridView1.Rows[indiceDestion];

                object d = Destino.Cells[0].Value;
                Destino.Cells[0].Value = Origem.Cells[0].Value;
                Origem.Cells[0].Value = d;

                dataGridView1.Rows.Remove(Origem);
                dataGridView1.Rows.Insert(indiceDestion, Origem);

                dataGridView1.ClearSelection();
                Origem.Selected = true;

                RecalcularPesos();
            }
        }

        private void HabilitarBotao()
        {
            if (dataGridView1.SelectedRows.Count > 0  && dataGridView1.SelectedRows[0].Index > 0)
            {
                btSubir.Enabled = true;
            }
            else
            {
                btSubir.Enabled = false;
            }

            if (dataGridView1.SelectedRows.Count > 0  && dataGridView1.SelectedRows[0].Index <= dataGridView1.Rows.Count - 2)
            {
                btDescer.Enabled = true;
            }
            else
            {
                btDescer.Enabled = false;
            }


            btExcluir.Enabled = dataGridView1.SelectedRows.Count > 0 ;
            if (subtransmissao)
            {
                if (must)
                {
                    btAdicionar.Enabled = dataGridView1.Rows.Count < 9;
                }
                else
                {
                    btAdicionar.Enabled = dataGridView1.Rows.Count < 13;
                }
            }
            else
            {
                btAdicionar.Enabled = dataGridView1.Rows.Count < 17;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            HabilitarBotao();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            List<Criterio> listaAlterada = new List<AvalOpe.Criterio>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Criterio c;
                
                if (this.automatico)
                {
                    c = new Criterio(Convert.ToInt16(row.Cells[3].Value), row.Cells[1].Value.ToString(), 0, Convert.ToDouble(row.Cells[4].Value), true);
                }
                else
                {
                    c = new Criterio(Convert.ToInt16(row.Cells[3].Value), row.Cells[1].Value.ToString(), Convert.ToDouble(row.Cells[2].Value), Convert.ToDouble(row.Cells[4].Value), true);
                }
                listaAlterada.Add(c);
            }

            //Percorre as duas lista comparando item por item, necessario apenas se quantidade de itens for igual
            bool existeAlgumDiferente = false;
            if (listaAlterada.Count == listaOriginal.Count)
            {
                foreach (Criterio c1 in listaAlterada)
                {
                    bool existeIgual = false;
                    foreach (Criterio c2 in listaOriginal)
                    {
                        if (c1.Id == c2.Id)
                        {
                            existeIgual = true;
                            break;
                        }
                    }
                    if (!existeIgual)
                    {
                        existeAlgumDiferente = true;
                        break;
                    }
                }
            }

            //Compara lista de criterios com a lista original para verificar criterios que foram excluidos
            //Os criterios Excluídos devem ser desabilitados
            if (listaAlterada.Count != listaOriginal.Count || existeAlgumDiferente)
            {
                //Ao excluir
                List<Criterio> listaFinal = listaAlterada.Except(listaOriginal).ToList();

                //Percorre lista Original
                foreach (Criterio criterioOriginal in listaOriginal)
                {
                    //Se o item existe na nova lista, atualiza o peso
                    if (listaFinal.Exists(o => o.Id == criterioOriginal.Id))
                    {
                        listaOriginal.First(o => o.Id == criterioOriginal.Id).Peso = listaFinal.First(o => o.Id == criterioOriginal.Id).Peso;
                    }
                    else
                    {
                        //Se o item não existe na nova lista

                        //desativa o item
                        listaOriginal.First(o => o.Id == criterioOriginal.Id).Ativo = false;

                        //Zera os pesos e criterios
                        listaOriginal.First(o => o.Id == criterioOriginal.Id).Peso = 0;
                        listaOriginal.First(o => o.Id == criterioOriginal.Id).Desvio = 0;
                    }
                }

            }
            else
            {
                listaOriginal = listaAlterada;
            }


            //Verifica se tem itens a para incluir
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if(Convert.ToInt32(row.Cells[5].Value) == 1)
                {
                    Criterio cr = new Criterio(Convert.ToInt16(row.Cells[3].Value), row.Cells[1].Value.ToString(), 0, 0, true);
                    listaOriginal.Add(cr);
                }
            }

            if (subtransmissao)
            {
                ((FormArvoreSubtransmissao)((FormInterface)this.Owner).ActiveMdiChild).listaCriterio = listaOriginal;
            }
            else
            {
                ((FormArvoreCriterios)((FormInterface)this.Owner).ActiveMdiChild).listaCriterio = listaOriginal;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int sel = dataGridView1.SelectedRows[0].Index;

                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);

                //Atualiza prioridades
                int i = 1;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells[0].Value = i;
                    i++;
                }

                if (this.automatico)
                {
                    RecalcularPesos();
                }

                HabilitarBotao();

                dataGridView1.ClearSelection();

                if (dataGridView1.Rows.Count > sel)
                {
                    dataGridView1.Rows[sel].Selected = true;
                }
            }
        }

        private void RecalcularPesos()
        {
            List<Double> listPesos =  ucArvoreDeCriterios.GeraListaPesos(dataGridView1.Rows.Count);

            int i = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[2].Value = (listPesos[i]).ToString("N3");
                i++;
            }
        }

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            //Busca lista atual de criterios no grid
            List<Criterio> lista = new List<AvalOpe.Criterio>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Criterio c = new Criterio(Convert.ToInt16(row.Cells[3].Value), row.Cells[1].Value.ToString(), 0, 0, true);
                lista.Add(c);
            }

            DialogResult dr = new DialogResult();
            FormAdicionarCriterio frmSelecionar = new FormAdicionarCriterio(lista, subtransmissao, this.must);
            dr = frmSelecionar.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                if (idCriterioAdicionar > 0)
                {
                    if (subtransmissao)
                    {
                        this.dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, ucArvoreSubtransmissao.getDescricaoCriteriosById(idCriterioAdicionar), 0, idCriterioAdicionar, 0, 1);
                    }
                    else
                    {
                        this.dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, ucArvoreDeCriterios.getDescricaoCriteriosById(idCriterioAdicionar), 0, idCriterioAdicionar, 0, 1);
                    }
                }

                if (this.automatico)
                {
                    RecalcularPesos();
                }
                HabilitarBotao();

            }
        }
    }
}
