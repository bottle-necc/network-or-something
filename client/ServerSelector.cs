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


namespace Client
{
    public partial class ServerSelector : Form
    {
        TcpClient client = new TcpClient();
        IPAddress address;
        int port = 12345;

        public ServerSelector()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            bool hasLoaded = false;

            StartConnecting();
            
            // Keeps the form from loading next window until a connection has been made
            while (!client.Connected)
            {
                await Task.Delay(1000);
            }

            if (!hasLoaded)
            {
                this.Hide();
                hasLoaded = true;
                Login login = new Login();
                login.ShowDialog();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            StartConnecting();
        }

        public async void StartConnecting()
        {
            try
            {
                btnLogin.Enabled = false;
                btnRegister.Enabled = false;

                // Connects to the attributed server
                address = IPAddress.Parse(tbxAddress.Text);
                await client.ConnectAsync(address, port);

                ServerConnection.Client = client;
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Stop); 
                btnLogin.Enabled = true;
                btnRegister.Enabled = true;
                return; 
            }
        }
    }
}
