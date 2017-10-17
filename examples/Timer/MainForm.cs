using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Timer
{
    public partial class MainForm : Form
    {
        private int countdown = 10;

        public MainForm()
        {
            InitializeComponent();
            DisplayCountdown();
        }

        private void countdownBtn_Click(object sender, EventArgs e)
        {
            //countdownTimer.Tick += new EventHandler(countdownTimer_Tick);
            //countdownTimer.Interval = 1000;                               
            countdownTimer.Enabled = true;
            SwitchButtons();
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            countdownTimer.Enabled = false;
            SwitchButtons();
        }

        private void countdownTimer_Tick(object sender, EventArgs e)
        {
            countdown--;
            DisplayCountdown();
            if (countdown == 0)
            {
                countdownTimer.Enabled = false;
                MessageBox.Show("BOUM !", "Tout est cassé", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                ResetCountdown();
                SwitchButtons();
            }
        }

        private void DisplayCountdown()
        {
            countdownLbl.Text = countdown.ToString();
        }

        private void ResetCountdown()
        {
            countdown = 10;
            DisplayCountdown();
        }

        private void SwitchButtons()
        {
            startBtn.Enabled = !startBtn.Enabled;
            stopBtn.Enabled = !stopBtn.Enabled;
        }

        
    }
}
