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
    public partial class FormManual : Form
    {
        public FormManual()
        {
            InitializeComponent();
            string file = "file:///" + Application.StartupPath + "\\manual.pdf";// @"\manual.pdf";

            webBrowser1.Navigate(file);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        
    }
}
