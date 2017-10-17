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
    public partial class SubForm : Form
    {
        public SubForm(string message)
        {
            InitializeComponent();
            inputLbl.Text = message;
        }

        public string Input 
        {
            get { return inputBox.Text; }
        }
    }
}
