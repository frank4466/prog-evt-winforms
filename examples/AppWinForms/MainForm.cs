using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppWinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // Gère le clic sur le boutton helloBtn
        private void helloBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Merci !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Gère la fermeture du formulaire par l'utilisateur
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Etes-vous sûr(e) ?", "Demande de confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void nameBtn_Click(object sender, EventArgs e)
        {
            // Affiche le formulaire SubForm modal
            SubForm subForm = new SubForm("Entrez votre login");
            if (subForm.ShowDialog() == DialogResult.OK)
            {
                string login = subForm.Input;
                this.Text = "Bienvenue, " + login;
            }
            // throw new Exception("Test"); // Simule l'apparition d'une erreur
        }
    }
}
