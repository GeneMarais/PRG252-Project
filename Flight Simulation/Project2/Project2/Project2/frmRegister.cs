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
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please enter a name.");
                txtName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtSurname.Text))
            {
                MessageBox.Show("Please enter a surname.");
                txtSurname.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cbGender.Text))
            {
                MessageBox.Show("Please select a gender.");
                cbGender.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Please enter a username.");
                txtUsername.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please enter a password.");
                txtPassword.Focus();
                return;
            }

            User addUser = new User();
            addUser.Name = txtName.Text;
            addUser.Surname = txtSurname.Text;
            addUser.Gender = cbGender.Text;
            addUser.Username = txtUsername.Text;
            addUser.Password = txtPassword.Text;

            List<User> existingUsers = addUser.PopulateUsers();
            foreach (User item in existingUsers)
            {
                if (addUser.Username == item.Username)
                {
                    MessageBox.Show("Please enter a different username.", "Username already exists!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUsername.Clear();
                    txtUsername.Focus();
                    return;
                }
            }

            addUser.AddUsers();
            MessageBox.Show("Your account was created successfully.", "Account Created!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            frmLogin login = new frmLogin();
            login.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {

        }
    }
}
