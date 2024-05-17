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

// IMPORTANT INFO: WHEN SERVER IS FULLY DONE, SWITCH THE PROJECT FROM A CONSOLE PROJECT TO A WINDOWS PROJECT!

// TODO: Revamp the client list and turn it into a class that stores both the tcp and the user id for future use
// Each client is an object of that class

namespace server
{
    public partial class Server : Form
    {
        TcpListener _listener;
        TcpClient _client;
        List<TcpClient> _clients = new List<TcpClient>();
        int port = 12345;

        public Server()
        {
            InitializeComponent();
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            try
            {
                _listener = new TcpListener(IPAddress.Any, port);
                _listener.Start();
            }
            catch (Exception error) { MessageBox.Show(error.Message, Text); return; }

            btnStartServer.Enabled = false;
            StartInput();
        }

        public async void StartInput()
        {
            try
            {
                _client = await _listener.AcceptTcpClientAsync();
            }
            catch (Exception error) { MessageBox.Show(error.Message, Text); return; }

            if (!_clients.Contains(_client))
            {
                _clients.Add(_client);
            }

            StartInput();
            StartListening(_client);
        }

        public async void StartListening(TcpClient client)
        {
            byte[] buffer = new byte[1024];
            int n = 0;

            try
            {
                n = await client.GetStream().ReadAsync(buffer, 0, buffer.Length);
            }
            catch (Exception error) { MessageBox.Show(error.Message, Text); return; }

            tbxInbox.AppendText(Encoding.Unicode.GetString(buffer, 0, n) + Environment.NewLine);

            foreach (TcpClient i in _clients)
            {
                Console.WriteLine(i.ToString());
            }

            StartListening(client);
        }
    }
}
