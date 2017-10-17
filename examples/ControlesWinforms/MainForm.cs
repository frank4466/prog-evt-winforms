using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlesWinforms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Ajoute 3 pays à la liste
            countryCB.Items.Add("France");
            countryCB.Items.Add("Belgique");
            countryCB.Items.Add("Suisse");

            // Sélectionne le 2ème élément de la liste
            countryCB.SelectedIndex = 1;

            // Ajoute 4 éléments à la liste
            hardwareLB.Items.Add("PC");
            hardwareLB.Items.Add("Mac");
            hardwareLB.Items.Add("Tablette");
            hardwareLB.Items.Add("Smartphone");

            // Sélectionner le 1er élément
            hardwareLB.SelectedIndex = 0;
        }

        // Gère le changement de sélection dans la liste déroulante
        private void countryCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            // On caste l'objet renvoyé par SelectedItem vers le type chaîne
            string selectedValue = (string) countryCB.SelectedItem;
            // ...
        }

        // Gère le changement de sélection dans la liste
        private void hardwareLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Parcours de la liste des éléments sélectionnés
            foreach (string value in hardwareLB.SelectedItems)
            {
                // ...
            }
        }

        // Gère le clic sur le bouton de connexion
        private void connectBtn_Click(object sender, EventArgs e)
        {
            // ...
        }

        // Gère le clic sur la commande Quitter
        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ...
        }
    }
}
