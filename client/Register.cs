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
    public partial class Register : Form
    {
        private TcpClient _client;
        private StreamReader _reader;
        private StreamWriter _writer;

        public Register(TcpClient client)
        {
            InitializeComponent();
            FormClosing += ApplicationExitHandler.OnWindowClosing;

            _client = client;
            _reader = new StreamReader(_client.GetStream(), Encoding.Unicode);
            _writer = new StreamWriter(_client.GetStream(), Encoding.Unicode);

            Task.Run(() => StartListener());
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbxUserID.Text) && !string.IsNullOrEmpty(tbxPassword.Text))
                {
                    btnRegister.Enabled = false;

                    // Creates a new package with the registration request
                    Package package = new Package
                    {
                        requestType = RequestType.Register,
                        userID = tbxUserID.Text,
                        password = tbxPassword.Text,
                    };

                    // Prepares package for sending
                    string delivery = JsonConvert.SerializeObject(package);

                    // Sends the delivery
                    await _writer.WriteLineAsync(delivery);
                    _writer.Flush();
                }
                else
                {
                    // If the fields are blank, warn the user
                    MessageBox.Show("Username and/or password can not be left blank", "Registration Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        }

        public async void StartListener()
        {
            try
            {
                // Collects delivered packages
                string delivery = await _reader.ReadLineAsync();
                Package package = JsonConvert.DeserializeObject<Package>(delivery);

                // TODO: Handle different results
                if (package.loginResult == "Exists")
                {
                    MessageBox.Show("This account exists already", "Overlap Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnRegister.Enabled = true;
                }
                else if (package.loginResult == "Success") 
                {
                    // Calls the main thread to execute the following block
                    Invoke((MethodInvoker)delegate
                    {
                        // Loads the next window
                        Hide();
                        MainProgram mainProgram = new MainProgram(_client);
                        mainProgram.ShowDialog();
                    });
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Reading Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        }
    }
}
