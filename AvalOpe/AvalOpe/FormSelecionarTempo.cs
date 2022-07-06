using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AvalOpe
{
    public partial class FormSelecionarTempo : Form
    {
        public int SelectionStart { get; private set; }

        public FormSelecionarTempo()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ((FormAvaliacao)((FormInterface)this.Owner).ActiveMdiChild).nrTempoMedioManobra = Convert.ToInt32(txtTempo.Text);
                this.DialogResult = DialogResult.OK;
            }
            catch {
                this.DialogResult = DialogResult.Abort;
                MessageBox.Show("Informe um valor válido.");
            }

            //foreach (Form f in this.MdiChildren)
            //{
            //    if (f.GetType() == typeof(FormInicio))
            //    {
            //        f.Activate();
            //        return;
            //    }
            //}
            //FormInicio form = new FormInicio();
            //form.MdiParent = this;
            //form.Show();


        }
    }

    /*public class Int32TextBox : TextBox
    {
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            NumberFormatInfo fi = CultureInfo.CurrentCulture.NumberFormat;
            string c = e.KeyChar.ToString();
            if (char.IsDigit(c, 0))
                return;
            if ((SelectionStart == 0 && (c.Equals(fi.NegativeSign))))
                return;

            //copy/paste
            if ((((int)e.KeyChar == 22) || ((int)e.KeyChar == 3)) && ((ModifierKeys & Keys.Control) == Keys.Control))
                return;
        }
    }*/
}
