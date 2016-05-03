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
    public partial class AddStateDialog : Form
    {
        public string StateName
        {
            get
            {
                return textBoxName.Text;
            }
        }

        public bool InitState
        {
            get
            {
                return checkBoxInitState.Checked;
            }
        }

        public bool EndState
        {
            get
            {
                return checkBoxEndState.Checked;
            }
        }

        public AddStateDialog()
        {
            InitializeComponent();
        }
    }
}
