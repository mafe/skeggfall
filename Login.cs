using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkeggFallLevelDesigner
{
    public partial class Login : Form
    {
        private cUAC UAC;
        public Login()
        {
            InitializeComponent();
            UAC = new cUAC();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbPassword.Text != UAC.password || tbUsername.Text != UAC.username)
            {
                MessageBox.Show("Falscher Login!");
            }
            else
            {
                MessageBox.Show("Login erfolgreich!");
                this.Close();
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tbPassword.Text != UAC.password || tbUsername.Text != UAC.username)
            {
                MessageBox.Show("Falscher Login!");
                e.Cancel = true;
            }
        }
    }
}
