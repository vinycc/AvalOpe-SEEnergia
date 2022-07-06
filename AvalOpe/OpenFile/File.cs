using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel;


/*

        0 - Comum,
        1 - NF,
        2 - FU,
        3 - NA
        */

namespace OpenFile
{
   
    public class File
    {
        public static Grafo g = new Grafo();
        static List<Aresta> ListaDeChavesJusante = new List<Aresta>();
        public static int idTeste;
        public static int idFalha = 1;

        public Grafo Open(int caso)
        {
            string stringRetorno = "";
            string caminhoArquivoRede = "";
            string caminhoArquivoNo = "";

            if (caso == 1)
            {
                caminhoArquivoRede = @"Caso01\Linha.xlsx";
                caminhoArquivoNo = @"Caso01\No.xlsx";
            }
            else if (caso == 2)
            {
                caminhoArquivoRede = @"Caso02\Linha.xlsx";
                caminhoArquivoNo = @"Caso02\No.xlsx";
            }
            else if (caso == 3)
            {
                caminhoArquivoRede = @"Caso03\Linha.xlsx";
                caminhoArquivoNo = @"Caso03\No.xlsx";
            }



            //string caminhoArquivoRede = @"Caso01\Linha.xlsx";
            //string caminhoArquivoNo = @"Caso01\No.xlsx";

            //Instanciar Objetos
            Grafo rede = new Grafo();
            rede.edges = new List<Aresta>();
            rede.vertices = new List<Vertice>();


            #region CRIAR LISTA DE NÓS
            if (System.IO.File.Exists(caminhoArquivoNo))
            {
                foreach (var worksheet in Workbook.Worksheets(caminhoArquivoNo))
                {
                    foreach (var row in worksheet.Rows)
                    {
                        // CRIAR No
                        Vertice no = new Vertice();
                        
                        if (row.Cells[(int)enumNo.id] != null)
                            if (row.Cells[(int)enumNo.id].IsAmount)
                                no.Id = Convert.ToInt32(row.Cells[(int)enumNo.id].Amount);
                            else
                                no.Id = -1;

                        if (row.Cells[(int)enumNo.nome] != null)
                            if (!row.Cells[(int)enumNo.nome].IsAmount)
                                no.Nome = row.Cells[(int)enumNo.nome].Text;

                        if (row.Cells[(int)enumNo.alimentador] != null)
                            if (row.Cells[(int)enumNo.alimentador].IsAmount)
                                no.Alimentador = Convert.ToInt32(row.Cells[(int)enumNo.alimentador].Amount);

                        if (row.Cells[(int)enumNo.carga] != null)
                            if (row.Cells[(int)enumNo.carga].IsAmount)
                                no.Carga = row.Cells[(int)enumNo.carga].Amount;

                        if (row.Cells[(int)enumNo.numeroDeConsumidores] != null)
                            if (row.Cells[(int)enumNo.numeroDeConsumidores].IsAmount)
                                no.NumeroDeConsumidores = Convert.ToInt32(row.Cells[(int)enumNo.numeroDeConsumidores].Amount);

                        if (row.Cells[(int)enumNo.tempoDeReparo] != null)
                            if (row.Cells[(int)enumNo.tempoDeReparo].IsAmount)
                                no.TempoDeReparo = row.Cells[(int)enumNo.tempoDeReparo].Amount;

                        if (row.Cells[(int)enumNo.taxaDeFalha] != null)
                            if (row.Cells[(int)enumNo.taxaDeFalha].IsAmount)
                                no.TaxaDeFalha = row.Cells[(int)enumNo.taxaDeFalha].Amount;

                        if (no.Id >= 0)
                            rede.vertices.Add(no);
                    }
                }
            }
            else
            {
                throw new Exception("Erro ao abrir arquivo de Nós");
            }
            #endregion

            #region CRIAR LISTA DE LINHAS
            if (System.IO.File.Exists(caminhoArquivoRede))
            {
                foreach (var worksheet in Workbook.Worksheets(caminhoArquivoRede))
                {
                    int idLinha = -1;
                    foreach (var row in worksheet.Rows)
                    {
                        // CRIAR LINHA
                        Aresta linha = new Aresta();

                        if (row.Cells[(int)enumLinha.origem] != null)
                            if (row.Cells[(int)enumLinha.origem].IsAmount)
                                linha.Origem = rede.vertices.Where(p => p.Id == Convert.ToInt32(row.Cells[(int)enumLinha.origem].Amount)).First();

                        if (row.Cells[(int)enumLinha.destino] != null)
                            if (row.Cells[(int)enumLinha.destino].IsAmount)
                                linha.Destino = rede.vertices.Where(p => p.Id == Convert.ToInt32(row.Cells[(int)enumLinha.destino].Amount)).First();

                        if (row.Cells[(int)enumLinha.resistencia] != null)
                            if (row.Cells[(int)enumLinha.resistencia].IsAmount)
                                linha.Resistencia = row.Cells[(int)enumLinha.resistencia].Amount;

                        if (row.Cells[(int)enumLinha.reatancia] != null)
                            if (row.Cells[(int)enumLinha.reatancia].IsAmount)
                                linha.Reatancia = row.Cells[(int)enumLinha.reatancia].Amount;

                        if (row.Cells[(int)enumLinha.tipo] != null)
                            if (row.Cells[(int)enumLinha.tipo].IsAmount)
                                linha.Tipo = Convert.ToInt32(row.Cells[(int)enumLinha.tipo].Amount);

                        if (row.Cells[(int)enumLinha.L] != null)
                            if (row.Cells[(int)enumLinha.L].IsAmount)
                                linha.L = row.Cells[(int)enumLinha.L].Amount;

                        if (row.Cells[(int)enumLinha.P] != null)
                            if (row.Cells[(int)enumLinha.P].IsAmount)
                                linha.P = row.Cells[(int)enumLinha.P].Amount;

                        if (row.Cells[(int)enumLinha.Q] != null)
                            if (row.Cells[(int)enumLinha.Q].IsAmount)
                                linha.Q = row.Cells[(int)enumLinha.Q].Amount;

                        linha.EdgeOposto = false;
                        linha.idAresta = idLinha;
                        
                        if (linha.Reatancia > 0)
                            rede.edges.Add(linha);

                        #region converte para texto
                        foreach (var cell in row.Cells)
                        {
                            if (cell != null)
                            {
                                if (cell.IsAmount)
                                {
                                    stringRetorno += cell.Amount + "\t";
                                }
                                else
                                {
                                    stringRetorno += cell.Text + "\t";
                                }
                            }
                        }
                        stringRetorno += "\n";
                        #endregion

                        idLinha++;
                    }
                    var t = rede;
                }
            }
            else
            {
                throw new Exception("Erro ao abrir arquivo de Rede");
            }
            #endregion

            return rede;
        }

        /*public void UpdateExcel(string sheetName, int row, int col, string data)
        {
            Microsoft.Office.Interop.Excel.Application oXL = null;
            Microsoft.Office.Interop.Excel._Workbook oWB = null;
            Microsoft.Office.Interop.Excel._Worksheet oSheet = null;

            try
            {
                oXL = new Microsoft.Office.Interop.Excel.Application();
                oWB = oXL.Workbooks.Open("d:\\MyExcel.xlsx");
                oSheet = String.IsNullOrEmpty(sheetName) ? (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet : (Microsoft.Office.Interop.Excel._Worksheet)oWB.Worksheets[sheetName];

                oSheet.Cells[row, col] = data;

                oWB.Save();

                MessageBox.Show("Done!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (oWB != null)
                    oWB.Close();
            }
        }*/
    }
}