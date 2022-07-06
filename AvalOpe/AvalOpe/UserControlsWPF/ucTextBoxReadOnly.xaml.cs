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
    /// Interaction logic for ucTextBoxReadOnly.xaml
    /// </summary>
    public partial class ucTextBoxReadOnly : UserControl
    {
        public string Valor
        {
            get { return this.textBox.Text; }
            set { this.textBox.Text = value; }
        }

        public ucTextBoxReadOnly()
        {
            InitializeComponent();
        }

        
    }
}
