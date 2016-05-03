using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AStarAlgorithm
{
    public partial class NewNodeDialog : Form
    {
        public string NodeName
        {
            get
            {
                return textBoxName.Text;
            }
        }

        public NewNodeDialog()
        {
            InitializeComponent();
        }
    }
}
