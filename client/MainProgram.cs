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
using Newtonsoft.Json.Linq;

namespace Client
{
    public partial class MainProgram : Form
    {
        private TcpClient _client;
        private StreamReader _reader;
        private StreamWriter _writer;
        private string _placeholderText = "Type your message here, write something captivating!"; // Placeholder text for tbxBroadcast
        private List<string> _userList = new List<string>();

        // TODO: when logging in or registering, run a warning window if the username has '~' to prevent issues

        public MainProgram(TcpClient client)
        {
            InitializeComponent();
            FormClosing += ApplicationExitHandler.OnWindowClosing;

            // Assigns the fields with the given values
            _client = client;
            _reader = new StreamReader(_client.GetStream(), Encoding.Unicode);
            _writer = new StreamWriter(_client.GetStream(), Encoding.Unicode);
            _writer.AutoFlush = true;

            // Sets the placeholder text
            tbxBroadcast.Text = _placeholderText;
            tbxBroadcast.ForeColor = Color.DarkSlateGray;
            tbxBroadcast.Font = new Font(tbxBroadcast.Font, FontStyle.Italic);

            // New thread that listens for messages
            Task.Run(() => Mailbox());
        }
        
        // Delivers a message broadcast to the server
        private async void Broadcast(string message)
        {
            try
            {
                // Clears the field
                tbxBroadcast.Text = "";
                
                // Package containing the relevant data
                Package package = new Package()
                {
                    requestType = RequestType.Broadcast,
                    data = message
                };
                
                // Converts it to string before delivering
                string delivery = JsonConvert.SerializeObject(package);

                // Sends the package
                await _writer.WriteLineAsync(delivery);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Delivering Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        }

        // Handles and sorts all deliveries recieved from the server
        private void Mailbox()
        {
            try
            {
                while (_client.Connected)
                {
                    string message = "";

                    // Collects the package and unpacks it
                    string delivery = _reader.ReadLine();
                    Package package = JsonConvert.DeserializeObject<Package>(delivery);
                    
                    
                    if (package.requestType == RequestType.Broadcast || package.requestType == RequestType.Whisper)
                    {
                        // If the package is an ordinary broadcast or a whisper then simply display it
                        message = package.data;
                    }
                    else if (package.requestType == RequestType.UpdateUserList)
                    {
                        string data = package.data;
                        _userList = new List<string>(data.Split('~'));
                    }

                    if (message == null)
                    {
                        // If disconnected, display it
                        tbxInbox.Text += "Disconnected!";
                        break;
                    }

                    tbxInbox.Text += message + Environment.NewLine;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Reading Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        }

        private void btnBroadcast_Click(object sender, EventArgs e)
        {
            Broadcast(tbxBroadcast.Text);
        }

        // Removes placeholder text upon gaining focus
        private void tbxBroadcast_MouseEnter(object sender, EventArgs e)
        {
            if (tbxBroadcast.Text == _placeholderText)
            {
                tbxBroadcast.Text = "";
                tbxBroadcast.ForeColor = Color.Black;
                tbxBroadcast.Font = new Font(tbxBroadcast.Font, FontStyle.Regular);
            }
        }

        // Adds placeholder text upon losing focus if its empty
        private void tbxBroadcast_MouseLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxBroadcast.Text))
            {
                tbxBroadcast.Text = _placeholderText;
                tbxBroadcast.ForeColor = Color.DarkSlateGray;
                tbxBroadcast.Font = new Font(tbxBroadcast.Font, FontStyle.Italic);
            }
        }

        // Assists the placeholder remover by also allowing text changes remove it
        private void tbxBroadcast_TextChanged(object sender, EventArgs e)
        {
            if (tbxBroadcast.ForeColor == Color.DarkSlateGray && tbxBroadcast.Text.Contains(_placeholderText))
            {
                tbxBroadcast.Text = "";
                tbxBroadcast.ForeColor = Color.Black;
                tbxBroadcast.Font = new Font(tbxBroadcast.Font, FontStyle.Regular);
            }
        }

        private void btnWhisper_Click(object sender, EventArgs e)
        {
            
        }
    }
}
