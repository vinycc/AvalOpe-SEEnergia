using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Mommosoft.ExpertSystem;
using System.Diagnostics;
using System.IO;
using System.Globalization;

namespace avalclips
{
    public class DebugRouter : Router
    {
        public override string Name
        {
            get { return "DebugRouter"; }
        }

        public override int Priority
        {
            get { return 10; }
        }

        public override bool Query(string logicalName)
        {
            
            return true;
            return (logicalName.Equals("wwarning") ||
                   logicalName.Equals("werror") ||
                   logicalName.Equals("wtrace") ||
                   logicalName.Equals("wdialog") ||
                   logicalName.Equals("wclips") ||
                   logicalName.Equals("wdisplay"));
        }

        public override int Print(string logicalName, string message)
        {
            Console.WriteLine(message);
            return 1;
        }
    }

    public class ManualReader : TextReader
    {
        public override int Read()
        {
            Console.WriteLine("invocado");
            return 69;
        }
    }


    class Program
    {
        
        public static Mommosoft.ExpertSystem.Environment enviroment;
        public Process p;
        
        static void Main(string[] args)
        {
            bool external = true;
            if (external)
            {
                //Configuração para unicode, para evitar problemas de acentuação.
                Console.OutputEncoding = Encoding.Unicode;

                enviroment = new Mommosoft.ExpertSystem.Environment();
                //Console.WriteLine("TENTA");
                Router r = new DebugRouter();
                enviroment.AddRouter(r);
                //enviroment.Load("C:/Users/paulo/Documents/Visual Studio 2015/Projects/AvalOpe/clipsInterface/avalclips/avalclips/CPFL_1.clp");
                enviroment.Load("CPFL_1.clp");

                enviroment.Reset();

                enviroment.Run();

                Thread.Sleep(2000);
                Console.WriteLine("TERMINOU");
                Console.Read();

            }
            else
            {
                //ProcessStartInfo info = new ProcessStartInfo("C:/Users/paulo/Documents/Visual Studio 2015/Projects/AvalOpe/clipsInterface/avalclips/avalclips/bin/Debug/avalclips2.exe");
                //info.UseShellExecute = false;
                //info.RedirectStandardInput = true;

                ////manter o console oculto
                //info.CreateNoWindow = true;

                //Process proc = Process.Start(info);
               
                //while (true)
                //{
                //    Console.WriteLine("Ola");
                //    string s = Console.ReadLine();
                //    proc.StandardInput.WriteLine(s);
                //}
            }
        }
    }
}
