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

namespace Client
{
    public partial class MainProgram : Form
    {
        private TcpClient _client;

        public MainProgram(TcpClient client)
        {
            InitializeComponent();
            _client = client;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Send("Tjena");
        }
        
        private async void Send(string message)
        {
            byte[] outputData = Encoding.Unicode.GetBytes(message);

            try
            {
                await _client.GetStream().WriteAsync(outputData, 0, outputData.Length);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Sending Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        }
    }
}
