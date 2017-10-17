using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Multithreading
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            infoLbl.Text = "";
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startMonoBtn_Click(object sender, EventArgs e)
        {
            SwitchButtons();

            // Opération longue dans le thread principal => blocage de l'application
            infoLbl.Text = "Opération en cours...";
            Thread.Sleep(5000); // Arrête le thread courant pendant 5 secondes
            infoLbl.Text = "Opération terminée";

            SwitchButtons();
        }

        private void startMultiBtn_Click(object sender, EventArgs e)
        {
            SwitchButtons();

            infoLbl.Text = "Opération en cours...";
            worker.RunWorkerAsync(); // Démarre un thread
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Thread.Sleep(5000); // Arrête le thread courant pendant 5 secondes
                //throw new Exception("Test"); // Simula l'apparition d'une erreur dans le thread
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            infoLbl.Text = "Opération terminée";
            SwitchButtons();
        }

        private void SwitchButtons()
        {
            startMonoBtn.Enabled = !startMonoBtn.Enabled;
            startMultiBtn.Enabled = !startMultiBtn.Enabled;
        }
    }
}
