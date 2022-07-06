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
    /*The items in a combobox can be of any object type, and the value that gets displayed is the ToString() value.
    So you could create a new class that has a string value for display purposes and a hidden id. Simply override the ToString function to return the display string.
    http://stackoverflow.com/questions/3762981/hidden-id-with-combobox-items
    */

    public class ComboBoxItem {
        string descricao;
        int identificador;

        //Constructor
        public ComboBoxItem(string desc, int id)
        {
            descricao = desc;
            identificador = id;
        }

        //Accessor
        public int ID
        {
            get
            {
                return identificador;
            }
        }

        //Override ToString method
        public override string ToString()
        {
            return descricao;
        }
    }


    public partial class FormAdicionarCriterio : Form
    {

        public FormAdicionarCriterio()
        {
            InitializeComponent();

        }
        public FormAdicionarCriterio(List<Criterio> lista, bool ehSubtransmissao, bool ehMust)
        {
            InitializeComponent();

            List<int> listaIDs = new List<int>();
            if (ehSubtransmissao)
            {
                //Contingencia por MUST
                if (ehMust)
                {
                    //Manter apenas MUST, Competencia profissionais, limite de carregamento, limite de tensao, sequencia de restabelecimento e extras
                    int[] listIncluir = new[] { 
                        (int)enumCriteriosSubtransmissao.criterioLimiteTensao,
                        (int)enumCriteriosSubtransmissao.criterioLimiteCarregamento,
                        (int)enumCriteriosSubtransmissao.criterioCompetencia,
                        (int)enumCriteriosSubtransmissao.criterioMust,
                        (int)enumCriteriosSubtransmissao.criterioSequenciaRestabelecimento,
                        (int)enumCriteriosSubtransmissao.criterioExtra1,
                        (int)enumCriteriosSubtransmissao.criterioExtra2,
                        (int)enumCriteriosSubtransmissao.criterioExtra3,
                        (int)enumCriteriosSubtransmissao.criterioExtra4
                    };
                    for (int i = 1; i <= Enum.GetNames(typeof(enumCriteriosSubtransmissao)).Length; i++)
                    {
                        if ( listIncluir.Contains(i))
                        {
                            listaIDs.Add(i);
                        }
                    }
                }
                else
                {
                    //Excluir conhecimento, habilidade, atitude e stress
                    int[] listExcluir = new[] {
                        (int)enumCriteriosSubtransmissao.criterioConhecimento,
                        (int)enumCriteriosSubtransmissao.criterioHabilidade,
                        (int)enumCriteriosSubtransmissao.criterioAtitude,
                        (int)enumCriteriosSubtransmissao.criterioStress
                };
                    for (int i = 1; i <= Enum.GetNames(typeof(enumCriteriosSubtransmissao)).Length; i++)
                    {
                        //Excluir Conhecimento, Habilidade, Atitude, Stress
                        if (! listExcluir.Contains(i))
                        {
                            listaIDs.Add(i);
                        }
                    }
                }
            }
            else
            {
                //Excluir criterios abaixo
                int[] listExcluir = new[] {
                        (int)enumCriterios.criterioHabilidade,
                        (int)enumCriterios.criterioAtitude,
                        (int)enumCriterios.criterioConhecimento,
                        (int)enumCriterios.criterioStress,
                        (int)enumCriterios.criterioDMChave,
                        (int)enumCriterios.criterioDMDisjuntor,
                        (int)enumCriterios.criterioDMReligador,
                        (int)enumCriterios.criterioDMTransformador
                };
                for (int i = 1; i <= Enum.GetNames(typeof(enumCriterios)).Length ; i++)
                {
                    if (!listExcluir.Contains(i))
                    {
                        listaIDs.Add(i);
                    }
                }
            }

            List<int> listaIDsSelecionados = new List<int>();
            foreach (Criterio c in lista)
            {
                listaIDsSelecionados.Add(c.Id);
            }

            List<int> listaIDsExcluidos = listaIDs.Except(listaIDsSelecionados).ToList();

            //Add item to ComboBox:
            foreach (int id in listaIDsExcluidos)
            {
                if (ehSubtransmissao)
                {
                    comboBox1.Items.Add(new ComboBoxItem(ucArvoreSubtransmissao.getDescricaoCriteriosById(id), id));
                }
                else
                {
                    comboBox1.Items.Add(new ComboBoxItem(ucArvoreDeCriterios.getDescricaoCriteriosById(id), id));
                }
            }
        }

        private void btEnviar_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione um Critério.");
                // this.DialogResult = DialogResult.Abort;
            }
            else
            {
                //Get hidden value of selected item:
                int crit = ((ComboBoxItem)comboBox1.SelectedItem).ID;
                ((FormReordenarCriterios)this.Owner).idCriterioAdicionar = crit;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
