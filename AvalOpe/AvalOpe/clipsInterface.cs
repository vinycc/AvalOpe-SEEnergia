using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Text.RegularExpressions;
using System.Globalization;

namespace AvalOpe
{
    public partial class clipsInterface : Form
    {
        Process proc;
        string saida;

        public void AdicionarAcertoErro(string mensagem)
        {
            //ACERTOS
            if (mensagem.Contains("CORRETA"))
            {
                string strAcao = mensagem.Split('|')[0].Trim();

                //ListViewItem item1 = new ListViewItem(new[] { "", strAcao });
                //item1.ImageIndex = 0;
                //listAcertos.Items.Add(item1);

                //GLItem item;
                //item = this.gListAcertos.Items.Add(strAcao);

                gridAcertos.Rows.Add(strAcao);
            }

            //ERROS
            if (mensagem.Contains("ERRO") || mensagem.Contains("ERROR"))
            {

                string strAcao = mensagem.Split('|')[0].Trim();
                //ListViewItem item1 = new ListViewItem(new[] { "", strAcao });
                //item1.ImageIndex = 1;
                //listErros.Items.Add(item1);


                //GLItem item;
                //item = this.gListErros.Items.Add(strAcao);

                gridErros.Rows.Add(strAcao);


                //item.SubItems[1].BackColor = Color.Aqua; // set the background 
                // of this particular subitem ONLY
                //item.UserObject = myownuserobjecttype; // set a private user object
                //item.Selected = true; // set this item to selected state
                //item.SubItems[1].Span = 2; // set this sub item to span 2 spaces


                //ListViewItem item2 = new ListViewItem(new[] { "", mensagem.Split('|')[0].Trim() });
                //item2.ImageIndex = 1;
                //listAcertosErros.Items.Add(item2);
            }
        }

        public clipsInterface()
        {
            
            ProcessoPrincipal();

            InitializeComponent();


            gridLog.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            gridLog.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

        }

        public void ProcessoPrincipal()
        {
            

            //SOLICITA O PROCESSO EXTERNO 
            ProcessStartInfo info = new ProcessStartInfo("avalclips.exe");
            info.UseShellExecute = false;
            info.CreateNoWindow = true;
            info.RedirectStandardOutput = true;
            info.RedirectStandardInput = true;
            info.RedirectStandardError = true;

            //Codificação em unicode para evitar problemas com acentuação; Tambem deve ser configurado no aap que será instanciado.
            info.StandardOutputEncoding = UnicodeEncoding.Unicode;

            proc = new Process();
            proc.StartInfo = info;

            saida = "";
            proc.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
            {
                saida += e.Data + "\n";
                //Console.WriteLine("Msg : " + e.Data);
                this.Invoke((MethodInvoker)delegate
                {
                    //AQUI ESCREVE NA LABEL DO FORM

                    //Remove quebras de linhas que estão em excesso
                    while (saida.Contains("\n\n"))
                    {
                        saida = saida.Replace("\n\n", "\n");
                    }

                    txtOutput.Text = saida.Replace("TENTA", "");
                    txtOutput.Text = saida.Replace("TERMINOU", "");

                    //txtOutput.Text.Replace('|', ' ');
                    
                    #region CONTROLES DE ENTRADA
                    //Remove controles
                    panelInput.Controls.Clear();

                    //Verifica se insere comboBox ou TextBox
                    if (saida.Contains("(S/N)"))
                    {
                        //Adiciona ComboBox
                        ComboBox combo = new ComboBox();
                        combo.Name = "combo";
                        combo.Width = 150;
                        combo.Items.Add("S");
                        combo.Items.Add("N");
                        combo.SelectedIndex = 0;
                        combo.DropDownStyle = ComboBoxStyle.DropDownList;
                        panelInput.Controls.Add(combo);
                        combo.Focus();
                    }
                    else if (saida.Contains("(Y/N)"))
                    {
                        //Adiciona ComboBox
                        ComboBox combo = new ComboBox();
                        combo.Name = "combo";
                        combo.Width = 150;
                        combo.Items.Add("Y");
                        combo.Items.Add("N");
                        combo.SelectedIndex = 0;
                        combo.DropDownStyle = ComboBoxStyle.DropDownList;
                        panelInput.Controls.Add(combo);
                        combo.Focus();
                    }
                    else if (saida.Contains("(SE/JUSANTE)"))
                    {
                        //Adiciona ComboBox
                        ComboBox combo = new ComboBox();
                        combo.Name = "combo";
                        combo.Width = 150;
                        combo.Items.Add("SE");
                        combo.Items.Add("JUSANTE");
                        combo.SelectedIndex = 0;
                        combo.DropDownStyle = ComboBoxStyle.DropDownList;
                        panelInput.Controls.Add(combo);
                        combo.Focus();
                    }
                    else if (saida.Contains("(SU/BEYOND)"))
                    {
                        //Adiciona ComboBox
                        ComboBox combo = new ComboBox();
                        combo.Name = "combo";
                        combo.Width = 150;
                        combo.Items.Add("SU");
                        combo.Items.Add("BEYOND");
                        combo.SelectedIndex = 0;
                        combo.DropDownStyle = ComboBoxStyle.DropDownList;
                        panelInput.Controls.Add(combo);
                        combo.Focus();
                    }
                    else if (saida.Contains("(DJ/JUSANTE)"))
                    {
                        //Adiciona ComboBox
                        ComboBox combo = new ComboBox();
                        combo.Name = "combo";
                        combo.Width = 150;
                        combo.Items.Add("DJ");
                        combo.Items.Add("JUSANTE");
                        combo.SelectedIndex = 0;
                        combo.DropDownStyle = ComboBoxStyle.DropDownList;
                        panelInput.Controls.Add(combo);
                        combo.Focus();
                    }
                    else if (saida.Length > 20)
                    {
                        //Adiciona TextBox
                        TextBox text = new TextBox();
                        text.Name = "text";
                        text.Width = 150;
                        panelInput.Controls.Add(text);
                        text.Focus();

                    }

                    //Adicionar botao
                    Button botao = new Button();
                    if (Thread.CurrentThread.CurrentCulture.Name == "en-US")
                    {
                        botao.Text = "Submit";
                    }
                    else
                    {
                        botao.Text = "Enviar";
                    }

                    botao.Click += Botao_Click;
                    panelInput.Controls.Add(botao);
                    this.AcceptButton = botao;

                    #endregion

                    //Verifica se terminou
                    if (saida.Contains("TERMINOU"))
                    {
                        //Se terminou, captura ultima mensagem caso exista
                        this.AdicionarAcertoErro(saida);

                        //Adiciona ultima mensagem no LOG
                        if (saida.Contains("CORRETA") || saida.Contains("ERRO") || saida.Contains("ERROR"))
                        {
                            string strPergunta = txtOutput.Text.Split('|')[0].Trim();
                            string strResposta = "";

                            gridLog.Rows.Add(
                                strPergunta.Replace("\n", " "),
                                strResposta.Replace("\n", " ")
                            );
                        }

                        //Limpa tela de questionário
                        txtOutput.Text = "";
                        panelInput.Controls.Clear();
                        
                        //Muda aba
                        if (gridAcertos.Rows.Count > 0)
                        {
                            tabControl1.SelectedIndex = 1;
                        }
                        else if (gridErros.Rows.Count > 0)
                        {
                            tabControl1.SelectedIndex = 2;
                        }
                        else
                        {
                            tabControl1.SelectedIndex = 3;
                        }

                        //Adicionar botao de reiniciar
                        panelOutput.Controls.Clear();
                        Button botaoReiniciar = new Button();
                        botaoReiniciar.Text = "Reiniciar";
                        botaoReiniciar.Click += BotaoReiniciar_Click;
                        panelOutput.Controls.Add(botaoReiniciar);

                    }
                });
            };

            Thread threadClips = new Thread(() =>
            {
                proc.Start();
                proc.BeginOutputReadLine();
                proc.WaitForExit();
            });

            //Instrução utilizada para garantir que a thread será automaticamente fechada no final da aplicaçaõ
            threadClips.IsBackground = true;
            threadClips.Start();

        }


        private void Botao_Click(object sender, EventArgs e)
        {
            saida = "";

            if (panelInput.Controls.Find("combo", false).Count() > 0 || panelInput.Controls.Find("text", false).Count() > 0)
            {
                string strResposta = "";

                if (panelInput.Controls.Find("combo", false).Count() > 0)
                {
                    ComboBox combo = (ComboBox)panelInput.Controls.Find("combo", false).First();
                    strResposta = combo.SelectedItem.ToString().ToUpper();
                    //if (strResposta.Contains("SU"))
                    //{
                    //    strResposta.Replace("SU", "SE");
                    //}
                    proc.StandardInput.WriteLine(combo.SelectedItem.ToString().ToUpper());
                }
                else if (panelInput.Controls.Find("text", false).Count() > 0)
                {
                    TextBox text = (TextBox)panelInput.Controls.Find("text", false).First();
                    strResposta = text.Text.ToUpper();
                    proc.StandardInput.WriteLine(text.Text.ToUpper());
                }

                //LOG
                if (txtOutput.Text.Contains("CORRETA") || txtOutput.Text.Contains("ERRO") || txtOutput.Text.Contains("ERROR"))
                {
                    string strPergunta1 = txtOutput.Text.Split('|')[0].Trim();
                    string strPergunta2 = txtOutput.Text.Split('|')[1].Trim();

                    gridLog.Rows.Add(strPergunta1.Replace("\n", " "), "");

                    //pergunta e resposta
                    gridLog.Rows.Add(
                        strPergunta2.Replace("\n", " "),
                        strResposta.Trim().Replace("\n", " ")
                    );
                }
                else
                {
                    gridLog.Rows.Add(
                        txtOutput.Text.Trim().Replace("\n", " "),
                        strResposta.Trim().Replace("\n", " ")
                    );
                }

                //Adiciona mensagem na tela de erros e acertos
                this.AdicionarAcertoErro(txtOutput.Text);
            }
        }
        private void BotaoReiniciar_Click(object sender, EventArgs e)
        {
            gridAcertos.Rows.Clear();
            gridErros.Rows.Clear();
            gridLog.Rows.Clear();

            panelOutput.Controls.Clear();
            panelOutput.Controls.Add(txtOutput);
            ProcessoPrincipal();
        }

    }
}
