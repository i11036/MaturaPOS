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
    public partial class NewPathDialog : Form
    {
        public int Distance
        {
            get
            {
                string distStr = textBoxDistance.Text;
                int distance;

                if (Int32.TryParse(distStr, out distance))
                {
                    return distance;
                }
                return -1;
            }
        }

        public NewPathDialog()
        {
            InitializeComponent();
        }
    }
}
