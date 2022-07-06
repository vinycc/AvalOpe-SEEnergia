using AvalOpe.FormAvaliacaoCriterioSub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AvalOpe.UserControlsWPF
{
    /// <summary>
    /// Interaction logic for ucArvoreSubtransmissao.xaml
    /// </summary>
    public partial class ucArvoreSubtransmissao : UserControl
    {
        public bool calculo;
        public bool automatico;
        public bool ehMUST;
        int codigoContingencia;
        public FormArvoreSubtransmissao fa;

        public AspectosPessoais Aspecto;

        public ucArvoreSubtransmissao()
        {
            InitializeComponent();
            //CriarNos();
        }

        public void SetAspectosPessoais(AspectosPessoais asp)
        {
            this.Aspecto = asp;
        }

        public ucArvoreSubtransmissao(bool aut, bool must, int codContingencia)
        {
            InitializeComponent();

            this.ehMUST = must;
            this.codigoContingencia = codContingencia;

            if (aut)
            {
                CriarFolhasAutomatico();
                this.automatico = aut;
            }
            else
            {
                CriarFolhasManual();
                this.automatico = aut;
            }
        }
        
        /// <summary>
        /// Cria nós habilitados para edição
        /// </summary>
        public void CriarFolhasManual()
        {
            raiz.CriarNo("Avaliação de Operadores");
            no01.CriarNo(true, "Qualidade do Produto EE", criterioLIMITETENSAO.getPeso() + criterioLIMITECARREGAMENTO.getPeso(), getDesvioQualidadeProduto(), true, true, false, false, false);
            no02.CriarNo(true, "Custos Adicionais", criterioMUST.getPeso(), getDesvioCusto(), true, true, false, false, false);
            no03.CriarNo(!ehMUST, "Qualidade do Serviço EE", criterioFEC.getPeso() + criterioDM.getPeso() + criterioCHI.getPeso(), getDesvioQualidadeServico(), true, true, false, false, false);
            no04.CriarNo(true, "Conformidade de Manobra", criterioSEGURANCA.getPeso() + criterioSEQUENCIARESTABELECIMENTO.getPeso(), getDesvioConformidade(), true, true, false, false, false);
            no05.CriarNo(true, "Aspectos Pessoais", criterioCOMPETENCIA.getPeso(), criterioCOMPETENCIA.getDesvio(), true, true, false, false, false);

            if (this.ehMUST)
            {
                criterioLIMITETENSAO.CriarNo(true, enumCriteriosSubtransmissao.criterioLimiteTensao.EnumToString(), 0, 0, true, true, true, true, false);
                criterioLIMITECARREGAMENTO.CriarNo(true, enumCriteriosSubtransmissao.criterioLimiteCarregamento.EnumToString(), 0, 0, true, true, true, true, false);
                criterioCOMPETENCIA.CriarNo(true, enumCriteriosSubtransmissao.criterioCompetencia.EnumToString(), 0, 0, true, true, true, true, false);
                criterioMUST.CriarNo(true, enumCriteriosSubtransmissao.criterioMust.EnumToString(), 0, 0, true, true, true, true, false);
                criterioSEQUENCIARESTABELECIMENTO.CriarNo(true, enumCriteriosSubtransmissao.criterioSequenciaRestabelecimento.EnumToString(), 0, 0, true, true, true, true, false);
                criterioFEC.CriarNo(false, enumCriteriosSubtransmissao.criterioFEC.EnumToString(), 0, 0, true, true, true, true, false);
                criterioDM.CriarNo(false, enumCriteriosSubtransmissao.criterioDM.EnumToString(), 0, 0, true, true, true, true, false);
                criterioCHI.CriarNo(false, enumCriteriosSubtransmissao.criterioCHI.EnumToString(), 0, 0, true, true, true, true, false);
                criterioSEGURANCA.CriarNo(false, enumCriteriosSubtransmissao.criterioSeguranca.EnumToString(), 0, 0, true, true, true, true, false);

                criterioCONHECIMENTO.CriarNo(false, enumCriteriosSubtransmissao.criterioConhecimento.EnumToString(), 1, 0, true, true, true, true, false);
                criterioHABILIDADE.CriarNo(false, enumCriteriosSubtransmissao.criterioHabilidade.EnumToString(), 1, 0, true, true, true, true, false);
                criterioATITUDE.CriarNo(false, enumCriteriosSubtransmissao.criterioAtitude.EnumToString(), 1, 0, true, true, true, true, false);
                criterioSTRESS.CriarNo(false, enumCriteriosSubtransmissao.criterioStress.EnumToString(), 0, 0, true, true, true, true, false);

                criterioExtra01.CriarNo(false, "Extra 1", 0, 0, true, true, true, true, false);
                criterioExtra02.CriarNo(false, "Extra 2", 0, 0, true, true, true, true, false);
                criterioExtra03.CriarNo(false, "Extra 3", 0, 0, true, true, true, true, false);
                criterioExtra04.CriarNo(false, "Extra 4", 0, 0, true, true, true, true, false);
            }
            else
            {
                criterioLIMITETENSAO.CriarNo(true, enumCriteriosSubtransmissao.criterioLimiteTensao.EnumToString(), 0, 0, true, true, true, true, false);
                criterioLIMITECARREGAMENTO.CriarNo(true, enumCriteriosSubtransmissao.criterioLimiteCarregamento.EnumToString(), 0, 0, true, true, true, true, false);
                criterioFEC.CriarNo(true, enumCriteriosSubtransmissao.criterioFEC.EnumToString(), 0, 0, true, true, true, true, false);
                criterioDM.CriarNo(true, enumCriteriosSubtransmissao.criterioDM.EnumToString(), 0, 0, true, true, true, true, false);
                criterioCHI.CriarNo(true, enumCriteriosSubtransmissao.criterioCHI.EnumToString(), 0, 0, true, true, true, true, false);
                criterioCOMPETENCIA.CriarNo(true, enumCriteriosSubtransmissao.criterioCompetencia.EnumToString(), 0, 0, true, true, true, false, false);
                criterioMUST.CriarNo(true, enumCriteriosSubtransmissao.criterioMust.EnumToString(), 0, 0, true, true, true, true, false);
                criterioSEGURANCA.CriarNo(true, enumCriteriosSubtransmissao.criterioSeguranca.EnumToString(), 0, 0, true, true, true, true, false);
                criterioSEQUENCIARESTABELECIMENTO.CriarNo(true, enumCriteriosSubtransmissao.criterioSequenciaRestabelecimento.EnumToString(), 0, 0, true, true, true, true, false);

                criterioCONHECIMENTO.CriarNo(true, enumCriteriosSubtransmissao.criterioConhecimento.EnumToString(), 1, 0, true, true, true, true, false);
                criterioHABILIDADE.CriarNo(true, enumCriteriosSubtransmissao.criterioHabilidade.EnumToString(), 1, 0, true, true, true, true, false);
                criterioATITUDE.CriarNo(true, enumCriteriosSubtransmissao.criterioAtitude.EnumToString(), 1, 0, true, true, true, true, false);
                criterioSTRESS.CriarNo(true, enumCriteriosSubtransmissao.criterioStress.EnumToString(), 0, 0, false, false, false, false, false);

                criterioExtra01.CriarNo(false, "Extra 1", 0, 0, true, true, true, true, false);
                criterioExtra02.CriarNo(false, "Extra 2", 0, 0, true, true, true, true, false);
                criterioExtra03.CriarNo(false, "Extra 3", 0, 0, true, true, true, true, false);
                criterioExtra04.CriarNo(false, "Extra 4", 0, 0, true, true, true, true, false);
            }
            this.SetPesoNoPai();
        }

        /// <summary>
        /// Cria nós preenchidos automaticamente
        /// </summary>
        public void CriarFolhasAutomatico()
        {
            raiz.CriarNo("Avaliação de Operadores");
            no01.CriarNo(true, "Qualidade do Produto EE", criterioLIMITETENSAO.getPeso() + criterioLIMITECARREGAMENTO.getPeso(), getDesvioQualidadeProduto(), true, true, false, false, true);
            no02.CriarNo(true, "Custos Adicionais", criterioMUST.getPeso(), getDesvioCusto(), true, true, false, false, true);
            no03.CriarNo(!ehMUST, "Qualidade do Serviço EE", criterioFEC.getPeso() + criterioDM.getPeso() + criterioCHI.getPeso(), getDesvioQualidadeServico(), true, true, false, false, true);
            no04.CriarNo(true, "Conformidade de Manobra", criterioSEGURANCA.getPeso() + criterioSEQUENCIARESTABELECIMENTO.getPeso(), getDesvioConformidade(), true, true, false, false, true);
            no05.CriarNo(true, "Aspectos Pessoais", criterioCOMPETENCIA.getPeso(), criterioCOMPETENCIA.getDesvio(), true, true, false, false, true);
            //criterioSTRESS.SetColor(0, false);

            if (this.ehMUST)
            {
                List<double> listaPesos = GeraListaPesos(5);

                criterioLIMITETENSAO.CriarNo(true, enumCriteriosSubtransmissao.criterioLimiteTensao.EnumToString(), listaPesos[3], 0, true, true, false, true, true);
                criterioLIMITECARREGAMENTO.CriarNo(true, enumCriteriosSubtransmissao.criterioLimiteCarregamento.EnumToString(), listaPesos[2], 0, true, true, false, true, true);
                criterioCOMPETENCIA.CriarNo(true, enumCriteriosSubtransmissao.criterioCompetencia.EnumToString(), listaPesos[1], criterioCOMPETENCIA.getDesvio(), true, true, false, true, true);
                criterioMUST.CriarNo(true, enumCriteriosSubtransmissao.criterioMust.EnumToString(), listaPesos[0], 0, true, true, false, true, true);
                criterioSEQUENCIARESTABELECIMENTO.CriarNo(true, enumCriteriosSubtransmissao.criterioSequenciaRestabelecimento.EnumToString(), listaPesos[4], 0, true, true, false, true, true);

                criterioFEC.CriarNo(false, enumCriteriosSubtransmissao.criterioFEC.EnumToString(), 0, 0, true, true, false, true, true);
                criterioDM.CriarNo(false, enumCriteriosSubtransmissao.criterioDM.EnumToString(), 0, 0, true, true, false, true, true);
                criterioCHI.CriarNo(false, enumCriteriosSubtransmissao.criterioCHI.EnumToString(), 0, 0, true, true, false, true, true);
                criterioSEGURANCA.CriarNo(false, enumCriteriosSubtransmissao.criterioSeguranca.EnumToString(), 0, 0, true, true, false, true, true);

                criterioCONHECIMENTO.CriarNo(false, enumCriteriosSubtransmissao.criterioConhecimento.EnumToString(), 1, 0, true, true, false, true, true);
                criterioHABILIDADE.CriarNo(false, enumCriteriosSubtransmissao.criterioHabilidade.EnumToString(), 1, 0, true, true, false, true, true);
                criterioATITUDE.CriarNo(false, enumCriteriosSubtransmissao.criterioAtitude.EnumToString(), 1, 0, true, true, false, true, true);
                criterioSTRESS.CriarNo(false, enumCriteriosSubtransmissao.criterioStress.EnumToString(), 0, 0, true, true, false, true, true);

                criterioExtra01.CriarNo(false, "Extra 1", 0, 0, true, true, false, true, true);
                criterioExtra02.CriarNo(false, "Extra 2", 0, 0, true, true, false, true, true);
                criterioExtra03.CriarNo(false, "Extra 3", 0, 0, true, true, false, true, true);
                criterioExtra04.CriarNo(false, "Extra 4", 0, 0, true, true, false, true, true);
            }
            else
            {
                List<double> listaPesos = GeraListaPesos(9);

                //Caso_1
                if (codigoContingencia == 1)
                {
                    criterioSEGURANCA.CriarNo(true, enumCriteriosSubtransmissao.criterioSeguranca.EnumToString(), listaPesos[0], 0, true, true, false, true, true); //seguranca
                    criterioMUST.CriarNo(true, enumCriteriosSubtransmissao.criterioMust.EnumToString(), listaPesos[1], 0, true, true, false, true, true); //must
                    criterioFEC.CriarNo(true, enumCriteriosSubtransmissao.criterioFEC.EnumToString(), listaPesos[2], 100, true, true, false, true, true); //fec evitado
                    criterioDM.CriarNo(true, enumCriteriosSubtransmissao.criterioDM.EnumToString(), listaPesos[3], 0, true, true, false, true, true); //dm
                    criterioCOMPETENCIA.CriarNo(true, enumCriteriosSubtransmissao.criterioCompetencia.EnumToString(), listaPesos[4], criterioCOMPETENCIA.getDesvio(), true, true, false, false, true); //competencia profissional
                    criterioCHI.CriarNo(true, enumCriteriosSubtransmissao.criterioCHI.EnumToString(), listaPesos[5], 100, true, true, false, true, true); //chi
                    criterioSEQUENCIARESTABELECIMENTO.CriarNo(true, enumCriteriosSubtransmissao.criterioSequenciaRestabelecimento.EnumToString(), listaPesos[6], 100, true, true, false, true, true); //sequencia restabelecimento
                    criterioLIMITETENSAO.CriarNo(true, enumCriteriosSubtransmissao.criterioLimiteTensao.EnumToString(), listaPesos[7], 0, true, true, false, true, true); //limite de tensao
                    criterioLIMITECARREGAMENTO.CriarNo(true, enumCriteriosSubtransmissao.criterioLimiteCarregamento.EnumToString(), listaPesos[8], 100, true, true, false, true, true); //limite carregamento

                    criterioCONHECIMENTO.CriarNo(true, enumCriteriosSubtransmissao.criterioConhecimento.EnumToString(), 1, 50, true, true, true, true, true); //conhecimento
                    criterioHABILIDADE.CriarNo(true, enumCriteriosSubtransmissao.criterioHabilidade.EnumToString(), 1, 50, true, true, true, true, true); //habilidade
                    criterioATITUDE.CriarNo(true, enumCriteriosSubtransmissao.criterioAtitude.EnumToString(), 1, 50, true, true, true, true, true); //atitude
                    criterioSTRESS.CriarNo(true, enumCriteriosSubtransmissao.criterioStress.EnumToString(), 0, 0, false, false, false, false, true); //stress

                    criterioExtra01.CriarNo(false, "Extra 1", 0, 0, true, true, false, true, true);
                    criterioExtra02.CriarNo(false, "Extra 2", 0, 0, true, true, false, true, true);
                    criterioExtra03.CriarNo(false, "Extra 3", 0, 0, true, true, false, true, true);
                    criterioExtra04.CriarNo(false, "Extra 4", 0, 0, true, true, false, true, true);
                }
                else
                {
                    criterioSEGURANCA.CriarNo(true, enumCriteriosSubtransmissao.criterioSeguranca.EnumToString(), listaPesos[0], 0, true, true, false, true, true); //seguranca
                    criterioMUST.CriarNo(true, enumCriteriosSubtransmissao.criterioMust.EnumToString(), listaPesos[1], 0, true, true, false, true, true); //must
                    criterioFEC.CriarNo(true, enumCriteriosSubtransmissao.criterioFEC.EnumToString(), listaPesos[2], 0, true, true, false, true, true); //fec evitado
                    criterioDM.CriarNo(true, enumCriteriosSubtransmissao.criterioDM.EnumToString(), listaPesos[3], 0, true, true, false, true, true); //dm
                    criterioCOMPETENCIA.CriarNo(true, enumCriteriosSubtransmissao.criterioCompetencia.EnumToString(), listaPesos[4], criterioCOMPETENCIA.getDesvio(), true, true, false, false, true); //competencia profissional
                    criterioCHI.CriarNo(true, enumCriteriosSubtransmissao.criterioCHI.EnumToString(), listaPesos[5], 0, true, true, false, true, true); //chi
                    criterioSEQUENCIARESTABELECIMENTO.CriarNo(true, enumCriteriosSubtransmissao.criterioSequenciaRestabelecimento.EnumToString(), listaPesos[6], 0, true, true, false, true, true); //sequencia restabelecimento
                    criterioLIMITETENSAO.CriarNo(true, enumCriteriosSubtransmissao.criterioLimiteTensao.EnumToString(), listaPesos[7], 0, true, true, false, true, true); //limite de tensao
                    criterioLIMITECARREGAMENTO.CriarNo(true, enumCriteriosSubtransmissao.criterioLimiteCarregamento.EnumToString(), listaPesos[8], 0, true, true, false, true, true); //limite carregamento

                    criterioCONHECIMENTO.CriarNo(true, enumCriteriosSubtransmissao.criterioConhecimento.EnumToString(), 1, 0, true, true, true, true, true); //conhecimento
                    criterioHABILIDADE.CriarNo(true, enumCriteriosSubtransmissao.criterioHabilidade.EnumToString(), 1, 0, true, true, true, true, true); //habilidade
                    criterioATITUDE.CriarNo(true, enumCriteriosSubtransmissao.criterioAtitude.EnumToString(), 1, 0, true, true, true, true, true); //atitude
                    criterioSTRESS.CriarNo(true, enumCriteriosSubtransmissao.criterioStress.EnumToString(), 0, 0, false, false, false, false, true); //stress

                    criterioExtra01.CriarNo(false, "Extra 1", 0, 0, true, true, false, true, true);
                    criterioExtra02.CriarNo(false, "Extra 2", 0, 0, true, true, false, true, true);
                    criterioExtra03.CriarNo(false, "Extra 3", 0, 0, true, true, false, true, true);
                    criterioExtra04.CriarNo(false, "Extra 4", 0, 0, true, true, false, true, true);
                }
            }
            this.SetPesoNoPai();
        }

        internal List<Criterio> GetListCriterios()
        {
            List<Criterio> lista = new List<Criterio>();

            lista.Add(new Criterio(enumCriteriosSubtransmissao.criterioLimiteTensao, criterioLIMITETENSAO.getPeso(), criterioLIMITETENSAO.getDesvio(), criterioLIMITETENSAO.getAtivo()));
            lista.Add(new Criterio(enumCriteriosSubtransmissao.criterioLimiteCarregamento, criterioLIMITECARREGAMENTO.getPeso(), criterioLIMITECARREGAMENTO.getDesvio(), criterioLIMITECARREGAMENTO.getAtivo()));
            lista.Add(new Criterio(enumCriteriosSubtransmissao.criterioFEC, criterioFEC.getPeso(), criterioFEC.getDesvio(), criterioFEC.getAtivo()));
            lista.Add(new Criterio(enumCriteriosSubtransmissao.criterioDM, criterioDM.getPeso(), criterioDM.getDesvio(), criterioDM.getAtivo()));
            lista.Add(new Criterio(enumCriteriosSubtransmissao.criterioCHI, criterioCHI.getPeso(), criterioCHI.getDesvio(), criterioCHI.getAtivo()));
            lista.Add(new Criterio(enumCriteriosSubtransmissao.criterioCompetencia, criterioCOMPETENCIA.getPeso(), criterioCOMPETENCIA.getDesvio(), criterioCOMPETENCIA.getAtivo()));
            lista.Add(new Criterio(enumCriteriosSubtransmissao.criterioMust, criterioMUST.getPeso(), criterioMUST.getDesvio(), criterioMUST.getAtivo()));
            lista.Add(new Criterio(enumCriteriosSubtransmissao.criterioSeguranca, criterioSEGURANCA.getPeso(), criterioSEGURANCA.getDesvio(), criterioSEGURANCA.getAtivo()));
            lista.Add(new Criterio(enumCriteriosSubtransmissao.criterioSequenciaRestabelecimento, criterioSEQUENCIARESTABELECIMENTO.getPeso(), criterioSEQUENCIARESTABELECIMENTO.getDesvio(), criterioSEQUENCIARESTABELECIMENTO.getAtivo()));
            lista.Add(new Criterio(enumCriteriosSubtransmissao.criterioConhecimento, criterioCONHECIMENTO.getPeso(), criterioCONHECIMENTO.getDesvio(), criterioCONHECIMENTO.getAtivo()));
            lista.Add(new Criterio(enumCriteriosSubtransmissao.criterioHabilidade, criterioHABILIDADE.getPeso(), criterioHABILIDADE.getDesvio(), criterioHABILIDADE.getAtivo()));
            lista.Add(new Criterio(enumCriteriosSubtransmissao.criterioAtitude, criterioATITUDE.getPeso(), criterioATITUDE.getDesvio(), criterioATITUDE.getAtivo()));

            lista.Add(new Criterio(enumCriteriosSubtransmissao.criterioExtra1, criterioExtra01.getPeso(), criterioExtra01.getDesvio(), criterioExtra01.getAtivo()));
            lista.Add(new Criterio(enumCriteriosSubtransmissao.criterioExtra2, criterioExtra02.getPeso(), criterioExtra02.getDesvio(), criterioExtra02.getAtivo()));
            lista.Add(new Criterio(enumCriteriosSubtransmissao.criterioExtra3, criterioExtra03.getPeso(), criterioExtra03.getDesvio(), criterioExtra03.getAtivo()));
            lista.Add(new Criterio(enumCriteriosSubtransmissao.criterioExtra4, criterioExtra04.getPeso(), criterioExtra04.getDesvio(), criterioExtra04.getAtivo()));


            return lista;
        }

        internal void SetFolhaExtra(ucFolhaExtra ucFolhaExtra)
        {
            throw new NotImplementedException();
        }

        internal void SetFolha(ucFolhaArvore ucFolhaArvore)
        {
            ucFolhaArvore.Focus();
        }

        public void AtualizarArvore(List<Criterio> lista)
        {

            //Buscar Lista de Pesos Calculados
            List<double> l = GeraListaPesos(lista.Count(o => o.Ativo == true));

            //Percorre nova lista de criterios e atualiza os pesos dos criterios ativos
            int i = 0;
            foreach (Criterio c in lista.Where(o => o.Ativo == true).OrderByDescending(a => a.Peso))
            {
                c.Peso = l[i];
                i++;
            }


            foreach (Criterio c in lista)
            {
                switch (c.Id)
                {
                    case (int)enumCriteriosSubtransmissao.criterioLimiteTensao :
                        criterioLIMITETENSAO.SetPeso(c.Peso, c.Desvio);
                        criterioLIMITETENSAO.SetColor(c.Desvio, c.Ativo);
                        break;
                    case (int)enumCriteriosSubtransmissao.criterioLimiteCarregamento:
                        criterioLIMITECARREGAMENTO.SetPeso(c.Peso, c.Desvio);
                        criterioLIMITECARREGAMENTO.SetColor(c.Desvio, c.Ativo);
                        break;
                    case (int)enumCriteriosSubtransmissao.criterioFEC:
                        criterioFEC.SetPeso(c.Peso, c.Desvio);
                        criterioFEC.SetColor(c.Desvio, c.Ativo);
                        break;
                    case (int)enumCriteriosSubtransmissao.criterioDM:
                        criterioDM.SetPeso(c.Peso, c.Desvio);
                        criterioDM.SetColor(c.Desvio, c.Ativo);
                        break;
                    case (int)enumCriteriosSubtransmissao.criterioCHI:
                        criterioCHI.SetPeso(c.Peso, c.Desvio);
                        criterioCHI.SetColor(c.Desvio, c.Ativo);
                        break;
                    case (int)enumCriteriosSubtransmissao.criterioCompetencia:
                        criterioCOMPETENCIA.SetPeso(c.Peso, c.Desvio);
                        criterioCOMPETENCIA.SetColor(c.Desvio, c.Ativo);

                        //Atualizar os filhos se não for must
                        if (!ehMUST)
                        {
                            //se o peso e o desvio for zero, é porque desabilitou, o pai. Então deve desabilitar os filhos tbm
                            if (c.Peso == 0 & c.Desvio == 0)
                            {
                                criterioCONHECIMENTO.SetPeso(c.Peso, c.Desvio);
                                criterioCONHECIMENTO.SetColor(c.Desvio, c.Ativo);

                                criterioHABILIDADE.SetPeso(c.Peso, c.Desvio);
                                criterioHABILIDADE.SetColor(c.Desvio, c.Ativo);

                                criterioATITUDE.SetPeso(c.Peso, c.Desvio);
                                criterioATITUDE.SetColor(c.Desvio, c.Ativo);
                            }
                            else
                            {
                                if (criterioCONHECIMENTO.getAtivo())
                                {
                                    criterioCONHECIMENTO.SetColor(criterioCONHECIMENTO.getDesvio(), c.Ativo);
                                }
                                else
                                {
                                    criterioCONHECIMENTO.SetPeso(0, 0);
                                    criterioCONHECIMENTO.SetColor(0, c.Ativo);
                                }
                                if (criterioHABILIDADE.getAtivo())
                                {
                                    criterioHABILIDADE.SetColor(criterioHABILIDADE.getDesvio(), c.Ativo);
                                }
                                else
                                {
                                    criterioHABILIDADE.SetPeso(0, 0);
                                    criterioHABILIDADE.SetColor(0, c.Ativo);
                                }
                                if (criterioATITUDE.getAtivo())
                                {
                                    criterioATITUDE.SetColor(criterioATITUDE.getDesvio(), c.Ativo);
                                }
                                else
                                {
                                    criterioATITUDE.SetPeso(0, 0);
                                    criterioATITUDE.SetColor(0, c.Ativo);
                                }
                            }
                        }
                        break;
                    case (int)enumCriteriosSubtransmissao.criterioMust:
                        criterioMUST.SetPeso(c.Peso, c.Desvio);
                        criterioMUST.SetColor(c.Desvio, c.Ativo);
                        break;
                    case (int)enumCriteriosSubtransmissao.criterioSeguranca:
                        criterioSEGURANCA.SetPeso(c.Peso, c.Desvio);
                        criterioSEGURANCA.SetColor(c.Desvio, c.Ativo);
                        break;
                    case (int)enumCriteriosSubtransmissao.criterioSequenciaRestabelecimento:
                        criterioSEQUENCIARESTABELECIMENTO.SetPeso(c.Peso, c.Desvio);
                        criterioSEQUENCIARESTABELECIMENTO.SetColor(c.Desvio, c.Ativo);
                        break;
                    case (int)enumCriteriosSubtransmissao.criterioExtra1:    
                        criterioExtra01.SetPeso(c.Peso, c.Desvio);
                        criterioExtra01.SetColor(c.Desvio, c.Ativo);
                        break;
                    case (int)enumCriteriosSubtransmissao.criterioExtra2:    
                        criterioExtra02.SetPeso(c.Peso, c.Desvio);
                        criterioExtra02.SetColor(c.Desvio, c.Ativo);
                        break;
                    case (int)enumCriteriosSubtransmissao.criterioExtra3:    
                        criterioExtra03.SetPeso(c.Peso, c.Desvio);
                        criterioExtra03.SetColor(c.Desvio, c.Ativo);
                        break;
                    case (int)enumCriteriosSubtransmissao.criterioExtra4: 
                        criterioExtra04.SetPeso(c.Peso, c.Desvio);
                        criterioExtra04.SetColor(c.Desvio, c.Ativo);
                        break;
                }
            }

            this.SetPesoNoPai();
        }

        internal void SetCalculo(FormArvoreSubtransmissao formArvore, bool c)
        {
            this.fa = formArvore;
            this.calculo = c;
        }


        public static List<double> GeraListaPesos(int n)
        {
            List<double> listaPesos = new List<double>();

            for (int j = 1; j <= n; j++)
            {
                double soma = 0;
                for (int i = j; i <= n; i++)
                {
                    soma = soma + (1.0 / i);
                }

                double w = (1.0 / n) * soma;
                w = w * 100;

                //listaPesos.Add(Math.Round(w, 4));
                listaPesos.Add(w);
            }

            return listaPesos;
        }

        

        public double getDesvioQualidadeProduto()
        {
            try
            {                
                return (
                    criterioLIMITETENSAO.getDesvio() * criterioLIMITETENSAO.getPeso() +
                    criterioLIMITECARREGAMENTO.getDesvio() * criterioLIMITECARREGAMENTO.getPeso() +
                    criterioExtra01.getDesvio() * criterioExtra01.getPeso()) /
                    (criterioLIMITETENSAO.getPeso() + criterioLIMITECARREGAMENTO.getPeso() + criterioExtra01.getPeso());
            }
            catch
            {
                return 0;
            }
        }

        public double getDesvioCusto()
        {
            try
            {
                return (
                    criterioMUST.getDesvio() * criterioMUST.getPeso() +
                    criterioExtra02.getDesvio() * criterioExtra02.getPeso()) /
                    (criterioMUST.getPeso() + criterioExtra02.getPeso());
            }
            catch
            {
                return 0;
            }
        }

        public double getDesvioQualidadeServico()
        {
            try
            {
                return (
                    criterioFEC.getDesvio() * criterioFEC.getPeso() +
                    criterioDM.getDesvio() * criterioDM.getPeso() +
                    criterioCHI.getDesvio() * criterioCHI.getPeso() +
                    criterioExtra03.getDesvio() * criterioExtra03.getPeso()) /
                    (criterioFEC.getPeso() + criterioDM.getPeso() + criterioCHI.getPeso() + criterioExtra03.getPeso());
            }
            catch
            {
                return 0;
            }
        }

        public double getDesvioConformidade()
        {
            try
            {
                return (
                    criterioSEGURANCA.getDesvio() * criterioSEGURANCA.getPeso() +
                    criterioSEQUENCIARESTABELECIMENTO.getDesvio() * criterioSEQUENCIARESTABELECIMENTO.getPeso() +
                    criterioExtra04.getDesvio() * criterioExtra04.getPeso()) /
                    (criterioSEGURANCA.getPeso() + criterioSEQUENCIARESTABELECIMENTO.getPeso() + criterioExtra04.getPeso());
            }
            catch
            {
                return 0;
            }
        }

        public double getDesvioAspectosPessoaisPai()
        {
            try
            {
                return (
                    criterioCOMPETENCIA.getDesvio() * criterioCOMPETENCIA.getPeso()) /
                    (criterioCOMPETENCIA.getPeso());
            }
            catch
            {
                return 0;
            }
        }

        public double getDesvioAspectosPessoaisFilho()
        {
            try
            {
                return (
                    criterioCONHECIMENTO.getDesvio() * criterioCONHECIMENTO.getPeso() +
                    criterioHABILIDADE.getDesvio() * criterioHABILIDADE.getPeso() +
                    criterioATITUDE.getDesvio() * criterioATITUDE.getPeso()) /
                    (criterioCONHECIMENTO.getPeso() + criterioHABILIDADE.getPeso() + criterioATITUDE.getPeso());
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Calcula e retorna o valor da avaliação
        /// Fórmula: 1 - (peso1 * desvio1 + peso2 * desvio2 + ... pesoN * desvioN)
        /// </summary>
        /// <returns></returns>
        public double GetAvaliacao()
        {
            double avaliacao;

            if (this.automatico)
            {
                avaliacao = 100 - ((
                    criterioLIMITETENSAO.getPeso() * criterioLIMITETENSAO.getDesvio() +
                    criterioLIMITECARREGAMENTO.getPeso() * criterioLIMITECARREGAMENTO.getDesvio() +
                    criterioFEC.getPeso() * criterioFEC.getDesvio() +
                    criterioDM.getPeso() * criterioDM.getDesvio() +
                    criterioCHI.getPeso() * criterioCHI.getDesvio() +
                    criterioCOMPETENCIA.getPeso() * criterioCOMPETENCIA.getDesvio() +
                    criterioMUST.getPeso() * criterioMUST.getDesvio() +
                    criterioSEGURANCA.getPeso() * criterioSEGURANCA.getDesvio() +
                    criterioSEQUENCIARESTABELECIMENTO.getPeso() * criterioSEQUENCIARESTABELECIMENTO.getDesvio() +
                    criterioExtra01.getPeso() * criterioExtra01.getDesvio() +
                    criterioExtra02.getPeso() * criterioExtra02.getDesvio() +
                    criterioExtra03.getPeso() * criterioExtra03.getDesvio() +
                    criterioExtra04.getPeso() * criterioExtra04.getDesvio()
                    ) / GetSomaPesos());
            }
            else
            {
                //ARVORE MANUAL - Converter pesos (0 a 10) para porcentagem
                double somaPeso = GetSomaPesos();

                double cLIMITETENSAO = 100 * (criterioLIMITETENSAO.getPeso() / somaPeso);
                double cLIMITECARREGAMENTO = 100 * (criterioLIMITECARREGAMENTO.getPeso() / somaPeso);
                double cFEC = 100 * (criterioFEC.getPeso() / somaPeso);
                double cDM = 100 * (criterioDM.getPeso() / somaPeso);
                double cCHI = 100 * (criterioCHI.getPeso() / somaPeso);
                double cCOMPETENCIA = 100 * (criterioCOMPETENCIA.getPeso() / somaPeso);
                double cMUST = 100 * (criterioMUST.getPeso() / somaPeso);
                double cSEGURANCA = 100 * (criterioSEGURANCA.getPeso() / somaPeso);
                double cSEQUENCIAMANOBRA = 100 * (criterioSEQUENCIARESTABELECIMENTO.getPeso() / somaPeso);
                double cExtra01 = 100 * (criterioExtra01.getPeso() / somaPeso);
                double cExtra02 = 100 * (criterioExtra02.getPeso() / somaPeso);
                double cExtra03 = 100 * (criterioExtra03.getPeso() / somaPeso);
                double cExtra04 = 100 * (criterioExtra04.getPeso() / somaPeso);


                avaliacao = 100 - ((
                cLIMITETENSAO * criterioLIMITETENSAO.getDesvio() +
                cLIMITECARREGAMENTO * criterioLIMITECARREGAMENTO.getDesvio() +
                cFEC * criterioFEC.getDesvio() +
                cDM * criterioDM.getDesvio() +
                cCHI * criterioCHI.getDesvio() +
                cCOMPETENCIA * criterioCOMPETENCIA.getDesvio() +
                cMUST * criterioMUST.getDesvio() +
                cSEGURANCA * criterioSEGURANCA.getDesvio() +
                cSEQUENCIAMANOBRA * criterioSEQUENCIARESTABELECIMENTO.getDesvio() +
                cExtra01 * criterioExtra01.getDesvio() +
                cExtra02 * criterioExtra02.getDesvio() +
                cExtra03 * criterioExtra03.getDesvio() +
                cExtra04 * criterioExtra04.getDesvio()
                ) / (100));
            }

            if (Double.IsNaN(avaliacao))
                avaliacao = 0;

            return avaliacao;
        }

        public double GetSomaPesos()
        {
            double p =
                criterioLIMITETENSAO.getPeso() +
                criterioLIMITECARREGAMENTO.getPeso() +
                criterioFEC.getPeso() +
                criterioDM.getPeso() +
                criterioCHI.getPeso() +
                criterioCOMPETENCIA.getPeso() +
                criterioMUST.getPeso() +
                criterioSEGURANCA.getPeso() +
                criterioSEQUENCIARESTABELECIMENTO.getPeso() +
                criterioExtra01.getPeso() +
                criterioExtra02.getPeso() +
                criterioExtra03.getPeso() +
                criterioExtra04.getPeso();                
            return p;
        }

        public void SetPesoNoPai()
        {
            if (this.ehMUST)
            {
                no01.AtualizarNo(criterioLIMITETENSAO.getPeso() + criterioLIMITECARREGAMENTO.getPeso() + criterioExtra01.getPeso(), getDesvioQualidadeProduto(), (criterioLIMITETENSAO.getAtivo() || criterioLIMITECARREGAMENTO.getAtivo() || criterioExtra01.getAtivo()));
                no02.AtualizarNo(criterioMUST.getPeso() + criterioExtra02.getPeso(), getDesvioCusto(), (criterioMUST.getAtivo() || criterioExtra02.getAtivo()));
                no03.AtualizarNo(criterioFEC.getPeso() + criterioDM.getPeso() + criterioCHI.getPeso() + criterioExtra03.getPeso(), getDesvioQualidadeServico(), (criterioFEC.getAtivo() || criterioDM.getAtivo() || criterioCHI.getAtivo() || criterioExtra03.getAtivo()));
                no04.AtualizarNo(criterioSEGURANCA.getPeso() + criterioSEQUENCIARESTABELECIMENTO.getPeso() + criterioExtra04.getPeso(), getDesvioConformidade(), (criterioSEGURANCA.getAtivo() || criterioSEQUENCIARESTABELECIMENTO.getAtivo() || criterioExtra04.getAtivo()));
                criterioCOMPETENCIA.AtualizarNo(criterioCOMPETENCIA.getPeso(), getDesvioAspectosPessoaisPai(), criterioCOMPETENCIA.getAtivo());
                no05.AtualizarNo(criterioCOMPETENCIA.getPeso(), getDesvioAspectosPessoaisPai() /*criterio06.getDesvio()*/, criterioCOMPETENCIA.getAtivo());

            }
            else {

                no01.AtualizarNo(criterioLIMITETENSAO.getPeso() + criterioLIMITECARREGAMENTO.getPeso() + criterioExtra01.getPeso(), getDesvioQualidadeProduto(), (criterioLIMITETENSAO.getAtivo() || criterioLIMITECARREGAMENTO.getAtivo() || criterioExtra01.getAtivo()));
                no02.AtualizarNo(criterioMUST.getPeso() + criterioExtra02.getPeso(), getDesvioCusto(), (criterioMUST.getAtivo() || criterioExtra02.getAtivo()));
                no03.AtualizarNo(criterioFEC.getPeso() + criterioDM.getPeso() + criterioCHI.getPeso() + criterioExtra03.getPeso(), getDesvioQualidadeServico(), (criterioFEC.getAtivo() || criterioDM.getAtivo() || criterioCHI.getAtivo() || criterioExtra03.getAtivo()));
                no04.AtualizarNo(criterioSEGURANCA.getPeso() + criterioSEQUENCIARESTABELECIMENTO.getPeso() + criterioExtra04.getPeso(), getDesvioConformidade(), (criterioSEGURANCA.getAtivo() || criterioSEQUENCIARESTABELECIMENTO.getAtivo() || criterioExtra04.getAtivo()));
                criterioCOMPETENCIA.AtualizarNo(criterioCOMPETENCIA.getPeso(), getDesvioAspectosPessoaisFilho(), criterioCONHECIMENTO.getAtivo() || criterioHABILIDADE.getAtivo() || criterioATITUDE.getAtivo());
                no05.AtualizarNo(criterioCOMPETENCIA.getPeso(), getDesvioAspectosPessoaisPai() /*criterio06.getDesvio()*/, criterioCOMPETENCIA.getAtivo());
            }
        }

        public static string getDescricaoCriteriosById(int id)
        {
            switch (id)
            {
                case (int)enumCriteriosSubtransmissao.criterioLimiteTensao:
                    return enumCriteriosSubtransmissao.criterioLimiteTensao.EnumToString();
                case (int)enumCriteriosSubtransmissao.criterioLimiteCarregamento:
                    return enumCriteriosSubtransmissao.criterioLimiteCarregamento.EnumToString();
                case (int)enumCriteriosSubtransmissao.criterioFEC:
                    return enumCriteriosSubtransmissao.criterioFEC.EnumToString();
                case (int)enumCriteriosSubtransmissao.criterioDM:
                    return enumCriteriosSubtransmissao.criterioDM.EnumToString();
                case (int)enumCriteriosSubtransmissao.criterioCHI:
                    return enumCriteriosSubtransmissao.criterioCHI.EnumToString();
                case (int)enumCriteriosSubtransmissao.criterioCompetencia:
                    return enumCriteriosSubtransmissao.criterioCompetencia.EnumToString();
                case (int)enumCriteriosSubtransmissao.criterioMust:
                    return enumCriteriosSubtransmissao.criterioMust.EnumToString();
                case (int)enumCriteriosSubtransmissao.criterioSeguranca:
                    return enumCriteriosSubtransmissao.criterioSeguranca.EnumToString();
                case (int)enumCriteriosSubtransmissao.criterioSequenciaRestabelecimento:
                    return enumCriteriosSubtransmissao.criterioSequenciaRestabelecimento.EnumToString();
                case (int)enumCriteriosSubtransmissao.criterioConhecimento:
                    return enumCriteriosSubtransmissao.criterioConhecimento.EnumToString();
                case (int)enumCriteriosSubtransmissao.criterioHabilidade:
                    return enumCriteriosSubtransmissao.criterioHabilidade.EnumToString();
                case (int)enumCriteriosSubtransmissao.criterioAtitude:
                    return enumCriteriosSubtransmissao.criterioAtitude.EnumToString();
                case (int)enumCriteriosSubtransmissao.criterioStress:
                    return enumCriteriosSubtransmissao.criterioStress.EnumToString();
                case (int)enumCriteriosSubtransmissao.criterioExtra1:
                    return enumCriteriosSubtransmissao.criterioExtra1.EnumToString();
                case (int)enumCriteriosSubtransmissao.criterioExtra2:
                    return enumCriteriosSubtransmissao.criterioExtra2.EnumToString();
                case (int)enumCriteriosSubtransmissao.criterioExtra3:
                    return  enumCriteriosSubtransmissao.criterioExtra3.EnumToString();
                case (int)enumCriteriosSubtransmissao.criterioExtra4:
                    return enumCriteriosSubtransmissao.criterioExtra4.EnumToString();
                default:
                    return "";
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            criterioExtra01.Habilitar(! criterioExtra01.getAtivo());

            string src;
            if (criterioExtra01.getAtivo())
            {
                src = "pack://siteoforigin:,,,/Resources/delete2.png";
            }
            else
            {
                src = "pack://siteoforigin:,,,/Resources/add.png";
            }
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(src);
            logo.EndInit();
            imgExtra01.Source = logo;

            if (automatico)
            {
                List<Criterio> lista = GetListCriterios();
                AtualizarArvore(lista);
            }
            else
            {
                criterioExtra01.SetPeso(0, 0);
            }
        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {
            criterioExtra03.Habilitar(!criterioExtra03.getAtivo());

            string src;
            if (criterioExtra03.getAtivo())
            {
                src = "pack://siteoforigin:,,,/Resources/delete2.png";
            }
            else
            {
                src = "pack://siteoforigin:,,,/Resources/add.png";
            }
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(src);
            logo.EndInit();
            imgExtra03.Source = logo;

            if (automatico)
            {
                List<Criterio> lista = GetListCriterios();
                AtualizarArvore(lista);
            }
            else
            {
                criterioExtra03.SetPeso(0, 0);
            }

        }

        private void button_Copy2_Click(object sender, RoutedEventArgs e)
        {
            criterioExtra04.Habilitar(!criterioExtra04.getAtivo());

            string src;
            if (criterioExtra04.getAtivo())
            {
                src = "pack://siteoforigin:,,,/Resources/delete2.png";
            }
            else
            {
                src = "pack://siteoforigin:,,,/Resources/add.png";
            }
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(src);
            logo.EndInit();
            imgExtra04.Source = logo;

            if (automatico)
            {
                List<Criterio> lista = GetListCriterios();
                AtualizarArvore(lista);
            }
            else
            {
                criterioExtra04.SetPeso(0, 0);
            }


        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            criterioExtra02.Habilitar(!criterioExtra02.getAtivo());

            string src;
            if (criterioExtra02.getAtivo())
            {
                src = "pack://siteoforigin:,,,/Resources/delete2.png";
            }
            else
            {
                src = "pack://siteoforigin:,,,/Resources/add.png";
            }
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(src);
            logo.EndInit();
            imgExtra02.Source = logo;

            if (automatico)
            {
                List<Criterio> lista = GetListCriterios();
                AtualizarArvore(lista);
            }
            else
            {
                criterioExtra02.SetPeso(0, 0);
            }
        }

        private void criterio01_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FormAvaliarCriterioLimiteTensao f = new FormAvaliarCriterioLimiteTensao(criterioLIMITETENSAO.getPeso(), this);
            f.Show();
        }

        private void criterio02_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FormAvaliarCriterioLimiteCarregamento f = new FormAvaliarCriterioLimiteCarregamento(criterioLIMITECARREGAMENTO.getPeso(), this);
            f.Show();
        }

        private void criterio06_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FormAvaliarCriterioCompetenciaProfissional f = new FormAvaliarCriterioCompetenciaProfissional(criterioCOMPETENCIA.getPeso(), criterioCONHECIMENTO.getPeso(), criterioHABILIDADE.getPeso(), criterioATITUDE.getPeso(), this.Aspecto, this);
            f.Show();
        }

        private void criterio03_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FormAvaliarCriterioFecEvitado f = new FormAvaliarCriterioFecEvitado(criterioFEC.getPeso(), this);
            f.Show();
        }

        private void criterio04_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FormAvaliarCriterioDM f = new FormAvaliarCriterioDM(criterioDM.getPeso(), this);
            f.Show();
        }

        private void criterio05_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FormAvaliarCriterioCHI f = new FormAvaliarCriterioCHI(criterioCHI.getPeso(), this);
            f.Show();
        }

        private void criterio07_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FormAvaliarCriterioMust f = new FormAvaliarCriterioMust(criterioMUST.getPeso(), this);
            f.Show();
        }

        private void criterio08_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FormAvaliarCriterioSegurancaRede f = new FormAvaliarCriterioSegurancaRede(criterioSEGURANCA.getPeso(), this);
            f.Show();
        }

        private void criterio09_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FormAvaliarCriterioSequenciaRestabelecimento f = new FormAvaliarCriterioSequenciaRestabelecimento(criterioSEQUENCIARESTABELECIMENTO.getPeso(), this);
            f.Show();
        }

        private void no05_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FormAvaliarCriterioCompetenciaProfissional f = new FormAvaliarCriterioCompetenciaProfissional(criterioCOMPETENCIA.getPeso(), criterioCONHECIMENTO.getPeso(), criterioHABILIDADE.getPeso(), criterioATITUDE.getPeso(), this.Aspecto, this);
            f.Show();
        }
    }
}
