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

namespace Client
{
    public partial class MainProgram : Form
    {
        private TcpClient _client;
        private StreamReader _reader;
        private StreamWriter _writer;

        public MainProgram(TcpClient client)
        {
            InitializeComponent();
            _client = client;
            _reader = new StreamReader(_client.GetStream(), Encoding.Unicode);
            _writer = new StreamWriter(_client.GetStream(), Encoding.Unicode);
            _writer.AutoFlush = true;

            // New thread that listens for messages
            Task.Run(() => Mailbox());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Send("Tjena");
        }
        
        private async void Send(string message)
        {
            try
            {
                await _writer.WriteLineAsync(message);
                _writer.Flush();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Delivering Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        }

        private void Mailbox()
        {
            try
            {
                while (_client.Connected)
                {
                    string message = _reader.ReadLine();

                    if (message == null)
                    {                         
                        tbxTemporary.Text += "Disconnected!";
                        break;
                    }

                    tbxTemporary.Text += message + Environment.NewLine;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Reading Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        }
    }
}
