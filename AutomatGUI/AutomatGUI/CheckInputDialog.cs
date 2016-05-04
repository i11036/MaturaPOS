using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomatGUI
{
    public partial class CheckInputDialog : Form
    {
        public string Input
        {
            get
            {
                return textBoxInput.Text;
            }
        }

        public CheckInputDialog()
        {
            InitializeComponent();
        }
    }
}
