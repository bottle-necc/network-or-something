using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

namespace Client
{
    public partial class Login : Form
    {
        private string _userID;
        private string _password;

        public Login()
        {
            InitializeComponent();
            this.FormClosing += ApplicationExitHandler.OnWindowClosing;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbxUserID.Text) && !string.IsNullOrEmpty(tbxPassword.Text))
                {
                    btnLogin.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Username and/or password can not be left blank", "Login Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Stop); return; }
        }
    }
}
