using AvalOpe.FormAvaliacaoCriterioDist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AvalOpe
{

    public class AspectosPessoais{
        public double HabilidadePeso { get; set; }
        public int HabilidadeAvaliacao { get; set; }
        public double ConhecimentoPeso { get; set; }
        public int ConhecimentoAvaliacao { get; set; }
        public double AtitudePeso { get; set; }
        public int AtitudeAvaliacao { get; set; }
        public string Observacao;
        public double Peso;
        public double Desvio;
    }



    /// <summary>
    /// Interaction logic for ucArvoreDeCriterios.xaml
    /// </summary>
    public partial class ucArvoreDeCriterios : UserControl
    {
        //public bool calculo;
        public bool automatico;
        public int Operador;
        public int Contingencia;
        public FormArvoreCriterios fa;

        public AspectosPessoais Aspecto;

        /// <summary>
        /// Construtor Padrao
        /// </summary>
        public ucArvoreDeCriterios()
        {
            InitializeComponent();
            //CriarNos();
        }

        public void SetAspectosPessoais(AspectosPessoais asp)
        {
            this.Aspecto = asp;
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="automatico">Preenche automaticamente</param>
        public ucArvoreDeCriterios(bool aut, int idOperador, int idContingencia)
        {
            InitializeComponent();

            this.Operador = idOperador;
            this.Contingencia = idContingencia;

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
            //CriarNos();
        }
        
        /// <summary>
        /// Cria nós habilitados para edição
        /// </summary>
        public void CriarFolhasManual()
        {
            #region FOLHAS PAIS
            no01.CriarNo(true, "Qualidade do Produto", criterioMAGNITUDETENSAO.getPeso() + criterioVARIACAOLINHA.getPeso(), getDesvioQualidadeProduto(), true, true, false, false, false);
            no02.CriarNo(true, "Custos", criterioEUSD.getPeso() + criterioDMIC.getPeso(), getDesvioCusto(), true, true, false, false, false);
            no03.CriarNo(true, "Qualidade de Serviço", criterioDEC.getPeso() + criterioFEC.getPeso() + criterioCONSUMIDORES.getPeso() + criterioTEMPOFILA.getPeso() + criterioCONSUMIDORESPRIORITARIOS.getPeso(), getDesvioQualidadeServico(), true, true, false, false, false);
            no04.CriarNo(true, "Conformidade da Manobra", criterioSEQUENCIACHAVEAMENTO.getPeso() + criterioSEGURANCA.getPeso(), getDesvioConformidade(), true, true, false, false, false);
            //criterioSTRESS.SetColor(0, false);
            #endregion

            criterioMAGNITUDETENSAO.CriarNo(true, enumCriterios.criterioMagnitudeTensao.EnumToString(), 0, 0, true, true, true, true, false);
            criterioVARIACAOLINHA.CriarNo(true, enumCriterios.criterioVariacaoLinha.EnumToString(), 0, 0, true, true, true, true, false);
            criterioEUSD.CriarNo(true, enumCriterios.criterioEUSD.EnumToString(), 0, 0, true, true, true, true, false);
            criterioDMIC.CriarNo(true, enumCriterios.criterioDMIC.EnumToString(), 0, 0, true, true, true, true, false);
            criterioDEC.CriarNo(true, enumCriterios.criterioDEC.EnumToString(), 0, 0, true, true, true, true, false);
            criterioFEC.CriarNo(true, enumCriterios.criterioFEC.EnumToString(), 0, 0, true, true, true, true, false);
            criterioCONSUMIDORES.CriarNo(true, enumCriterios.criterioConsumidoes.EnumToString(), 0, 0, true, true, true, true, false);
            criterioTEMPOFILA.CriarNo(true, enumCriterios.criterioTempoFila.EnumToString(), 0, 0, true, true, true, true, false);
            criterioCONSUMIDORESPRIORITARIOS.CriarNo(true, enumCriterios.criterioConsumidoresPrioritario.EnumToString(), 0, 0, true, true, true, true, false);
            criterioSEQUENCIACHAVEAMENTO.CriarNo(true, enumCriterios.criterioChaveamento.EnumToString(), 0, 0, true, true, true, true, false);
            criterioSEGURANCA.CriarNo(true, enumCriterios.criterioSeguranca.EnumToString(), 0, 0, true, true, true, true, false);

            criterioHABILIDADE.CriarNo(true, enumCriterios.criterioHabilidade.EnumToString(), 1, 0, true, true, true, true, false);
            criterioCONHECIMENTO.CriarNo(true, enumCriterios.criterioConhecimento.EnumToString(), 1, 0, true, true, true, true, false);
            criterioATITUDE.CriarNo(true, enumCriterios.criterioAtitude.EnumToString(), 1, 0, true, true, true, true, false);
            criterioSTRESS.CriarNo(false, enumCriterios.criterioStress.EnumToString(), 0, 0, false, false, false, false, false);
            criterioCOMPETENCIA.CriarNo(true, enumCriterios.criterioCompetencia.EnumToString(), 0, 0, true, true, true, false, false);

            criterioDMChave.CriarNo(true, enumCriterios.criterioDMChave.EnumToString(), 1, 0, true, true, true, true, false);
            criterioDMTransformador.CriarNo(true, enumCriterios.criterioDMTransformador.EnumToString(), 1, 0, true, true, true, true, false);
            criterioDMReligador.CriarNo(true, enumCriterios.criterioDMReligador.EnumToString(), 1, 0, true, true, true, true, false);
            criterioDMDisjuntor.CriarNo(true, enumCriterios.criterioDMDisjuntor.EnumToString(), 1, 0, true, true, true, true, false);
            criterioDM.CriarNo(true, enumCriterios.criterioDM.EnumToString(), 0, 0, true, true, true, false, false);


            criterioExtra1.CriarNo(false, "Extra 1", 0, 0, true, true, true, true, false);
            criterioExtra2.CriarNo(false, "Extra 2", 0, 0, true, true, true, true, false);
            criterioExtra3.CriarNo(false, "Extra 3", 0, 0, true, true, true, true, false);
            criterioExtra4.CriarNo(false, "Extra 4", 0, 0, true, true, true, true, false);

            this.SetPesoNoPai();
        }

        /// <summary>
        /// Cria nós preenchidos automaticamente
        /// </summary>
        public void CriarFolhasAutomatico()
        {
            #region FOLHAS PAIS
            no01.CriarNo(true, "Qualidade do Produto", criterioMAGNITUDETENSAO.getPeso() + criterioVARIACAOLINHA.getPeso(), getDesvioQualidadeProduto(), true, true, false, false, true);
            no02.CriarNo(true, "Custos", criterioEUSD.getPeso() + criterioDMIC.getPeso(), getDesvioCusto(), true, true, false, false, true);
            no03.CriarNo(true, "Qualidade de Serviço", criterioDEC.getPeso() + criterioFEC.getPeso() + criterioCONSUMIDORES.getPeso() + criterioTEMPOFILA.getPeso() + criterioCONSUMIDORESPRIORITARIOS.getPeso(), getDesvioQualidadeServico(), true, true, false, false, true);
            no04.CriarNo(true, "Conformidade da Manobra", criterioSEQUENCIACHAVEAMENTO.getPeso() + criterioSEGURANCA.getPeso(), getDesvioConformidade(), true, true, false, false, true);
            //criterioSTRESS.SetColor(0, false);
            #endregion

            //LISTA DE PESOS GERADA AUTOMATICAMENTE
            int numeroCriterios = 13; 
            List<double> listaPesos = GeraListaPesos(numeroCriterios);

            //MAZ-10
            if (this.Contingencia == 4)
            {
                criterioMAGNITUDETENSAO.CriarNo(true, enumCriterios.criterioMagnitudeTensao.EnumToString(), listaPesos[7], 0, true, true, false, true, true);
                criterioVARIACAOLINHA.CriarNo(true, enumCriterios.criterioVariacaoLinha.EnumToString(), listaPesos[6], 0, true, true, false, true, true);
                criterioEUSD.CriarNo(true, enumCriterios.criterioEUSD.EnumToString(), listaPesos[11], 70.2, true, true, false, true, true);
                criterioDMIC.CriarNo(true, enumCriterios.criterioDMIC.EnumToString(), listaPesos[10], 70.5, true, true, false, true, true);
                criterioDEC.CriarNo(true, enumCriterios.criterioDEC.EnumToString(), listaPesos[5], 70.6, true, true, false, true, true);
                criterioFEC.CriarNo(true, enumCriterios.criterioFEC.EnumToString(), listaPesos[9], 0, true, true, false, true, true);
                criterioCONSUMIDORES.CriarNo(true, enumCriterios.criterioConsumidoes.EnumToString(), listaPesos[4], 0, true, true, false, true, true);
                criterioTEMPOFILA.CriarNo(true, enumCriterios.criterioTempoFila.EnumToString(), listaPesos[3], 0, true, true, false, true, true);
                criterioCONSUMIDORESPRIORITARIOS.CriarNo(true, enumCriterios.criterioConsumidoresPrioritario.EnumToString(), listaPesos[2], 28.8, true, true, false, true, true);
                criterioSEQUENCIACHAVEAMENTO.CriarNo(true, enumCriterios.criterioChaveamento.EnumToString(), listaPesos[8], 72.0, true, true, false, true, true);
                criterioSEGURANCA.CriarNo(true, enumCriterios.criterioSeguranca.EnumToString(), listaPesos[0], 0, true, true, false, true, true);

                criterioHABILIDADE.CriarNo(true, enumCriterios.criterioHabilidade.EnumToString(), 1, 50, true, true, true, true, true);
                criterioCONHECIMENTO.CriarNo(true, enumCriterios.criterioConhecimento.EnumToString(), 1, 30, true, true, true, true, true);
                criterioATITUDE.CriarNo(true, enumCriterios.criterioAtitude.EnumToString(), 1, 0, true, true, true, true, true);
                criterioSTRESS.CriarNo(false, enumCriterios.criterioStress.EnumToString(), 0, 0, false, false, false, false, true);
                criterioCOMPETENCIA.CriarNo(true, enumCriterios.criterioCompetencia.EnumToString(), listaPesos[1], getDesvioAspectosPessoais(), true, true, false, false, true);

                criterioDMChave.CriarNo(true, enumCriterios.criterioDMChave.EnumToString(), 1, 0, true, true, true, true, true);
                criterioDMDisjuntor.CriarNo(true, enumCriterios.criterioDMDisjuntor.EnumToString(), 1, 0, true, true, true, true, true);
                criterioDMReligador.CriarNo(true, enumCriterios.criterioDMReligador.EnumToString(), 1, 0, true, true, true, true, true);
                criterioDMTransformador.CriarNo(true, enumCriterios.criterioDMTransformador.EnumToString(), 1, 0, true, true, true, true, true);
                criterioDM.CriarNo(true, enumCriterios.criterioDM.EnumToString(), listaPesos[12], getDesvioDM(), true, true, false, false, true);

                criterioExtra1.CriarNo(false, "Extra 1", 0, 0, true, true, false, true, true);
                criterioExtra2.CriarNo(false, "Extra 2", 0, 0, true, true, false, true, true);
                criterioExtra3.CriarNo(false, "Extra 3", 0, 0, true, true, false, true, true);
                criterioExtra4.CriarNo(false, "Extra 4", 0, 0, true, true, false, true, true);
            }
            else
            {
                criterioMAGNITUDETENSAO.CriarNo(true, enumCriterios.criterioMagnitudeTensao.EnumToString(), listaPesos[7], 0, true, true, false, true, true);     
                criterioVARIACAOLINHA.CriarNo(true, enumCriterios.criterioVariacaoLinha.EnumToString(), listaPesos[6], 0, true, true, false, true, true);       
                criterioEUSD.CriarNo(true, enumCriterios.criterioEUSD.EnumToString(), listaPesos[11], -0.0082, true, true, false, true, true);
                criterioDMIC.CriarNo(true, enumCriterios.criterioDMIC.EnumToString(), listaPesos[10], 0, true, true, false, true, true);      
                criterioDEC.CriarNo(true, enumCriterios.criterioDEC.EnumToString(), listaPesos[5], 0.0615, true, true, false, true, true);  
                criterioFEC.CriarNo(true, enumCriterios.criterioFEC.EnumToString(), listaPesos[9], -0.4033, true, true, false, true, true);
                criterioCONSUMIDORES.CriarNo(true, enumCriterios.criterioConsumidoes.EnumToString(), listaPesos[4], -0.3837, true, true, false, true, true); 
                criterioTEMPOFILA.CriarNo(true, enumCriterios.criterioTempoFila.EnumToString(), listaPesos[3], 0.60, true, true, false, true, true);    
                criterioCONSUMIDORESPRIORITARIOS.CriarNo(true, enumCriterios.criterioConsumidoresPrioritario.EnumToString(), listaPesos[2], 0.3846, true, true, false, true, true);
                criterioSEQUENCIACHAVEAMENTO.CriarNo(true, enumCriterios.criterioChaveamento.EnumToString(), listaPesos[8], 0.25, true, true, false, true, true); 
                criterioSEGURANCA.CriarNo(true, enumCriterios.criterioSeguranca.EnumToString(), listaPesos[0], 0, true, true, false, true, true);       

                criterioHABILIDADE.CriarNo(true, enumCriterios.criterioHabilidade.EnumToString(), 1, 0, true, true, true, true, true);                   
                criterioCONHECIMENTO.CriarNo(true, enumCriterios.criterioConhecimento.EnumToString(), 1, 0, true, true, true, true, true);                 
                criterioATITUDE.CriarNo(true, enumCriterios.criterioAtitude.EnumToString(), 1, 0, true, true, true, true, true);                   
                criterioSTRESS.CriarNo(false, enumCriterios.criterioStress.EnumToString(), 0, 0, false, false, false, false, true);               
                criterioCOMPETENCIA.CriarNo(true, enumCriterios.criterioCompetencia.EnumToString(), listaPesos[1], getDesvioAspectosPessoais(), true, true, false, false, true);

                criterioDMChave.CriarNo(true, enumCriterios.criterioDMChave.EnumToString(), 1, 0, true, true, true, true, true);
                criterioDMDisjuntor.CriarNo(true, enumCriterios.criterioDMDisjuntor.EnumToString(), 1, 0, true, true, true, true, true);
                criterioDMReligador.CriarNo(true, enumCriterios.criterioDMReligador.EnumToString(), 1, 0, true, true, true, true, true);
                criterioDMTransformador.CriarNo(true, enumCriterios.criterioDMTransformador.EnumToString(), 1, 0, true, true, true, true, true);
                criterioDM.CriarNo(true, enumCriterios.criterioDM.EnumToString(), listaPesos[12], getDesvioDM(), true, true, false, false, true);

                criterioExtra1.CriarNo(false, "Extra 1", 0, 0, true, true, false, true, true);
                criterioExtra2.CriarNo(false, "Extra 2", 0, 0, true, true, false, true, true);
                criterioExtra3.CriarNo(false, "Extra 3", 0, 0, true, true, false, true, true);
                criterioExtra4.CriarNo(false, "Extra 4", 0, 0, true, true, false, true, true);
            }

            
            this.SetPesoNoPai();
        }

        internal List<Criterio> GetListCriterios()
        {
            List<Criterio> lista = new List<Criterio>();

            lista.Add(new Criterio(enumCriterios.criterioMagnitudeTensao, criterioMAGNITUDETENSAO.getPeso(), criterioMAGNITUDETENSAO.getDesvio(), criterioMAGNITUDETENSAO.getAtivo()));
            lista.Add(new Criterio(enumCriterios.criterioVariacaoLinha, criterioVARIACAOLINHA.getPeso(), criterioVARIACAOLINHA.getDesvio(), criterioVARIACAOLINHA.getAtivo()));
            lista.Add(new Criterio(enumCriterios.criterioCompetencia, criterioCOMPETENCIA.getPeso(), criterioCOMPETENCIA.getDesvio(), criterioCOMPETENCIA.getAtivo()));
            lista.Add(new Criterio(enumCriterios.criterioEUSD, criterioEUSD.getPeso(), criterioEUSD.getDesvio(), criterioEUSD.getAtivo()));
            lista.Add(new Criterio(enumCriterios.criterioDMIC, criterioDMIC.getPeso(), criterioDMIC.getDesvio(), criterioDMIC.getAtivo()));
            lista.Add(new Criterio(enumCriterios.criterioDEC, criterioDEC.getPeso(), criterioDEC.getDesvio(), criterioDEC.getAtivo()));
            lista.Add(new Criterio(enumCriterios.criterioFEC, criterioFEC.getPeso(), criterioFEC.getDesvio(), criterioFEC.getAtivo()));
            lista.Add(new Criterio(enumCriterios.criterioConsumidoes, criterioCONSUMIDORES.getPeso(), criterioCONSUMIDORES.getDesvio(), criterioCONSUMIDORES.getAtivo()));
            lista.Add(new Criterio(enumCriterios.criterioTempoFila, criterioTEMPOFILA.getPeso(), criterioTEMPOFILA.getDesvio(), criterioTEMPOFILA.getAtivo()));
            lista.Add(new Criterio(enumCriterios.criterioConsumidoresPrioritario, criterioCONSUMIDORESPRIORITARIOS.getPeso(), criterioCONSUMIDORESPRIORITARIOS.getDesvio(), criterioCONSUMIDORESPRIORITARIOS.getAtivo()));
            lista.Add(new Criterio(enumCriterios.criterioChaveamento, criterioSEQUENCIACHAVEAMENTO.getPeso(), criterioSEQUENCIACHAVEAMENTO.getDesvio(), criterioSEQUENCIACHAVEAMENTO.getAtivo()));
            lista.Add(new Criterio(enumCriterios.criterioSeguranca, criterioSEGURANCA.getPeso(), criterioSEGURANCA.getDesvio(), criterioSEGURANCA.getAtivo()));
            lista.Add(new Criterio(enumCriterios.criterioHabilidade, criterioHABILIDADE.getPeso(), criterioHABILIDADE.getDesvio(), criterioHABILIDADE.getAtivo()));
            lista.Add(new Criterio(enumCriterios.criterioConhecimento, criterioCONHECIMENTO.getPeso(), criterioCONHECIMENTO.getDesvio(), criterioCONHECIMENTO.getAtivo()));
            lista.Add(new Criterio(enumCriterios.criterioAtitude, criterioATITUDE.getPeso(), criterioATITUDE.getDesvio(), criterioATITUDE.getAtivo()));

            lista.Add(new Criterio(enumCriterios.criterioDMChave, criterioDMChave.getPeso(), criterioDMChave.getDesvio(), criterioDMChave.getAtivo()));
            lista.Add(new Criterio(enumCriterios.criterioDMDisjuntor, criterioDMDisjuntor.getPeso(), criterioDMDisjuntor.getDesvio(), criterioDMDisjuntor.getAtivo()));
            lista.Add(new Criterio(enumCriterios.criterioDMReligador, criterioDMReligador.getPeso(), criterioDMReligador.getDesvio(), criterioDMReligador.getAtivo()));
            lista.Add(new Criterio(enumCriterios.criterioDMTransformador, criterioDMTransformador.getPeso(), criterioDMTransformador.getDesvio(), criterioDMTransformador.getAtivo()));
            lista.Add(new Criterio(enumCriterios.criterioDM, criterioDM.getPeso(), criterioDM.getDesvio(), criterioDM.getAtivo()));

            lista.Add(new Criterio(enumCriterios.criterioExtra1, criterioExtra1.getPeso(), criterioExtra1.getDesvio(), criterioExtra1.getAtivo()));
            lista.Add(new Criterio(enumCriterios.criterioExtra2, criterioExtra2.getPeso(), criterioExtra2.getDesvio(), criterioExtra2.getAtivo()));
            lista.Add(new Criterio(enumCriterios.criterioExtra3, criterioExtra3.getPeso(), criterioExtra3.getDesvio(), criterioExtra3.getAtivo()));
            lista.Add(new Criterio(enumCriterios.criterioExtra4, criterioExtra4.getPeso(), criterioExtra4.getDesvio(), criterioExtra4.getAtivo()));

            return lista;
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
            foreach (Criterio c in lista.Where(o => o.Ativo == true).OrderByDescending(a=>a.Peso))
            {
                double cc = c.Peso;
                string ss = c.Descricao;
                Console.WriteLine(ss +" " + cc);

                if (this.automatico)
                {
                    c.Peso = l[i];
                }

                i++;
            }
            
            foreach (Criterio c in lista)
            {
                switch (c.Id) {
                    case (int)enumCriterios.criterioMagnitudeTensao:
                        criterioMAGNITUDETENSAO.SetPeso(c.Peso, c.Desvio);
                        criterioMAGNITUDETENSAO.SetColor(c.Desvio, c.Ativo);
                        break;
                    case (int)enumCriterios.criterioVariacaoLinha:
                        criterioVARIACAOLINHA.SetPeso(c.Peso, c.Desvio);
                        criterioVARIACAOLINHA.SetColor(c.Desvio, c.Ativo);
                        break;
                    case (int)enumCriterios.criterioCompetencia:
                        criterioCOMPETENCIA.SetPeso(c.Peso, c.Desvio);
                        criterioCOMPETENCIA.SetColor(c.Desvio, c.Ativo);

                        //se o peso e o desvio for zero, é porque desabilitou, o pai. Então deve desabilitar os filhos tbm
                        if (c.Peso == 0 & c.Desvio == 0)
                        {
                            criterioHABILIDADE.SetPeso(c.Peso, c.Desvio);
                            criterioHABILIDADE.SetColor(c.Desvio, c.Ativo);

                            criterioCONHECIMENTO.SetPeso(c.Peso, c.Desvio);
                            criterioCONHECIMENTO.SetColor(c.Desvio, c.Ativo);

                            criterioATITUDE.SetPeso(c.Peso, c.Desvio);
                            criterioATITUDE.SetColor(c.Desvio, c.Ativo);
                        }
                        else
                        {

                            if (criterioHABILIDADE.getAtivo())
                            {
                                criterioHABILIDADE.SetColor(criterioHABILIDADE.getDesvio(), c.Ativo);
                            }
                            else
                            {
                                criterioHABILIDADE.SetPeso(0, 0);
                                criterioHABILIDADE.SetColor(0, c.Ativo);
                            }
                            if (criterioCONHECIMENTO.getAtivo())
                            {
                                criterioCONHECIMENTO.SetColor(criterioCONHECIMENTO.getDesvio(), c.Ativo);
                            }
                            else
                            {
                                criterioCONHECIMENTO.SetPeso(0, 0);
                                criterioCONHECIMENTO.SetColor(0, c.Ativo);
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
                        break;    
                    case (int)enumCriterios.criterioEUSD:
                        criterioEUSD.SetPeso(c.Peso, c.Desvio);
                        criterioEUSD.SetColor(c.Desvio, c.Ativo);
                        break;
                    case (int)enumCriterios.criterioDMIC:
                        criterioDMIC.SetPeso(c.Peso, c.Desvio);
                        criterioDMIC.SetColor(c.Desvio, c.Ativo);
                        break;
                    case (int)enumCriterios.criterioDEC:
                        criterioDEC.SetPeso(c.Peso, c.Desvio);
                        criterioDEC.SetColor(c.Desvio, c.Ativo);
                        break;
                    case (int)enumCriterios.criterioFEC:
                        criterioFEC.SetPeso(c.Peso, c.Desvio);
                        criterioFEC.SetColor(c.Desvio, c.Ativo);
                        break;
                    case (int)enumCriterios.criterioConsumidoes:
                        criterioCONSUMIDORES.SetPeso(c.Peso, c.Desvio);
                        criterioCONSUMIDORES.SetColor(c.Desvio, c.Ativo);
                        break;
                    case (int)enumCriterios.criterioTempoFila:
                        criterioTEMPOFILA.SetPeso(c.Peso, c.Desvio);
                        criterioTEMPOFILA.SetColor(c.Desvio, c.Ativo);
                        break;
                    case (int)enumCriterios.criterioConsumidoresPrioritario:
                        criterioCONSUMIDORESPRIORITARIOS.SetPeso(c.Peso, c.Desvio);
                        criterioCONSUMIDORESPRIORITARIOS.SetColor(c.Desvio, c.Ativo);
                        break;
                    case (int)enumCriterios.criterioChaveamento:
                        criterioSEQUENCIACHAVEAMENTO.SetPeso(c.Peso, c.Desvio);
                        criterioSEQUENCIACHAVEAMENTO.SetColor(c.Desvio, c.Ativo);
                        break;
                    case (int)enumCriterios.criterioSeguranca:
                        criterioSEGURANCA.SetPeso(c.Peso, c.Desvio);
                        criterioSEGURANCA.SetColor(c.Desvio, c.Ativo);
                        break;
                    case (int)enumCriterios.criterioDM:
                        criterioDM.SetPeso(c.Peso, c.Desvio);
                        criterioDM.SetColor(c.Desvio, c.Ativo);

                        //se o peso e o desvio for zero, é porque desabilitou, o pai. Então deve desabilitar os filhos tbm
                        if (c.Peso == 0 & c.Desvio == 0)
                        {
                            criterioDMChave.SetPeso(c.Peso, c.Desvio);
                            criterioDMChave.SetColor(c.Desvio, c.Ativo);
                            criterioDMDisjuntor.SetPeso(c.Peso, c.Desvio);
                            criterioDMDisjuntor.SetColor(c.Desvio, c.Ativo);
                            criterioDMReligador.SetPeso(c.Peso, c.Desvio);
                            criterioDMReligador.SetColor(c.Desvio, c.Ativo);
                            criterioDMTransformador.SetPeso(c.Peso, c.Desvio);
                            criterioDMTransformador.SetColor(c.Desvio, c.Ativo);
                        }
                        else
                        {

                            if (criterioDMChave.getAtivo())
                            {
                                criterioDMChave.SetColor(criterioDMChave.getDesvio(), c.Ativo);
                            }
                            else
                            {
                                criterioDMChave.SetPeso(0, 0);
                                criterioDMChave.SetColor(0, c.Ativo);
                            }
                            if (criterioDMDisjuntor.getAtivo())
                            {
                                criterioDMDisjuntor.SetColor(criterioDMDisjuntor.getDesvio(), c.Ativo);
                            }
                            else
                            {
                                criterioDMDisjuntor.SetPeso(0, 0);
                                criterioDMDisjuntor.SetColor(0, c.Ativo);
                            }
                            if (criterioDMReligador.getAtivo())
                            {
                                criterioDMReligador.SetColor(criterioDMReligador.getDesvio(), c.Ativo);
                            }
                            else
                            {
                                criterioDMReligador.SetPeso(0, 0);
                                criterioDMReligador.SetColor(0, c.Ativo);
                            }
                            if (criterioDMTransformador.getAtivo())
                            {
                                criterioDMTransformador.SetColor(criterioDMTransformador.getDesvio(), c.Ativo);
                            }
                            else
                            {
                                criterioDMTransformador.SetPeso(0, 0);
                                criterioDMTransformador.SetColor(0, c.Ativo);
                            }
                        }
                        break;
                    case (int)enumCriterios.criterioExtra1:
                        criterioExtra1.SetPeso(c.Peso, c.Desvio);
                        criterioExtra1.SetColor(c.Desvio, c.Ativo);
                        break;
                    case (int)enumCriterios.criterioExtra2:
                        criterioExtra2.SetPeso(c.Peso, c.Desvio);
                        criterioExtra2.SetColor(c.Desvio, c.Ativo);
                        break;
                    case (int)enumCriterios.criterioExtra3:
                        criterioExtra3.SetPeso(c.Peso, c.Desvio);
                        criterioExtra3.SetColor(c.Desvio, c.Ativo);
                        break;
                    case (int)enumCriterios.criterioExtra4:
                        criterioExtra4.SetPeso(c.Peso, c.Desvio);
                        criterioExtra4.SetColor(c.Desvio, c.Ativo);
                        break;
                }
            }

            this.SetPesoNoPai();
        }

        internal void SetFolhaExtra(ucFolhaExtra ucFolhaExtra)
        {
            throw new NotImplementedException();
        }

        internal void SetCalculo(FormArvoreCriterios formArvoreCriterios, bool c)
        {
            this.fa = formArvoreCriterios;
            //this.calculo = c;
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
                    criterioMAGNITUDETENSAO.getDesvio() * criterioMAGNITUDETENSAO.getPeso() +
                    criterioVARIACAOLINHA.getDesvio() * criterioVARIACAOLINHA.getPeso() +
                    criterioExtra1.getDesvio() * criterioExtra1.getPeso()) /
                    (criterioMAGNITUDETENSAO.getPeso() + criterioVARIACAOLINHA.getPeso() + criterioExtra1.getPeso());
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
                    criterioEUSD.getDesvio() * criterioEUSD.getPeso() +
                    criterioDMIC.getDesvio() * criterioDMIC.getPeso() +
                    criterioExtra2.getDesvio() * criterioExtra2.getPeso()) /
                    (criterioEUSD.getPeso() + criterioDMIC.getPeso() + criterioExtra2.getPeso());
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
                    criterioDEC.getDesvio() * criterioDEC.getPeso() +
                    criterioFEC.getDesvio() * criterioFEC.getPeso() +
                    criterioCONSUMIDORES.getDesvio() * criterioCONSUMIDORES.getPeso() +
                    criterioTEMPOFILA.getDesvio() * criterioTEMPOFILA.getPeso() +
                    criterioCONSUMIDORESPRIORITARIOS.getDesvio() * criterioCONSUMIDORESPRIORITARIOS.getPeso() +
                    criterioExtra3.getDesvio() * criterioExtra3.getPeso()) /
                    (criterioDEC.getPeso() + criterioFEC.getPeso() + criterioCONSUMIDORES.getPeso() + criterioTEMPOFILA.getPeso() + criterioCONSUMIDORESPRIORITARIOS.getPeso() + criterioExtra3.getPeso());
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
                    criterioSEQUENCIACHAVEAMENTO.getDesvio() * criterioSEQUENCIACHAVEAMENTO.getPeso() +
                    criterioSEGURANCA.getDesvio() * criterioSEGURANCA.getPeso() +
                    criterioExtra4.getDesvio() * criterioExtra4.getPeso()) / +
                    (criterioSEQUENCIACHAVEAMENTO.getPeso() + criterioSEGURANCA.getPeso() + criterioExtra4.getPeso());
            }
            catch
            {
                return 0;
            }
        }

        public double getDesvioAspectosPessoais()
        {
            try
            {
                return (
                    criterioHABILIDADE.getDesvio() * criterioHABILIDADE.getPeso() +
                    criterioCONHECIMENTO.getDesvio() * criterioCONHECIMENTO.getPeso() +
                    criterioATITUDE.getDesvio() * criterioATITUDE.getPeso()) /
                    (criterioHABILIDADE.getPeso() + criterioCONHECIMENTO.getPeso() + criterioATITUDE.getPeso());
            }
            catch
            {
                return 0;
            }
        }

        public double getDesvioDM()
        {
            try
            {
                return (
                    criterioDMChave.getDesvio() * criterioDMChave.getPeso() +
                    criterioDMDisjuntor.getDesvio() * criterioDMDisjuntor.getPeso() +
                    criterioDMReligador.getDesvio() * criterioDMReligador.getPeso() +
                    criterioDMTransformador.getDesvio() * criterioDMTransformador.getPeso()) /
                    (criterioDMChave.getPeso() + criterioDMDisjuntor.getPeso() + criterioDMReligador.getPeso() + criterioDMTransformador.getPeso());
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
                    criterioMAGNITUDETENSAO.getPeso() * criterioMAGNITUDETENSAO.getDesvio() +
                    criterioVARIACAOLINHA.getPeso() * criterioVARIACAOLINHA.getDesvio() +
                    criterioCOMPETENCIA.getPeso() * criterioCOMPETENCIA.getDesvio() +
                    criterioEUSD.getPeso() * criterioEUSD.getDesvio() +
                    criterioDMIC.getPeso() * criterioDMIC.getDesvio() +
                    criterioDEC.getPeso() * criterioDEC.getDesvio() +
                    criterioFEC.getPeso() * criterioFEC.getDesvio() +
                    criterioCONSUMIDORES.getPeso() * criterioCONSUMIDORES.getDesvio() +
                    criterioTEMPOFILA.getPeso() * criterioTEMPOFILA.getDesvio() +
                    criterioCONSUMIDORESPRIORITARIOS.getPeso() * criterioCONSUMIDORESPRIORITARIOS.getDesvio() +
                    criterioSEQUENCIACHAVEAMENTO.getPeso() * criterioSEQUENCIACHAVEAMENTO.getDesvio() +
                    criterioSEGURANCA.getPeso() * criterioSEGURANCA.getDesvio() +
                    criterioDM.getPeso() * criterioDM.getDesvio() +
                    criterioExtra1.getPeso() * criterioExtra1.getDesvio() +
                    criterioExtra2.getPeso() * criterioExtra2.getDesvio() +
                    criterioExtra3.getPeso() * criterioExtra3.getDesvio() +
                    criterioExtra4.getPeso() * criterioExtra4.getDesvio()
                    ) / GetSomaPesos());
            }
            else
            {
                //ARVORE MANUAL - Converter pesos (0 a 10) para porcentagem
                double somaPeso = GetSomaPesos();

                double cMAGNITUDETENSAO = 100 * (criterioMAGNITUDETENSAO.getPeso() / somaPeso);
                double cVARIACAOLINHA = 100 * (criterioVARIACAOLINHA.getPeso() / somaPeso);
                double cCOMPETENCIA = 100 * (criterioCOMPETENCIA.getPeso() / somaPeso);
                double cEUSD = 100 * (criterioEUSD.getPeso() / somaPeso);
                double cDMIC = 100 * (criterioDMIC.getPeso() / somaPeso);
                double cDEC = 100 * (criterioDEC.getPeso() / somaPeso);
                double cFEC = 100 * (criterioFEC.getPeso() / somaPeso);
                double cNUMEROCONSUMIDORES = 100 * (criterioCONSUMIDORES.getPeso() / somaPeso);
                double cTEMPOFILA = 100 * (criterioTEMPOFILA.getPeso() / somaPeso);
                double cCONSUMIDORESPRIORITARIOS = 100 * (criterioCONSUMIDORESPRIORITARIOS.getPeso() / somaPeso);
                double cSEQUENCIACHAVEAMENTO = 100 * (criterioSEQUENCIACHAVEAMENTO.getPeso() / somaPeso);
                double cSEGURANCA = 100 * (criterioSEGURANCA.getPeso() / somaPeso);
                double cDM = 100 * (criterioDM.getPeso() / somaPeso);
                double cExtra01 = 100 * (criterioExtra1.getPeso() / somaPeso);
                double cExtra02 = 100 * (criterioExtra2.getPeso() / somaPeso);
                double cExtra03 = 100 * (criterioExtra3.getPeso() / somaPeso);
                double cExtra04 = 100 * (criterioExtra4.getPeso() / somaPeso);

                    avaliacao = 100 - ((
                    cMAGNITUDETENSAO * criterioMAGNITUDETENSAO.getDesvio() +
                    cVARIACAOLINHA * criterioVARIACAOLINHA.getDesvio() +
                    cCOMPETENCIA * criterioCOMPETENCIA.getDesvio() +
                    cEUSD * criterioEUSD.getDesvio() +
                    cDMIC * criterioDMIC.getDesvio() +
                    cDEC * criterioDEC.getDesvio() +
                    cFEC * criterioFEC.getDesvio() +
                    cNUMEROCONSUMIDORES * criterioCONSUMIDORES.getDesvio() +
                    cTEMPOFILA * criterioTEMPOFILA.getDesvio() +
                    cCONSUMIDORESPRIORITARIOS * criterioCONSUMIDORESPRIORITARIOS.getDesvio() +
                    cSEQUENCIACHAVEAMENTO * criterioSEQUENCIACHAVEAMENTO.getDesvio() +
                    cSEGURANCA * criterioSEGURANCA.getDesvio() +
                    cDM * criterioDM.getDesvio() +
                    cExtra01 * criterioExtra1.getDesvio() +
                    cExtra02 * criterioExtra2.getDesvio() +
                    cExtra03 * criterioExtra3.getDesvio() +
                    cExtra04 * criterioExtra4.getDesvio()
                    ) / (100) );

            }

            if (Double.IsNaN(avaliacao))
                avaliacao = 0;

            return avaliacao;
        }

        public double GetSomaPesos()
        {
            double p =
                criterioMAGNITUDETENSAO.getPeso() +
                criterioVARIACAOLINHA.getPeso() +
                criterioCOMPETENCIA.getPeso() +
                criterioEUSD.getPeso() +
                criterioDMIC.getPeso() +
                criterioDEC.getPeso() +
                criterioFEC.getPeso() +
                criterioCONSUMIDORES.getPeso() +
                criterioTEMPOFILA.getPeso() +
                criterioCONSUMIDORESPRIORITARIOS.getPeso() +
                criterioSEQUENCIACHAVEAMENTO.getPeso() +
                criterioSEGURANCA.getPeso() +
                criterioDM.getPeso() +
                criterioExtra1.getPeso() +
                criterioExtra2.getPeso() +
                criterioExtra3.getPeso() +
                criterioExtra4.getPeso();
            return p;
        }

        public void SetPesoNoPai()
        {
            no01.AtualizarNo(criterioMAGNITUDETENSAO.getPeso() + criterioVARIACAOLINHA.getPeso() + criterioExtra1.getPeso(), getDesvioQualidadeProduto(), (criterioMAGNITUDETENSAO.getAtivo() || criterioVARIACAOLINHA.getAtivo() || criterioExtra1.getAtivo()));
            no02.AtualizarNo(criterioEUSD.getPeso() + criterioDMIC.getPeso() + criterioExtra2.getPeso(), getDesvioCusto(), (criterioEUSD.getAtivo() || criterioDMIC.getAtivo() || criterioExtra2.getAtivo()));
            no03.AtualizarNo(criterioDEC.getPeso() + criterioFEC.getPeso() + criterioCONSUMIDORES.getPeso() + criterioTEMPOFILA.getPeso() + criterioCONSUMIDORESPRIORITARIOS.getPeso() + criterioExtra3.getPeso(), getDesvioQualidadeServico(), (criterioDEC.getAtivo() || criterioFEC.getAtivo() || criterioCONSUMIDORES.getAtivo() || criterioTEMPOFILA.getAtivo() || criterioCONSUMIDORESPRIORITARIOS.getAtivo() || criterioExtra3.getAtivo()));
            no04.AtualizarNo(criterioSEQUENCIACHAVEAMENTO.getPeso() + criterioSEGURANCA.getPeso() + criterioExtra4.getPeso(), getDesvioConformidade(), (criterioSEQUENCIACHAVEAMENTO.getAtivo() || criterioSEGURANCA.getAtivo() || criterioExtra4.getAtivo()));
            
            criterioCOMPETENCIA.AtualizarNo(criterioCOMPETENCIA.getPeso(), getDesvioAspectosPessoais(), criterioHABILIDADE.getAtivo() || criterioCONHECIMENTO.getAtivo() || criterioATITUDE.getAtivo());

            criterioDM.AtualizarNo(criterioDM.getPeso(), getDesvioDM(), criterioDMChave.getAtivo() || criterioDMDisjuntor.getAtivo() || criterioDMReligador.getAtivo() || criterioDMTransformador.getAtivo());

        }

        public static string getDescricaoCriteriosById(int id)
        {
            switch (id)
            {
                case (int)enumCriterios.criterioMagnitudeTensao:
                    return enumCriterios.criterioMagnitudeTensao.EnumToString();
                case (int)enumCriterios.criterioVariacaoLinha:
                    return enumCriterios.criterioVariacaoLinha.EnumToString();
                case (int)enumCriterios.criterioCompetencia:
                    return enumCriterios.criterioCompetencia.EnumToString();
                case (int)enumCriterios.criterioEUSD:
                    return enumCriterios.criterioEUSD.EnumToString();
                case (int)enumCriterios.criterioDMIC:
                    return enumCriterios.criterioDMIC.EnumToString();
                case (int)enumCriterios.criterioDEC:
                    return enumCriterios.criterioDEC.EnumToString();
                case (int)enumCriterios.criterioFEC:
                    return enumCriterios.criterioFEC.EnumToString();
                case (int)enumCriterios.criterioConsumidoes:
                    return enumCriterios.criterioConsumidoes.EnumToString();
                case (int)enumCriterios.criterioTempoFila:
                    return enumCriterios.criterioTempoFila.EnumToString();
                case (int)enumCriterios.criterioConsumidoresPrioritario:
                    return enumCriterios.criterioConsumidoresPrioritario.EnumToString();
                case (int)enumCriterios.criterioChaveamento:
                    return enumCriterios.criterioChaveamento.EnumToString();
                case (int)enumCriterios.criterioSeguranca:
                    return enumCriterios.criterioSeguranca.EnumToString();
                case (int)enumCriterios.criterioHabilidade:
                    return enumCriterios.criterioHabilidade.EnumToString();
                case (int)enumCriterios.criterioConhecimento:
                    return enumCriterios.criterioConhecimento.EnumToString();
                case (int)enumCriterios.criterioAtitude:
                    return enumCriterios.criterioAtitude.EnumToString();
                case (int)enumCriterios.criterioStress:
                    return enumCriterios.criterioStress.EnumToString();
                case (int)enumCriterios.criterioDM:
                    return enumCriterios.criterioDM.EnumToString();
                case (int)enumCriterios.criterioDMChave:
                    return enumCriterios.criterioDMChave.EnumToString();
                case (int)enumCriterios.criterioDMDisjuntor:
                    return enumCriterios.criterioDMDisjuntor.EnumToString();
                case (int)enumCriterios.criterioDMReligador:
                    return enumCriterios.criterioDMReligador.EnumToString();
                case (int)enumCriterios.criterioDMTransformador:
                    return enumCriterios.criterioDMTransformador.EnumToString();
                case (int)enumCriterios.criterioExtra1:
                    return enumCriterios.criterioExtra1.EnumToString();
                case (int)enumCriterios.criterioExtra2:
                    return enumCriterios.criterioExtra2.EnumToString();
                case (int)enumCriterios.criterioExtra3:
                    return enumCriterios.criterioExtra3.EnumToString();
                case (int)enumCriterios.criterioExtra4:
                    return enumCriterios.criterioExtra4.EnumToString();
                default:
                    return "";
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            criterioExtra1.Habilitar(!criterioExtra1.getAtivo());

            string src;
            if (criterioExtra1.getAtivo())
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
                criterioExtra1.SetPeso(0, 0);
            }
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            criterioExtra2.Habilitar(!criterioExtra2.getAtivo());

            string src;
            if (criterioExtra2.getAtivo())
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
                criterioExtra2.SetPeso(0, 0);
            }
        }

        private void button_Copy2_Click(object sender, RoutedEventArgs e)
        {
            criterioExtra3.Habilitar(!criterioExtra3.getAtivo());

            string src;
            if (criterioExtra3.getAtivo())
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
                criterioExtra3.SetPeso(0, 0);
            }
        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {
            criterioExtra4.Habilitar(!criterioExtra4.getAtivo());

            string src;
            if (criterioExtra4.getAtivo())
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
                criterioExtra4.SetPeso(0, 0);
            }
        }

        private void no02_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FormAvaliarCriterioCompetenciaProfissional f = new FormAvaliarCriterioCompetenciaProfissional(criterioCOMPETENCIA.getPeso(), criterioCONHECIMENTO.getPeso(), criterioHABILIDADE.getPeso(), criterioATITUDE.getPeso(), this.Aspecto, this);
            f.Show();
        }

        private void criterio01_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FormAvaliarCriterioMagnitudeTensao f = new FormAvaliarCriterioMagnitudeTensao(criterioMAGNITUDETENSAO.getPeso(), this);
            f.Show();
        }

        private void criterio02_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FormAvaliarCriterioVariacaoCarregamento f = new FormAvaliarCriterioVariacaoCarregamento(criterioVARIACAOLINHA.getPeso(), this);
            f.Show();
        }

        private void criterio09_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FormAvaliarCriterioTempoFila f = new FormAvaliarCriterioTempoFila(criterioTEMPOFILA.getPeso(), this);
            f.Show();

        }

        
        private void criterio12_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FormAvaliarCriterioSequenciaChaveamento f = new FormAvaliarCriterioSequenciaChaveamento(criterioSEQUENCIACHAVEAMENTO.getPeso(), this);
            f.Show();
        }

        private void criterio13_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FormAvaliarCriterioSegurancaRede f = new FormAvaliarCriterioSegurancaRede(criterioSEGURANCA.getPeso(), this);
            f.Show();
        }
    }
}
