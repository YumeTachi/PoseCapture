using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace posertrimer
{
    public partial class ToolForm : Form
    {
        MainForm m_Form1 = null;
        public ToolForm(MainForm form1)
        {
            InitializeComponent();

            m_Form1 = form1;
        }

        private void buttonScaleUp_Click(object sender, EventArgs e)
        {
            m_Form1.scaleUp();
        }

        private void buttonScaleDown_Click(object sender, EventArgs e)
        {
            m_Form1.scaleDown();
        }

        private void buttonClockwise_Click(object sender, EventArgs e)
        {
            m_Form1.rotClockwise();
        }

        private void buttonCounterClockwise_Click(object sender, EventArgs e)
        {
            m_Form1.rotCounterClockwise();
        }

        private void buttonChangeFillMode_Click(object sender, EventArgs e)
        {
            m_Form1.changeFillMode();
        }

        private void buttonCapture_Click(object sender, EventArgs e)
        {
            m_Form1.capture();
        }

        private void ToolForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall || e.CloseReason == CloseReason.FormOwnerClosing)
                return;

            e.Cancel = true;
        }
    }
}
