using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project2
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void btnExitLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usernameInput = txtUsername.Text;
            string passwordInput = txtPassword.Text;

            User userInstance = new User();
            List<User> allUsers = userInstance.PopulateUsers();
            bool canLogin = false;

            foreach (User item in allUsers)
            {
                if (item.Username == usernameInput && item.Password == passwordInput)
                {
                    canLogin = true;
                }
            }

            if (canLogin)
            {
                frmJets simulation = new frmJets();
                simulation.Show();
                this.Hide();
            }
            else
            {
                DialogResult dr = MessageBox.Show("Invalid username and password combination.", "Login Failed!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dr == DialogResult.Retry)
                {
                    txtUsername.Clear();
                    txtPassword.Clear();
                    txtUsername.Focus();
                }
            }
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            frmRegister ca = new frmRegister();
            ca.Show();
            this.Hide();
        }

    }
}
