using AStarAlgorithm.Dialogs;
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
    public partial class FormMap : Form
    {
        private NodeController ctrl;
        private int status_;

        public FormMap()
        {
            InitializeComponent();

            ctrl = new NodeController(true);
            AddTest();
        }

        private void AddTest()
        {
            ctrl.AddNode("A", 100, 100);
            ctrl.AddNode("B", 200, 100);
            ctrl.AddNode("C", 300, 100);
            ctrl.AddNode("D", 100, 200);
            ctrl.AddNode("E", 200, 200);
            ctrl.AddNode("F", 300, 200);

            ctrl.AddPath("A", "B", 1000);
            ctrl.AddPath("B", "C", 1000);
            ctrl.AddPath("C", "E", 1500);
            ctrl.AddPath("A", "D", 1000);
            ctrl.AddPath("D", "E", 1000);
            ctrl.AddPath("E", "F", 1000);
            ctrl.AddPath("B", "E", 1000);
            UpdatePanel();
        }

        private void UpdatePanel()
        {
            panelMap.Refresh();
        }

        private void UpdateStatus(int status)
        {
            status_ = status;

            switch (status)
            {
                case 0:
                    toolStripStatusLabel1.Text = "";
                    break;
                case 1:
                    toolStripStatusLabel1.Text = "Click to add a node";
                    break;
                case 2:
                    toolStripStatusLabel1.Text = "Drag to add a path";
                    break;
                default:
                    toolStripStatusLabel1.Text = "";
                    break;
            }
        }

        private void MouseDownEvent(int x, int y)
        {
            switch (status_)
            {
                case 1:
                    NewNodeDialog diag = new NewNodeDialog();

                    if (diag.ShowDialog() == DialogResult.OK)
                    {
                        if (!ctrl.AddNode(diag.NodeName, x, y))
                        {
                            MessageBox.Show("Creating node failed");
                        }
                    }

                    UpdatePanel();
                    UpdateStatus(0);
                    break;

                case 2:
                    ctrl.BeginPath(x, y);
                    break;

                default:
                    ctrl.BeginMove(x, y);
                    break;
            }
        }

        private void MouseMoveEvent(MouseButtons button, int x, int y)
        {
            if (button == MouseButtons.Left && status_ == 0)
            {
                ctrl.Move(x, y);
                UpdatePanel();
            }
        }

        private void MouseUpEvent(int x, int y)
        {
            if (status_ == 2)
            {
                NewPathDialog diag = new NewPathDialog();

                if (diag.ShowDialog() == DialogResult.OK)
                {
                    if (diag.Distance >= 0)
                    {
                        ctrl.EndPath(x, y, diag.Distance);
                    }
                    else
                    {
                        MessageBox.Show("Creating path failed");
                    }
                }

                UpdatePanel();
                UpdateStatus(0);
            }
        }

        private void newNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateStatus(1);
        }

        private void newPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateStatus(2);
        }

        private void panelMap_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownEvent(e.X, e.Y);
        }

        private void panelMap_MouseMove(object sender, MouseEventArgs e)
        {
            MouseMoveEvent(e.Button, e.X, e.Y);
        }

        private void panelMap_MouseUp(object sender, MouseEventArgs e)
        {
            MouseUpEvent(e.X, e.Y);
        }

        private void panelMap_Paint(object sender, PaintEventArgs e)
        {
            ctrl.Paint(e.Graphics);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ctrl.Reset();
            UpdatePanel();
        }

        private void findPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindPathDialog diag = new FindPathDialog();

            if (diag.ShowDialog() == DialogResult.OK)
            {
                bool found = ctrl.HighlightPath(diag.FromNode, diag.ToNode);

                if (found)
                {
                    UpdatePanel();
                }
                else
                {
                    MessageBox.Show("No path found!");
                }
            }
        }
    }
}