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
    public partial class Form1 : Form
    {
        TcpClient _client = new TcpClient();
        string _userID = "";
        int port = 12345;

        public Form1()
        {
            InitializeComponent();
            _client.NoDelay = true;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!_client.Connected)
            {
                StartConnecting();
            }
        }

        public async void StartConnecting()
        {
            try
            {
                IPAddress address = IPAddress.Parse(tbxAddress.Text);
                _userID = tbxUserID.Text;
                await _client.ConnectAsync(address, port);
            }
            catch (Exception error) {MessageBox.Show(error.Message, Text); return; }

            tbxAddress.Enabled = false;
            tbxUserID.Enabled = false;
            btnConnect.Enabled = false;
            btnSend.Enabled = true;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Send($"{_userID}: {tbxMessage.Text}");
        }

        public async void Send(string message)
        {
            byte[] outputData = Encoding.Unicode.GetBytes(message);

            try
            {
                await _client.GetStream().WriteAsync(outputData, 0, outputData.Length);
            }
            catch (Exception error) { MessageBox.Show(error.Message, Text); return; }
        }
    }
}
