﻿using System;
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

        public MainProgram(TcpClient client)
        {
            InitializeComponent();
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
                var package = new
                {
                    requestType = RequestType.Broadcast,
                    data = message
                };
                
                string strPackage = JsonConvert.SerializeObject(package);

                // Sends the message
                await _writer.WriteLineAsync(strPackage);
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
    }
}