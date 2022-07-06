using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace interfaceClips
{ 

    public partial class Form1 : Form
    {
        Process proc;

        protected override void OnClosed(EventArgs e)
        {
            if (proc != null)
            {
                //proc.Close();
            }
            base.OnClosed(e);
        }

        public Form1()
        {
            //SOLICITA O PROCESSO EXTERNO 
            ProcessStartInfo info = new ProcessStartInfo("C:/Users/paulo/Documents/Visual Studio 2015/Projects/AvalOpe/clipsInterface/avalclips/avalclips/bin/Debug/avalclips2.exe");
            info.UseShellExecute = false;
            info.CreateNoWindow = true;
            info.RedirectStandardOutput = true;
            info.RedirectStandardInput = true;

            
            proc = new Process();
            proc.StartInfo = info;

            proc.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
            {
                Console.WriteLine("Msg : " + e.Data);
                this.Invoke((MethodInvoker)delegate
                {
                    //AQUI ESCREVE NA LABEL DO FORM
                   label1.Text = e.Data;
                });

            };

            new Thread(() =>
            {
                proc.Start();
                proc.BeginOutputReadLine();
                proc.WaitForExit();

            }).Start();

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SETA SIM PARA TODOS AS FUNÇÔES
            //proc.StandardInput.WriteLine("S");
            proc.StandardInput.WriteLine(textBox1.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
