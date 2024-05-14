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

namespace server
{
    public partial class Server : Form
    {
        TcpListener _listener;
        TcpClient _client;
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

            tbxInbox.AppendText(Encoding.Unicode.GetString(buffer, 0, n));

            StartListening(client);
        }
    }
}
