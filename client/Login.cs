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
        private TcpClient _client;
        private StreamReader _reader;
        private StreamWriter _writer;

        public Login(TcpClient client)
        {
            InitializeComponent();
            this.FormClosing += ApplicationExitHandler.OnWindowClosing;

            _client = client;
            _reader = new StreamReader(_client.GetStream(), Encoding.Unicode);
            _writer = new StreamWriter(_client.GetStream(), Encoding.Unicode);
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbxUserID.Text) && !string.IsNullOrEmpty(tbxPassword.Text))
                {
                    btnLogin.Enabled = false;

                    var package = new
                    {
                        requestType = RequestType.Login,
                        userID = tbxUserID.Text,
                        password = tbxPassword.Text,
                    };

                    string delivery = JsonConvert.SerializeObject(package);
                    await _writer.WriteLineAsync(delivery);
                    _writer.Flush();
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
