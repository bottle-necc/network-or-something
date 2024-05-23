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
        private TcpClient _client = new TcpClient();
        private IPAddress _address;
        private int _port = 12345;
        private bool _hasLoaded = false;

        public ServerSelector()
        {
            InitializeComponent();
            this.FormClosing += ApplicationExitHandler.OnWindowClosing;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            StartConnecting();
            
            // Keeps the form from loading next window until a connection has been made
            while (!_client.Connected)
            {
                await Task.Delay(1000);
            }

            // Loads the next window, also prevents bug that causes window to load twice
            if (!_hasLoaded)
            {
                this.Hide();
                _hasLoaded = true;
                Login login = new Login();
                login.ShowDialog();
            }
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            StartConnecting();
            
            // Keeps the form from loading next window until a connection has been made
            while (!_client.Connected)
            {
                await Task.Delay(1000);
            }

            // Loads the next window, also prevents bug that causes window to load twice
            if (!_hasLoaded)
            {
                this.Hide();
                _hasLoaded = true;
                MainProgram mainProgram = new MainProgram(_client);
                mainProgram.ShowDialog();
            }
        }

        public async void StartConnecting()
        {
            try
            {
                btnLogin.Enabled = false;
                btnRegister.Enabled = false;

                // Connects to the attributed server
                _address = IPAddress.Parse(tbxAddress.Text);
                await _client.ConnectAsync(_address, _port);
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
