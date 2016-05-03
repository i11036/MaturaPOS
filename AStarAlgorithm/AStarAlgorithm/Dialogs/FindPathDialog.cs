using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AStarAlgorithm.Dialogs
{
    public partial class FindPathDialog : Form
    {
        public string FromNode
        {
            get
            {
                return textBoxFrom.Text;
            }
        }

        public string ToNode
        {
            get
            {
                return textBoxTo.Text;
            }
        }

        public FindPathDialog()
        {
            InitializeComponent();
        }
    }
}
