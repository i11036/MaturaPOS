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
    public partial class AutomatGUI : Form
    {
        private GuiAutomat automat;
        private int status_;

        public AutomatGUI()
        {
            InitializeComponent();
            automat = new GuiAutomat();
            status_ = 0;
        }

        private void InitTest()
        {
            automat.Reset();

            automat.SetAlphabet("ab");

            automat.AddState("1", 100, 150, false, true);
            automat.AddState("2", 200, 100, false, false);
            automat.AddState("3", 200, 200, false, false);
            automat.AddState("4", 300, 100, false, false);
            automat.AddState("5", 300, 200, false, false);
            automat.AddState("6", 400, 150, true, false);

            automat.AddPath("1", "3", 'a');
            automat.AddPath("1", "2", 'b');
            automat.AddPath("2", "1", 'a');
            automat.AddPath("2", "4", 'b');
            automat.AddPath("3", "1", 'a');
            automat.AddPath("3", "5", 'b');
            automat.AddPath("4", "6", 'a');
            automat.AddPath("4", "5", 'b');
            automat.AddPath("5", "6", 'a');
            automat.AddPath("5", "4", 'b');
            automat.AddPath("6", "6", 'a');
            automat.AddPath("6", "6", 'b');
        }

        public void UpdateAutomatGUI()
        {
            automat.InitGui();
            UpdatePanel();
        }

        private void UpdatePanel()
        {
            automatPanel.Refresh();
        }

        private void UpdateStatus(int status)
        {
            switch (status)
            {
                case 0:
                    status_ = 0;
                    automatStatusLabel.Text = "";
                    break;
                case 1:
                    status_ = 1;
                    automatStatusLabel.Text = "Klick to add a state";
                    break;
                case 2:
                    status_ = 2;
                    automatStatusLabel.Text = "Drag to add a path";
                    break;
                default:
                    status_ = 0;
                    automatStatusLabel.Text = "";
                    break;
            }
        }

        private void automatPanel_Paint(object sender, PaintEventArgs e)
        {
            automat.Paint(e.Graphics);
        }

        private void AutomatGUI_Load(object sender, EventArgs e)
        {
            UpdatePanel();
        }

        private void newAutomatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitTest();
            UpdateAutomatGUI();
        }

        private void automatPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
            {
                if (status_ == 0)
                {
                    automat.BeginMove(e.X, e.Y);
                }
                else if (status_ == 1)
                {
                    AddStateDialog diag = new AddStateDialog();

                    if (diag.ShowDialog() == DialogResult.OK)
                    {
                        automat.AddState(diag.StateName, e.X, e.Y,
                            diag.EndState, diag.InitState);
                        UpdatePanel();
                    }

                    UpdateStatus(0);
                }
                else if (status_ == 2)
                {
                    automat.BeginConnect(e.X, e.Y);
                }
            }
        }

        private void automatPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
            {
                if (status_ == 0)
                {
                    automat.EndMove();
                    UpdatePanel();
                }
                else if (status_ == 2)
                {
                    AddPathDialog diag = new AddPathDialog();

                    if (diag.ShowDialog() == DialogResult.OK)
                    {
                        if (diag.Valid)
                        {
                            automat.EndConnect(e.X, e.Y, diag.Token);
                            UpdatePanel();
                        }
                        else
                        {
                            MessageBox.Show("Invalid token");
                        }
                    }

                    UpdateStatus(0);
                }
            }
        }

        private void automatPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left)
                && status_ == 0 && automat.Moving)
            {
                automat.Move(e.X, e.Y);
                UpdatePanel();
            }
        }

        private void newStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateStatus(1);
        }

        private void newPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateStatus(2);
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateAutomatGUI();
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            automat.Minimize();
            UpdateAutomatGUI();
        }
    }
}