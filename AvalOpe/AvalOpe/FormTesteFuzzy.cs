using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FuzzyFramework;
using FuzzyFramework.Dimensions;
using FuzzyFramework.Sets;
using FuzzyFramework.Defuzzification;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;

/// <summary>
/// Fuzzy Framework
/// Fuzzy Framework library supports calculations based on fuzzy logic in .NET.
/// http://www.codeproject.com/Articles/151161/Fuzzy-Framework
/// 
/// FuzzyFramework.dll
/// PolyLib.dll
/// </summary>

namespace AvalOpe
{
    public partial class FormTesteFuzzy : Form
    {
        public FormTesteFuzzy()
        {
            InitializeComponent();

           
        }

        private void testeFuzzy()
        {
            #region Definitions
            //Definition of dimensions on which we will measure the input values
            ContinuousDimension height = new ContinuousDimension("Height", "Personal height", "cm", 100, 250);
            ContinuousDimension weight = new ContinuousDimension("Weight", "Personal weight", "kg", 30, 200);

            //Definition of dimension for output value
            ContinuousDimension consequent = new ContinuousDimension("Suitability for basket ball", "0 = not good, 5 = very good", "grade", 0, 5);

            //Definition of basic fuzzy sets with which we will work
            //  input sets:
            FuzzySet tall = new LeftLinearSet(height, "Tall person", 170, 185);
            FuzzySet weighty = new LeftLinearSet(weight, "Weighty person", 80, 100);
            //  output set:
            FuzzySet goodForBasket = new LeftLinearSet(consequent, "Good in basket ball", 0, 5);

            //Definition of antedescent
            FuzzyRelation lanky = tall & !weighty;

            //Implication
            FuzzyRelation term = (lanky & goodForBasket) | (!lanky & !goodForBasket);
            #endregion

            
            #region Input values
            decimal inputHeight = Decimal.Parse(txtAltura.Text); //decimal.Parse(Console.ReadLine());

            decimal inputWeight = Decimal.Parse(txtPeso.Text);// decimal.Parse(Console.ReadLine());
            #endregion


            #region Auxiliary messages; just for better understanding and not necessary for the final defuzzification
            double isLanky = lanky.IsMember(
                new Dictionary<IDimension, decimal>{
                            { height, inputHeight },
                            { weight, inputWeight }
                    }
            );

            txtResultado.Text += String.Format("You are lanky to the {0:F3} degree out of range <0,1>.", isLanky) +"\n"; 
            txtResultado.Text += "Membership distribution in the output set for given inputs:" + "\n";

            for (decimal i = 0; i <= 5; i++)
            {
                double membership = term.IsMember(
                    new Dictionary<IDimension, decimal>{
                        { height, inputHeight },
                        { weight, inputWeight },
                        { consequent, i}
                    }
                 );

                txtResultado.Text += String.Format("µrelation(height={0:F0},weight={1:F0},consequent={2:F0}) = {3:F3}", inputHeight, inputWeight, i, membership) + "\n";
            }
            txtResultado.Text += "\n";
            #endregion


            #region Deffuzification of the output set
            Defuzzification result = new MeanOfMaximum(
                term,
                new Dictionary<IDimension, decimal>{
                    { height, inputHeight },
                    { weight, inputWeight }
                }
            );

            txtResultado.Text += String.Format("Your disposition to be a basketball player is {0:F3} out of <0,...,5>", result.CrispValue) + "\n";

            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "";
            testeFuzzy();
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    txtResultado.Text = "";
        //    string s = "";
        //    ExecPro("avalclips.exe", "", "", "", s);

        //    //this.txtResultado.Text = s;
        //}

        //public void ExecPro(string ProcessName, string args, string WrkDir, string cmdtxt, string coutext)
        //{
        //    //Process process = new Process();
        //    //// Configure the process using the StartInfo properties.
        //    //process.StartInfo.FileName = "avalclips.exe";
        //    //process.StartInfo.Arguments = "";
        //    //process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
        //    //process.Start();
        //    //process.WaitForExit();// Waits here for the process to exit.


        //    for (int i = 0; i < 5; i++)
        //    {
        //        Process cmd = new Process();

        //        cmd.StartInfo.FileName = ProcessName;
        //        cmd.StartInfo.Arguments = args;
        //        cmd.StartInfo.UseShellExecute = false;
        //        cmd.StartInfo.CreateNoWindow = true;
        //        cmd.StartInfo.ErrorDialog = true;
        //        cmd.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
        //        cmd.StartInfo.RedirectStandardOutput = true;
        //        cmd.StartInfo.RedirectStandardInput = true;
        //        cmd.StartInfo.RedirectStandardError = true;


        //        cmd.Start();


        //        StreamWriter cin = cmd.StandardInput;
        //        StreamReader cout = cmd.StandardOutput;

        //        //if (i == 0)
        //        //{
        //        //    cin.WriteLine("");
        //        //}
        //        //else if (i == 1)
        //        //{
        //        //    cin.WriteLine("");
        //        //    cin.WriteLine("S");
        //        //}else if (i == 2)
        //        //{
        //        //    cin.WriteLine("");
        //        //    cin.WriteLine("S");
        //        //    cin.WriteLine("S");
        //        //}else if (i == 3)
        //        //{
        //        //    cin.WriteLine("");
        //        //    cin.WriteLine("S");
        //        //    cin.WriteLine("S");
        //        //    cin.WriteLine("S");
        //        //}else if (i == 4)
        //        //{
        //        //    cin.WriteLine("");
        //        //    cin.WriteLine("S");
        //        //    cin.WriteLine("S");
        //        //    cin.WriteLine("S");
        //        //    cin.WriteLine("JUSANTE");
        //        //}
        //        cin.WriteLine("");
        //        cin.WriteLine("S");
        //        cin.WriteLine("S");
        //        cin.WriteLine("S");
        //        cin.WriteLine("JUSANTE");

        //        cin.Close();
        //        coutext = cout.ReadToEnd();
        //        cmd.WaitForExit();
        //        cmd.Close();

        //        this.txtResultado.Text += "\n\n\n" + coutext;
        //    }
        //}
    }
}
